namespace BcxpChallenge.Utils;

public class DataCleaningUtils
{
    public static IEnumerable<string[]>? CleanDataOfHeadersAndSeparators(string[] lines, char separator)
    {
        lines = lines.Skip(1).ToArray();
        var data = lines.Select(line => line.Split(separator));
        return data;
    }
}