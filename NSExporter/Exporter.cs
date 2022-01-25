using System.Net.Http.Headers;

namespace NSExporter;

public class Exporter
{
    private GlucoseEntry[]? _entries;

    public string[] Export()
    {
        var sb = new List<string>
        {
            "#Version",
            "NL2.2",
            "#MeterFamilie",
            $"NightScout,{Version}",
            "#Glucose"
        };

        if (_entries == null) return sb.ToArray();

        sb.AddRange(_entries.Select(entry => $"{Identifier},{DateOfBirth:ddMMyyyy},{entry}"));

        return sb.ToArray();
    }

    public string? Version { get; set; }
    public string? Identifier { get; set; }
    public DateTime DateOfBirth { get; set; }

    public void AddEntries(GlucoseEntry[] entries)
    {
        _entries = entries;
    }

    public static Exporter For(string nightscoutUrl, string Identifier, DateTime dateOfBirth, HttpClient client, DateTime from, DateTime to)
    {
        var exporter = new Exporter() { DateOfBirth = dateOfBirth, Identifier = Identifier };
        client.BaseAddress = new Uri(nightscoutUrl);
        client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("NSExporter", "1.0"));
        var nightscoutApi = new NightscoutApi(client);
        exporter.Version = NightscoutVersion.FromJson(nightscoutApi.GetServerInformation().Result).VersionString;
        exporter.AddEntries(GlucoseEntry.FromJson(nightscoutApi.GetGlucose(from, to, 600).Result));

        return exporter;
    }
}