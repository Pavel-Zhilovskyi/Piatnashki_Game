using PiatnashkiGame.Enums;

namespace PiatnashkiGame.Options;

internal class Settings
{
    private const int defaultMinutesCount3x3 = 3;
    private const int defaultMinutesCount4x4 = 7;

    private ControlsSettings Controls = ControlsSettings.Arrows;

    public ControlsSettings KeyControls
    {
        get { return Controls; }
        set { Controls = value; }
    }

    private TimeSpan GameTime3x3 = new TimeSpan(0, defaultMinutesCount3x3, 0);

    public TimeSpan Time3x3
    {
        get { return GameTime3x3; }
        set { GameTime3x3 = value; }
    }

    private TimeSpan GameTime4x4 = new TimeSpan(0, defaultMinutesCount4x4, 0);

    public TimeSpan Time4x4
    {
        get { return GameTime4x4; }
        set { GameTime4x4 = value; }
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