using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    public static class EulerHelpers
    {
        public static int ComputeSumOfDigits(BigInteger value)
        {
            return value.ToString().Sum(i => int.Parse(i.ToString()));
        }

        public static bool IsPrimeNumber(long num)
        {
            if (num == 1) return false;
            if (num < 4) return true;
            if (num % 2 == 0) return false;
            if (num < 9) return true;
            if (num % 3 == 0) return false;

            var r = Math.Floor(Math.Sqrt(num));
            var f = 5;
            while (f <= r)
            {
                if (num % f == 0) return false;
                if (num % (f + 2) == 0) return false;
                f = f + 6;
            }
            return true;
        }

        public static bool IsPalindrome(string str)
        {
            var i = 0;
            var j = str.Length - 1;

            while (i < j)
            {
                if (str[i] != str[j])
                    return false;

                i++;
                j--;
            }

            return true;
        }

        public static int GetNumberOfDivisors(int number)
        {
            var nod = 0;
            var sqrt = (int)Math.Sqrt(number);

            for (var i = 1; i <= sqrt; i++)
            {
                if (number % i == 0)
                {
                    nod += 2;
                }
            }
            //Correction if the number is a perfect square
            if (sqrt * sqrt == number)
            {
                nod--;
            }

            return nod;
        }

        public static int GetSumOfDivisors(int number)
        {
            return GetDivisors(number).Sum();
        }

        public static List<int> GetDivisors(int number)
        {
            var divisors = new List<int>() { 1 };

            var sqrt = (int)Math.Sqrt(number);

            for (var i = 2; i <= sqrt; i++)
            {
                if (number % i == 0)
                {
                    divisors.Add(i);
                    if (i*i == number) continue;
                    divisors.Add(number/i);
                }
            }

            return divisors;
        }
    }
}
