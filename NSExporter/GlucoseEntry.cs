using System.Globalization;
using Newtonsoft.Json;

namespace NSExporter;

public class GlucoseEntry
{
    [JsonProperty("dateString")]
    public DateTime EntryTime { get; }
    [JsonProperty("sgv")]
    public double GlucoseValue { get; }
    [JsonProperty("device")]
    public string SerialNumber { get; }

    public GlucoseEntry(DateTime entryTime, double glucoseValue, string serialNumber)
    {
        SerialNumber = serialNumber;
        GlucoseValue = glucoseValue;
        EntryTime = entryTime;
    }

    public override string ToString()
    {
        return $"{SerialNumber},{EntryTime:yyyyMMddHHmmss},{GlucoseValue.ToMmolL().ToString("F1", CultureInfo.InvariantCulture)},";
    }

    public static GlucoseEntry[] FromJson(string sgvJsonResult)
    {
        return JsonConvert.DeserializeObject<GlucoseEntry[]>(sgvJsonResult);
    }
}