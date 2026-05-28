using Piatnashki_Game.Enums;

namespace Piatnashki_Game;

static class KeyInputConverter
{
    public static Direction? ConvertKey(ConsoleKeyInfo keyInfo, Settings settings)
    {
        switch (settings.KeyControls)
        {
            case ControlsSettings.WASD:
                if (keyInfo.Key == ConsoleKey.W)
                {
                    return Direction.Up;
                }
                else if (keyInfo.Key == ConsoleKey.S)
                {
                    return Direction.Down;
                }
                else if (keyInfo.Key == ConsoleKey.A)
                {
                    return Direction.Left;
                }
                else if (keyInfo.Key == ConsoleKey.D)
                {
                    return Direction.Right;
                }
                Console.Beep();
                return null;

            case ControlsSettings.Arrows:
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    return Direction.Up;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    return Direction.Down;
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    return Direction.Left;
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    return Direction.Right;
                }
                Console.Beep();
                return null;
            default:
                return null;
        }
    }
}