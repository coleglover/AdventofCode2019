using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2019
{
    class IntcodeProgram
    {
        //int[] intCodeProgramArr = new int[0];

        public IntcodeProgram(int[] aIntcodeProgramArrI)
        {
            //int[] intcodeProgramArrF = new int[aIntcodeProgramArrI.Length];
            int[] intcodeProgramArrF = aIntcodeProgramArrI;

            for (int i = 0; i < intcodeProgramArrF.Length; i = i + 4)
            {

                Console.WriteLine("\nArray position: "+ i);

                if (intcodeProgramArrF[i] == 1)
                {

                    int posOfSum = intcodeProgramArrF[i + 3];

                    intcodeProgramArrF[posOfSum] = intcodeProgramArrF[intcodeProgramArrF[i + 1]] + intcodeProgramArrF[intcodeProgramArrF[i + 2]];

                    Console.WriteLine(intcodeProgramArrF[i]);
                    Console.WriteLine(intcodeProgramArrF[i + 1]);
                    Console.WriteLine(intcodeProgramArrF[i + 2]);
                    Console.WriteLine(intcodeProgramArrF[i + 3] + "\n");
                    Console.WriteLine("new value at position [" + posOfSum + "]" + " = " + intcodeProgramArrF[posOfSum]);

                }
                else if (intcodeProgramArrF[i] == 2)
                {

                    int posOfMult = intcodeProgramArrF[i + 3];

                    //assigning value to position of multiplication soltution
                    intcodeProgramArrF[posOfMult] = intcodeProgramArrF[intcodeProgramArrF[i + 1]] * intcodeProgramArrF[intcodeProgramArrF[i + 2]];

                    Console.WriteLine(intcodeProgramArrF[i]);
                    Console.WriteLine(intcodeProgramArrF[i + 1]);
                    Console.WriteLine(intcodeProgramArrF[i + 2]);
                    Console.WriteLine(intcodeProgramArrF[i + 3] + "\n");
                    Console.WriteLine("new value at position [" + posOfMult + "]" + " = " + intcodeProgramArrF[posOfMult]);

                }
                else if (intcodeProgramArrF[i] == 99)
                {
                    //Console.WriteLine("HALT - INTCODE: " + intcodeProgramArrF[i] + "\n");
                    break;
                }
            }            
            Console.WriteLine("intcode value at position [0] is: " + intcodeProgramArrF[0]);
            Console.ReadLine();
        }
    }
}
