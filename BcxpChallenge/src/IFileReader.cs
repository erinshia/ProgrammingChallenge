namespace BcxpChallenge;

/// <summary>
/// Interface defining the methods for parsing files.
/// </summary>
public interface IFileReader
{
    /// <summary>
    /// Reads data from file, validates the input, and returns the data as a list of string arrays.
    /// </summary>
    /// <param name="filePath"> The path to the file </param>
    /// <param name="separator"> The character at which to split each line </param>
    /// <returns> String array containing the data </returns>
    public IEnumerable<string[]>? ReadDataFromFile(string filePath, char separator);
}