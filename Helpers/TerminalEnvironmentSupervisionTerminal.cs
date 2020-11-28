using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AoC2019
{
    class IntcodeProgramDay05
    {
        //< this method pulls the intcode .txt file and parses it into an array
        public static int[] ImportIntcodeProgram()
        {
            string intcodeProgramStr = System.IO.File.ReadAllText(@"C:PATHTOYOURDATA.txt");
            return intcodeProgramStr.Split(',').Select(int.Parse).ToArray();
        }

        public static void ThermalEnvironmentSupervisionTerminal()
        {
            //int[] intcodeProgram = { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 };
            //int[] intcodeProgram = {3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99};
            int[] intcodeProgram = ImportIntcodeProgram();
            

            int i = 0;
            Boolean run = true;

            //< create an array to hold parameter modes
            int[] parameter = new int[3];
            bool[] paramMode = new bool[3];

            while(run)
            {

                string instruction = intcodeProgram[i].ToString();

                // adding leading zeros to each instruction (result: "[00000]")
                for (int j = 0; instruction.Length < 5; j++) 
                {
                    instruction = "0" + instruction;
                }

                //< pull the last two digits "[000xx]" as the opcode
                int opcode = Convert.ToInt32(instruction.Substring(instruction.Length - 2));


                //< ex. instruction: [0 1 0 02] 
                //< bool array holding T/F test results, used to determine the instruction's parameter mode
                paramMode[0] = instruction[2] == '0';
                paramMode[1] = instruction[1] == '0';
                paramMode[2] = instruction[0] == '0';

                Console.WriteLine($"\nopcode: {opcode}");
                //Console.WriteLine($"I: {intcodeProgram[i]} {intcodeProgram[i + 1]} {intcodeProgram[i + 2]} {intcodeProgram[i + 3]}");

                int result;
                switch (opcode)
                {
                    //< adds input parameters
                    case 1:


                        Console.WriteLine($"I: {intcodeProgram[i]} {intcodeProgram[i + 1]} {intcodeProgram[i + 2]} {intcodeProgram[i + 3]}");

                        //< send parameter modes, instruction list, and index - returns parameters
                        parameter[0] = GetValueForParamMode(paramMode[0], intcodeProgram, i + 1);
                        parameter[1] = GetValueForParamMode(paramMode[1], intcodeProgram, i + 2);
                        parameter[2] = intcodeProgram[i + 3];
                       
                        result = parameter[0] + parameter[1];

                        //< position which will be overwritten
                        intcodeProgram[parameter[2]] = result;
                        i += 4;

                        break;

                      
                    //< multiplies input parameters
                    case 2:


                        Console.WriteLine($"I: {intcodeProgram[i]} {intcodeProgram[i + 1]} {intcodeProgram[i + 2]} {intcodeProgram[i + 3]}");

                        //< send parameter modes, instruction list, and index - returns parameters
                        parameter[0] = GetValueForParamMode(paramMode[0], intcodeProgram, i + 1);
                        parameter[1] = GetValueForParamMode(paramMode[1], intcodeProgram, i + 2);
                        parameter[2] = intcodeProgram[i + 3];

                        result = parameter[0] * parameter[1];



                        //assigning value to position of multiplication soltution
                        intcodeProgram[parameter[2]] = result;
                        i += 4;

                        break;

                    //< receive input parameter from user
                    case 3:

                        Console.WriteLine($"I: {intcodeProgram[i]} {intcodeProgram[i + 1]}");

                        //< retrieve user input
                        Console.WriteLine("\nPlease provide an input instruction: ");
                        int input = Convert.ToInt32(Console.ReadLine());

                        parameter[0] = intcodeProgram[i + 1];

                        intcodeProgram[parameter[0]] = input;
                        i += 2;

                        break;

                    //< print output parameter(s)
                    case 4:

                        Console.WriteLine($"I: {intcodeProgram[i]} {intcodeProgram[i + 1]}");

                        parameter[0] = GetValueForParamMode(paramMode[0], intcodeProgram, i + 1);
                        Console.WriteLine($"\nOutput: {parameter[0]}\n");
                        Console.ReadLine();
                        i += 2;

                        break;


                    //< change index by a parameter
                    case 5:

                        Console.WriteLine($"I: {intcodeProgram[i]} {intcodeProgram[i + 1]} {intcodeProgram[i + 2]}");

                        parameter[0] = GetValueForParamMode(paramMode[0], intcodeProgram, i + 1);
                        parameter[1] = GetValueForParamMode(paramMode[1], intcodeProgram, i + 2);

                        if (parameter[0] != 0)
                        {
                            i = parameter[1];
                        }
                        else 
                        {
                            i += 3;
                        }

                        break;


                    //< change index by a parameter
                    case 6:

                        Console.WriteLine($"I: {intcodeProgram[i]} {intcodeProgram[i + 1]} {intcodeProgram[i + 2]}");

                        parameter[0] = GetValueForParamMode(paramMode[0], intcodeProgram, i + 1);
                        parameter[1] = GetValueForParamMode(paramMode[1], intcodeProgram, i + 2);

                        if (parameter[0] == 0)
                        {                          
                            i = parameter[1];
                        }
                        else 
                        {
                            i += 3;
                        }

                        break;

                    //< change values at a position in opcode array
                    case 7:

                        Console.WriteLine($"I: {intcodeProgram[i]} {intcodeProgram[i + 1]} {intcodeProgram[i + 2]} {intcodeProgram[i + 3]}");


                        parameter[0] = GetValueForParamMode(paramMode[0], intcodeProgram, i + 1);
                        parameter[1] = GetValueForParamMode(paramMode[1], intcodeProgram, i + 2);
                        parameter[2] = intcodeProgram[i + 3];

                        //< Ternary Operator: if T/F parameter at position parameter[2] = 1/0
                        intcodeProgram[parameter[2]] = (parameter[0] < parameter[1]) ? 1 : 0;

                        i += 4;
                        break;


                    //< change values at a position in opcode array
                    case 8:

                        Console.WriteLine($"I: {intcodeProgram[i]} {intcodeProgram[i + 1]} {intcodeProgram[i + 2]} {intcodeProgram[i + 3]}");


                        parameter[0] = GetValueForParamMode(paramMode[0], intcodeProgram, i + 1);
                        parameter[1] = GetValueForParamMode(paramMode[1], intcodeProgram, i + 2);
                        parameter[2] = intcodeProgram[i + 3];

                        //< Ternary Operator: if T/F parameter at position parameter[2] = 1/0
                        intcodeProgram[parameter[2]] = (parameter[0] == parameter[1]) ? 1 : 0;

                        i += 4;
                        break;


                    //> halt program if opcode 99
                    case 99:

                        Console.WriteLine("Process exited with opcode: " + intcodeProgram[i] + "\n");
                        Console.ReadLine();

                        return;

                    default:
                        run = false;
                        break;
                }
            }
        }

        //< return parameters based on parameter mode inputs
        public static int GetValueForParamMode(bool posMode, int[] intcodeProgram, int i) 
        {         
            if (posMode)
            {
                //< indicates parameter mode 0: "position mode" - parameter is interpreted as a position
                return  intcodeProgram[intcodeProgram[i]];
            }
            else
            {
                //< indicates parameter mode 1: "immediate mode" - parameter is interpreted as a value;
                return  intcodeProgram[i];
            }

        }
    }
}
