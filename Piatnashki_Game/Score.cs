namespace Piatnashki_Game
{
    internal class Score
    {
        public string Name { get; }

        public TimeSpan Time { get; }

        public Score(string name, TimeSpan time) {
            Name = name;
            Time = time;
        }
    }
}
