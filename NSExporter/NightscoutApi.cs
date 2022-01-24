namespace NSExporter;

public class NightscoutApi
{
    private readonly HttpClient _httpClient;

    public NightscoutApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetServerInformation()
    {
        var response = await _httpClient.GetAsync("/api/v1/status.json");

        return await response.Content.ReadAsStringAsync();
    }

    public async Task<string> GetGlucose(DateTime @from, DateTime to, int count)
    {
        var response = await _httpClient.GetAsync($"/api/v1/entries/sgv.json?count={count}&find[dateString][$gte]={from:yyyy-MM-dd}&find[dateString][$lte]={to:yyyy-MM-dd}");

        return await response.Content.ReadAsStringAsync();
    }
}