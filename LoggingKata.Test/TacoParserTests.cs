using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            //Complete Something, if anything

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }
        //Create a test ShouldParseLongitude
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        public void ShouldParseLongitude(string line, double expected)
        {
            //Testing to find longitude out of the .CSV data we recieve.
            //The string line is the .CSV data, the double is the Logitude.

            //Arrange
            //Parse method is located inside of the TacoParser class
            var tacoParserInstance = new TacoParser();

            //Act
            //Will read the whole string and its job is its going to create a Taco Bell out of the line.
            var actual = tacoParserInstance.Parse(line); 

            //Assert
            Assert.Equal(expected, actual.Location.Longitude);
        }


        //Create a test ShouldParseLatitude
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        public void ShouldParseLatitude(string line, double expected)
        {
            //Testing to find langitude out of the .CSV data we recieve.
            //The string line is the .CSV data, the double is the Latitude.

            //Arrange
            var tacoParserInstance = new TacoParser();

            //Act
            var actual = tacoParserInstance.Parse(line);

            //Assert
            Assert.Equal(expected, actual.Location.Latitude);
        }

    }
}
