namespace Piatnashki_Game
{
    internal class Settings
    {
        private ControlsSettings _controls = ControlsSettings.Arrows;

        private void ControlsMenu()
        {
            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Clear();
                Console.WriteLine("CONTROLS\n");
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
               
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        public void SettingsMenu()
        {
            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Clear();

                Console.WriteLine("SETTIGNS\n");
                Console.WriteLine("1 - Controls(WASD/Arrows): ");
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
                }
                
            } while (keyInfo.Key != ConsoleKey.Escape);
        }
    }
}
