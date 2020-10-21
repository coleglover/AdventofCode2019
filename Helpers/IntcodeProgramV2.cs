using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AoC2019
{
    class IntcodeProgram2
    {
        public static int[] ImportIntcodeProgram()
        {
            string intcodeProgramStr = System.IO.File.ReadAllText(@"C:\Users\Cole\source\repos\AoC2019\data\adventOfCode2019IntcodeProgram_working.txt");
            return intcodeProgramStr.Split(',').Select(int.Parse).ToArray();
        }
        public static void GravityAssistProgram()
        {

            int customInput1 = 12;
            int customInput2 = 2;

            int breakValue = 19690720;          

            for (int noun = 0; noun < 100; noun++)
            {

                for (int verb = 0; verb < 100; verb++)
                {


                    int[] intcodeProgramArr = ImportIntcodeProgram();

                    intcodeProgramArr[1] = noun;
                    intcodeProgramArr[2] = verb;

                    //Console.WriteLine("~~~NOUN = " + noun);
                    //Console.WriteLine("~~~~~~~~VERB = " + verb);


                    for (int i = 0; i < intcodeProgramArr.Length; i += 4)
                    {


                        if (intcodeProgramArr[i] == 1)
                        {

                            int posOfSum = intcodeProgramArr[i + 3];

                            intcodeProgramArr[posOfSum] = intcodeProgramArr[intcodeProgramArr[i + 1]] + intcodeProgramArr[intcodeProgramArr[i + 2]];


                        }
                        else if (intcodeProgramArr[i] == 2)
                        {

                            int posOfMult = intcodeProgramArr[i + 3];

                            //assigning value to position of multiplication soltution
                            intcodeProgramArr[posOfMult] = intcodeProgramArr[intcodeProgramArr[i + 1]] * intcodeProgramArr[intcodeProgramArr[i + 2]];


                        }
                        else if (intcodeProgramArr[i] == 99)
                        {
                            //Console.WriteLine("HALT - INTCODE: " + intcodeProgramArr[i] + "\n");
                            break;
                        }

                        if (intcodeProgramArr[0] == breakValue)
                        {
                            int gravityAssistAns = 100 * intcodeProgramArr[1] + intcodeProgramArr[2];

                            Console.WriteLine("\nSUCCESS! Output value of: " + intcodeProgramArr[0]);
                            Console.WriteLine("THE NOUN & VERB ARE: " + intcodeProgramArr[1] + " & " + intcodeProgramArr[2] + ", RESPECTIVELY.");
                            Console.WriteLine("THEREFORE, YOUR ANSWER IS: " + gravityAssistAns);

                            Console.ReadLine();
                            return;
                        }
                    } 
                        
                    if (intcodeProgramArr[1] == customInput1 && intcodeProgramArr[2] == customInput2)
                    {
                        Console.WriteLine("CUSTOM INPUTS OF: "+ customInput1 + " AND "+ customInput2 + " PRODUCES: " + intcodeProgramArr[0] + " AT POSITION [0]");
                        Console.ReadLine();

                    }
                    //Console.WriteLine("intcode value at position [0] is: " + intcodeProgramArr[0]);
                }                   
            }
        }
    }
}
