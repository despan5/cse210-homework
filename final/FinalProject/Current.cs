namespace FinalProject;
public class CurrentWeather
{
    public long last_updated_epoch { get; set; }
    public string last_updated { get; set; }
    public double temp_c { get; set; }
    public double temp_f { get; set; }
    public double feelslike_c { get; set; }
    public double feelslike_f { get; set; }
    public double wind_mph { get; set; }
    public double wind_kph { get; set; }
    public Condition condition { get; set; }
}
