namespace BcxpChallenge.Utils;

public class NumberParsingUtilsTest
{
    /// <summary>
    /// Test if the int is parsed correctly when given a number without separators.
    /// </summary>
    [Test]
    public void TryParseInt_ParsedCorrectly_WhenGivenNumberWithoutSeparators()
    {
        Assert.That(NumberParsingUtils.TryParseIntInGermanFormatting("1000"), Is.EqualTo(1000));
    }
    
    /// <summary>
    /// Test if the int is parsed correctly when given a number with a comma separator in german formatting.
    /// In German formatting, the comma is used as the decimal separator and the dot is used as the group separator.
    /// </summary>
    [Test]
    public void TryParseInt_ParsedCorrectly_WhenGivenNumberWithCommaSeparator()
    {
        Assert.That(NumberParsingUtils.TryParseIntInGermanFormatting("1000,00"), Is.EqualTo(1000));
    }
    
    /// <summary>
    /// Test if the int is parsed correctly when given a number with a dot separator in german formatting.
    /// In German formatting, the comma is used as the decimal separator and the dot is used as the group separator.
    /// </summary>
    [Test]
    public void TryParseInt_ParsedCorrectly_WhenGivenNumberWithDotSeparator()
    {
        Assert.That(NumberParsingUtils.TryParseIntInGermanFormatting("1.000"), Is.EqualTo(1000));
    }
    
    /// <summary>
    /// Test if the int is parsed correctly when given a number with a comma and a dot separator in german formatting.
    /// In German formatting, the comma is used as the decimal separator and the dot is used as the group separator.
    /// </summary>
    [Test]
    public void TryParseInt_ParsedCorrectly_WhenGivenNumberWithCommaAndDotSeparators()
    {
        Assert.That(NumberParsingUtils.TryParseIntInGermanFormatting("1.000,00"), Is.EqualTo(1000));
    }
    
    /// <summary>
    /// Test if an ArgumentException is thrown when given an invalid number with a comma and a dot separator in non-german formatting.
    /// In German formatting, the comma is used as the decimal separator and the dot is used as the group separator.
    /// </summary>
    [Test]
    public void TryParseInt_ThrowsArgumentException_WhenGivenNumberInInternationalFormatting()
    {
        Assert.Throws<ArgumentException>(() => NumberParsingUtils.TryParseIntInGermanFormatting("1,000.00"));
    }
}