namespace FinalProject;
public abstract class WeatherForecast
{
    public DateTime _date { get; set; }
    public string _summary { get; set; }
    public double _temperature { get; set; }
    public double _maxTemperature { get; set;}
    public double _minTemperature { get; set;}
    public double _feelsLike { get; set;}
    public double _windKPH { get; set;}
    public double _chanceOfRain { get; set; }
    public string _name { get; set; }
    public string _country { get; set; }

    public abstract void Display();
}