namespace Piatnashki_Game
{
    internal class Game
    {
        public void Menu()
        {
            int choice;
            do
            {
                Console.WriteLine("Fifteen Puzzle");
                Console.WriteLine("1 - Play.");
                Console.WriteLine("2 - See rules.");
                Console.WriteLine("3 - Exit.");

                choice = InputHandler.ReadMenuInput();

                switch (choice)
                {
                    case 1:
                    //todo place Play here

                    case 2:
                        Rules rules = new Rules();
                        rules.ShowRules();
                        break;

                    case 3:
                        Console.Write("Bye!");
                        Environment.Exit(0);
                        break;
                }
            } while (choice != 3);
        }

        public void Play()
        {
            Board board = new Board();

        }
    }
}