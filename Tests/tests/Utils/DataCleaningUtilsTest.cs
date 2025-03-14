using BcxpChallenge.Utils;

namespace Tests.Utils;

public class DataCleaningUtilsTest
{
    /// <summary>
    /// Test if the method returns an empty result when given an empty array.
    /// </summary>
    [Test]
    public void CleanDataOfHeadersAndSeparators_ReturnsEmpty_WhenGivenEmptyArray()
    {
        string[] lines = [];
        var result = DataCleaningUtils.CleanDataOfHeadersAndSeparators(lines, ',');
        Assert.That(result, Is.Empty);
    }

    /// <summary>
    /// Test if the method returns an empty result when given an array with only headers.
    /// </summary>
    [Test]
    public void CleanDataOfHeadersAndSeparators_ReturnsEmpty_WhenGivenArrayWithOnlyHeaders()
    {
        string[] lines = ["Header1,Header2,Header3"];
        var result = DataCleaningUtils.CleanDataOfHeadersAndSeparators(lines, ',');
        Assert.That(result, Is.Empty);
    }

    /// <summary>
    /// Test if the method returns the correct data when given valid data with a comma separator.
    /// </summary>
    [Test]
    public void CleanDataOfHeadersAndSeparators_ReturnsData_WhenGivenValidDataWithCommaSeparator()
    {
        string[] lines =
        [
            "Header1,Header2,Header3",
            "Data1,Data2,Data3",
            "Data4,Data5,Data6"
        ];
        var expectedResults = new List<string[]>
        {
            new string[] { "Data1", "Data2", "Data3" },
            new string[] { "Data4", "Data5", "Data6" }
        };
        var result = DataCleaningUtils.CleanDataOfHeadersAndSeparators(lines, ',');
        Assert.That(result, Is.EqualTo(expectedResults));
    }

    /// <summary>
    /// Test if the method returns the correct data when given valid data with a semicolon separator.
    /// </summary>
    [Test]
    public void CleanDataOfHeadersAndSeparators_ReturnsData_WhenGivenValidDataWithSemicolonSeparator()
    {
        string[] lines =
        [
            "Header1;Header2;Header3",
            "Data1;Data2;Data3",
            "Data4;Data5;Data6"
        ];
        var expectedResults = new List<string[]>
        {
            new string[] { "Data1", "Data2", "Data3" },
            new string[] { "Data4", "Data5", "Data6" }
        };
        var result = DataCleaningUtils.CleanDataOfHeadersAndSeparators(lines, ';');
        Assert.That(result, Is.EqualTo(expectedResults));
    }
}