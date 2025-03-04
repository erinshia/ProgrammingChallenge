using System.Globalization;

namespace BcxpChallenge
{
    /// <summary>
    /// Parses CSV files and return the data as a list.
    /// </summary>
    public class CsvFileParser : IFileParser
    {
        private const int WeatherDataFieldsCount = 3;
        private const int CountryDataFieldsCount = 5;
        private const int DayIndex = 0;
        private const int MaxTempIndex = 1;
        private const int MinTempIndex = 2;
        private const int NameIndex = 0;
        private const int PopulationIndex = 3;
        private const int AreaIndex = 4;
        
        /// <summary>
        /// Parses the weather data from a CSV file at the given path.
        /// </summary>
        /// <param name="filePath"> The path to the csv file </param>
        /// <returns> A list of Weather objects containing the data from the csv file </returns>
        public List<Weather>? ParseWeatherFile(string filePath)
        {
            var data = ReadDataFromCsv(filePath, ',');
            if (data == null) return null;
        
            var weatherData = new List<Weather>();
            foreach (var date in data)
            {
                // If this entry doesn't contain enough data, skip it
                if(date.Length < WeatherDataFieldsCount)
                {
                    Console.WriteLine("Invalid weather data, skipping entry");
                    continue;
                }

                try
                {
                    int day = TryParseInt(date[DayIndex]);
                    int maxTemp = TryParseInt(date[MaxTempIndex]);
                    int minTemp = TryParseInt(date[MinTempIndex]);
                    Weather weather = new Weather(day, maxTemp, minTemp);
                    weatherData.Add(weather);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error parsing weather data, skipping entry: " + ex);
                }
            }

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
        
            var countryData = new List<Country>();
            foreach (var date in data)
            {
                // If this entry doesn't contain enough data, skip it
                if(date.Length < CountryDataFieldsCount)
                {
                    Console.WriteLine("Invalid country data, skipping entry");
                    continue;
                }

                try
                {
                    int population = TryParseInt(date[PopulationIndex]);
                    int area = TryParseInt(date[AreaIndex]);
                    Country country = new Country(date[NameIndex], population, area);
                    countryData.Add(country);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error parsing country data: " + ex);
                }
            }
            return countryData.ToList();
        }

        /// <summary>
        /// Reads data from csv, validates the input, and returns the data as a list of string arrays.
        /// </summary>
        /// <param name="filePath"> The path to the csv file </param>
        /// <param name="separator"> The character at which to split each line </param>
        /// <returns> String array containing the data </returns>
        private static IEnumerable<string[]>? ReadDataFromCsv(string filePath, char separator)
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
        
        
        /// <summary>
        /// Try parsing the input as a normal int and if that fails, try parsing it as a decimal and casting it to int.
        /// </summary>
        /// <param name="input"> The string to parse </param>
        /// <returns> The parsed int </returns>
        private static int TryParseInt(string input)
        {
            var numberFormatInfo = new NumberFormatInfo
            {
                NumberGroupSeparator = ".",
                NumberDecimalSeparator = ","
            };
        
            // Try parsing the input as an int
            if (int.TryParse(input, out int parsedInt))
            {
                return parsedInt;
            }

            // Try parsing the input as a decimal and cast it to int to handle separators like '.' and ','
            if (decimal.TryParse(input, NumberStyles.Number, numberFormatInfo, out decimal parsedDecimal))
            {
                return (int)parsedDecimal;
            }
        
            throw new ArgumentException("Invalid input value: " + input);
        }
    }
}