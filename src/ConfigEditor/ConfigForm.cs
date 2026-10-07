using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DeployLib;

namespace ConfigEditor
{
    public partial class ConfigForm : Form
    {
        // Same file that ax-deploy reads at startup: Documents\AX3\config.ini
        private readonly string configFile = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AX3", "config.ini");

        // Entry in a selection list: shows Text, stores Value
        private class Option
        {
            public int Value { get; }
            public string Text { get; }
            public Option(int value, string text) { Value = value; Text = text; }
            public override string ToString() { return Text; }
        }

        public ConfigForm()
        {
            InitializeComponent();
            FillLists();

            // Connect buttons and fields to the methods below
            buttonSave.Click += buttonSave_Click;
            buttonClose.Click += (s, e) => Close();
            buttonBrowse.Click += buttonBrowse_Click;
            comboRate.SelectedIndexChanged += (s, e) => UpdateWarning();
            comboGyro.SelectedIndexChanged += (s, e) => UpdateWarning();
            comboDurationUnit.SelectedIndexChanged += (s, e) => UpdateWarning();
            numericDuration.ValueChanged += (s, e) => UpdateWarning();

            LoadConfig();
        }

        // ------------------------------------------------------------------
        // Selection lists (allowed values come from DeployLib.Configuration)
        // ------------------------------------------------------------------

        private void FillLists()
        {
            foreach (int rate in Configuration.ValidRates)
            {
                comboRate.Items.Add(new Option(rate, rate == 12 ? "12.5 Hz" : rate + " Hz"));
            }
            foreach (int range in Configuration.ValidRanges)
            {
                comboRange.Items.Add(new Option(range, "+/- " + range + " g"));
            }
            foreach (int gyro in Configuration.ValidGyros)
            {
                comboGyro.Items.Add(new Option(gyro, gyro == 0 ? "Off" : "+/- " + gyro + " dps"));
            }
            comboDurationUnit.Items.Add("hours");
            comboDurationUnit.Items.Add("days");

            numericDuration.Minimum = 1;
            numericDuration.Maximum = 1440;   // 60 days in hours
        }

        // Select the list entry with the given value (or the first entry if not found)
        private static void SelectByValue(ComboBox combo, int value)
        {
            foreach (Option option in combo.Items)
            {
                if (option.Value == value) { combo.SelectedItem = option; return; }
            }
            combo.SelectedIndex = 0;
        }

        private static int SelectedValue(ComboBox combo)
        {
            return ((Option)combo.SelectedItem).Value;
        }

        private int DurationHours()
        {
            int value = (int)numericDuration.Value;
            return (string)comboDurationUnit.SelectedItem == "days" ? value * 24 : value;
        }

        // ------------------------------------------------------------------
        // Load config.ini
        // ------------------------------------------------------------------

        private void LoadConfig()
        {
            // Read all "key=value" lines, like ax-deploy does (keys lower-case, '#' = comment)
            var values = new Dictionary<string, string>();
            if (File.Exists(configFile))
            {
                foreach (string line in File.ReadAllLines(configFile))
                {
                    string[] parts = line.Split(new char[] { '=' }, 2);
                    string key = parts[0].Trim().ToLower();
                    if (parts.Length < 2 || key.Length == 0 || key.StartsWith("#")) { continue; }
                    values[key] = parts[1].Trim();
                }
                labelConfigPath.Text = "config.ini: " + configFile;
            }
            else
            {
                labelConfigPath.Text = "config.ini: " + configFile + "  (not found, will be created on save)";
            }

            // Helper functions: value from config.ini, or a default if missing/invalid
            string GetString(string key, string def) { return values.TryGetValue(key, out string v) ? v : def; }
            int GetInt(string key, int def) { return values.TryGetValue(key, out string v) && int.TryParse(v, out int i) ? i : def; }
            bool GetBool(string key, bool def) { return values.TryGetValue(key, out string v) && bool.TryParse(v, out bool b) ? b : def; }

            textTitle.Text = GetString("title", "");
            textWelcome.Text = GetString("welcome", "");

            SelectByValue(comboRate, GetInt("rate", Configuration.DefaultRate));
            SelectByValue(comboRange, GetInt("range", Configuration.DefaultRange));
            SelectByValue(comboGyro, GetInt("gyro", Configuration.DefaultGyro));

            // Show whole days as days, everything else as hours
            int hours = Math.Max(1, GetInt("duration", Configuration.DefaultDurationHours));
            if (hours % 24 == 0)
            {
                comboDurationUnit.SelectedItem = "days";
                numericDuration.Value = Math.Min(hours / 24, 60);
            }
            else
            {
                comboDurationUnit.SelectedItem = "hours";
                numericDuration.Value = Math.Min(hours, 1440);
            }

            numericBattery.Value = Math.Max(numericBattery.Minimum, Math.Min(numericBattery.Maximum, GetInt("battery", 85)));
            checkScanDevices.Checked = GetBool("scandevices", false);
            checkTestMode.Checked = GetBool("testmode", false);
            textFolder.Text = GetString("workingdirectory", "");

            UpdateWarning();
        }

