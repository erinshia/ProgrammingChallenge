namespace BcxpChallenge.FileParser
{
    /// <summary>
    /// Parses CSV files and return the data as a list.
    /// </summary>
    public class CsvFileReader : IFileReader
    {
        /// <summary>
        /// Reads data from csv, validates the input, and returns the data as a list of string arrays.
        /// </summary>
        /// <param name="filePath"> The path to the csv file </param>
        /// <param name="separator"> The character at which to split each line </param>
        /// <returns> String array containing the data </returns>
        public IEnumerable<string[]>? ReadDataFromFile(string filePath, char separator)
        {
            try
            {
                var lines = File.ReadAllLines(filePath);

                if (lines.Length == 0)
                {
                    Console.WriteLine($"File is empty: {filePath}");
                    return null;
                }

                if (lines.Length == 1)
                {
                    Console.WriteLine($"File only contains headers: {filePath}");
                    return null;
                }

                lines = lines.Skip(1).ToArray();
                var data = lines.Select(line => line.Split(separator));
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading the file {filePath}: " + ex);
            }

            return null;
        }
    }
}