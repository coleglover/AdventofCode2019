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
            //IMPORT MODULE MASS DATA
            // convert fuel data from string[] -> float[]
            string[] moduleMassesStr = System.IO.File.ReadAllLines(@"C:\Users\Cole\source\repos\AoC2019\data\adventOfCode2019FuelData.txt");
            float[] moduleMassesFlt = moduleMassesStr.Select(float.Parse).ToArray();
            
            //sending module masses to Fuel Calculator Object
            FuelCalculator fuelForModulesCalculator = new FuelCalculator(moduleMassesFlt);
            fuelForModulesCalculator.FuelForFuelCalculator(moduleMassesFlt);
            
            //IMPORT INTCODE PROGRAM DATA
            string intcodeProgramStr = System.IO.File.ReadAllText(@"C:\Users\Cole\source\repos\AoC2019\data\adventOfCode2019IntcodeProgram_working.txt");
            int[] intcodeProgramIntArr = intcodeProgramStr.Split(',').Select(int.Parse).ToArray();
            //List<int> intcodeProgramList

            //Console.WriteLine(intcodeProgramIntArr[155]);
            IntcodeProgram opcodeHandler = new IntcodeProgram(intcodeProgramIntArr);

            //Console.WriteLine(string.Join(",", intcodeProgramIntArr));
            Console.ReadLine();




        }
    }
}
