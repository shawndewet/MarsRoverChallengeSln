using Shouldly;
using System;
using Xunit;

namespace MarsRoverChallenge.Tests
{
    public class CollisionTests
    {
        [Theory] //none of these should move
        [InlineData(1, 2, "E", "1 2 E")] //to the Left, facing East
        [InlineData(3, 2, "W", "3 2 W")] //to the Right, facing West
        [InlineData(2, 1, "N", "2 1 N")] //to the South, facing North
        [InlineData(2, 3, "S", "2 3 S")] //to the North, facing South
        public void Rover_ExecuteCommand_ignores_command_that_would_cause_collision_with_another_rover(int x, int y, string heading, string expected)
        {
            //arrange an existing rover at x,y 2,2
            var otherRovers = new Library.Rover[]{
                new Library.Rover(5, 5, 2, 2, "N")
            };

            var roverToMove = new Library.Rover(5, 5, x, y, heading);

            //act
            roverToMove.ExecuteCommand('M', otherRovers);

            //assert
            var actual = roverToMove.ReportPosition();
            actual.ShouldBe(expected);
        }

    }
}
