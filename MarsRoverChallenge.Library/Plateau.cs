using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverChallenge.Library
{
    public static class Plateau
    {
        public static string[] Process(string[] instructions)
        {
            var plateauWidth = int.Parse(instructions[0].Split(' ')[0]) + 1;
            var plateauHeight = int.Parse(instructions[0].Split(' ')[1]) + 1;

            //subtract 1 to ignore the first instruction (plateau size)
            //divide by two because each rover has two lines of input
            var roverCount = (instructions.Length - 1) / 2;

            //stores a list of rovers that appear in the instructions
            var rovers = new Rover[roverCount];

            for (int roverNumber = 1; roverNumber <= roverCount; roverNumber++)
            {
                var roverLocation = instructions[roverNumber == 1 ? roverNumber : roverNumber + 1];
                var roverCommands = instructions[roverNumber == 1 ? roverNumber + 1 : roverNumber + 2];

                var roverX = int.Parse(roverLocation.Split(' ')[0]);
                var roverY = int.Parse(roverLocation.Split(' ')[1]);

                if (roverX > plateauWidth || roverY > plateauHeight || roverX < 0 || roverY < 0)
                    continue; //ignore rover initialized off-plateau

                rovers[roverNumber - 1] = new Rover(
                    plateauWidth, plateauHeight,
                    roverX,
                    roverY,
                    roverLocation.Split(' ')[2]
                    );

                foreach (var command in roverCommands)
                    rovers[roverNumber - 1].ExecuteCommand(command, Splice(rovers, roverNumber - 1));
            }

            var output = new string[roverCount];
            for (int roverNumber = 1; roverNumber <= roverCount; roverNumber++)
                output[roverNumber - 1] = rovers[roverNumber - 1].ReportPosition();

            return output;
        }

        private static Rover[] Splice(Rover[] existingArray, int indexToRemove)
        {
            var newArray = new Rover[existingArray.Length - 1];
            if (indexToRemove == 0)
                existingArray[(indexToRemove + 1)..].CopyTo(newArray, 0);
            else
            {
                existingArray[0..(indexToRemove - 1)].CopyTo(newArray, 0);
                existingArray[(indexToRemove + 1)..].CopyTo(newArray, 0);
            }
            return newArray;
        }
    }
}