        // ------------------------------------------------------------------
        // Battery warning
        // ------------------------------------------------------------------

        private void UpdateWarning()
        {
            if (comboRate.SelectedItem == null || comboGyro.SelectedItem == null || comboDurationUnit.SelectedItem == null) { return; }
            int rate = SelectedValue(comboRate);
            int gyro = SelectedValue(comboGyro);
            double days = DurationHours() / 24.0;

            // Axivity specification: AX6 with gyroscope lasts approx. 7 days at 100 Hz
            if (gyro > 0 && rate > 100)
            {
                labelWarning.Text = "Warning: with gyroscope above 100 Hz the battery lasts less than 7 days.";
            }
            else if (gyro > 0 && rate == 100 && days > 7)
            {
                labelWarning.Text = "Warning: with gyroscope at 100 Hz the battery lasts approx. 7 days only.";
            }
            else
            {
                labelWarning.Text = "";
            }
        }

        // ------------------------------------------------------------------
        // Choose data folder
        // ------------------------------------------------------------------

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Folder for downloaded data and the deployment log";
                if (Directory.Exists(textFolder.Text)) { dialog.SelectedPath = textFolder.Text; }
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    textFolder.Text = dialog.SelectedPath;
                }
            }
        }

        // ------------------------------------------------------------------
        // Save config.ini
        // ------------------------------------------------------------------

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Data folder must be a full path, create it if needed
            string folder = textFolder.Text.Trim();
            if (folder.Length > 0)
            {
                if (!Path.IsPathRooted(folder))
                {
                    MessageBox.Show(this, "Please enter a full path for the data folder, e.g. C:\\AX3\\data", "Data folder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!Directory.Exists(folder))
                {
                    var answer = MessageBox.Show(this, "The data folder does not exist:\r\n" + folder + "\r\n\r\nCreate it now?", "Data folder", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (answer != DialogResult.Yes) { return; }
                    Directory.CreateDirectory(folder);
                }
            }

            // Values from the form (keys as used in config.ini)
            var newValues = new Dictionary<string, string>
            {
                { "title", textTitle.Text.Trim() },
                { "welcome", textWelcome.Text.Trim() },
                { "rate", SelectedValue(comboRate).ToString() },
                { "range", SelectedValue(comboRange).ToString() },
                { "gyro", SelectedValue(comboGyro).ToString() },
                { "duration", DurationHours().ToString() },
                { "battery", ((int)numericBattery.Value).ToString() },
                { "scandevices", checkScanDevices.Checked ? "true" : "false" },
                { "testmode", checkTestMode.Checked ? "true" : "false" },
            };
            if (folder.Length > 0) { newValues["workingdirectory"] = folder; }

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(configFile));

                // Keep all existing lines (comments, AWS settings, ...) and only replace our own keys
                List<string> lines = File.Exists(configFile) ? File.ReadAllLines(configFile).ToList() : new List<string>();
                var written = new HashSet<string>();
                for (int i = 0; i < lines.Count; i++)
                {
                    string[] parts = lines[i].Split(new char[] { '=' }, 2);
                    string key = parts[0].Trim().ToLower();
                    if (parts.Length == 2 && newValues.ContainsKey(key))   // active line (commented lines start with '#')
                    {
                        lines[i] = key + "=" + newValues[key];
                        written.Add(key);
                    }
                }
                // Add keys that were not in the file yet
                foreach (var pair in newValues)
                {
                    if (!written.Contains(pair.Key)) { lines.Add(pair.Key + "=" + pair.Value); }
                }

                // Backup of the previous file, then write the new one
                if (File.Exists(configFile)) { File.Copy(configFile, configFile + ".bak", true); }
                File.WriteAllLines(configFile, lines, new UTF8Encoding(false));
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Could not save the configuration:\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ax-deploy only reads config.ini at startup
            string message = "Configuration saved.";
            if (Process.GetProcessesByName("Deploy").Length > 0)
            {
                message += "\r\n\r\nax-deploy is running: please close and restart it to apply the new settings.";
            }
            MessageBox.Show(this, message, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadConfig();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}