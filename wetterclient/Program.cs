/*
 * Beschreibung für die Abfrage:
 * 
 * Latitude and Longitude (Decimal degree) e.g: q=48.8567,2.3508
 * city name e.g.: q=Paris
 * US zip e.g.: q=10001
 * UK postcode e.g: q=SW1
 * Canada postal code e.g: q=G2J
 * metar: e.g: q=metar:EGLL
 * iata: e.g: q=iata:DXB
 * auto:ip IP lookup e.g: q=auto:ip
 * IP address (IPv4 and IPv6 supported) e.g: q=100.0.0.1
 * 
 * 
 * Zusatzparameter :    Days = max.Tage (max = 3)
 *                      Resulte lang = Spracheinstellung 
*/
namespace wetterclient;

public class Program
{
    private static async Task Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        IConfigurationBuilder? builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("config.json", true, true);

        var apiKey = builder.Build().GetSection("Weather").GetSection("WeatherApiKey").Value;
        var uri1 = builder.Build().GetSection("URI").GetSection("uri1").Value;
        var uri2 = builder.Build().GetSection("URI").GetSection("uri2").Value;
        var uri3 = builder.Build().GetSection("URI").GetSection("uri3").Value;
        
        Console.WriteLine(uri1);
#pragma warning disable CA1416
        var synthesizer = new SpeechSynthesizer();
        synthesizer.SetOutputToDefaultAudioDevice();
        synthesizer.Speak(textToSpeak: "Willkommen bei Wetter Client 1.0");
        synthesizer.Speak(textToSpeak: "Geben Sie Ihre Stadt ein: ");
#pragma warning restore CA1416
        Console.Write("Geben Sie die Stand ein oder PLZ,Stadt ein: ");
        var plzCity = Console.ReadLine();
        
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"{uri1}{apiKey}{uri2}{plzCity}{uri3}"),
            
        };

        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var weatherMapRespone = JsonConvert.DeserializeObject<WeatherMapRespone>(body);
            
            Output.AusgabeOne(weatherMapRespone);
        }

        Console.ReadLine(); 
    }

    public DateTime UnixTimeToDateTime(long unixtime)
    {
        DateTime dtDateTime;
         dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0,
             System.DateTimeKind.Utc);
         dtDateTime = dtDateTime.AddMilliseconds(unixtime).ToLocalTime();
        return dtDateTime;
    }
}