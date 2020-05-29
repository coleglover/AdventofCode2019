using System;
using System.IO;
using System.Linq;

namespace adventOfCode2019
{
    class Day01
    {
        public static void Main(string[] args)
        {
        
            // read each line of the file into a string array
            //convert string[] -> float[]
            string[] moduleMassesStr = System.IO.File.ReadAllLines(@"C:\Users\Cole\Documents\cSharpProjects\adventOfCode2019\adventOfCode2019Data.txt");
            float[] moduleMassesFlt = new float[moduleMassesStr.Length];
            int[] fuel = new int[moduleMassesStr.Length]; //create empty string for fuel values


            // displays file contents by using a foreach loop.
            System.Console.WriteLine("\nModule masses: \n");

            for (int module = 0; module < moduleMassesStr.Length; module++){
                
                moduleMassesFlt[module] = float.Parse(moduleMassesStr[module]);

                fuel[module] = Convert.ToInt32(Math.Floor(moduleMassesFlt[module]/3)) - 2;


                // write masses to the terminal:
                Console.WriteLine("Module mass: " + moduleMassesFlt[module]);

                // write masses to the terminal:
                Console.WriteLine("Fuel required to launch given module: " + fuel[module] + "\n");
                
                //write masses to the terminal:
                //Console.WriteLine("\t" + moduleMassesFlt[module]);
            }

            int fuelSum = fuel.Sum();
            Console.WriteLine("Total fuel required to launch all modules: " + fuelSum + "\n");
           
            
        }
    }
}
