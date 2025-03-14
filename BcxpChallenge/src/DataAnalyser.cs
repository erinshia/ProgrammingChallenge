namespace BcxpChallenge;

public abstract class DataAnalyser<T>
{
    /// <summary>
    /// Parses the country data from a CSV file at the given path.
    /// </summary>
    /// <param name="input"> The lines that were read from the file </param>
    /// <param name="requiredNumbersOfEntries"> How many entries are needed in each line </param>
    /// <returns> A list of T objects containing the data from the file </returns>
    public List<T>? ParseDataFromInput(IEnumerable<string[]>? input, int requiredNumbersOfEntries)
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
    /// Parses the data entries from the given line into a list of T objects.
    /// </summary>
    /// <param name="date"> A line of data </param>
    /// <returns> A T object containing the data </returns>
    protected abstract T ParseDataEntries(string[] date);
}