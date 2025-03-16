using BcxpChallenge;
using BcxpChallenge.WeatherAnalysis;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;

namespace Tests.WeatherAnalysis
{
    /// <summary>
    /// Provides tests for the WeatherAnalyser class.
    /// </summary>
    public class WeatherAnalyserTest
    {
        private WeatherAnalyser _weatherAnalyser;

        /// <summary>
        /// Setting up the WeatherAnalyser for testing.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _weatherAnalyser = new WeatherAnalyser();
        }

        /// <summary>
        /// Test if the method returns null when given null input.
        /// </summary>
        [Test]
        public void ParseWeatherData_ReturnsNull_WhenGivenNullInput()
        {
            IEnumerable<string[]>? weatherInput = null;
            var result = _weatherAnalyser.ParseWeatherData(weatherInput);
            Assert.That(result, Is.Null);
        }

        /// <summary>
        /// Test if the method returns null when given empty input.
        /// </summary>
        [Test]
        public void ParseWeatherData_ReturnsNull_WhenGivenEmptyInput()
        {
            IEnumerable<string[]> weatherInput = new List<string[]>();
            var result = _weatherAnalyser.ParseWeatherData(weatherInput);
            Assert.That(result, Is.Null);
        }

        /// <summary>
        /// Test if the method returns parsed weather data when given valid input.
        /// </summary>
        [Test]
        public void ParseWeatherData_ReturnsParsedData_WhenGivenValidInput()
        {
            IEnumerable<string[]> weatherInput = new List<string[]>
            {
                new string[] { "1", "88", "59" },
                new string[] { "2", "79", "63" }
            };
            var result = _weatherAnalyser.ParseWeatherData(weatherInput);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Day, Is.EqualTo(1));
            Assert.That(result[1].Day, Is.EqualTo(2));
        }

        /// <summary>
        /// Test if the day with the lowest temperature spread is found when given valid data.
        /// </summary>
        [Test]
        public void FindDayWithLowestTempSpread_ReturnsCorrectDay_WhenGivenValidData()
        {
            var weatherData = new List<Weather>
            {
                new Weather(1, 10, 5),
                new Weather(2, 3, 1)
            };
            var result = WeatherAnalyser.FindDayWithLowestTempSpread(weatherData);
            Assert.That(result, Is.EqualTo(2));
        }
        
        /// <summary>
        /// Test if 0 is returned when given an empty list.
        /// </summary>
        [Test]
        public void FindDayWithLowestTempSpread_Returns0_WhenGivenEmptyList()
        {
            var result = WeatherAnalyser.FindDayWithLowestTempSpread(new List<Weather>());
            Assert.That(result, Is.EqualTo(0));
        }
    }
}