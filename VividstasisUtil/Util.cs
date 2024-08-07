namespace VividstasisUtil;

public static class Util
{
    public static void ReadVerified(this Stream stream, byte[] buffer, int count)
    {
        if (stream.Read(buffer, 0, count) < count)
        {
            throw new ArgumentException("End of Stream");
        }
    }

    public static string? Input(string prefix)
    {
        Console.Write(prefix);
        return Console.ReadLine();
    }
}