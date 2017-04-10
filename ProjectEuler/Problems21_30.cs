using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace ProjectEuler
{
    public partial class Problems
    {
        public static long Problem21()
        {
            long result = 0;
            var divisors = new Dictionary<int, int>();

            for (var i = 1; i <= 10000; i++)
            {
                divisors.Add(i, EulerHelpers.GetSumOfDivisors(i));
            }

            for (var i = 1; i <= 10000; i++)
            {
                if (divisors[i] == i) continue;
                var temp = divisors[i];
                if (temp > 10000) continue;
                if (divisors[temp] == i && divisors[i] == temp)
                {
                    result += i;
                }
            }

            return result;
        }

        public static long Problem22()
        {
            var result = 0;

            var names = FileHelpers.ReadNamesFromFile(@"files\Problem22.txt");
            names.Sort();

            for (var i = 0; i < names.Count; i++)
            {
                result += names[i].Sum(c => c - 'a' + 1) * (i+1);
            }
            return result;
        }

        public static long Problem23()
        {
            var result = 0;

            List<int> abundantNumbers = new List<int>();
            Dictionary<int, bool> allNumbers = new Dictionary<int, bool>();

            int max = 28123;
            for (int i = 1; i <= max; i++)
            {
                if (EulerHelpers.GetSumOfDivisors(i) > i)
                {
                    abundantNumbers.Add(i);
                }
                allNumbers.Add(i, false);
            }

            for (int i = 0; i < abundantNumbers.Count; i++)
            {
                for (int j = i; j < abundantNumbers.Count; j++)
                {

                    int checkValue = abundantNumbers[i] + abundantNumbers[j];
                    if (checkValue <= max)
                    {
                        allNumbers[checkValue] = true;
                    }
                    else if (checkValue > max)
                    {
                        break;
                    }

                }
            }

            foreach (KeyValuePair<int, bool> kvp in allNumbers)
            {
                if (!kvp.Value)
                {
                    result += kvp.Key;
                }
            }

            return result;
        }

        public static long Problem24()
        {
            throw new NotImplementedException();
        }

        public static long Problem25()
        {
            BigInteger fib1 = new BigInteger(1);
            BigInteger fib2 = new BigInteger(1);
            var count = 2;

            while (true)
            {
                var temp = BigInteger.Add(fib1, fib2);
                count++;
                if (temp.ToString().Length >= 1000) break;
                fib1 = fib2;
                fib2 = temp;
            }

            return count;
        }

        public static long Problem28()
        {
            //21 22 23 24 25
            //20  7  8  9 10
            //19  6  1  2 11
            //18  5  4  3 12
            //17 16 15 14 13
            var result = 0;
            List<long> diagonal1 = new List<long>();
            List<long> diagonal2 = new List<long>();
            diagonal1.Add(1);
            diagonal2.Add(0);

            //500 times: Add two in diagonal 1, two in 2 and add 2 to the count
            int counter = 2;
            int currentValue = 1;



            for (int i = 0; i < 500; i++)
            {
                currentValue += counter;
                diagonal1.Add(currentValue);
                currentValue += counter;
                diagonal2.Add(currentValue);
                currentValue += counter;
                diagonal1.Add(currentValue);
                currentValue += counter;
                diagonal2.Add(currentValue);
                counter += 2;
            }
            return diagonal1.Sum() + diagonal2.Sum();
        }
    }
}
