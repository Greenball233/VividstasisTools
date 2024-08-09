using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VividstasisBetweenspaceDocumentReader;

public static class Program
{
    private static readonly Dictionary<string, object>[] qwq =
    {
        new()
        {
            { "name", "SUNRISE_001" },
            { "cost", 1 },
            {
                "script", "lt_hub_2"
            }
        },
        new()
        {
            { "name", "DUSKBREAKER_001_PRELIM" },
            { "cost", 2 },
            {
                "script", "lt_sewer_1"
            }
        },
        new()
        {
            { "name", "DUSKBREAKER_043_ROADBL" },
            { "cost", 3 },
            {
                "script", "lt_sewer_2"
            }
        },
        new()
        {
            { "name", "DUSKBREAKER_048_FOURTH" },
            { "cost", 3 },
            {
                "script", "lt_sewer_3"
            }
        },
        new()
        {
            { "name", "METALAYER_001_CONCEP" },
            { "cost", 3 },
            {
                "script", "lt_sewer_3a"
            }
        },
        new()
        {
            { "name", "DUSKBREAKER_061_SIMLAY" },
            { "cost", 3 },
            {
                "script", "lt_sewer_6a"
            }
        },
        new()
        {
            { "name", "DUSKBREAKER_059_EDTEPT" },
            { "cost", 3 },
            {
                "script", "lt_sewer_6b"
            }
        },
        new()
        {
            { "name", "DUSKBREAKER_110_TESTRN" },
            { "cost", 4 },
            {
                "script", "lt_sewer_7"
            }
        },
        new()
        {
            { "name", "CYCLE_DEFINE" },
            { "cost", 4 },
            {
                "script", "lt_archives_2"
            }
        },
        new()
        {
            { "name", "CYCLE_ITRTYP" },
            { "cost", 4 },
            {
                "script", "lt_archives_4"
            }
        },
        new()
        {
            { "name", "CYCLE_CYLOCK" },
            { "cost", 4 },
            {
                "script", "lt_archives_7a"
            }
        },
        new()
        {
            { "name", "TVO_STARTP" },
            { "cost", 4 },
            {
                "script", "lt_temple_2"
            }
        },
        new()
        {
            { "name", "TVO_SCHCYC" },
            { "cost", 4 },
            {
                "script", "lt_temple_4"
            }
        },
        new()
        {
            { "name", "TVO_CLIENT" },
            { "cost", 4 },
            {
                "script", "lt_temple_5"
            }
        },
        new()
        {
            { "name", "TVO_PGDEMO" },
            { "cost", 4 },
            {
                "script", "lt_temple_6"
            }
        },
        new()
        {
            { "name", "TVO_RELESE" },
            { "cost", 4 },
            {
                "script", "lt_temple_7"
            }
        },
        new()
        {
            { "name", "DUSKBREAKER_116_SVRNCE" },
            { "cost", 5 },
            {
                "script", "lt_final"
            }
        },
        new()
        {
            { "name", "TVO_FISHIN" },
            { "cost", 5 },
            {
                "script", "lt_fishing"
            }
        },
        new()
        {
            { "name", "？？？_MELODY" },
            { "cost", 5 },
            {
                "script", "lt_sector"
            }
        },
        new()
        {
            { "name", "_" },
            { "cost", 5 },
            {
                "script", "lt_hiddenmaze"
            }
        },
        new()
        {
            { "name", "TVO_BRKLKS" },
            { "cost", 10 },
            {
                "script", "lt_stargazers"
            }
        },
        new()
        {
            { "name", "Egg" },
            { "cost", 0 },
            {
                "script", "lt_tama_unlock"
            }
        },
        new()
        {
            { "name", "SUNSET_ARRIVE" },
            { "cost", 5 },
            {
                "script", "lt_grotto_1"
            }
        },
        new()
        {
            { "name", "SUNSET_MEMORY" },
            { "cost", 7 },
            {
                "script", "lt_grotto_2"
            }
        },
        new()
        {
            { "name", "SUNSET_RANCH_" },
            { "cost", 8 },
            {
                "script", "lt_grotto_3"
            }
        },
        new()
        {
            { "name", "SUNSET_REPORT" },
            { "cost", 8 },
            {
                "script", "lt_grotto_4"
            }
        },
        new()
        {
            { "name", "SUNSET_KANSHI" },
            { "cost", 11 },
            {
                "script", "lt_grotto_5"
            }
        },
        new()
        {
            { "name", "Froze" },
            { "cost", 0 },
            {
                "script", "sd_froze"
            }
        },
        new()
        {
            { "name", "Melody" },
            { "cost", 0 },
            {
                "script", "sd_melody"
            }
        },
        new()
        {
            { "name", "Cherry" },
            { "cost", 0 },
            {
                "script", "sd_cherry"
            }
        },
        new()
        {
            { "name", "Vessel" },
            { "cost", 0 },
            {
                "script", "sd_vessel"
            }
        },
        new()
        {
            { "name", "Alicia" },
            { "cost", 0 },
            {
                "script", "sd_alicia"
            }
        },
        new()
        {
            { "name", "Lynne" },
            { "cost", 0 },
            {
                "script", "sd_lynne"
            }
        },
        new()
        {
            { "name", "Mitzi" },
            { "cost", 0 },
            {
                "script", "sd_mitzi"
            }
        },
        new()
        {
            { "name", "Ashley" },
            { "cost", 0 },
            {
                "script", "sd_ashley"
            }
        },
        new()
        {
            { "name", "Blistion" },
            { "cost", 0 },
            {
                "script", "sd_blistion"
            }
        },
        new()
        {
            { "name", "Felicia" },
            { "cost", 0 },
            {
                "script", "sd_felicia"
            }
        },
        new()
        {
            { "name", "Valerie" },
            { "cost", 0 },
            {
                "script", "sd_valerie"
            }
        },
        new()
        {
            { "name", "Mint" },
            { "cost", 0 },
            {
                "script", "sd_mint"
            }
        },
        new()
        {
            { "name", "Aqua" },
            { "cost", 0 },
            {
                "script", "sd_aqua"
            }
        },
        new()
        {
            { "name", "Spirit Dreamers" },
            { "cost", 21 },
            {
                "script", "sd_final"
            }
        },
        new()
        {
            { "name", "Grave" },
            { "cost", 0 },
            { "script", "bs_grave" }
        }
    };

