namespace Piatnashki_Game
{
    internal class Score
    {
        public string _name { get; }

        public TimeSpan _time { get; }

        public Score(string name, TimeSpan time) {
            _name = name;
            _time = time;
        }
    }
}
