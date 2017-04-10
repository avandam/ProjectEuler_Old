using System;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = DateTime.Now;
            Console.WriteLine("Problem 2: " + Problems.Problem2());
            Console.WriteLine("Took " + (DateTime.Now - start).TotalMilliseconds + "ms to solve");

            //Console.WriteLine("Problem 1: " + Problems.Problem1());
            //Console.WriteLine("Problem 2: " + Problems.Problem2());
            //Console.WriteLine("Problem 3: " + Problems.Problem3());
            //Console.WriteLine("Problem 4: " + Problems.Problem4());
            //Console.WriteLine("Problem 5: " + Problems.Problem5());
            //Console.WriteLine("Problem 6: " + Problems.Problem6());
            //Console.WriteLine("Problem 7: " + Problems.Problem7());
            //Console.WriteLine("Problem 9: " + Problems.Problem9());
            //Console.WriteLine("Problem 10: " + Problems.Problem10());
            Console.Read();

        }
    }
}
