using System;
using System.Collections.Generic;

namespace MarsRoverChallenge.ControlPanel
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = new List<string>();
            Console.WriteLine("Welcome to the Mars Rover control panel!");
            Console.WriteLine("Enter (or paste) your sequence of commands to control the rovers.");
            Console.WriteLine("(Signify the end of your input by entering an empty row)");

            string input;
            do
            {
                input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                    commands.Add(input);
            } while (!string.IsNullOrEmpty(input));

            if (commands.Count == 0)
                Console.WriteLine("No commands have been provided...exiting control panel.");
            else
            {
                Console.WriteLine("Sending commands to rovers...");
                Console.WriteLine();

                var output = Library.Plateau.Process(commands.ToArray());
                foreach (var item in output)
                    Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
