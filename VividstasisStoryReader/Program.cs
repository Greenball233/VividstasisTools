using System.Text;
using Newtonsoft.Json;

namespace VividstasisStoryReader;

public static class Program
{
    private static Dictionary<string, object>[] qwq = new Dictionary<string, object>[]
    {
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e1_1" },
            { "ep_name", "Episode 1" },
            { "ep_title", "Station; The Entrance of Approach" },
            { "desc_1", "Saturday inquires at the Tanegashima" },
            { "desc_2", "Precinct about her missing sister." },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e2_1" },
            { "ep_name", "Episode 2" },
            { "ep_title", "Meeting; The Intersection of Wills" },
            { "desc_1", "Saturday and Allison meet up to discuss" },
            { "desc_2", "Tsuki's case." },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e3_1" },
            { "ep_name", "Episode 3" },
            { "ep_title", "Workplace; An Investigation of Remainder" },
            { "desc_1", "The trio check up on the state of" },
            { "desc_2", "Tsuki's workplace." },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e4_1" },
            { "ep_name", "Episode 4" },
            { "ep_title", "Cipher; Beyond the Puzzle’s Veil" },
            { "desc_1", "Saturday and her friend try to figure" },
            { "desc_2", "out the meaning of a strange video." },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e5_1" },
            { "ep_name", "Episode 5" },
            { "ep_title", "Aflame; The Embers of the Intersection" },
            { "desc_1", "Saturday inquires at the Ferry" },
            { "desc_2", "Terminal about Tsuki." },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e6a_1" },
            { "ep_name", "Episode 6" },
            { "ep_title", "Terminal; Prelude to the Cross" },
            { "desc_1", "Saturday tries to save her" },
            { "desc_2", "friends." },
            { "content_alert", true },
            { "content_1", "Depiction of panic attack," },
            { "content_2", "death, fire" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e6b_1" },
            { "ep_name", "Episode 6.2" },
            { "ep_title", "Terminal; The Cross" },
            { "desc_1", "???????" },
            { "desc_2", "DATA INCOMPATIBLE" },
            { "content_alert", true },
            { "content_1", "Fire, depiction of" },
            { "content_2", "stress and breakdown" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e7a_1" },
            { "ep_name", "Episode 7.1" },
            { "ep_title", "Decision; A Perusal on Yesterday" },
            { "desc_1", "Saturday contemplates the" },
            { "desc_2", "incident at the museum." },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e7b_1" },
            { "ep_name", "Episode 7.2" },
            { "ep_title", "Decision; A Perusal on Tomorrow" },
            { "desc_1", "Saturday makes a decision about" },
            { "desc_2", "her future." },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e8_2" },
            { "ep_name", "Episode 8" },
            { "ep_title", "Following; The Gate Opens" },
            { "desc_1", "Saturday and Allison wait for a ferry," },
            { "desc_2", "and encounter an unlikely ally." },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e9_1" },
            { "ep_name", "Episode 9" },
            { "ep_title", "Crossing; The Entrance of Endeavor" },
            { "desc_1", "Saturday and her friends take a ferry" },
            { "desc_2", "ride to the mainland." },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e10_1" },
            { "ep_name", "Episode 10" },
            { "ep_title", "Encounter; Cross-Stitched Meeting" },
            { "desc_1", "Saturday meets a familiar face" },
            { "desc_2", "while walking around." },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e11_1" },
            { "ep_name", "Episode 11" },
            { "ep_title", "Arrival; The Relinquish of Board" },
            { "desc_1", "The trio arrive to the mainland" },
            { "desc_2", "and go to their hotel." },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e12_1" },
            { "ep_name", "Episode 12" },
            { "ep_title", "Dual; The Fear of Two" },
            { "desc_1", "Saturday and Allison have a" },
            { "desc_2", "late-night chat." },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e13a_1" },
            { "ep_name", "Episode 13" },
            { "ep_title", "Shrine; Above the Intersection" },
            { "desc_1", "Saturday and her friends visit" },
            { "desc_2", "the Okawachi Shrine." },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e13b_1" },
            { "ep_name", "Episode 13.2" },
            { "ep_title", "Shrine; Under the Intersection" },
            { "desc_1", "???????" },
            { "desc_2", "RECOVERING DATA" },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e14a_1" },
            { "ep_name", "Episode 14" },
            { "ep_title", "Report; History of Dusk" },
            { "desc_1", "Saturday rests in her hotel" },
            { "desc_2", "room." },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e14b_1" },
            { "ep_name", "Episode 14.2" },
            { "ep_title", "Report; Future of Dusk" },
            { "desc_1", "The Worldkeeper takes action." },
            { "desc_2", "" },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e15_1" },
            { "ep_name", "Episode 15" },
            { "ep_title", "Resolve; Their Feelings" },
            { "desc_1", "Saturday and Allison discuss" },
            { "desc_2", "their feelings." },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_hidden1" },
            { "ep_name", "LOST EPISODE" },
            { "ep_title", "????????????" },
            { "desc_1", "" },
            { "desc_2", "" },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e16_2" },
            { "ep_name", "Episode 16" },
            { "ep_title", "Passage; The Temporal Gateway" },
            { "desc_1", "The group gets ready to fly to" },
            { "desc_2", "Tokyo." },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e17_1" },
            { "ep_name", "Episode 17" },
            { "ep_title", "Landing; The Crested Arrival" },
            { "desc_1", "Chiyo welcomes the group to Tokyo" },
            { "desc_2", "at her apartment." },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e18_1" },
            { "ep_name", "Episode 18" },
            { "ep_title", "Capital; Settling In Preparation" },
            { "desc_1", "Saturday, Allison, and Kotomi spend" },
            { "desc_2", "some time in Tokyo." },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e19_1" },
            { "ep_name", "Episode 19" },
            { "ep_title", "Worldbreaker" },
            { "desc_1", "?????" },
            { "desc_2", "DATA INCOMPATIBLE" },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e20_1" },
            { "ep_name", "Episode 20" },
            { "ep_title", "Connect; Bringing Everything Together" },
            { "desc_1", "Eri and Chiyo go over the information" },
            { "desc_2", "about the case." },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e21_1" },
            { "ep_name", "Episode 21" },
            { "ep_title", "Breach; Into the Sunrise" },
            { "desc_1", "Saturday visits the Sunrise Foundation" },
            { "desc_2", "at night." },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e22_1" },
            { "ep_name", "Episode 22" },
            { "ep_title", "Altercation" },
            { "desc_1", "The truth is seen." },
            { "desc_2", "" },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_tvo_e22_2" },
            { "ep_name", "Episode 22'.1" },
            { "ep_title", "Noitacretla" },
            { "desc_1", "??????????" },
            { "desc_2", "DATA NOT RECOGNIZED" },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_tvo_e22_4" },
            { "ep_name", "Episode 22'.2" },
            { "ep_title", "Noitacretla" },
            { "desc_1", "Thank you. Because of you, we can" },
            { "desc_2", "finally look to the unknown future." },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e23_1" },
            { "ep_name", "Episode 23" },
            { "ep_title", "Lost and Found" },
            { "desc_1", "Allison looks for Saturday." },
            { "desc_2", "" },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e24_1" },
            { "ep_name", "Episode 24" },
            { "ep_title", "Determination and Suspicion" },
            { "desc_1", "The group decides what to do" },
            { "desc_2", "next." },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e25_1" },
            { "ep_name", "Episode 25" },
            { "ep_title", "Clair de Lune" },
            { "desc_1", "Saturday and Allison visit Tsuki's" },
            { "desc_2", "grave." },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new Dictionary<string, object>
        {
            { "story_id", "ss_c1_e26a" },
            { "ep_name", "Final Episode" },
            { "ep_title", "_" },
            { "desc_1", "Saturday confronts herself." },
            { "desc_2", "" },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new()
        {
            { "story_id", "ss_c1_e26b_1" },
            { "ep_name", "Final Episode" },
            { "ep_title", "_, Act II" },
            { "desc_1", "Saturday confronts herself." },
            { "desc_2", "" },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new()
        {
            { "story_id", "ss_c1_e26c_1" },
            { "ep_name", "Final Episode" },
            { "ep_title", "_, Act III" },
            { "desc_1", "Saturday confronts herself." },
            { "desc_2", "" },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new()
        {
            { "story_id", "ss_c1_e26d" },
            { "ep_name", "Final Episode" },
            { "ep_title", "_, Act IV" },
            { "desc_1", "Saturday confronts herself." },
            { "desc_2", "" },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new()
        {
            { "story_id", "ss_c1_e26e" },
            { "ep_name", "Final Episode" },
            { "ep_title", "_, Act V" },
            { "desc_1", "Saturday confronts herself." },
            { "desc_2", "" },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new()
        {
            { "story_id", "ss_c1_e26f" },
            { "ep_name", "Final Episode" },
            { "ep_title", "_, Act VI" },
            { "desc_1", "Saturday confronts herself." },
            { "desc_2", "" },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        },
        new()
        {
            { "story_id", "ss_c1_e26g_1" },
            { "ep_name", "Final Episode" },
            { "ep_title", "_, Act VII" },
            { "desc_1", "Saturday confronts herself." },
            { "desc_2", "" },
            { "content_alert", false },
            { "content_1", "" },
            { "content_2", "" }
        }
    };

    public static void Main(string[] args)
    {
        if (args.Length < 1) return;
        // File.WriteAllText(".\\node_list.json", JsonConvert.SerializeObject(qwq, Formatting.None));
        // return;
        if (!Directory.Exists(args[0])) return;
        string[] files = Directory.GetFiles(args[0]).Where(str => str.EndsWith(".gml")).OrderBy(str => str).ToArray();
        foreach (string file in files)
        {
            Read(file);
        }
    }

    private static void Read(string filePath)
    {
        if (!File.Exists(filePath)) return;
        string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);
        string folder = Path.Combine(".", "Output");
        if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
        string path = Path.Combine(folder, Path.GetFileNameWithoutExtension(filePath) + "_formatted.txt");
        using StreamWriter streamWriter = File.CreateText(path);

        string currentName = "";
        bool isConversation = false;
        string conversationName = "";
        string conversationText = "";
        foreach (string line in lines)
        {
            string str = line.TrimStart();
            if (isConversation)
            {
                if (str.StartsWith("sender:"))
                {
                    conversationName = ExtractTextInString(str);
                    continue;
                }

                if (str.StartsWith("msgtext:"))
                {
                    conversationText = FormatText(ExtractTextInString(str));
                    conversationText = string.Join("\n",
                        conversationText.Split('\n').Select((text, i) =>
                            i == 0 ? text : new string(' ', 4 + conversationName.Length + 2) + text));
                    continue;
                }

                if (str.StartsWith("},"))
                {
                    streamWriter.WriteLine($"    {conversationName}: {conversationText}");
                    continue;
                }

                if (str.StartsWith("}]"))
                {
                    isConversation = false;
                    streamWriter.WriteLine("文本聊天结束");
                    continue;
                }

                continue;
            }

            if (str.StartsWith("set_msg_conversation("))
            {
                isConversation = true;
                streamWriter.WriteLine("文本聊天开始");
                continue;
            }

            if (str.StartsWith("o_cutsceneConductor."))
            {
                str = str["o_cutsceneConductor.".Length..];
                string identifier = str[..str.IndexOf('=')].TrimEnd();
                switch (identifier)
                {
                    case "location":
                        streamWriter.Write("位置：");
                        break;
                    case "time":
                        streamWriter.Write("时间：");
                        break;
                    case "date":
                        streamWriter.Write("日期：");
                        break;
                    default:
                        continue;
                }

                string content = ExtractTextInString(str);
                streamWriter.WriteLine(content);
                continue;
            }

            if (str.StartsWith("o_bg.sprite_index"))
            {
                string sceneName = str[(str.IndexOf('=') + 1)..];
                sceneName = sceneName[..sceneName.LastIndexOf(';')];
                sceneName = sceneName.Trim();
                streamWriter.WriteLine("背景：" + sceneName);
                continue;
            }

            // if (str.Contains("instance_create") && str.Contains("o_cg_"))

            if (str.StartsWith("name_set(\""))
            {
                currentName = ExtractTextInString(str);
                continue;
            }

            if (str.StartsWith("text(\""))
            {
                string text = FormatText(ExtractTextInString(str));
                var contentLines = text.Split('\n');
                if (!string.IsNullOrEmpty(currentName)) streamWriter.Write(currentName + ": ");
                for (var i = 0; i < contentLines.Length; i++)
                {
                    var contentLine = contentLines[i];
                    if (i != 0) streamWriter.Write(new string(' ', currentName.Length + 2));
                    streamWriter.WriteLine(contentLine);
                }
            }
        }
    }

    private static string FormatText(string text)
    {
        return text.Replace("\\n", "\n").Replace("\\\"", "\"");
    }

    private static string ExtractTextInString(string str)
    {
        string text = str[(str.IndexOf('"') + 1)..];
        text = text[..text.LastIndexOf('"')];
        return text;
    }
}