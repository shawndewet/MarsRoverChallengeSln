using Shouldly;
using System;
using Xunit;

namespace MarsRoverChallenge.Tests
{
    public class PlateauEdgeTests
    {
        [Theory]
        [InlineData(5, 5, 3, 4, "N", 'M', "3 4 N")] //rover facing north on top row
        public void Rover_ExecuteCommand_on_plateau_edge_ignores_command_that_would_move_it_off_the_plateau(int width, int height, int x, int y, string heading, Char command, string expected)
        {
            //arrange
            var rover = new Library.Rover(width, height, x, y, heading);

            //act
            rover.ExecuteCommand(command);

            //assert
            var actual = rover.ReportPosition();
            actual.ShouldBe(expected);
        }

    }
}
