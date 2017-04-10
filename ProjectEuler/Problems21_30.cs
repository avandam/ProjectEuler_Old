using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

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
    }
}
