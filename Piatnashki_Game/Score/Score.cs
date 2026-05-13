namespace Piatnashki_Game
{
    internal class Score
    {
        public string Name { get; }

        public TimeSpan Time { get; }

        public GameMode Mode { get; }

        public Score(string name, TimeSpan time, GameMode mode)
        {
            Name = name;
            Time = time;
            Mode = mode;
        }
    }
}