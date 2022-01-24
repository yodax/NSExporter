using Newtonsoft.Json;

namespace NSExporter;

public class NightscoutVersion
{
    public static NightscoutVersion FromJson(string statusJsonResult)
    {
        return JsonConvert.DeserializeObject<NightscoutVersion>(statusJsonResult);
    }

    [JsonProperty("version")]
    public string? VersionString { get; set; }
}