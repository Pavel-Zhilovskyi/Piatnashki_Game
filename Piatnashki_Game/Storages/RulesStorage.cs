using Piatnashki_Game.Helpers;

namespace Piatnashki_Game;

internal class RulesStorage
{
    private string[] rules = [];

    private readonly SafeFileHelper safeFileHelper = new SafeFileHelper();

    private string filePath;

    public RulesStorage()
    {
        filePath = FilePathHelper.CreateFilePath(AppDomain.CurrentDomain.BaseDirectory,
            "Piatnashki_Game_Rules", "Rules");
    }

    public string[] ReadRulesFromFile()
    {
        if (!safeFileHelper.IsExists(filePath))
        {
            return Array.Empty<string>();
        }

        rules = safeFileHelper.ReadAllLines(filePath);

        return rules;
    }
}