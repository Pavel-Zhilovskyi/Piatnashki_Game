namespace Piatnashki_Game
{
    internal class Score
    {
        public string name { get; }

        public TimeSpan time { get; }

        public GameMode mode { get; }

        public Score(string Name, TimeSpan Time, GameMode Mode)
        {
            name = Name;
            time = Time;
            mode = Mode;
        }
    }
}