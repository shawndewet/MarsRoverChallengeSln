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
                            Y++;
                            break;
                        case "E":
                            X++;
                            break;
                        case "S":
                            Y--;
                            break;
                        case "W":
                            X--;
                            break;
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
