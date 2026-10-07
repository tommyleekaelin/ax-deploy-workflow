namespace ConfigEditor
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.groupStudy = new System.Windows.Forms.GroupBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textTitle = new System.Windows.Forms.TextBox();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.textWelcome = new System.Windows.Forms.TextBox();
            this.groupRecording = new System.Windows.Forms.GroupBox();
            this.labelRate = new System.Windows.Forms.Label();
            this.comboRate = new System.Windows.Forms.ComboBox();
            this.labelRange = new System.Windows.Forms.Label();
            this.comboRange = new System.Windows.Forms.ComboBox();
            this.labelGyro = new System.Windows.Forms.Label();
            this.comboGyro = new System.Windows.Forms.ComboBox();
            this.labelDuration = new System.Windows.Forms.Label();
            this.numericDuration = new System.Windows.Forms.NumericUpDown();
            this.labelWarning = new System.Windows.Forms.Label();
            this.groupDevice = new System.Windows.Forms.GroupBox();
            this.labelBattery = new System.Windows.Forms.Label();
            this.numericBattery = new System.Windows.Forms.NumericUpDown();
            this.labelPercent = new System.Windows.Forms.Label();
            this.checkScanDevices = new System.Windows.Forms.CheckBox();
            this.checkTestMode = new System.Windows.Forms.CheckBox();
            this.groupStorage = new System.Windows.Forms.GroupBox();
            this.labelFolder = new System.Windows.Forms.Label();
            this.textFolder = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.labelConfigPath = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.comboDurationUnit = new System.Windows.Forms.ComboBox();
            this.groupStudy.SuspendLayout();
            this.groupRecording.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDuration)).BeginInit();
            this.groupDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBattery)).BeginInit();
            this.groupStorage.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupStudy
            // 
            this.groupStudy.Controls.Add(this.labelTitle);
            this.groupStudy.Controls.Add(this.textTitle);
            this.groupStudy.Controls.Add(this.labelWelcome);
            this.groupStudy.Controls.Add(this.textWelcome);
            this.groupStudy.Location = new System.Drawing.Point(12, 12);
            this.groupStudy.Name = "groupStudy";
            this.groupStudy.Size = new System.Drawing.Size(496, 90);
            this.groupStudy.TabIndex = 0;
            this.groupStudy.TabStop = false;
            this.groupStudy.Text = "Study";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(15, 28);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(27, 13);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Title";
            // 
            // textTitle
            // 
            this.textTitle.Location = new System.Drawing.Point(130, 25);
            this.textTitle.Name = "textTitle";
            this.textTitle.Size = new System.Drawing.Size(350, 20);
            this.textTitle.TabIndex = 1;
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Location = new System.Drawing.Point(15, 58);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(72, 13);
            this.labelWelcome.TabIndex = 2;
            this.labelWelcome.Text = "Welcome text";
            // 
            // textWelcome
            // 
            this.textWelcome.Location = new System.Drawing.Point(130, 55);
            this.textWelcome.Name = "textWelcome";
            this.textWelcome.Size = new System.Drawing.Size(350, 20);
            this.textWelcome.TabIndex = 2;
            // 
            // groupRecording
            // 
            this.groupRecording.Controls.Add(this.comboDurationUnit);
            this.groupRecording.Controls.Add(this.labelRate);
            this.groupRecording.Controls.Add(this.comboRate);
            this.groupRecording.Controls.Add(this.labelRange);
            this.groupRecording.Controls.Add(this.comboRange);
            this.groupRecording.Controls.Add(this.labelGyro);
            this.groupRecording.Controls.Add(this.comboGyro);
            this.groupRecording.Controls.Add(this.labelDuration);
            this.groupRecording.Controls.Add(this.numericDuration);
            this.groupRecording.Controls.Add(this.labelWarning);
            this.groupRecording.Location = new System.Drawing.Point(12, 110);
            this.groupRecording.Name = "groupRecording";
            this.groupRecording.Size = new System.Drawing.Size(496, 170);
            this.groupRecording.TabIndex = 3;
            this.groupRecording.TabStop = false;
            this.groupRecording.Text = "Recording";
            // 
            // labelRate
            // 
            this.labelRate.AutoSize = true;
            this.labelRate.Location = new System.Drawing.Point(15, 28);
            this.labelRate.Name = "labelRate";
            this.labelRate.Size = new System.Drawing.Size(71, 13);
            this.labelRate.TabIndex = 0;
            this.labelRate.Text = "Sampling rate";
            // 
            // comboRate
            // 
            this.comboRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRate.FormattingEnabled = true;
            this.comboRate.Location = new System.Drawing.Point(130, 25);
            this.comboRate.Name = "comboRate";
            this.comboRate.Size = new System.Drawing.Size(120, 21);
            this.comboRate.TabIndex = 4;
            // 
            // labelRange
            // 
            this.labelRange.AutoSize = true;
            this.labelRange.Location = new System.Drawing.Point(15, 58);
            this.labelRange.Name = "labelRange";
            this.labelRange.Size = new System.Drawing.Size(105, 13);
            this.labelRange.TabIndex = 5;
            this.labelRange.Text = "Accelerometer range";
            // 
            // comboRange
            // 
            this.comboRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRange.FormattingEnabled = true;
            this.comboRange.Location = new System.Drawing.Point(130, 55);
            this.comboRange.Name = "comboRange";
            this.comboRange.Size = new System.Drawing.Size(120, 21);
            this.comboRange.TabIndex = 5;
            // 
            // labelGyro
            // 
            this.labelGyro.AutoSize = true;
            this.labelGyro.Location = new System.Drawing.Point(15, 88);
            this.labelGyro.Name = "labelGyro";
            this.labelGyro.Size = new System.Drawing.Size(88, 13);
            this.labelGyro.TabIndex = 6;
            this.labelGyro.Text = "Gyroscope range";
            // 
            // comboGyro
            // 
            this.comboGyro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGyro.FormattingEnabled = true;
            this.comboGyro.Location = new System.Drawing.Point(130, 85);
            this.comboGyro.Name = "comboGyro";
            this.comboGyro.Size = new System.Drawing.Size(120, 21);
            this.comboGyro.TabIndex = 6;
            // 
            // labelDuration
            // 
            this.labelDuration.AutoSize = true;
            this.labelDuration.Location = new System.Drawing.Point(15, 118);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(47, 13);
            this.labelDuration.TabIndex = 7;
            this.labelDuration.Text = "Duration";
            // 
            // numericDuration
            // 
            this.numericDuration.Location = new System.Drawing.Point(130, 116);
            this.numericDuration.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericDuration.Name = "numericDuration";
            this.numericDuration.Size = new System.Drawing.Size(60, 20);
            this.numericDuration.TabIndex = 7;
            this.numericDuration.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // labelWarning
            // 
            this.labelWarning.ForeColor = System.Drawing.Color.DarkOrange;
            this.labelWarning.Location = new System.Drawing.Point(15, 145);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(465, 18);
            this.labelWarning.TabIndex = 9;
            // 
            // groupDevice
            // 
            this.groupDevice.Controls.Add(this.labelBattery);
            this.groupDevice.Controls.Add(this.numericBattery);
            this.groupDevice.Controls.Add(this.labelPercent);
            this.groupDevice.Controls.Add(this.checkScanDevices);
            this.groupDevice.Controls.Add(this.checkTestMode);
            this.groupDevice.Location = new System.Drawing.Point(12, 288);
            this.groupDevice.Name = "groupDevice";
            this.groupDevice.Size = new System.Drawing.Size(496, 110);
            this.groupDevice.TabIndex = 8;
            this.groupDevice.TabStop = false;
            this.groupDevice.Text = "Device handling";
            // 
            // labelBattery
            // 
            this.labelBattery.AutoSize = true;
            this.labelBattery.Location = new System.Drawing.Point(15, 28);
            this.labelBattery.Name = "labelBattery";
            this.labelBattery.Size = new System.Drawing.Size(83, 13);
            this.labelBattery.TabIndex = 0;
            this.labelBattery.Text = "Minimum battery";
            // 
            // numericBattery
            // 
            this.numericBattery.Location = new System.Drawing.Point(130, 26);
            this.numericBattery.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericBattery.Name = "numericBattery";
            this.numericBattery.Size = new System.Drawing.Size(60, 20);
            this.numericBattery.TabIndex = 9;
            this.numericBattery.Value = new decimal(new int[] {
            85,
            0,
            0,
            0});
            // 
            // labelPercent
            // 
            this.labelPercent.AutoSize = true;
            this.labelPercent.Location = new System.Drawing.Point(196, 28);
            this.labelPercent.Name = "labelPercent";
            this.labelPercent.Size = new System.Drawing.Size(15, 13);
            this.labelPercent.TabIndex = 10;
            this.labelPercent.Text = "%";
            // 
            // checkScanDevices
            // 
            this.checkScanDevices.AutoSize = true;
            this.checkScanDevices.Location = new System.Drawing.Point(18, 55);
            this.checkScanDevices.Name = "checkScanDevices";
            this.checkScanDevices.Size = new System.Drawing.Size(256, 17);
            this.checkScanDevices.TabIndex = 10;
            this.checkScanDevices.Text = "Check: scan device barcode again after removal";
            // 
            // checkTestMode
            // 
            this.checkTestMode.AutoSize = true;
            this.checkTestMode.Location = new System.Drawing.Point(18, 80);
            this.checkTestMode.Name = "checkTestMode";
            this.checkTestMode.Size = new System.Drawing.Size(270, 17);
            this.checkTestMode.TabIndex = 11;
            this.checkTestMode.Text = "Test mode (also accept legacy configuration codes)";
            // 
            // groupStorage
            // 
            this.groupStorage.Controls.Add(this.labelFolder);
            this.groupStorage.Controls.Add(this.textFolder);
            this.groupStorage.Controls.Add(this.buttonBrowse);
            this.groupStorage.Location = new System.Drawing.Point(12, 406);
            this.groupStorage.Name = "groupStorage";
            this.groupStorage.Size = new System.Drawing.Size(496, 60);
            this.groupStorage.TabIndex = 12;
            this.groupStorage.TabStop = false;
            this.groupStorage.Text = "Storage";
            // 
            // labelFolder
            // 
            this.labelFolder.AutoSize = true;
            this.labelFolder.Location = new System.Drawing.Point(15, 28);
            this.labelFolder.Name = "labelFolder";
            this.labelFolder.Size = new System.Drawing.Size(59, 13);
            this.labelFolder.TabIndex = 0;
            this.labelFolder.Text = "Data folder";
            // 
            // textFolder
            // 
            this.textFolder.Location = new System.Drawing.Point(130, 25);
            this.textFolder.Name = "textFolder";
            this.textFolder.Size = new System.Drawing.Size(265, 20);
            this.textFolder.TabIndex = 13;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(401, 23);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(80, 23);
            this.buttonBrowse.TabIndex = 14;
            this.buttonBrowse.Text = "Browse...";
            // 
            // labelConfigPath
            // 
            this.labelConfigPath.ForeColor = System.Drawing.Color.Gray;
            this.labelConfigPath.Location = new System.Drawing.Point(12, 478);
            this.labelConfigPath.Name = "labelConfigPath";
            this.labelConfigPath.Size = new System.Drawing.Size(496, 30);
            this.labelConfigPath.TabIndex = 13;
            this.labelConfigPath.Text = "config.ini: (not loaded)";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(332, 520);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(85, 28);
            this.buttonSave.TabIndex = 15;
            this.buttonSave.Text = "Save";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(423, 520);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(85, 28);
            this.buttonClose.TabIndex = 16;
            this.buttonClose.Text = "Close";
            // 
            // comboDurationUnit
            // 
            this.comboDurationUnit.FormattingEnabled = true;
            this.comboDurationUnit.Location = new System.Drawing.Point(199, 116);
            this.comboDurationUnit.Name = "comboDurationUnit";
            this.comboDurationUnit.Size = new System.Drawing.Size(121, 21);
            this.comboDurationUnit.TabIndex = 10;
            this.comboDurationUnit.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 560);
            this.Controls.Add(this.groupStudy);
            this.Controls.Add(this.groupRecording);
            this.Controls.Add(this.groupDevice);
            this.Controls.Add(this.groupStorage);
            this.Controls.Add(this.labelConfigPath);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AX Deploy - Study Configuration";
            this.groupStudy.ResumeLayout(false);
            this.groupStudy.PerformLayout();
            this.groupRecording.ResumeLayout(false);
            this.groupRecording.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDuration)).EndInit();
            this.groupDevice.ResumeLayout(false);
            this.groupDevice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBattery)).EndInit();
            this.groupStorage.ResumeLayout(false);
            this.groupStorage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupStudy;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textTitle;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.TextBox textWelcome;
        private System.Windows.Forms.GroupBox groupRecording;
        private System.Windows.Forms.Label labelRate;
        private System.Windows.Forms.ComboBox comboRate;
        private System.Windows.Forms.Label labelRange;
        private System.Windows.Forms.ComboBox comboRange;
        private System.Windows.Forms.Label labelGyro;
        private System.Windows.Forms.ComboBox comboGyro;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.NumericUpDown numericDuration;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.GroupBox groupDevice;
        private System.Windows.Forms.Label labelBattery;
        private System.Windows.Forms.NumericUpDown numericBattery;
        private System.Windows.Forms.Label labelPercent;
        private System.Windows.Forms.CheckBox checkScanDevices;
        private System.Windows.Forms.CheckBox checkTestMode;
        private System.Windows.Forms.GroupBox groupStorage;
        private System.Windows.Forms.Label labelFolder;
        private System.Windows.Forms.TextBox textFolder;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label labelConfigPath;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ComboBox comboDurationUnit;
    }
}