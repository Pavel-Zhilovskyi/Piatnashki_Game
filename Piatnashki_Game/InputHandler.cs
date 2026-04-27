namespace Piatnashki_Game
{
    internal class InputHandler
    {
        public static string ReadNameInput()
        {
            string name;
            do
            {
                Console.Write("Enter your nickname: ");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("\nEnter your valid nickname!");
                }
                else
                {
                    break;
                }
            } while (true);
            return name;
        }
    }
}