using Shouldly;
using System;
using Xunit;

namespace MarsRoverChallenge.Tests
{
    public class PlateauEdgeTests
    {
        [Theory]
        [InlineData(5, 5, 3, 4, "N", 'M', "3 4 N")] //rover facing north on top edge
        [InlineData(5, 5, 4, 2, "E", 'M', "4 2 E")] //rover facing east on right edge
        [InlineData(5, 5, 3, 0, "S", 'M', "3 0 S")] //rover facing south on bottom edge
        [InlineData(5, 5, 0, 2, "W", 'M', "0 2 W")] //rover facing west on left edge
        public void Rover_ExecuteCommand_on_plateau_edge_ignores_command_that_would_move_it_off_the_plateau(int width, int height, int x, int y, string heading, Char command, string expected)
        {
            //arrange
            var rover = new Library.Rover(width, height, x, y, heading);

            //act
            rover.ExecuteCommand(command, new Library.Rover[0]);

            //assert
            var actual = rover.ReportPosition();
            actual.ShouldBe(expected);
        }

    }
}
