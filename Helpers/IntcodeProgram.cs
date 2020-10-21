using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AoC2019
{
    public class IntcodeProgram
    {
        public static void MissionControl() 
        {
            int[] intcodeProgramArrF = ImportIntcodeProgram();
            GravityAssistProgram(ImportIntcodeProgram());
        }
        public static int[] ImportIntcodeProgram() 
        {
            string intcodeProgramStr = System.IO.File.ReadAllText(@"C:\Users\Cole\source\repos\AoC2019\data\adventOfCode2019IntcodeProgram_working.txt");
            return intcodeProgramStr.Split(',').Select(int.Parse).ToArray();
        }

        public static void GravityAssistProgram(int[] intcodeProgramArrF)
        {

            for (int i = 0; i < intcodeProgramArrF.Length; i += 4)
            {
                int breakValue = 19690720;

                if (intcodeProgramArrF[i] == 1)
                {

                    int posOfSum = intcodeProgramArrF[i + 3];

                    intcodeProgramArrF[posOfSum] = intcodeProgramArrF[intcodeProgramArrF[i + 1]] + intcodeProgramArrF[intcodeProgramArrF[i + 2]];
                

                }
                else if (intcodeProgramArrF[i] == 2)
                {

                    int posOfMult = intcodeProgramArrF[i + 3];

                    //assigning value to position of multiplication soltution
                    intcodeProgramArrF[posOfMult] = intcodeProgramArrF[intcodeProgramArrF[i + 1]] * intcodeProgramArrF[intcodeProgramArrF[i + 2]];

                   
                }
                else if (intcodeProgramArrF[i] == 99)
                {
                    
                    //Console.WriteLine("HALT - INTCODE: " + intcodeProgramArrF[i] + "\n");
                    break;
                }

                if (intcodeProgramArrF[0] == breakValue)
                {
                    int gravityAssistAns = 100 * intcodeProgramArrF[1] + intcodeProgramArrF[2];

                    Console.WriteLine("\nYOUR PROGRAM WORKED! Output value of: " + intcodeProgramArrF[0]);
                    Console.WriteLine("THE NOUN & VERB ARE: " + intcodeProgramArrF[1] + " & " + intcodeProgramArrF[2] + ", RESPECTIVELY.");
                    Console.WriteLine("YOUR ANSWER IS: " + gravityAssistAns);
                    //Console.ReadLine();

                    GravityAssistProgramInput(breakValue);
                    Console.ReadLine();
                    break;
                }
            }
            Console.WriteLine("intcode value at position [0] is: " + intcodeProgramArrF[0]);
            //Console.ReadLine();
        }
        public static void GravityAssistProgramInput(int breakValue)
        {

            while (breakValue != 19690720)
            {
                for (int noun = 0; noun < 100; noun++)
                {

                    for (int verb = 0; verb < 100; verb++)
                    {

                        //if (breakValue != 0) 
                        //{                          
                        //    break;
                        //}

                        int[] intcodeProgramArrPerm = ImportIntcodeProgram();

                        intcodeProgramArrPerm[1] = noun;
                        intcodeProgramArrPerm[2] = verb;

                        //Console.WriteLine("~~~NOUN = " + noun);
                        //Console.WriteLine("~~~~~~~~VERB = " + verb);
                        GravityAssistProgram(intcodeProgramArrPerm);
                    }
                }//return;
            } 
           return;
        }
    }
}
