using System.Text;
using Newtonsoft.Json.Linq;

namespace VividstasisUtil;

public static class VsdReader
{
    
    // 0xB2=uint, 0xB7=bool, 0xB8=string
    private static readonly string[] TypeScheme =
    {
        "song_id",            // 0  int
        "name",               // 1  string
        "formatted_name",     // 2  string
        "artist",             // 3  string
        "chart_id",           // 4  string
        "bpm_display",        // 5  string
        "version",            // 6  string
        "has_encore",         // 7  bool
        "is_original",        // 8  bool
        "jacket_artist",      // 9  string
        "is_published"        // 10 bool
    };
    
    public static Songlist ReadVsd(byte[] data)
    {
        CheckData(data);
        Stream stream = new MemoryStream(data.Skip(5).ToArray());
        switch (data[3])
        {
            case 1:
                return ReadV1VSD(stream);
            default:
                throw new ArgumentException("Invalid VSD version");
        }
    }
    
    private static Songlist ReadV1VSD(Stream stream)
    {
        byte[] buffer = new byte[16];
        List<JObject> songs = new List<JObject>();
        while (true)
        {
            stream.ReadVerified(buffer, 1);

            if (buffer[0] != 0xA0)
            {
                break;
            }

            JObject song = new JObject();

            while (true)
            {
                stream.ReadVerified(buffer, 1);
                int flag = buffer[0];

                if (flag == 0xA1) break;
                switch (flag)
                {
                    case 0xC0:
                        JArray charts;
                        if (song.TryGetValue("charts", out JToken? jToken))
                        {
                            charts = (JArray)jToken;
                        }
                        else
                        {
                            song["charts"] = charts = new JArray();
                        }

                        JObject chart = new JObject
                        {
                            { "rating_class", 0 },
                            { "difficulty_display", ReadString(stream) },
                            { "difficulty_constant", MathF.Round(ReadFloat32(stream), 1) },
                            { "note_designer", ReadString(stream) }
                        };
                        charts.Add(chart);
                        break;
                    case 0xA2:
                        byte[] buffer1 = new byte[1];
                        stream.ReadVerified(buffer1, 1);
                        int type = buffer1[0];
                        stream.ReadVerified(buffer1, 1);
                        int keyId = buffer1[0];
                        string key = TypeScheme[keyId];

                        switch (type)
                        {
                            case 0xB2: // uint
                                song.Add(key, ReadUInt32(stream));
                                break;
                            case 0xB7: // bool
                                song.Add(key, ReadBoolean(stream));
                                break;
                            case 0xB8: // string
                                song.Add(key, ReadString(stream));
                                break;
                            default:
                                throw new ArgumentOutOfRangeException(nameof(type), type, "Invalid Field Type");
                        }

                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(flag), flag, "Invalid VSD Flag");
                }
            }

            if (song.ContainsKey(TypeScheme[2])) song[TypeScheme[2]] = song[TypeScheme[2]].ToString().Replace("#", "\n");

            JArray jArray = song["charts"].ToObject<JArray>();
            for (var i = 0; i < jArray.Count; i++)
            {
                JObject? jObject = jArray[i].ToObject<JObject>();
                jObject["rating_class"] = i;
                jArray[i] = jObject;
            }
            song["charts"] = jArray;

            songs.Add(song);
        }

        songs.Sort((a, b) => a[TypeScheme[0]].ToObject<int>() - b[TypeScheme[0]].ToObject<int>());
        return new JObject { { "songs", JArray.FromObject(songs) } }.ToObject<Songlist>();
    }

    private static void CheckData(byte[] data)
    {
        // 86 = V, 83 = S, 68 = D
        if (data.Length < 5 || data[0] != 86 || data[1] != 83 || data[2] != 68 || data[4] != 0)
        {
            throw new ArgumentException("Invalid VSD header");
        }
    }

    #region DataProcessor

    private static float ReadFloat32(Stream stream)
    {
        byte[] buffer = new byte[4];
        stream.ReadVerified(buffer, 4);
        return BitConverter.ToSingle(buffer);
    }

    private static uint ReadUInt32(Stream stream)
    {
        byte[] buffer = new byte[4];
        stream.ReadVerified(buffer, 4);
        return BitConverter.ToUInt32(buffer);
    }

    private static bool ReadBoolean(Stream stream)
    {
        byte[] buffer = new byte[1];
        stream.ReadVerified(buffer, 1);
        return buffer[0] != 0;
    }

    private static string ReadString(Stream stream)
    {
        byte[] buffer = new byte[1];
        List<byte> stringData = new List<byte>();
        while (true)
        {
            stream.ReadVerified(buffer, 1);
            if (buffer[0] == 0) break;
            stringData.Add(buffer[0]);
        }

        return Encoding.UTF8.GetString(stringData.ToArray());
    }

    #endregion
}