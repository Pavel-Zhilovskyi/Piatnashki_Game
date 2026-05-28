namespace Piatnashki_Game.Menues;

static class AfterGameMenu
{
    public static bool AfterGameChoiceMenu()
    {
        Game game = new Game();

        Console.WriteLine("Restart the game - R");
        Console.WriteLine("Return to the main menu - M");
        Console.WriteLine("Quit the game - Q");

        ConsoleKeyInfo keyInfo;

        do
        {
            keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.R:
                    return true;

                case ConsoleKey.M:
                    Console.Clear();
                    return false;

                case ConsoleKey.Q:
                    Console.WriteLine("\nBYE!");
                    break;

                default:
                    Console.Beep();
                    break;
            }
        } while (keyInfo.Key != ConsoleKey.Q);
        Environment.Exit(0);
        return false;
    }
}
