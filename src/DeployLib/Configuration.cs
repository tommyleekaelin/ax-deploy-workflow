using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeployLib
{
    public class Configuration
    {
        public Configuration(uint sessionId, DateTime start, int duration, int rate, int range, int gyro)
        {
            this.SessionId = sessionId;
            this.Start = start;
            this.Duration = duration;
            this.Rate = rate;
            this.Range = range;
            this.Gyro = gyro;
        }

        // Default recording settings, used for every new configuration.
        // Set once at startup from config.ini (see MainForm).
        // Patient barcodes (P...) always use these values; only legacy codes in test mode can override them.
        public static int DefaultRate { get; set; } = 100;           // Hz
        public static int DefaultRange { get; set; } = 8;            // +/- g
        public static int DefaultGyro { get; set; } = 0;             // degrees/second, 0 = disabled
        public static int DefaultDurationHours { get; set; } = 24 * 7;


        // Allowed values, shared by ax-deploy (validation) and ConfigEditor (selection lists)
        // AX6: 12.5-1600 Hz (12 = 12.5 Hz)
        public static readonly int[] ValidRates = { 12, 25, 50, 100, 200, 400, 800, 1600 };
        public static readonly int[] ValidRanges = { 2, 4, 8, 16 };
        public static readonly int[] ValidGyros = { 0, 125, 250, 500, 1000, 2000 };

        public Configuration() : this(0, DateTime.MinValue, DefaultDurationHours * 60 * 60, DefaultRate, DefaultRange, DefaultGyro) { }

        public int Rate { get; set; }

        public int Range { get; set; }

        // Gyro range in degrees/second (125, 250, 500, 1000, 2000), 0 = disabled (AX6 only)
        public int Gyro { get; set; }

        public int Duration { get; set; }

        public string Metadata { get { return ""; } }

        public DateTime Start { get; set; }

        public DateTime End
        {
            get
            {
                return Start.AddSeconds(Duration);
            }
            set
            {
                Duration = (int)((value - Start).TotalSeconds);
            }
        }

        public uint SessionId { get; set; }

        public bool Valid
        {
            get
            {
                if (Duration <= 0) { return false; }
                if (Start.Year < 2000) { return false; }
                if (End <= Start) { return false; }
                if (!ValidRates.Contains(Rate)) { return false; }
                if (!ValidRanges.Contains(Range)) { return false; }
                if (!ValidGyros.Contains(Gyro)) { return false; }
                return true;
            }
        }

        public int Within
        {
            get
            {
                DateTime now = DateTime.Now;
                if (End < now)
                {
                    return 1;
                }
                if (Start < now)
                {
                    return 0;
                }
                return -1;
            }
        }

        public override string ToString()
        {
            return "CONFIG #" + SessionId + " " + Start.ToString("yyyy-MM-dd HH\\:mm\\:ss") + " to " + End.ToString("yyyy-MM-dd HH\\:mm\\:ss") + " (" + (Duration / 60 / 60) + " hours) @" + Rate + "Hz +/-" + Range + "g" + (Gyro > 0 ? " gyro " + Gyro + "dps" : "");
        }
    }
}