using PiatnashkiGame.Enums;
using PiatnashkiGame.Points;
using PiatnashkiGame.Helpers;

namespace PiatnashkiGame.Storages;

internal class ScoreStorage
{
    private string filePath;

    private readonly SafeFileHelper safeFileHelper = new SafeFileHelper();

    public ScoreStorage()
    {
        filePath = FilePathHelper.CreateFilePath(AppDomain.CurrentDomain.BaseDirectory,
            "PiatnashkiGameScore", "Score");
    }

    private string ScoreToString(Score score)
    {
        return score.Name + ";" + score.Time.ToString(@"hh\:mm\:ss") + ";" + score.Mode.ToString();
    }

    public void WriteScoreFile(Score score)
    {
        safeFileHelper.Append(filePath, ScoreToString(score) + "\n");
    }

    public List<Score> ReadScoreFromFile()
    {
        if (!safeFileHelper.IsExists(filePath))
        {
            return new List<Score>();
        }

        List<Score> scores = new List<Score>();

        string[] lines = safeFileHelper.ReadAllLines(filePath);
        string[] parts;

        Score score;

        foreach(string line in lines) 
        {
            parts = line.Split(';');

            if (parts.Length != 3)
            {
                continue;
            } 
            else if(!TimeSpan.TryParse(parts[1], out TimeSpan time))  
            {
                continue;
            }
            else if(!Enum.TryParse(parts[2], true, out GameMode mode))
            {
                continue;
            }
            else
            {
                score = new Score(parts[0], time, mode);
            }

            scores.Add(score);
        }
        return scores;
    }

    public void ClearScoreboardFile()
    {
        safeFileHelper.Clear(filePath);
    }
}