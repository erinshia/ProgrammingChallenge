namespace BcxpChallenge;

/// <summary>
/// Defines methods to parse and analyse T data.
/// </summary>
/// <typeparam name="T"> The type of data to be analysed. </typeparam>
public abstract class DataAnalyser<T>
{
    /// <summary>
    /// Parses the data from a list of string arrays into a list of T objects.
    /// </summary>
    /// <param name="input"> The lines of data already split at the separator. </param>
    /// <param name="requiredNumbersOfEntries"> How many entries are needed in each line. </param>
    /// <returns> A list of T objects containing the data from the file. </returns>
    protected List<T>? ParseDataFromInput(IEnumerable<string[]>? input, int requiredNumbersOfEntries)
    {
        if (input == null) return null;
        
        var data = new List<T>();
        foreach (var date in input)
        {
            // If this entry doesn't contain enough data, skip it
            if(date.Length < requiredNumbersOfEntries)
            {
                Console.WriteLine($"Invalid {typeof(T)} data, skipping entry");
                continue;
            }

            try
            {
                data.Add(ParseDataEntries(date));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing  {typeof(T)} data: " + ex);
            }
        }

        return data.Count == 0 ? null : data;
    }

    /// <summary>
    /// Parses the data from the given string array into a T object.
    /// </summary>
    /// <param name="date"> Contains the data for a T object. </param>
    /// <returns> A T object containing the data. </returns>
    protected abstract T ParseDataEntries(string[] date);
}