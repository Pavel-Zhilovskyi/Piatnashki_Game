namespace Piatnashki_Game
{
    internal class InputHandler
    {
        static public int ReadTileNumber()
        {
            Console.Write("Enter the tile number to swap: ");
            
            int number;

            while(!int.TryParse(Console.ReadLine(), out number) || number < 1 || number > 15)
            {
                Console.WriteLine("Enter a valid tile number!");
            }

            return number;
        }

        static public int ReadMenuInput()
        {
            Console.Write("Your choice: ");
            int number;

            while (!int.TryParse(Console.ReadLine(), out number) || number < 1 || number > 3)
            {
                Console.WriteLine("Enter a valid menu option!");
            }

            return number;
        }

        static public int ReadRunInput()
        {
             Console.Write("Your choice: ");
            int number;

            while (!int.TryParse(Console.ReadLine(), out number) || number < 1 || number > 2)
            {
                Console.WriteLine("Enter a valid option!");
            }

            return number;
        }
    }
}
