namespace wetterclient.Ausgabe;

public class Output
{
    private WeatherMapRespone? weatherMapRespone;

    public Output(WeatherMapRespone? weatherMapRespone)
    {
        this.weatherMapRespone = weatherMapRespone;
    }

    public static void AusgabeOne(WeatherMapRespone? weatherMapRespone)
   {
        if (weatherMapRespone != null)
        {
#pragma warning disable CA1416
                var synthesizer = new SpeechSynthesizer();
                synthesizer.SetOutputToDefaultAudioDevice();
            
                Console.WriteLine($"Stadtname: {weatherMapRespone.location?.name}");
                Console.WriteLine($"Region : {weatherMapRespone.location?.region}");
                Console.WriteLine($"Contry : {weatherMapRespone.location?.country}");
                Console.WriteLine($"Geographische Breite: {weatherMapRespone.location?.lat}");
                Console.WriteLine($"Geographische Länge: {weatherMapRespone.location?.lon}");
                Console.WriteLine($"Zeitzone: {weatherMapRespone.location?.tz_id}");
            
                var localtimeEpoche =
                    UnixTimeConverter.UnixTimeStampToDateTime(weatherMapRespone.location!.localtime_epoch);
                Console.WriteLine($"Zeitepoche: {localtimeEpoche}");
                
                synthesizer.Speak($"Stadtname: {weatherMapRespone.location?.name}");
                synthesizer.Speak($"Region : {weatherMapRespone.location?.region}");
                synthesizer.Speak($"Contry : {weatherMapRespone.location?.country}");
                synthesizer.Speak($"Geographische Breite: {weatherMapRespone.location?.lat}");
                synthesizer.Speak($"Geographische Länge: {weatherMapRespone.location?.lon}");
                synthesizer.Speak($"Zeitzone: {weatherMapRespone.location?.tz_id}");
                synthesizer.Speak($"Zeitepoche: {localtimeEpoche}");
#pragma warning restore CA1416
        }
    }
}

