namespace Piatnashki_Game
{
    internal class Settings
    {
        private ControlsSettings _controls;
        
        public ControlsSettings Controls
        {
            get { return _controls; }
            private set { _controls = value; }
        }

        public Settings()
        {
            _controls = ControlsSettings.Arrows;
        }

        private void ControlsMenu()
        {
            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Clear();

                Console.WriteLine("CONTROLS\n");
                Console.WriteLine("You can change the control keys, by choosing the needed option.");
                Console.WriteLine("1 - WASD");
                Console.WriteLine("2 - Arrows");
                Console.WriteLine("Current controls: " + _controls.ToString() + "\n");
                Console.WriteLine("Esc - Quit controls");

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.D1)
                {
                    _controls = ControlsSettings.WASD;
                }
                else if(keyInfo.Key == ConsoleKey.D2)
                {
                    _controls = ControlsSettings.Arrows;
                }
                else if(keyInfo.Key != ConsoleKey.D1 &&  keyInfo.Key != ConsoleKey.D2 && keyInfo.Key != ConsoleKey.Escape)
                {
                    Console.Beep();
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        public void SettingsMenu()
        {
            ConsoleKeyInfo keyInfo;

            do
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
                        break;

                    default:
                        Console.Beep();
                        break;
                }
                
            } while (keyInfo.Key != ConsoleKey.Escape);
        }
    }
}
