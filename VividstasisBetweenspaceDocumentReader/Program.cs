using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VividstasisBetweenspaceDocumentReader;

public static class Program
{
    private const string Awa =
        "[  {    \"name\": \"SUNRISE_001\",    \"cost\": 1,    \"script\": \"lt_hub_2\"  },  {    \"name\": \"DUSKBREAKER_001_PRELIM\",    \"cost\": 2,    \"script\": \"lt_sewer_1\"  },  {    \"name\": \"DUSKBREAKER_043_ROADBL\",    \"cost\": 3,    \"script\": \"lt_sewer_2\"  },  {    \"name\": \"DUSKBREAKER_048_FOURTH\",    \"cost\": 3,    \"script\": \"lt_sewer_3\"  },  {    \"name\": \"METALAYER_001_CONCEP\",    \"cost\": 3,    \"script\": \"lt_sewer_3a\"  },  {    \"name\": \"DUSKBREAKER_061_SIMLAY\",    \"cost\": 3,    \"script\": \"lt_sewer_6a\"  },  {    \"name\": \"DUSKBREAKER_059_EDTEPT\",    \"cost\": 3,    \"script\": \"lt_sewer_6b\"  },  {    \"name\": \"DUSKBREAKER_110_TESTRN\",    \"cost\": 4,    \"script\": \"lt_sewer_7\"  },  {    \"name\": \"CYCLE_DEFINE\",    \"cost\": 4,    \"script\": \"lt_archives_2\"  },  {    \"name\": \"CYCLE_ITRTYP\",    \"cost\": 4,    \"script\": \"lt_archives_4\"  },  {    \"name\": \"CYCLE_CYLOCK\",    \"cost\": 4,    \"script\": \"lt_archives_7a\"  },  {    \"name\": \"TVO_STARTP\",    \"cost\": 4,    \"script\": \"lt_temple_2\"  },  {    \"name\": \"TVO_SCHCYC\",    \"cost\": 4,    \"script\": \"lt_temple_4\"  },  {    \"name\": \"TVO_CLIENT\",    \"cost\": 4,    \"script\": \"lt_temple_5\"  },  {    \"name\": \"TVO_PGDEMO\",    \"cost\": 4,    \"script\": \"lt_temple_6\"  },  {    \"name\": \"TVO_RELESE\",    \"cost\": 4,    \"script\": \"lt_temple_7\"  },  {    \"name\": \"DUSKBREAKER_116_SVRNCE\",    \"cost\": 5,    \"script\": \"lt_final\"  },  {    \"name\": \"TVO_FISHIN\",    \"cost\": 5,    \"script\": \"lt_fishing\"  },  {    \"name\": \"？？？_MELODY\",    \"cost\": 5,    \"script\": \"lt_sector\"  },  {    \"name\": \"_\",    \"cost\": 5,    \"script\": \"lt_hiddenmaze\"  },  {    \"name\": \"TVO_BRKLKS\",    \"cost\": 10,    \"script\": \"lt_stargazers\"  },  {    \"name\": \"Egg\",    \"cost\": 0,    \"script\": \"lt_tama_unlock\"  },  {    \"name\": \"SUNSET_ARRIVE\",    \"cost\": 5,    \"script\": \"lt_grotto_1\"  },  {    \"name\": \"SUNSET_MEMORY\",    \"cost\": 7,    \"script\": \"lt_grotto_2\"  },  {    \"name\": \"SUNSET_RANCH_\",    \"cost\": 8,    \"script\": \"lt_grotto_3\"  },  {    \"name\": \"SUNSET_REPORT\",    \"cost\": 8,    \"script\": \"lt_grotto_4\"  },  {    \"name\": \"SUNSET_KANSHI\",    \"cost\": 11,    \"script\": \"lt_grotto_5\"  },  {    \"name\": \"Froze\",    \"cost\": 0,    \"script\": \"sd_froze\"  },  {    \"name\": \"Melody\",    \"cost\": 0,    \"script\": \"sd_melody\"  },  {    \"name\": \"Cherry\",    \"cost\": 0,    \"script\": \"sd_cherry\"  },  {    \"name\": \"Vessel\",    \"cost\": 0,    \"script\": \"sd_vessel\"  },  {    \"name\": \"Alicia\",    \"cost\": 0,    \"script\": \"sd_alicia\"  },  {    \"name\": \"Lynne\",    \"cost\": 0,    \"script\": \"sd_lynne\"  },  {    \"name\": \"Mitzi\",    \"cost\": 0,    \"script\": \"sd_mitzi\"  },  {    \"name\": \"Ashley\",    \"cost\": 0,    \"script\": \"sd_ashley\"  },  {    \"name\": \"Blistion\",    \"cost\": 0,    \"script\": \"sd_blistion\"  },  {    \"name\": \"Felicia\",    \"cost\": 0,    \"script\": \"sd_felicia\"  },  {    \"name\": \"Valerie\",    \"cost\": 0,    \"script\": \"sd_valerie\"  },  {    \"name\": \"Mint\",    \"cost\": 0,    \"script\": \"sd_mint\"  },  {    \"name\": \"Aqua\",    \"cost\": 0,    \"script\": \"sd_aqua\"  },  {    \"name\": \"Spirit Dreamers\",    \"cost\": 21,    \"script\": \"sd_final\"  },  {    \"name\": \"Grave\",    \"cost\": 0,    \"script\": \"bs_grave\"  },  {    \"name\": \"STORYTELLER_SF\",    \"cost\": 4,    \"script\": \"lt_st_diarySF\"  },  {    \"name\": \"STORYTELLER_A1\",    \"cost\": 3,    \"script\": \"lt_st_diary1\"  },  {    \"name\": \"STORYTELLER_A2\",    \"cost\": 4,    \"script\": \"lt_st_diary2\"  },  {    \"name\": \"STORYTELLER_A3\",    \"cost\": 5,    \"script\": \"lt_st_diary3\"  },  {    \"name\": \"STORYTELLER_A4\",    \"cost\": 6,    \"script\": \"lt_st_diary4\"  },  {    \"name\": \"STORYTELLER_A5\",    \"cost\": 6,    \"script\": \"lt_st_diary5\"  },  {    \"name\": \"FINAL_LANDING\",    \"cost\": 1,    \"script\": \"lt_st_diaryF\"  },  {    \"name\": \"STORYTELLER_L\",    \"cost\": 3,    \"script\": \"lt_st_diaryL\"  },  {    \"name\": \"STORYTELLER_W\",    \"cost\": 3,    \"script\": \"lt_st_diaryW\"  },  {    \"name\": \"STORYTELLER_N\",    \"cost\": 3,    \"script\": \"lt_st_diaryN\"  },  {    \"name\": \"Final Note： The Last Page\",    \"cost\": 1,    \"script\": \"lt_st_m_lastpage\"  },  {    \"name\": \"Final Note： Candy@-Cracker\",    \"cost\": 1,    \"script\": \"lt_st_m_candy\"  },  {    \"name\": \"Final Note： Orphen\",    \"cost\": 1,    \"script\": \"lt_st_m_orphen\"  },  {    \"name\": \"Final Note： 3.1V.C1\",    \"cost\": 1,    \"script\": \"lt_st_m_end\"  }]";

    private const string InvalidPathCharacter = "\\/:?*\"<>|";

    public static void Main(string[] args)
    {
        if (args.Length < 1 || !Directory.Exists(args[0])) return;
        string folder = Path.GetFullPath(args[0]);
        Event[] events = JArray.Parse(Awa).ToObject<Event[]>();
        if (Directory.Exists(Path.Combine(".", "Output", "Document"))) Directory.Delete(Path.Combine(".", "Output", "Document"), true);
        if (Directory.Exists(Path.Combine(".", "Output", "CharactersInFinalCliffs"))) Directory.Delete(Path.Combine(".", "Output", "CharactersInFinalCliffs"), true);
        if (Directory.Exists(Path.Combine(".", "Output", "Grave"))) Directory.Delete(Path.Combine(".", "Output", "Grave"), true);
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