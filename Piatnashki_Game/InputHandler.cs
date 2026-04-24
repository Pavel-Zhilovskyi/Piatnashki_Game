namespace Piatnashki_Game
{
    internal class InputHandler
    {
        public static string ReadNameInput()
        {
            string name;

            do
            {
                Console.Write("\nEnter your name: ");
                name = Console.ReadLine();

                if (name.All(char.IsLetter))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nOnly letters allowed!");
                }
            } while (true);

            return name;
        }
    }
}