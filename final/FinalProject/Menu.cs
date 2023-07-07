namespace FinalProject;

//Menu class
public class Menu
{
    private WeatherApp weatherApp;

    public Menu(WeatherApp weatherApp)
    {
        this.weatherApp = weatherApp;
    }

    public void ShowOptions()
    {
        Console.WriteLine("Menu options:");
        Console.WriteLine("1. Display current weather");
        Console.WriteLine("2. Display daily forecast");
        Console.WriteLine("3. Display weekly forecast");
        Console.WriteLine("4. Display precipitation information");
        Console.WriteLine("5. Exit");
    }

    public async Task ProcessInput()
    {
        int option;

        do
        {
            ShowOptions();
            Console.Write("Enter option: ");
            option = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (option)
            {
                case 1:
                    await weatherApp.DisplayForecast(new ForecastNow(weatherApp));
                    break;
                case 2:
                    await weatherApp.DisplayForecast(new ForecastDaily(weatherApp));
                    break;
                case 3:
                    await weatherApp.DisplayForecast(new ForecastWeekly(weatherApp));
                    break;
                case 4:
                    await weatherApp.DisplayForecast(new ForecastPrecipitation(weatherApp));
                    break;
                case 5:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        } while (option != 5);
    }
}