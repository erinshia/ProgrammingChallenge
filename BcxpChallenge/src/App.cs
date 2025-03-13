using BcxpChallenge.WeatherAnalysis;
using BcxpChallenge.CountryAnalysis;
using BcxpChallenge.FileParser;

namespace BcxpChallenge;

/**
 * The entry class for your solution. This class is only aimed as starting point and not intended as baseline for your software
 * design. Read: create your own classes and packages as appropriate.
 */
public sealed class App
{
    /// <summary>
    /// This is the main entry method of the program.
    /// </summary>
    /// <param name="args"> The CLI arguments passed: path to the weather file, path to the country file </param>
    public static void Main(string[] args)
    {
        string weatherFilePath = args[0];
        string countryFilePath = args[1];
        
        CsvFileReader fileReader = new CsvFileReader();
        
        HandleWeatherData(fileReader, weatherFilePath);

        HandleCountriesData(fileReader, countryFilePath);
    }

    /// <summary>
    /// Handles the weather data by parsing the file and finding the day with the lowest temperature spread.
    /// Logs the result and returns the day for testing. 
    /// </summary>
    /// <param name="fileReader"> The file parser </param>
    /// <param name="weatherFilePath"> The path to the weather data file </param>
    /// <returns> The #day with the lowest temperature spread </returns>
    public static int HandleWeatherData(IFileReader fileReader, string weatherFilePath)
    {
        var weatherInput = fileReader.ReadDataFromFile(weatherFilePath, ',');
        List<Weather> weatherData = WeatherAnalyser.ParseWeatherFile(weatherInput);
        if (weatherData != null)
        {
            var lowestTempSpread = WeatherAnalyser.FindDayWithLowestTempSpread(weatherData);
            Console.WriteLine($"Day with smallest temperature spread: {lowestTempSpread}");
            return lowestTempSpread;
        }

        return 0;
    }
    
    /// <summary>
    /// Handles the country data by parsing the file and finding the country with the highest population density.
    /// Logs the result and returns the country name for testing.
    /// </summary>
    /// <param name="fileReader"> The file parser </param>
    /// <param name="countryFilePath"> The path to the country data file </param>
    /// <returns> The country name with the highest population density </returns>
    public static string HandleCountriesData(IFileReader fileReader, string countryFilePath)
    {
        var countryInput = fileReader.ReadDataFromFile(countryFilePath, ';');
        var countryData = CountryAnalyser.ParseCountriesFile(countryInput);
        if(countryData != null)
        {
            var countryWithHighestPopulationDensity = CountryAnalyser.FindCountryWithHighestPopulationDensity(countryData);
            Console.WriteLine($"Country with highest population density: {countryWithHighestPopulationDensity}");
            return countryWithHighestPopulationDensity;
        }

        return null;
    }
}