namespace Piatnashki_Game.Helpers;

internal class SafeFileHelper
{
    private void SafeExecute(Action action)
    {
        try
        {
            action();
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message + "\n");
        }
    }

    public void Append(string path, string text)
    {
        SafeExecute(() =>
        {
            File.AppendAllText(path, text);
        });

    }

    public void Write(string path, string text)
    {
        SafeExecute(() =>
        {
            File.WriteAllText(path, text);
        });
    }

    public void Clear(string path)
    {
        SafeExecute(() =>
        {
            File.WriteAllText(path, string.Empty);
        });
    }

    public string[] ReadAllLines(string path)
    {
        string[] lines = Array.Empty<string>();
        try
        {
            lines = File.ReadAllLines(path);
            return lines;
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message + "\n");
        }

        return lines;
    }

    public bool IsExists(string path)
    {
        return File.Exists(path);
    }
}
