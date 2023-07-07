namespace FinalProject;

// ForecastDay class
public class ForecastDay
{
    public DateTime Date { get; }
    public Condition DayCondition { get; }
    public double MaxTemperature { get; }
    public double MinTemperature { get; }
    public double Precipitation { get; }
    public int CloudCover { get; }

    public ForecastDay(DateTime date, Condition dayCondition, double maxTemperature, double minTemperature, double precipitation, int cloudCover)
    {
        Date = date;
        DayCondition = dayCondition;
        MaxTemperature = maxTemperature;
        MinTemperature = minTemperature;
        Precipitation = precipitation;
        CloudCover = cloudCover;
    }
}

