namespace BcxpChallenge;

/// <summary>
/// Parses CSV files and return the data as a list.
/// </summary>
public class CsvFileParser : FileParser
{
    /// <summary>
    /// Parses the weather data from a CSV file at the given path.
    /// </summary>
    /// <param name="filePath"> The path to the csv file </param>
    /// <returns> A list of Weather objects containing the data from the csv file </returns>
    public List<Weather>? ParseWeatherFile(string filePath)
    {
        var data = ReadDataFromCsv(filePath, ',');
        if (data == null) return null;
        var weatherData = data.ToList().Select(x => new Weather(x[0], x[1], x[2]));

        return weatherData.ToList();
    }

    /// <summary>
    /// Parses the country data from a CSV file at the given path.
    /// </summary>
    /// <param name="filePath"> The path to the csv file </param>
    /// <returns> A list of Country objects containing the data from the csv file </returns>
    public List<Country>? ParseCountriesFile(string filePath)
    {
        var data = ReadDataFromCsv(filePath, ';');
        if (data == null) return null;
        var countryData = data.ToList().Select(x => new Country(x[0], x[3], x[4]));

        return countryData.ToList();
    }

    /// <summary>
    /// Reads data from csv, validates the input, and returns the data as a list of string arrays.
    /// </summary>
    /// <param name="filePath"> The path to the csv file </param>
    /// <param name="separator"> The character at which to split each line </param>
    /// <returns> String array containing the data </returns>
    private IEnumerable<string[]>? ReadDataFromCsv(string filePath, char separator)
    {
        var lines = File.ReadAllLines(filePath);
        if (lines == null || lines.Length == 0)
        {
            Console.WriteLine("File is empty");
            return null;
        }
        if (lines.Length == 1)
        {
            Console.WriteLine("File is empty");
            return null;
        }

        lines = lines.Skip(1).ToArray();
        var data = lines.Select(line => line.Split(separator));
        return data;
    }
}