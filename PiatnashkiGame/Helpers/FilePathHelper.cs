namespace PiatnashkiGame.Helpers;

static class FilePathHelper
{
    static public string CreateFilePath(string baseDir, string folderName, string fileName)
    {
        string folder = Path.Combine(baseDir, folderName);

        Directory.CreateDirectory(folder);

        string filePath = Path.Combine(folder, fileName + ".txt");

        return filePath;
    }
}
