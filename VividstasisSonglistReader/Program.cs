using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VividstasisUtil;

namespace VividstasisSonglistReader;

public static class Program
{
    public static void Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Error: No File Path Detected");
            return;
        }

        if (args.Length == 2)
        {
            if (float.TryParse(args[0], out float f))
            {
                byte[] bytes = BitConverter.GetBytes(f);
                Console.WriteLine(string.Join(" ",
                    bytes.Select(b => Convert.ToString(b, 16).ToUpperInvariant().PadLeft(2, '0'))));
            }

            return;
        }

        if (!File.Exists(args[0]))
        {
            Console.WriteLine("Error: File Not Found");
            return;
        }

        byte[] data = File.ReadAllBytes(args[0]);
        File.WriteAllText(Path.Combine(Path.GetDirectoryName(Path.GetFullPath(args[0])), "songlist.json"),
            JsonConvert.SerializeObject(VsdReader.ReadVsd(data), Formatting.None), new UTF8Encoding(false));
        Console.WriteLine("Exported VSD");
    }
}