using BcxpChallenge.FileParser;

namespace Tests;

/// <summary>
/// Provides tests for the CsvFileReader class.
/// </summary>
public class CsvFileReaderTest
{
    private CsvFileReader _csvFileReader;

    /// <summary>
    /// Setting up the csv file reader for testing.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _csvFileReader = new CsvFileReader();
    }
    
    /// <summary>
    /// Test if the csv file reader returns null when given an invalid path.
    /// </summary>
    [Test]
    public void ReadCsvFile_ReturnsNull_WhenGivenInvalidFilePath()
    {
        string invalidFilePath = "../../../resources/BcxpChallenge/InvalidPath.csv";
        var result = _csvFileReader.ReadDataFromFile(invalidFilePath, ',');
        Assert.That(result, Is.EqualTo(null));
    }
    
    /// <summary>
    /// Test if the csv file reader returns null when given a path to an empty file.
    /// </summary>
    [Test]
    public void ReadCsvFile_ReturnsNull_WhenGivenEmptyFile()
    {
        string emptyFilePath = "../../../resources/BcxpChallenge/empty.csv";
        var result = _csvFileReader.ReadDataFromFile(emptyFilePath, ',');
        Assert.That(result, Is.EqualTo(null));
    }
    
    /// <summary>
    /// Test if the csv file reader returns null when given a path to a file containing only countries headers.
    /// </summary>
    [Test]
    public void ReadCsvFile_ReturnsNull_WhenGivenFileContainingOnlyCountriesHeaders()
    {
        string countriesHeadersOnly = "../../../resources/BcxpChallenge/countriesHeaders.csv";
        var result = _csvFileReader.ReadDataFromFile(countriesHeadersOnly, ';');
        Assert.That(result, Is.EqualTo(null));
    }
    
    /// <summary>
    /// Test if the csv file reader returns null when given a path to a file containing only weather headers.
    /// </summary>
    [Test]
    public void ReadCsvFile_ReturnsNull_WhenGivenFileContainingOnlyWeatherHeaders()
    {
        string weatherHeadersOnly = "../../../resources/BcxpChallenge/weatherHeaders.csv";
        var result = _csvFileReader.ReadDataFromFile(weatherHeadersOnly, ',');
        Assert.That(result, Is.EqualTo(null));
    }
    
    /// <summary>
    /// Test if the csv file reader returns the data when given a path to a file containing weather data.
    /// </summary>
    [Test]
    public void ReadCsvFile_ReturnsDataSeparatedInArray_WhenGivenValidWeatherFileAndCorrectSeparator()
    {
        string weatherHeadersOnly = "../../../resources/BcxpChallenge/weatherShort.csv";
        var expectedResults = new List<string[]>
        {
            new string[] { "1", "88", "59", "74", "53.8", "0", "280", "9.6", "270", "17", "1.6", "93", "23", "1004.5" },
            new string[] { "2", "79", "63", "71", "46.5", "0", "330", "8.7", "340", "23", "3.3", "70", "28", "1004.5" }
        };
        var result = _csvFileReader.ReadDataFromFile(weatherHeadersOnly, ',');
        Assert.That(result, Is.EqualTo(expectedResults));
    }
    
    /// <summary>
    /// Test if the csv file reader returns the data when given a path to a file containing countries data.
    /// </summary>
    [Test]
    public void ReadCsvFile_ReturnsDataSeparatedInArray_WhenGivenValidCountriesFileAndCorrectSeparator()
    {
        string countriesHeadersOnly = "../../../resources/BcxpChallenge/countriesShort.csv";
        var expectedResults = new List<string[]>
        {
            new string[] { "Austria", "Vienna", "1995", "8926000", "83855", "447718", "0.922", "19" },
            new string[] { "Belgium", "Brussels", "Founder", "11566041", "30528", "517609", "0.931", "21" }
        };
        var result = _csvFileReader.ReadDataFromFile(countriesHeadersOnly, ';');
        Assert.That(result, Is.EqualTo(expectedResults));
    }
}