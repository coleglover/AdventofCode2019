using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace AoC2019
{
    class Program
    {
        static void Main(string[] args)
        {
            //< IMPORT MODULE MASS DATA
            //< convert fuel data from string[] -> float[]
            string[] moduleMassesStr = System.IO.File.ReadAllLines(@"C:\Users\Cole\source\repos\AoC2019\data\adventOfCode2019FuelData.txt");
            int[] moduleMassesInt = moduleMassesStr.Select(int.Parse).ToArray();

            //sending module masses to Fuel Calculator Object
            var day1 = FuelCalculator.CalculateFuel(moduleMassesInt);
            var day1p2 = FuelCalculator.SumFuelForModulesAndFuel(moduleMassesInt);


            //INTCODE PROGRAM
            IntcodeProgram2.GravityAssistProgram();

            //< MANHATTAN DISTANCE

            var wireSteps = ManhattanDistance.ParseWireCoordinates();

            List<(double x, double y)> wireStepsA = wireSteps._wireStepsA;
            List<(double x, double y)> wireStepsB = wireSteps._wireStepsB;

            int minManhattanDistance = ManhattanDistance.FindManhattanDistance(wireStepsA, wireStepsB);
            int minWireLengthIntersect = ManhattanDistance.FindMinimumStepsIntersection(wireStepsA, wireStepsB);
            Console.WriteLine($"the minimum Manhattan distance to a crossed wire is: {minManhattanDistance}");
            
            int passwordCount = ElvenPassword.PasswordParser();
            Console.WriteLine($"\nThere are {passwordCount} passwords that meet the given criteria");
            Console.ReadLine();
        }
    }
}
