using Newtonsoft.Json;

namespace VividstasisUtil;

public class Songlist
{
    [JsonProperty("songs")] public Song[] songs { get; set; }
}

public class Song
{
    [JsonProperty("song_id")] public int id;
    [JsonProperty("name")] public string name;
    [JsonProperty("formatted_name")] public string formattedName;
    [JsonProperty("artist")] public string artist;
    [JsonProperty("chart_id")] public string identifier;
    [JsonProperty("bpm_display")] public string bpmDisplay;
    [JsonProperty("version")] public string version;
    [JsonProperty("has_encore")] public bool hasEncore;
    [JsonProperty("is_original")] public bool isOriginal;
    [JsonProperty("jacket_artist")] public string jacketArtist;
    [JsonProperty("is_published")] public bool isPublished;
    [JsonProperty("charts")] public Chart[] charts;
}

public class Chart
{
    [JsonProperty("rating_class")] public DifficultyType ratingClass;
    [JsonProperty("difficulty_display")] public string difficultyDisplay;
    [JsonProperty("difficulty_constant")] public float difficulty;
    [JsonProperty("note_designer")] public string noteDesigner;
}