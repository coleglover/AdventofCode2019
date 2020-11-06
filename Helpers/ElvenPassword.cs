using System;
using System.Collections.Generic;
using System.Linq;


namespace AoC2019
{
    public class ElvenPassword
    {
        public int Password;

        public ElvenPassword(int password)
        {
            this.Password = password;
        }

        //< test if password digits increase from left to right
        public bool IncreasingTest()
        {
            //< create reference to Password
            int passwordRef = Password;
            Console.WriteLine($"\nTESTING: {passwordRef}");

            //< by assigning digitCurrent = 10, we will always pass the first value comparion from: passwordRef % 10 b/c the result is always < 10.
            int digitCurrent = 10;

            while (passwordRef > 0)
            {
                int digitPrevious = digitCurrent;
                digitCurrent = passwordRef % 10; //< module operator provides remaining value after division operation
                passwordRef /= 10; //< remove an index

                if (digitCurrent > digitPrevious)
                {
                    Console.WriteLine($"fail: {digitCurrent} > {digitPrevious}");
                    return false;
                }
            }
            Console.WriteLine("pass: numbers increase");
            return true;
        }

        //< test if password contains repeated adjacent digits
        public bool DuplicatesTest() 
        {
            //create reference to Password
            int passwordRef = Password;

            int digitCurrent = 10;

            while (passwordRef > 0)
            {
                int digitPrevious = digitCurrent;
                digitCurrent = passwordRef % 10;
                passwordRef /= 10;

                if (digitCurrent == digitPrevious)
                {
                    Console.WriteLine($"pass: consecutive duplicates found");
                    return true;
                }
            }
            Console.WriteLine($"fail: no consecutive duplicates founds");
            return false;
        }

        //< test if password contains two adjacent matching digits are not part of a larger group of matching digits.
        public bool AdjacentPairsTest() 
        {
            int passwordRef = Password;

            int digitCurrent = 10;
            List<int> repeatList = new List<int>();

            while (passwordRef > 0) 
            {
                int digitPrevious = digitCurrent;
                digitCurrent = passwordRef % 10;
                passwordRef /= 10;

                if (digitCurrent == digitPrevious) 
                {
                    repeatList.Add(digitPrevious);
                }
            }

            //< catches single pair (i.e. one element exists in repeatList ex. 123455)
            if (repeatList.Count == 1)
            {
                Console.WriteLine("pass: single pair");
                return true;
            }

            //< takes all elements from repeatList which only contains adjacent repeated values*
            //< *repeat count = duplicates - 1 (i.e. repeat count = 2, then 3 duplicates exist in the password... Such as: 123444).
            var repeatListQueried = repeatList.GroupBy(x => x) 
                                  .Where(repeatValue => repeatValue.Skip(1).Any()) //< skips values in list of count 1... if no elements exist in new list, then there are double pairs (ex. 112344)
                                  .Select(value => new { Element = value.Key, Counter = value.Count() }) //< add number of repeats (Counter) to a value (Element)
                                  .ToList(); //< push to list

            //< catches two pairs (ex. 223455)
            if (repeatListQueried.Count == 0) 
            {
                Console.WriteLine("pass: double pairs"); 
                return true;
            }

            //< this allows us to access the Counter values within repeatQueriedList
            foreach (var value in repeatListQueried) 
            {
                //< password has a triple & double (triple double) ex. 255566
                if (value.Counter == 2 && repeatListQueried.Count == 1 && repeatList.Count == 3) 
                {
                    return true;
                }  
                //< password has a quadruple & double ex. 226666
                else if (value.Counter == 3 && repeatListQueried.Count == 1 && repeatList.Count == 4)
                {
                    return true;
                }               

            }            
            Console.WriteLine($"fail: greater than 2 repeated numbers, but no pairs: {Password}");
            //Console.ReadLine();
            return false;
        }

        public static int PasswordParser()
        { 
            //< setting the range for which potential passwords exist
            int passUpperBound = 789860;
            int passLowerBound = 254032;

            int countIsGood = 0;

            for (int i = passLowerBound; i <= passUpperBound; i++)
            {
                //create new instance (object) currPass of class ElvenPassword (blueprint of each object)
                var currPass = new ElvenPassword(i);

                //< Check if this password is good
                if (currPass.IncreasingTest() && currPass.DuplicatesTest() && currPass.AdjacentPairsTest())
                {
                    //< If so, add to count
                    countIsGood++;
                    Console.WriteLine($"COUNT: {countIsGood}");
                    //Console.ReadLine();
                }              
            }
            return countIsGood;
        }
    }
}
