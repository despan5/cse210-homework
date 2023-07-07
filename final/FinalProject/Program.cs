namespace FinalProject;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;


// Main entry point of the program
public class Program
{
    public static async Task Main(string[] args)
    {
        string apiKey = "4e316287cda887a206cb0fcf940dfbd5";

        // Create an instance of WeatherApp and provide the API key
        WeatherApp weatherApp = new WeatherApp(apiKey);

        // Run the WeatherApp
        await weatherApp.Run();
    }
}