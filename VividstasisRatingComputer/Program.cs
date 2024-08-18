using System.Globalization;
using Newtonsoft.Json.Linq;
using VividstasisUtil;

namespace VividstasisRatingComputer;

public static class Program
{
    public static void Main(string[] args)
    {
        string songlistPath = args.Length < 1 ? Path.Combine(".", "song_information.bin") : args[0];
        if (!File.Exists(songlistPath))
        {
            Console.WriteLine(
                "Error: Unable to find song_information.bin, please specify it or put it with the process");
            var processName = Path.GetFileNameWithoutExtension(Environment.ProcessPath);
            Console.WriteLine($"Usage:\n" +
                              $"    `{processName}`: The process will detect song_information.bin in the process folder and detect highscore_table file in the default path\n" +
                              $"    `{processName} <song_information.bin path>`: The process will use the specific path as the path to song_information.bin and detect highscore_table file in the default path");
            return;
        }

        Songlist songlist = VsdReader.ReadVsd(File.ReadAllBytes(songlistPath));
        string? scorePath = Path.Combine(Environment.GetEnvironmentVariable("localappdata"), "VIVIDSTASIS",
            "highscore_table");
        if (!File.Exists(scorePath))
        {
            scorePath = Util.Input(
                "highscore_table not found in default path, please specify it (path to highscore_table):");
            if (!File.Exists(scorePath))
            {
                Console.WriteLine("Error: Unable to find highscore_table");
                return;
            }
        }

        Dictionary<(int, DifficultyType), int> ratingList = new();

        foreach (Song song in songlist.songs)
        {
            if (song.id == 1) continue; // 屏蔽教程关
            foreach (Chart chart in song.charts)
            {
                int? rating = GetRating(scorePath, song.id, chart);
                if (rating == null) continue;
                ratingList.Add((song.id, chart.ratingClass), (int) rating);
            }
        }

        ratingList = ratingList.OrderByDescending(pair => pair.Value)
            .ToDictionary(pair => pair.Key, pair => pair.Value);

        ConsoleTableUtil consoleTable = new ConsoleTableUtil();
        consoleTable.TableTitleText = $"Rating List (Rating: {ratingList.Take(Math.Min(20, ratingList.Count)).Select(pair => pair.Value).Sum() / 20f:0})";

        consoleTable.AddTableColumn("Ranking", TextAlignment.Center, 6);
        consoleTable.AddTableColumn("Song Name", TextAlignment.Center, 100);
        consoleTable.AddTableColumn("Difficulty", TextAlignment.Center, 10);
        consoleTable.AddTableColumn("Rating", TextAlignment.Center, 8);

        int ranking = 1;
        foreach (KeyValuePair<(int id, DifficultyType difficulty), int> pair in ratingList)
        {
            ConsoleTableDataItem consoleTableDataItem = new ConsoleTableDataItem();
            consoleTableDataItem.AddItemColumnContent(ranking.ToString(CultureInfo.InvariantCulture));
            consoleTableDataItem.AddItemColumnContent(songlist.songs.First(song => song.id == pair.Key.id).name);
            consoleTableDataItem.AddItemColumnContent(pair.Key.difficulty.ToString());
            consoleTableDataItem.AddItemColumnContent(pair.Value.ToString(CultureInfo.InvariantCulture));
            consoleTable.AddTableDataItem(consoleTableDataItem);
            ranking++;
        }

        string table = consoleTable.MakeConsoleTable();
        File.WriteAllText("rating_list.txt", table);
    }

    private static int? GetRating(string scoreFilePath, int songId, Chart chart)
    {
        string scoreStr = IniHelper.ReadStr(songId.ToString(CultureInfo.InvariantCulture), chart.ratingClass.ToString(), "missing", scoreFilePath);
        if (scoreStr == "missing") return null;
        float score = float.Parse(scoreStr);
        float clearType = float.Parse(IniHelper.ReadStr(songId.ToString(CultureInfo.InvariantCulture),
            chart.ratingClass + "_COMBO", "0", scoreFilePath));

        float rating;

        if (score <= 1008000f)
        {
            if (score >= 1000000f)
                rating = (score - 1000000f) / 16000f + chart.difficulty + 1f;
            else if (score >= 980000f)
                rating = (score - 980000f) / 40000f + chart.difficulty + 0.5f;
            else if (score >= 950000f)
                rating = (score - 950000f) / 30000f + chart.difficulty - 0.5f;
            else
                rating = (score - 950000f) / 50000f + chart.difficulty - 0.5f;
        }
        else
        {
            rating = chart.difficulty + 1.5f;
        }

        if (rating < 0 || score < 600000) rating = 0;

        return (int)MathF.Round(1000f * (rating + clearType * 0.25f));
    }
}