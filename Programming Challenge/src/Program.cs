// See https://aka.ms/new-console-template for more information

namespace BcxpChallenge;

/**
 * The entry class for your solution. This class is only aimed as starting point and not intended as baseline for your software
 * design. Read: create your own classes and packages as appropriate.
 */
public sealed class Program
{

    /**
     * This is the main entry method of your program.
     * @param args The CLI arguments passed
     */
    public static void Main(String[] args)
    {
        FileParser fileParser = new CsvFileParser();
        var weatherData = fileParser.ParseWeatherFile("../../../resources/BcxpChallenge/weather.csv");
        var lowestTempSpread = DataAnalyser.FindDayWithLowestTempSpread(weatherData);
        Console.WriteLine($"Day with smallest temperature spread: {lowestTempSpread}\n");
        
        
        fileParser.ParseCountriesFile("../../../resources/BcxpChallenge/countries.csv");

        String countryWithHighestPopulationDensity = "Some country"; // Your population density analysis function call …
        Console.WriteLine($"Country with highest population density: {countryWithHighestPopulationDensity}\n");
    }
}

