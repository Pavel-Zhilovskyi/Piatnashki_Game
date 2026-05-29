
using Piatnashki_Game.Enums;

namespace Piatnashki_Game
{
    static class GameMenu
    {
        public static void Menu()
        {
            SettingsStorage settingsStorage = new SettingsStorage();
            Settings settings = settingsStorage.LoadSettingsFromFile();
            SettingsMenu settingsMenu = new SettingsMenu();
            ScoreStorage scoreStorage = new ScoreStorage();
            ScoreMenu scoreMenu = new ScoreMenu();

            ConsoleKeyInfo keyInfo;

            do
            {
                Console.WriteLine("Fifteen Puzzle\n");
                Console.WriteLine("1 - Play (4x4 board)");
                Console.WriteLine("2 - Fast game (3x3 board)");
                Console.WriteLine("3 - Scoreboard");
                Console.WriteLine("4 - See rules");
                Console.WriteLine("5 - Settings");
                Console.WriteLine("Esc - Exit");
                Console.WriteLine("Press the key to choose.\n");

                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                        Board board = new Board(4, 4);
                        Game game = new Game();
                        game.Run(board, settings, scoreStorage, GameMode.Classic);

                        if (AfterGameMenu.AfterGameChoiceMenu())
                        {
                            goto case ConsoleKey.D1;
                        }
                        break;

                    case ConsoleKey.D2:
                        Board field = new Board(3, 3);
                        Game match = new Game();
                        match.Run(field, settings, scoreStorage, GameMode.FastGame);

                        if (AfterGameMenu.AfterGameChoiceMenu())
                        {
                            goto case ConsoleKey.D2;
                        }
                        break;

                    case ConsoleKey.D3:
                        scoreMenu.ScoreboardMenu(scoreStorage);
                        break;

                    case ConsoleKey.D4:
                        RulesStorage rulesStorage = new RulesStorage();
                        RulesPrinter.ShowRules(rulesStorage.ReadRulesFromFile());
                        break;

                    case ConsoleKey.D5:
                        settingsMenu.SettingsGeneralMenu(settings, settingsStorage);
                        break;

                    case ConsoleKey.Escape:
                        Console.Write("\nBYE!");
                        break;

                    default:
                        Console.Clear();
                        Console.Beep();
                        break;
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }
    }
}
