using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverChallenge.Library
{
    public class Rover
    {
        public Rover(int x, int y, string heading)
        {
            X = x;
            Y = y;
            Heading = heading;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public string Heading { get; private set; }

        public void ExecuteCommand(char command)
        {
            throw new NotImplementedException();
        }

        public string ReportPosition()
        {
            return $"{X} {Y} {Heading}";
        }
    }
}
