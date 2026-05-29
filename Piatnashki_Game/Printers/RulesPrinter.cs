namespace Piatnashki_Game
{
    static class RulesPrinter
    {
        public static void ShowRules(string[] rules)
        {
            Console.Clear();

            int count = 1;

            Console.WriteLine("RULES\n");
            foreach (string rule in rules)
            {
                Console.WriteLine(count + ". " + rule);
                count++;
                Thread.Sleep(TimeSpan.FromSeconds(0.3));
            }
            Console.Write("\n");
        }
    }
}