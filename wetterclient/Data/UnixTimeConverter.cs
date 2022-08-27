namespace wetterclient.Data;

public class UnixTimeConverter
{
    // Unixtime (sek.) convertiert in Datum und Uhrzeit
    public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
    {
        DateTime dateTimeConvert = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        dateTimeConvert = dateTimeConvert.AddSeconds(unixTimeStamp).ToLocalTime();
        return dateTimeConvert;
    }
}