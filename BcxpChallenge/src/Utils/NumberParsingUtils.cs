using System.Globalization;

namespace BcxpChallenge.Utils;

/// <summary>
/// Provides utility methods for parsing numbers from strings.
/// </summary>
public static class NumberParsingUtils
{
    private static readonly NumberFormatInfo NumberFormatInfo = new()
    {
        NumberGroupSeparator = ".",
        NumberDecimalSeparator = ","
    };

    /// <summary>
    /// Try parsing the input as a normal int and if that fails, try parsing it as a decimal and casting it to int.
    /// This expects the input to contain no separators or german formatting i.e. with comma as decimal and dot as group separator.
    /// </summary>
    /// <param name="input"> The string to parse. </param>
    /// <returns> The parsed int. </returns>
    /// <exception cref="ArgumentException"> When trying to parse an int that doesn't match german formatting. </exception>
    public static int TryParseIntInGermanFormatting(string input)
    {
        // Try parsing the input as an int
        if (int.TryParse(input, out int parsedInt))
        {
            return parsedInt;
        }
        
        // Try parsing the input as a decimal and cast it to int to handle separators like '.' and ','
        if (decimal.TryParse(input, NumberStyles.Number, NumberFormatInfo, out decimal parsedDecimal))
        {
            return (int)parsedDecimal;
        }
        
        throw new ArgumentException("Invalid input value: " + input);
    }
}