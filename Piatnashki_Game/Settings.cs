namespace Piatnashki_Game
{
    internal class Settings
    {
        private ControlsSettings _controls = ControlsSettings.Arrows;

        private TimeSpan _GameTime3x3 = new TimeSpan(0, 3, 0);

        public TimeSpan Time3x3
        {
            get { return _GameTime3x3; }
            set { _GameTime3x3 = value; }
        }

        private TimeSpan _GameTime4x4 = new TimeSpan(0, 7, 0);

        public TimeSpan Time4x4
        {
            get { return _GameTime4x4; }
            set { _GameTime4x4 = value; }
        }

        public ControlsSettings Controls
        {
            get { return _controls; }
            set { _controls = value; }
        }

        private void ControlsMenu()
        {
            ConsoleKeyInfo keyInfo;

            while(true)
            {
                Console.Clear();

                Console.WriteLine("CONTROLS\n");
                Console.WriteLine("You can change the control keys, by choosing the needed option.");
                Console.WriteLine("1 - WASD");
                Console.WriteLine("2 - Arrows");
                Console.WriteLine("Current controls: " + _controls.ToString() + "\n");
                Console.WriteLine("Esc - Quit controls");

                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        _controls = ControlsSettings.WASD;
                        break;

                    case ConsoleKey.D2:
                        _controls = ControlsSettings.Arrows;
                        break;

                    case ConsoleKey.Escape:
                        return;

                    default:
                        Console.Beep();
                        break;
                }
            }
        }

        public void SettingsMenu()
        {
            ConsoleKeyInfo keyInfo;

            while(true)
            {
                Console.Clear();

                Console.WriteLine("SETTINGS\n");
                Console.WriteLine("1 - Controls");
                Console.WriteLine("Esc - Quit settings");

                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        ControlsMenu();
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
    }
}