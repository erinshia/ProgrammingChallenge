namespace BcxpChallenge;

/// <summary>
/// Interface defining the methods for parsing files.
/// </summary>
public interface IFileParser
{
    /// <summary>
    /// Parses the weather data from a file at the given path.
    /// </summary>
    /// <param name="filePath"> The file path </param>
    /// <returns> A list of weather objects containing the data from the file </returns>
    public List<Weather>? ParseWeatherFile(string filePath);
    
    /// <summary>
    /// Parses the country data from a file at the given path.
    /// </summary>
    /// <param name="filePath"> The file path </param>
    /// <returns> A list of country objects containing the data from the file </returns>
    public List<Country>? ParseCountriesFile(string filePath);
}