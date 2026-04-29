namespace Piatnashki_Game
{
    internal class SettingsManager
    {
        private string baseDir = AppDomain.CurrentDomain.BaseDirectory;

        private string filePath;

        public SettingsManager()
        {
            string folder = Path.Combine(baseDir, "Piatnashki_Game_Settings", "Settings");

            Directory.CreateDirectory(folder);

            filePath = Path.Combine(folder, "Settings.txt");
        }

        public Settings LoadSettingsFromFile()
        {
            if (!File.Exists(filePath))
            {
                return new Settings();
            }

            string[] lines = File.ReadAllLines(filePath);
            string[] parts;

            Settings settings = new Settings();

            for (int i = 0; i < lines.Length; i++) 
            {
                parts = lines[i].Split('=');

                try 
                { 
                    switch (parts[0])
                    {
                        case "Controls":
                            if (Enum.TryParse(parts[1], true, out ControlsSettings controls))
                            {
                                settings.Controls = controls;
                            }
                            break;

                        case "Time4x4":
                            if (TimeSpan.TryParse(parts[1], out TimeSpan time))
                            {
                                settings.Time4x4 = time;
                            }
                            break;

                        case "Time3x3":
                            if (TimeSpan.TryParse(parts[1], out TimeSpan timer))
                            {
                                settings.Time3x3 = timer;
                            }
                            break;
                    }
                }
                catch(System.IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return settings;
        }

        private string SettingsToString(Settings settings)
        {
            return "Controls=" + settings.Controls.ToString() + "\n" + "Time4x4=" +
                settings.Time4x4.ToString(@"hh\:mm\:ss") + "\n" + "Time3x3=" + 
                    settings.Time3x3.ToString(@"hh\:mm\:ss");
        }

        public void WriteSettingsFile(Settings settings)
        {
            try
            {
                File.WriteAllText(filePath, SettingsToString(settings) + "\n");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
