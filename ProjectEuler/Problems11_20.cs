using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler
{
    public partial class Problems
    {
        public static long Problem11()
        {
            long maxValue = 0;
            var numbers = FileHelpers.ReadNumberSequencePerLine(@"files\Problem11.txt");
            var direction = "";
            var iLocation = 0;
            var jLocation = 0;

            // Horizontal
            for (var i = 0; i <= numbers.Count - 4; i++)
            {
                for (var j = 0; j <= numbers[i].Count - 4; j++)
                {
                    var result = numbers[i][j]*numbers[i][j + 1]*numbers[i][j + 2]*numbers[i][j + 3];
                    if (result > maxValue)
                    {
                        maxValue = result;
                        direction = "horizontal";
                        iLocation = i;
                        jLocation = j;
                    }
                }
            }

            // vertical
            for (var j = 0; j <= numbers.Count - 4; j++)
            {
                for (var i = 0; i <= numbers[j].Count - 4; i++)
                {
                    var result = numbers[i][j] * numbers[i + 1][j] * numbers[i + 2][j] * numbers[i + 3][j];
                    if (result > maxValue)
                    {
                        maxValue = result;
                        direction = "vertical";
                        iLocation = i;
                        jLocation = j;
                    }
                }
            }

            // diagonal to the right
            for (var i = 0; i <= numbers.Count - 4; i++)
            {
                for (var j = 0; j <= numbers[i].Count - 4; j++)
                {
                    var result = numbers[i][j] * numbers[i + 1][j + 1] * numbers[i + 2][j + 2] * numbers[i + 3][j + 3];
                    if (result > maxValue)
                    {
                        maxValue = result;
                        direction = "diagright";
                        iLocation = i;
                        jLocation = j;
                    }
                }
            }

            // diagonal to the left
            for (var i = 3; i <= numbers.Count - 1; i++)
            {
                for (var j = numbers[i].Count - 4; j >= 0; j--)
                {
                    var result = numbers[i][j] * numbers[i - 1][j + 1] * numbers[i - 2][j + 2] * numbers[i - 3][j + 3];
                    if (result > maxValue)
                    {
                        maxValue = result;
                        direction = "diagleft";
                        iLocation = i;
                        jLocation = j;
                    }
                }
            }

            Console.WriteLine(direction);
            Console.WriteLine(iLocation);
            Console.WriteLine(jLocation);
            return maxValue;
        }

        public static int Problem12()
        {
            var number = 0;
            var i = 1;

            while (EulerHelpers.GetNumberOfDivisors(number) < 500)
            {
                number += i;
                i++;
            }
            return number;
        }

        public static string Problem13()
        {
            var digits = new List<int>();
            var numbers = FileHelpers.ReadDigitsPerLine(@"files\Problem13.txt");
            var intermediateResult = 0;
            for (var i = numbers[0].Count - 1; i >= 0; i--)
            {
                intermediateResult += numbers.Sum(line => line[i]);
                digits.Add(intermediateResult % 10);
                intermediateResult = intermediateResult / 10;
            }
            while (intermediateResult > 0)
            {
                if (intermediateResult > 10)
                {
                    digits.Add(intermediateResult % 10);
                    intermediateResult = intermediateResult / 10;
                }
                else
                {
                    digits.Add(intermediateResult);
                    intermediateResult = 0;
                }
            }
            digits.Reverse();
            return String.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}", digits[0], digits[1], digits[2], digits[3], digits[4], digits[5], digits[6], digits[7], digits[8], digits[9]);
        }

        public static long Problem14()
        {
            var collatzSequences = new Dictionary<long, long>();
            for (long i = 1; i <= 1000000; i++)
            {
                var n = i;
                long nrOfItems = 1;
                while (n > 1)
                {
                    if (collatzSequences.ContainsKey(n))
                    {
                        nrOfItems += collatzSequences[n] - 1;
                        break;
                    }

                    nrOfItems++;
                    if (n % 2 == 0)
                    {
                        n = n / 2;
                    }
                    else
                    {
                        n = 3 * n + 1;
                    }
                }
                collatzSequences.Add(i, nrOfItems);
            }
            
            Console.WriteLine(collatzSequences[1]);
            Console.WriteLine(collatzSequences[2]);
            Console.WriteLine(collatzSequences[3]);
            Console.WriteLine(collatzSequences[4]);
            Console.WriteLine(collatzSequences[5]);
            Console.WriteLine(collatzSequences[6]);
            Console.WriteLine(collatzSequences[7]);
            Console.WriteLine(collatzSequences[8]);
            Console.WriteLine(collatzSequences[9]);
            Console.WriteLine(collatzSequences[10]);

            return  collatzSequences.OrderByDescending(x => x.Value).First().Key;
        }

        public static long Problem15()
        {
            
            const int max = 20;
            var grid = new long[max + 1, max + 1];
            for (var i = 0; i <= max; i++)
            {
                grid[max, i] = 1;
                grid[i, max] = 1;
            }

            for (var x = max - 1; x >= 0; x--)
            {
                for (var y = max - 1; y >= 0; y--)
                {
                    grid[x, y] = grid[x + 1, y] + grid[x, y + 1];
                }
            }

            return grid[0,0];
        }

        public static long Problem16()
        {
            var power = BigInteger.Pow(2, 1000);
            return EulerHelpers.ComputeSumOfDigits(power);
        }

        public static long Problem17()
        {
            const int max = 1000;
            const string hundred = "hundred";
            const string thousand = "thousand";
            var count = 0;

            for (var i = 1; i <= max; i++)
            {
                var fullnumber = "";
                var number = i;
                if (number == 1000)
                {
                    var t = number.ToString().Substring(0, 1);
                    var tn = int.Parse(t);
                    fullnumber += Enum.GetName(typeof (Digits), tn) + thousand;
                    number = number - (tn*1000);
                }

                if (number >= 100)
                {
                    var h = number.ToString().Substring(0, 1);
                    var hn = int.Parse(h);
                    fullnumber += Enum.GetName(typeof (Digits), hn) + hundred;
                    number = number - (hn * 100);
                    if (number > 0)
                    {
                        fullnumber += "and";
                    }
                }

                if (number >= 20)
                {
                    var t = number.ToString().Substring(0, 1);
                    var tn = int.Parse(t);
                    fullnumber += Enum.GetName(typeof (Tens), tn);
                    number = number - (tn*10);
                }

                if (number >= 10)
                {
                    var t = number.ToString();
                    var tn = int.Parse(t);
                    fullnumber += Enum.GetName(typeof (Teens), tn);
                    number = number - tn;
                }

                if (number > 0)
                {
                    fullnumber += Enum.GetName(typeof(Digits), number);
                }

                count += fullnumber.Count();
            }
            
            return count;
        }

        public static long Problem18()
        {
            return SumFunctions.ComputeMaximumPath(FileHelpers.ReadNumberSequencePerLine(@"files\Problem18.txt"));
        }

        public static long Problem19()
        {
            var result = 0;
            var dayCount = 366;

            var months = new Dictionary<int, int>()
            {
                {1, 31},
                {2, 28},
                {3, 31},
                {4, 30},
                {5, 31},
                {6, 30},
                {7, 31},
                {8, 31},
                {9, 30},
                {10, 31},
                {11, 30},
                {12, 31}
            };

            for (var year = 1901; year <= 2000; year++)
            {
                for (var month = 1; month <= 12; month++)
                {
                    if (dayCount%7 == 0)
                    {
                        result++;
                    }
                    // Fix days
                    if (month == 2 && (year % 4 == 0) && (year % 400 != 0))
                    {
                        dayCount++;
                    }
                    dayCount += months[month];
                }
            }

            return result;
        }

        public static long Problem20()
        {
            var value = new BigInteger(1);

            for (var i = 2; i <= 100; i++)
            {
                value = BigInteger.Multiply(value, i);
            }

            return EulerHelpers.ComputeSumOfDigits(value);
        }
    }
}
