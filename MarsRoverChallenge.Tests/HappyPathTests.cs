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
            string[] actual = Library.Plateau.Process(input);

            //assert
            actual.ShouldBe(expected);

        }

        [Theory]
        [InlineData(5, 5, "N", 'L', "5 5 W")] //heading north, spin left, expected heading West
        [InlineData(5, 5, "N", 'R', "5 5 E")] //heading north, spin right, expected heading East
        [InlineData(5, 5, "E", 'L', "5 5 N")]
        [InlineData(5, 5, "E", 'R', "5 5 S")]
        [InlineData(5, 5, "S", 'L', "5 5 E")]
        [InlineData(5, 5, "S", 'R', "5 5 W")]
        [InlineData(5, 5, "W", 'L', "5 5 S")]
        [InlineData(5, 5, "W", 'R', "5 5 N")]
        public void Rover_ExecuteCommand_spin_faces_new_direction(int x, int y, string heading, Char command, string expected)
        {
            //arrange
            var rover = new Library.Rover(x, y, heading);

            //act
            rover.ExecuteCommand(command);

            //assert
            var actual = rover.ReportPosition();
            actual.ShouldBe(expected);
        }

        [Theory]
        [InlineData(5, 5, "N", 'M', "5 6 N")] //heading north, move, expected y + 1
        public void Rover_ExecuteCommand_move_changes_position(int x, int y, string heading, Char command, string expected)
        {
            //arrange
            var rover = new Library.Rover(x, y, heading);

            //act
            rover.ExecuteCommand(command);

            //assert
            var actual = rover.ReportPosition();
            actual.ShouldBe(expected);
        }
    }
}
