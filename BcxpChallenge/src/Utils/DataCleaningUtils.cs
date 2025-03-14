namespace BcxpChallenge.Utils;

/// <summary>
/// Provides utility methods for cleaning data.
/// </summary>
public static class DataCleaningUtils
{
    /// <summary>
    /// Cleans the data by removing headers and splitting each line at the specified separator.
    /// </summary>
    /// <param name="lines"> The lines read from the file. </param>
    /// <param name="separator"> The character used to split each line. </param>
    /// <returns> An enumerable of string arrays containing the cleaned data, or null if the input is empty or only contains headers. </returns>
    public static IEnumerable<string[]>? CleanDataOfHeadersAndSeparators(string[] lines, char separator)
    {
        lines = lines.Skip(1).ToArray();
        var data = lines.Select(line => line.Split(separator));
        return data;
    }
}