    private const string InvalidPathCharacter = "\\/:?*\"<>|";

    public static void Main(string[] args)
    {
        if (args.Length < 1 || !Directory.Exists(args[0])) return;
        string folder = Path.GetFullPath(args[0]);
        Event[] events = JArray.FromObject(qwq).ToObject<Event[]>();
        Directory.Delete(Path.Combine(".", "Output", "Document"), true);
        Directory.Delete(Path.Combine(".", "Output", "CharactersInFinalCliffs"), true);
        Directory.Delete(Path.Combine(".", "Output", "Grave"), true);
        foreach (Event @event in events)
        {
            string outputFolder;
            
            string eventType = @event.script[..2];
            switch (eventType)
            {
                case "lt":
                    outputFolder = "Document";
                    break;
                case "sd":
                    outputFolder = "CharactersInFinalCliffs";
                    break;
                case "bs":
                    outputFolder = "Grave";
                    break;
                default:
                    throw new ArgumentException(nameof(eventType), eventType, null);
            }

            if (InvalidPathCharacter.Any(c => @event.name.Contains(c)))
            {
                throw new ArgumentException("Invalid File Name: " + @event.name);
            }
            
            string[] lines = File.ReadAllLines(Path.Combine(folder, $"gml_GlobalScript_{@event.script}.gml"));
            foreach (string line in lines)
            {
                int index = line.IndexOf('=');
                if (index > 0)
                {
                    string awa = line[(index+1)..].TrimStart();
                    if (awa.StartsWith("[\""))
                    {
                        awa = awa[..(awa.LastIndexOf(']') + 1)];
                        string[] conversations = JArray.Parse(awa).ToObject<string[]>();
                        string finalFolder = Path.Combine(".", "Output", outputFolder);
                        Directory.CreateDirectory(finalFolder);
                        string finalPath = Path.Combine(finalFolder, @event.name + ".txt");
                        bool fileAlreadyExists = File.Exists(finalPath);
                        using StreamWriter streamWriter = new StreamWriter(finalPath, true, new UTF8Encoding(false));
                        if (fileAlreadyExists) streamWriter.WriteLine("------------------------------------------------------");
                        foreach (string fuck in conversations)
                        {
                            streamWriter.WriteLine(fuck);
                        }
                    }
                }
            }
        }
    }
}

public class Event
{
    public string name;
    public uint cost;
    public string script;
}