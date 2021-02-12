using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverChallenge.Library
{
    public static class Plateau
    {
        public static string[] Process(string[] instructions)
        {
            //subtract 1 to ignore the first instruction (plateau size)
            //divide by two because each rover has two lines of input
            var roverCount = (instructions.Length - 1) / 2;

            //stores a list of rovers that appear in the instructions
            var rovers = new Rover[roverCount - 1];

            for (int roverNumber = 1; roverNumber <= roverCount; roverNumber++)
            {
                var roverLocation = instructions[roverNumber];
                var roverCommands = instructions[roverNumber + 1];

                rovers[roverNumber - 1] = new Rover(
                    int.Parse(roverLocation.Split(' ')[0]),
                    int.Parse(roverLocation.Split(' ')[1]),
                    roverLocation.Split(' ')[2]
                    );

                foreach (var command in roverCommands)
                    rovers[roverNumber - 1].ExecuteCommand(command);
            }

            var output = new string[roverCount];
            for (int roverNumber = 1; roverNumber <= roverCount; roverNumber++)
                output[roverNumber - 1] = rovers[roverNumber - 1].ReportPosition();

            return output;
        }
    }
}
