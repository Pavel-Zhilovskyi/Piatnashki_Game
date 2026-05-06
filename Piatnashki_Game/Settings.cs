namespace Piatnashki_Game
{
    internal class Settings
    {
        private ControlsSettings _controls = ControlsSettings.Arrows;

        public ControlsSettings Controls
        {
            get { return _controls; }
            set { _controls = value; }
        }

        private TimeSpan _GameTime3x3 = new TimeSpan(0, 3, 0);

        public TimeSpan Time3x3
        {
            get { return _GameTime3x3; }
            set { _GameTime3x3 = value; }
        }

        private TimeSpan _GameTime4x4 = new TimeSpan(0, 7, 0);

        public TimeSpan Time4x4
        {
            get { return _GameTime4x4; }
            set { _GameTime4x4 = value; }
        }

        public TimeSpan GetGameTimerMode(GameMode mode)
        {
            switch (mode)
            {
                case GameMode.Classic:
                    return Time4x4;

                case GameMode.FastGame:
                    return Time3x3;

                default:
                    throw new InvalidOperationException("GameMode must be defined!");
            }
        }
    }
}