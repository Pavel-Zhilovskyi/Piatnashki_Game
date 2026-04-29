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

        public static TimeSpan ReadTimerInput()
        {
            string time;
            do
            {
                Console.WriteLine("Enter the time (hh:mm:ss)");
                time = Console.ReadLine();

                if (TimeSpan.TryParse(time, out TimeSpan result) && time.Length == 8)
                {
                    return result;
                }
                else
                {
                    Console.Beep();
                    Console.WriteLine("Enter valid time format!\n");
                }
            } while (true);
        }
    }
}