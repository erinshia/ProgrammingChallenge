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
        
        CsvFileParser fileParser = new CsvFileParser();
        
        HandleWeatherData(fileParser, weatherFilePath);

        HandleCountryData(fileParser, countryFilePath);
    }

    /// <summary>
    /// Handles the weather data by parsing the file and finding the day with the lowest temperature spread.
    /// Logs the result and returns the day for testing. 
    /// </summary>
    /// <param name="fileParser"> The file parser </param>
    /// <param name="weatherFilePath"> The path to the weather data file </param>
    /// <returns> The #day with the lowest temperature spread </returns>
    public static int HandleWeatherData(IFileParser fileParser, string weatherFilePath)
    {
        var weatherData = fileParser.ParseWeatherFile(weatherFilePath);
        if (weatherData != null)
        {
            var lowestTempSpread = DataAnalyser.FindDayWithLowestTempSpread(weatherData);
            Console.WriteLine($"Day with smallest temperature spread: {lowestTempSpread}");
            return lowestTempSpread;
        }

        return 0;
    }
    
    /// <summary>
    /// Handles the country data by parsing the file and finding the country with the highest population density.
    /// Logs the result and return the country name for testing.
    /// </summary>
    /// <param name="fileParser"> The file parser </param>
    /// <param name="countryFilePath"> The path to the weather data file </param>
    /// <returns> The country name with the highest population density </returns>
    public static string HandleCountryData(IFileParser fileParser, string countryFilePath)
    {
        var countryData = fileParser.ParseCountriesFile(countryFilePath);
        if(countryData != null)
        {
            var countryWithHighestPopulationDensity = DataAnalyser.FindCountryWithHighestPopulationDensity(countryData);
            Console.WriteLine($"Country with highest population density: {countryWithHighestPopulationDensity}");
            return countryWithHighestPopulationDensity;
        }

        return null;
    }
}