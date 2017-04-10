using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    public static partial class Problems
    {
        public static int Problem1()
        {
            var result = 0;
            for (var i = 0; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    result += i;
                }
            }
            return result;
        }

        public static int Problem2()
        {
            var result = 0;
            var fib1 = 1;
            var fib2 = 2;

            while (fib2 < 4000000)
            {
                if (fib2 % 2 == 0)
                {
                    result += fib2;
                }

                var temp = fib1 + fib2;
                fib1 = fib2;
                fib2 = temp;
            }

            return result;
        }

        private static readonly List<long> FoundPrimeFactors = new List<long>();
        private static readonly List<long> Primes = new List<long>();
        public static long Problem3()
        {
            const long initValue = 600851475143;
            Primes.Add(2);
            ComputePrimeFactor(initValue);
            return FoundPrimeFactors.Max();
        }

        private static void ComputePrimeFactor(long number)
        {
            foreach (var prime in Primes.Where(prime => number % prime == 0))
            {
                if (!FoundPrimeFactors.Contains(prime))
                {
                    FoundPrimeFactors.Add(prime);
                }
                ComputePrimeFactor(number / prime);
                return;
            }

            for (var i = Primes.Max() + 1; i < number; i++)
            {
                if (EulerHelpers.IsPrimeNumber(i))
                {
                    Primes.Add(i);
                    if (number % i == 0)
                    {
                        if (!FoundPrimeFactors.Contains(i))
                        {
                            FoundPrimeFactors.Add(i);
                        }
                        ComputePrimeFactor(number / i);
                        return;
                    }
                }
            }

            if (!FoundPrimeFactors.Contains(number))
            {
                FoundPrimeFactors.Add(number);
            }
        }

        public static int Problem4()
        {
            var result = 0;
            for (var i = 100; i <= 999; i++)
            {
                for (var j = 100; j <= 999; j++)
                {
                    var product = i * j;
                    if (EulerHelpers.IsPalindrome(product.ToString()) && product > result)
                    {
                        result = product;
                    }
                }
            }
            return result;
        }

        public static long Problem5()
        {
            const int k = 20;
            var n = 1;
            var i = 1;
            var check = true;
            var limit = Math.Sqrt(k);

            var primes = new long[k * 100];
            var a = new long[k * 100];
            var j = 1;
            while (i <= k * 100)
            {
                if (EulerHelpers.IsPrimeNumber(i))
                {
                    primes[j] = i;
                    j++;
                }
                i++;
            }

            i = 1;

            while (primes[i] <= k)
            {
                a[i] = 1;
                if (check)
                {
                    if (primes[i] <= limit)
                    {
                        a[i] = (int)Math.Floor(Math.Log10(k) / Math.Log10(primes[i]));
                    }
                    else
                    {
                        check = false;
                    }
                }
                n = n * (int)Math.Pow(primes[i], a[i]);
                i++;
            }
            return n;
        }

        public static long Problem6()
        {
            long sum = 0;
            long sumProduct = 0;

            for (var i = 1; i <= 100; i++)
            {
                sum += i;
                sumProduct += i * i;
            }
            return sum * sum - sumProduct;
        }

        public static long Problem7()
        {
            var limit = 10001;
            var count = 1;
            var candidate = 1;

            while (count < limit)
            {
                candidate += 2;
                if (EulerHelpers.IsPrimeNumber(candidate))
                {
                    count++;
                }
            }
            return candidate;
        }

        public static long Problem8()
        {
            long biggestProduct = -1;
            var n = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";
            var ranges = n.Split('0');
            foreach (var range in ranges)
            {
                if (range.Length < 13)
                {
                    continue;
                }

                long currentProduct = 1;
                var currentCount = 0;

                var numbers = new int[range.Length];
                for (var i = 0; i < range.Length; i++)
                {
                    numbers[i] = int.Parse((range[i]).ToString());
                }

                for (var i = 0; i < numbers.Length; i++)
                {
                    if (currentCount < 13)
                    {
                        currentProduct = currentProduct * numbers[i];
                        currentCount++;
                    }
                    else
                    {
                        currentProduct = (currentProduct / numbers[i - 13]) * numbers[i];

                        if (currentProduct > biggestProduct)
                        {
                            biggestProduct = currentProduct;
                        }
                    }

                    if (currentProduct > biggestProduct)
                    {
                        biggestProduct = currentProduct;
                    }
                }
            }

            return biggestProduct;   
        }

        public static long Problem9()
        {
            for (var a = 1; a <= 1000; a++)
            {
                for (var b = 1; b <= 1000; b++)
                {
                    for (var c = 1; c <= 1000; c++)
                    {
                        if ((a + b + c == 1000) && (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2)))
                        {
                            return a * b * c;
                        }
                    }
                }
            }
            throw new Exception("There should be an answer for problem 9");
        }

        public static long Problem10()
        {
            long result = 0;
            for (var i = 2; i < 2000000; i++)
            {
                if (EulerHelpers.IsPrimeNumber(i))
                {
                    result += i;
                }
            }
            return result;
        }
    }
}
