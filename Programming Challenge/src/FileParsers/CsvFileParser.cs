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
    /// <returns> A list of weather objects containing the data from the csv file </returns>
    public List<Weather> ParseWeatherFile(string filePath)
    {
        var data = ReadDataFromCsv(filePath);
        var weatherData = data.ToList().Select(x => new Weather(x[0], x[1], x[2]));

        return weatherData.ToList();
    }

    public List<Country> ParseCountriesFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        return null;
    }

    /// <summary>
    /// Reads data from csv, validates the input, and returns the data as a list of string arrays.
    /// </summary>
    /// <param name="filePath"> The path to the csv file </param>
    /// <returns> list of string arrays containing the data </returns>
    private IEnumerable<string[]> ReadDataFromCsv(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        if (lines == null || lines.Length == 0)
        {
            throw new ArgumentException("File is empty");
        }
        if (lines.Length == 1)
        {
            throw new ArgumentException("File does not contain data");
        }
        
        lines = lines.Skip(1).ToArray();
        
        var data = lines.Select(line => line.Split(','));
        return data;
    }
}