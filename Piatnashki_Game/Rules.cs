namespace Piatnashki_Game
{
    internal class Rules
    {
        private static readonly string[] rules = new string[] { "The game board consists of a 4x4 grid.",
                    "The board contains 15 numbered tiles and one empty space.",
                    "At the start of the game, the tiles are placed in random order.",
                    "The player can move only a tile that is adjacent to the empty space.",
                    "Tiles can be moved up, down, left, or right.",
                    "Diagonal moves are not allowed.",
                    "Only one tile can be moved at a time.",
                    "The goal of the game is to arrange the tiles in order from 1 to 15.",
                    "The correct order is formed from left to right and from top to bottom.",
                    "The empty space must be in the bottom-right corner.",
                    "The game ends when all tiles are arranged in the correct order."};

        public static void ShowRules()
        {
            Console.Clear();
            
            int count = 1;

            Console.Write("\n");
            foreach(string rule in rules)
            {
                Console.WriteLine(count + ". " + rule);
                count++;
                Thread.Sleep(300);
            }
            Console.Write("\n");
        }
    }
}