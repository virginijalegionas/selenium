public class Common
{
    public static string GenerateRandom()
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, 6)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    public static void Wait(int waitSeconds)
    {
        Thread.Sleep(waitSeconds * 1000);
    }

    public static void DeleteFile(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public static bool IsFileInFolder(string path, int waitSeconds)
    {
        for (; waitSeconds > 0; waitSeconds--)
        {
            if (File.Exists(path))
            {
                return true;
            }
            else
            {
                Wait(1);
            }
        }
        return false;
    }
}
