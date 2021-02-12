using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverChallenge.Library
{
    public class Rover
    {
        private readonly int maxX;
        private readonly int maxY;

        public Rover(int plateauWidth, int plateauHeight, int x, int y, string heading)
        {
            maxX = plateauWidth - 1;
            maxY = plateauHeight - 1;
            X = x;
            Y = y;
            Heading = heading;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public string Heading { get; private set; }

        public void ExecuteCommand(char command, Rover[] otherRovers)
        {
            var oldX = X;
            var oldY = Y;
            switch (command)
            {
                case 'L': //spin left
                    switch (Heading)
                    {
                        case "N":
                            Heading = "W";
                            break;
                        case "E":
                            Heading = "N";
                            break;
                        case "S":
                            Heading = "E";
                            break;
                        case "W":
                            Heading = "S";
                            break;
                    }
                    break;

                case 'R': //spin righ
                    switch (Heading)
                    {
                        case "N":
                            Heading = "E";
                            break;
                        case "E":
                            Heading = "S";
                            break;
                        case "S":
                            Heading = "W";
                            break;
                        case "W":
                            Heading = "N";
                            break;
                    }

                    break;

                case 'M': //move
                    switch (Heading)
                    {
                        case "N":
                            if (Y < maxY)
                                Y++;
                            break;
                        case "E":
                            if (X < maxX)
                                X++;
                            break;
                        case "S":
                            if (Y > 0)
                                Y--;
                            break;
                        case "W":
                            if (X > 0)
                                X--;
                            break;
                    }
                    if (otherRovers!= null)
                        foreach (var otherRover in otherRovers)
                        {
                            if (otherRover != null && X == otherRover.X && Y == otherRover.Y)
                            {
                                X = oldX;
                                Y = oldY;
                            }
                        }

                    break;
            }
        }

        public string ReportPosition()
        {
            return $"{X} {Y} {Heading}";
        }
    }
}
