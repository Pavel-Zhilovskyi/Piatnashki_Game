namespace Piatnashki_Game
{
    internal class InputHandler
    {
        public static int ReadTileNumber()
        {
            Console.Write("Enter the tile number to swap: ");
            
            int number;

            while(!int.TryParse(Console.ReadLine(), out number) || number < 1 || number > 15)
            {
                Console.WriteLine("Enter a valid tile number swap!");
            }

            return number;
        }

        public static int ReadGameOptionInput(int min, int max)
        {
            Console.Write("Your choice: ");
            int number;

            while (!int.TryParse(Console.ReadLine(), out number) || number < min || number > max)
            {
                Console.WriteLine("Enter a valid option!");
            }

            return number;
        }
    }
}
