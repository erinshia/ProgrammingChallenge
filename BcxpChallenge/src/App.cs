using BcxpChallenge.FileParser;
using BcxpChallenge.CountryAnalysis;
using BcxpChallenge.WeatherAnalysis;

namespace BcxpChallenge;

/**
 * The entry class for your solution. This class is only aimed as starting point and not intended as baseline for your software
 * design. Read: create your own classes and packages as appropriate.
 */
public static class App
{
    /// <summary>
    /// This is the main entry method of the program.
    /// </summary>
    /// <param name="args"> The CLI arguments passed: path to the weather file, path to the country file </param>
    public static void Main(string[] args)
    {
        if(args.Length < 2)
        {
            Console.WriteLine("Please provide the path to the weather data file and the country data file.");
            return;
        }
        
        string weatherFilePath = args[0];
        string countryFilePath = args[1];
        
        CsvFileReader fileReader = new CsvFileReader();
        
        Console.WriteLine($"Day with smallest temperature spread: {weatherFilePath.FindLowestTempSpread(fileReader)}");
        Console.WriteLine($"Country with highest population density: {countryFilePath.FindHighestPopulationDensity(fileReader)}");
    }

    /// <summary>
    /// Finds and returns the day with the lowest temperature spread in the file at the given location.
    /// </summary>
    /// <param name="weatherFilePath"> The path to the weather data file </param>
    /// <param name="fileReader"> The file parser </param>
    /// <returns> The #day with the lowest temperature spread </returns>
    public static int FindLowestTempSpread(this string weatherFilePath, IFileReader fileReader)
    {
        var weatherInput = fileReader.ReadDataFromFile(weatherFilePath, ',');
        WeatherAnalyser weatherAnalyser = new WeatherAnalyser();
        var weatherData = weatherAnalyser.ParseWeatherData(weatherInput);
        if (weatherData != null)
        {
            var lowestTempSpread = WeatherAnalyser.FindDayWithLowestTempSpread(weatherData);
            return lowestTempSpread;
        }

        return 0;
    }

    /// <summary>
    /// Finds and return the country with the highest population density in the file at the given location.
    /// </summary>
    /// <param name="countryFilePath"> The path to the country data file </param>
    /// <param name="fileReader"> The file parser </param>
    /// <returns> The country name with the highest population density </returns>
    public static string FindHighestPopulationDensity(this string countryFilePath, IFileReader fileReader)
    {
        var countryInput = fileReader.ReadDataFromFile(countryFilePath, ';');
        CountryAnalyser countryAnalyser = new CountryAnalyser();
        var countryData = countryAnalyser.ParseCountryData(countryInput);
        if(countryData != null)
        {
            var countryWithHighestPopulationDensity = CountryAnalyser.FindCountryWithHighestPopulationDensity(countryData);
            return countryWithHighestPopulationDensity;
        }

        return null;
    }
}