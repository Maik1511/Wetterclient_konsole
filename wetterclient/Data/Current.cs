namespace wetterclient.Data;

public class Current
{
    public DateTime last_updated { get; set; }
    public float temp_c { get; set; }
    public decimal wind_kph { get; set; }
    public int wind_degree { get; set; }
    public string? wind_dir { get; set; }
    public decimal pressure_mb { get; set; }
    public decimal precip_mm { get; set; }
    public int humidity { get; set; }
    public int cloud { get; set; }
    public decimal feelslike_c { get; set; }
    public decimal vis_km { get; set; }
    public decimal uv { get; set; }
    public decimal gust_kph { get; set; }
}