using Shouldly;
using System;
using Xunit;

namespace MarsRoverChallenge.Tests
{
    public class HappyPathTests
    {
        /// <summary>
        /// Tests for the scenario described in the project brief here: https://code.google.com/archive/p/marsrovertechchallenge/
        /// </summary>
        [Fact]
        public void Challenge_test_input_returns_expected_output()
        {
            //arrange
            var input = new string[]
            {
                "5 5",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"
            };


            var expected = new string[]
            {
                "1 3 N",
                "5 1 E"
            };

            //act
            var plateau = new Library.Plateau();
            string[] actual = plateau.Process(input);

            //assert
            actual.ShouldBe(expected);

        }
    }
}
