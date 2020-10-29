using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2019
{
    class ManhattanDistance
    {
        //< import wire path coordinates and seperate them to wireA & wireB
        public static (string[] _wirePathA, string[] _wirePathB) ImportWireCoordinates() 
        {
            string wireCoordinatesBlock = System.IO.File.ReadAllText(@"C:\Users\Cole\source\repos\AoC2019\data\manhatDist_master.txt");

            string[] wireCoordinatesSep = wireCoordinatesBlock.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            //< TRUE IMPORT
            string[] _wirePathA = wireCoordinatesSep[0].Split(',', StringSplitOptions.RemoveEmptyEntries);
            string[] _wirePathB = wireCoordinatesSep[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

            return (_wirePathA, _wirePathB);
        }
        //< Parse wire coordinates and translate them from points -> steps
        public static (List<(double x, double y)> _wireStepsA, List<(double x, double y)> _wireStepsB) ParseWireCoordinates()
        {
            var wirePathsAB = ImportWireCoordinates();

            //< translating file coordinates to a vector format
            List<(double x, double y)> wirePointsA = MoveWire(wirePathsAB._wirePathA);

            Console.WriteLine("\n\n ~~~ NEW WIRE ~~~ \n\n");

            List<(double x, double y)> wirePointsB = MoveWire(wirePathsAB._wirePathB);

            Console.WriteLine("\ncomputing steps between points ...... one moment, please.\n");

            //< generating steps between wire points
            List<(double x, double y)> _wireStepsA = GenerateSteps(wirePointsA);
            List<(double x, double y)> _wireStepsB = GenerateSteps(wirePointsB);

            //< reversing orders because... 
            _wireStepsA.Reverse();
            _wireStepsB.Reverse();

            //< removing origin from lists
            _wireStepsA.RemoveAt(0);
            _wireStepsB.RemoveAt(0);

            return (_wireStepsA, _wireStepsB);
        }

        //< of the list of intersections, find the intersection with the smallest Manhattan distance to the (0,0) origin
        public static int FindManhattanDistance(List<(double x, double y)> wireStepsA, List<(double x, double y)> wireStepsB)
        {
            //< generate all wire intersections
            (double x, double y)[] wireIntersections = wireStepsA.Intersect(wireStepsB).ToArray(); 
            
            return (int)wireIntersections.Min(minDist => Math.Abs(minDist.x) + Math.Abs(minDist.y));
        }


        //< find intersection with the fewest combined wire steps
        public static int FindMinimumStepsIntersection(List<(double x, double y)> wireStepsA, List<(double x, double y)> wireStepsB) 
        {

            //< generate all wire intersections
            (double x, double y)[] wireIntersections = wireStepsA.Intersect(wireStepsB).ToArray();

            //< for each wire store the index which a wire intersection occurred 
            List<int> intersectionIndexA = new List<int>();
            List<int> intersectionIndexB = new List<int>();

            //< for Day 3 p.2: adding together the steps performed by each wire to reach an intersection
            List<int> intersectionIndexSum = new List<int>();

            //< determine # of steps taken to reach each intersection
            foreach ((double x, double y) _intersection in wireIntersections)
            {
                int indexA = wireStepsA.IndexOf(_intersection);
                int indexB = wireStepsB.IndexOf(_intersection);

                int indexSum = (indexA + 1) + (indexB + 1);

                intersectionIndexSum.Add(indexSum);
                intersectionIndexA.Add(indexA + 1);
                intersectionIndexB.Add(indexB + 1);

                //Console.WriteLine($"At intersection: {_intersection}, the step count is: {indexA} & {indexB}, adding to: {indexSum}");
            }

            int minWireIntLength = (int)intersectionIndexSum.Min();

            Console.WriteLine($"\nthe fewest combined steps the wires take to reach an intersection is: {minWireIntLength} steps\n" +
                $"... intersection location: ({wireIntersections[0].x},{wireIntersections[0].y})\n" +
                $"...... wire A & B length: {intersectionIndexA[0]}, {intersectionIndexB[0]}, respectively\n");

            return minWireIntLength;
        }
        //< algorithm that steps between every wire coordinate 
        public static List<(double x, double y)> GenerateSteps(List<(double x, double y)> wirePoints) 
        {
            List<(double x, double y)> wireSteps = new List<(double x, double y)>();

            //< loop through each coordinate 
            for (var i = 0; i < wirePoints.Count - 1; i++)
            {              
                
                //< determine the absolute distance between each wire point
                double magnitudeX = Math.Abs(wirePoints[i + 1].x - wirePoints[i].x);
                double magnitudeY = Math.Abs(wirePoints[i + 1].y - wirePoints[i].y);

                //< determine the direction that the wire points (+/-x,+/-y)
                double directionX = wirePoints[i + 1].x - wirePoints[i].x;
                double directionY = wirePoints[i + 1].y - wirePoints[i].y;

                //< movement in the x direction
                if (magnitudeX != 0)
                {                 
                    //< //< movement in the +x direction
                    if (directionX > 0)
                    {
                        for (int j = 0; j <= magnitudeX; j++)
                        {
                            int index = wirePoints.IndexOf((wirePoints[i]));
                            wireSteps.Insert(index, ((wirePoints[i].x + j), wirePoints[i].y));
                        }
                    }
                    //< //< movement in the -x direction
                    else if (directionX < 0)
                    {
                        for (int j = 0; j <= magnitudeX; j++)
                        {
                            int index = wirePoints.IndexOf((wirePoints[i]));
                            wireSteps.Insert(index, ((wirePoints[i].x - j), wirePoints[i].y));

                        }
                    }
                }
                //< //< movement in the y direction
                else if (magnitudeY != 0)
                {
                    //< //< movement in the +y direction
                    if (directionY > 0)
                    {
                        for (int j = 0; j <= magnitudeY; j++)
                        {
                            int index = wirePoints.IndexOf((wirePoints[i]));
                            wireSteps.Insert(index, (wirePoints[i].x, (wirePoints[i].y + j)));
                        }
                    }
                    //< //< movement in the -y direction
                    else if (directionY < 0)
                    {
                        for (int j = 0; j <= magnitudeY; j++)
                        {
                            int index = wirePoints.IndexOf((wirePoints[i]));
                            wireSteps.Insert(index, (wirePoints[i].x, (wirePoints[i].y - j)));
                        }
                    }
                }                
            }
            return (wireSteps);
        }
        //< determine how many steps a wire takes to get to a point
        public static List<int> StepCounter(List<(double x, double y)> wireSteps) 
        {
            int i = 0;
            List<int> stepCount = new List<int>();

            foreach ((double x, double y) step in wireSteps)
            {
              i++;
              stepCount.Add(i);
            }

            return stepCount;
        }
        
        //< translating actual steps from imports
        public static List<(double x, double y)> MoveWire(string[] wireVectors) 
        {
            List<(double x, double y)> currentPath = new List<(double x, double y)>();

            double dX = 0;
            double dY = 0;

            //< adding origin to wire points list - necessary for generating steps
            AddCurrentPath();

            //< Looping through all directions given by coordinate file 
            foreach (string vector in wireVectors)
            {
                var direction = vector[0];
                
                //< determine how much to move
                var magnitude = int.Parse(vector.Substring(1));

                    //< determine what direction to move in - using 2D x/y plane format
                    switch (direction)
                    {
                        case 'U':
                            dY += magnitude;
                            break;

                        case 'D':
                            dY -= magnitude;
                            break;

                        case 'L':
                            dX -= magnitude;
                            break;

                        case 'R':
                            dX += magnitude;
                            break;

                        default:
                            Console.WriteLine($"Invalid direction: {direction}");
                            break;
                    }
            
                Console.WriteLine($"{direction},{magnitude} ...... {dX},{dY}");
            
            //< create new point and add to list with updated coordinates
            AddCurrentPath();

            }
            //<  return wire path list once each coordinate has been translated 
            return currentPath;

            void AddCurrentPath() => currentPath.Add((dX, dY));
        }
    }
}
