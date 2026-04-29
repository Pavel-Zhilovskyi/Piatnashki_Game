namespace Piatnashki_Game
{
    internal class SettingsMenuUI
    {
        public void SettingsMenu(Settings settings, SettingsManager settingsManager)
        {
            ConsoleKeyInfo keyInfo;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("SETTINGS\n");
                Console.WriteLine("1 - Controls");
                Console.WriteLine("2 - Timer settings");
                Console.WriteLine("Esc - Quit settings");

                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        ControlsMenu(settings, settingsManager);
                        break;

                    case ConsoleKey.D2:
                        TimerMenu(settings, settingsManager);
                        break;

                    case ConsoleKey.Escape:
                        Console.Clear();
                        return;

                    default:
                        Console.Beep();
                        break;
                }
            }
        }

        private void TimerMenu(Settings settings, SettingsManager settingsManager)
        {
            ConsoleKeyInfo keyInfo;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("TIMER\n");
                Console.WriteLine("You can change the timer time, by choosing the needed option.\n");
                Console.WriteLine("1 - Set timer for Classic 4x4 game");
                Console.WriteLine("2 - Set timer for Fast 3x3 game\n");
                Console.WriteLine("Current timer time for Classic game: " + settings.Time4x4.ToString());
                Console.WriteLine("Current timer time for Fast game: " + settings.Time3x3.ToString() + "\n");
                Console.WriteLine("Esc - Quit timer settings");

                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        settings.Time4x4 = InputHandler.ReadTimerInput();
                        settingsManager.WriteSettingsFile(settings);
                        break;

                    case ConsoleKey.D2:
                        Console.Clear();
                        settings.Time3x3 = InputHandler.ReadTimerInput();
                        settingsManager.WriteSettingsFile(settings);
                        break;

                    case ConsoleKey.Escape:
                        return;

                    default:
                        Console.Beep();
                        break;
                }
            }
        }

        private void ControlsMenu(Settings settings, SettingsManager settingsManager)
        {
            ConsoleKeyInfo keyInfo;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("CONTROLS\n");
                Console.WriteLine("You can change the control keys, by choosing the needed option.");
                Console.WriteLine("1 - WASD");
                Console.WriteLine("2 - Arrows");
                Console.WriteLine("Current controls: " + settings.Controls.ToString() + "\n");
                Console.WriteLine("Esc - Quit controls");

                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        settings.Controls = ControlsSettings.WASD;
                        settingsManager.WriteSettingsFile(settings);
                        break;

                    case ConsoleKey.D2:
                        settings.Controls = ControlsSettings.Arrows;
                        settingsManager.WriteSettingsFile(settings);
                        break;

                    case ConsoleKey.Escape:
                        return;

                    default:
                        Console.Beep();
                        break;
                }
            }
        }
    }
}