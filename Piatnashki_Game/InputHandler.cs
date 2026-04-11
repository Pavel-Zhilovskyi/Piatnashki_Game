namespace Piatnashki_Game
{
    internal class InputHandler
    {
        static public int ReadTileNumber()
        {
            Console.Write("Введите номер фишки: ");
            
            int number;

            while(!int.TryParse(Console.ReadLine(), out number) || number < 1 || number > 15)
            {
                Console.WriteLine("Введите коректный номер фишки.");
            }

            return number;
        }
    }
}
