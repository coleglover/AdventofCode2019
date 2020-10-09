using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2019
{
    public class FuelCalculator
    {
        //creating components of the Fuel Calculator - to be satisfied from the Main program

        public List<int> fuelForModule = new List<int>();
        public List<int> fuelForModuleAndFuel = new List<int>();
        public int fuelForModuleSum = 0;
        public int fuelForModuleAndFuelSum = 0;

        // creating an "instance" of Fuel Calculator
        public FuelCalculator(float[] aModuleMasses) 
        {
            //calling the fuel conversion calculator
            fuelForModule.Add(FuelConversion(aModuleMasses));

            //sum the fuel
            fuelForModuleSum = fuelForModule.Sum();
            Console.WriteLine("\nthe total fuel required to launch all modules is: " + fuelForModuleSum);
        }

        //creating a method within the Fuel Calculator Class (void = return nothing)
        public void FuelForFuelCalculator(float[] aModuleMasses) {
            //create counter
            int i = 0;

            do
            {
            // creating an int to store fuelForModule values and to pass to fuelForFuel calculator
            int fuelForModule = (int)(Math.Floor(aModuleMasses[i] / 3.0) - 2);           
            
            //add fuelForModule values to fuelForFuel list
            fuelForModuleAndFuel.Add(fuelForModule);
            
            //pass to fuelForModule values to be calculated in fuelForFuel calculator
            int fuelForFuel = fuelForModule;
            i++;


                //int fuelForModule = FuelConversion(aModuleMasses);
                //fuelForModuleAndFuel.Add(FuelConversion(aModuleMasses));
                //int fuelForFuel = FuelConversion(aModuleMasses);
                //i++;

                do {

                    //iterative calculator uses a solution in the following equation - solutions < 6 result in negative fuel values, and thus break the calculator
                    fuelForFuel = (int)(Math.Floor(fuelForFuel / 3.0) - 2);                 
                    //add values to fuelForFuel list
                    fuelForModuleAndFuel.Add(fuelForFuel);
                    //Console.WriteLine(fuelForFuel);                  

                } while (fuelForFuel > 6);           

            } while (i < aModuleMasses.Length);

            //sum fuelForFuel list & print it
            fuelForModuleAndFuelSum = fuelForModuleAndFuel.Sum();
            Console.WriteLine("\nthe total fuel required to launch all modules AND fuel is: " + fuelForModuleAndFuelSum+"\n");
        }
        // private mass -> fuel conversion method returns int values, receives float array 
        private int FuelConversion(float[] aModuleMasses)
        {

            for (int i = 0; i < aModuleMasses.Length; i++)
            {
                fuelForModule.Add((int)(Math.Floor(aModuleMasses[i] / 3.0) - 2));
                //Console.WriteLine(fuelForModule[i]);

            }
            return 0;
        }
    }


}
