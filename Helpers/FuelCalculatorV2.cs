using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2019
{
    public class FuelCalculator
    {
        //creating components of the Fuel Calculator - to be satisfied from the Main program
        public static int CalculateFuel(IEnumerable<int> moduleMasses)
        {
            //< Calculate the fuel required for each module's mass
            var fuelReqs = moduleMasses.Select(module => calcFuelFromMass(module));
            //< Return the sum
            return fuelReqs.Sum();
        }
        //< Calculates the sum of fuel for modules and fuel for fuel
        public static int SumFuelForModulesAndFuel(IEnumerable<int> moduleMasses)
        {
            //< .Select projects each element of a sequence (module masses) into a new form
            return moduleMasses.Select(module => CalculateFuelForModulesAndFuel(module))
                         .Sum();
        }
        //< enumerating through module masses the fuel for modules + fuel is calculated here
        public static int CalculateFuelForModulesAndFuel(int module)
        {
            int totalFuel = 0;
            int input = module;

            //< while a module mass or fuel is > 0 - call calculate fuel method
            while (input > 0)
            {
                var fuel = calcFuelFromMass(input);

                if (fuel > 0)
                {
                    //< 1) total fuel receives a calculated fuel value
                    //< 2) said fuel value is compared against 0 and will run if the give condition (fuel > 0) is ture
                    totalFuel += fuel;
                    input = fuel;
                }
                else
                {    
                    break;
                }
            } return totalFuel;

        }

        //< method which calculates fuel required for a given mass
        private static int calcFuelFromMass (int aMass) 
        {
            var fuel = (int)(Math.Floor(aMass / 3.0) - 2);
            return fuel;
        }

        /*private static int calcFuelFromMass(float f)
        {
            return calcFuelFromMass((int)f);
        }*/
    }
} 
