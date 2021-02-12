using Shouldly;
using System;
using Xunit;

namespace MarsRoverChallenge.Tests
{
    public class CollisionTests
    {
        [Theory]
        [InlineData(1,2,"E","1 2 E")]
        public void Rover_ExecuteCommand_ignores_command_that_would_cause_collision_with_another_rover(int x, int y, string heading, string expected)
        {
            //arrange
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
