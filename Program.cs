using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PNF;

Engine.LogUntil();

namespace PNF
{
    public static class Engine
    {
        private static bool IsPrime(double i)
        {
            for (double j = 2; j < Math.Floor(Math.Sqrt(i)); j++)
            {
                if (i % j == 0)
                {
                    return false;
                }
            }
            return true;
        }
        private static bool IsPrime(double i,IEnumerable<double> checkSet)
        {
            return checkSet.All(j => i % j != 0);
        }

        public static IEnumerable<double> GetUntil(double i)
        {
            HashSet<double> primes = new HashSet<double>() {2 };
            for (double j = 2; j < i; j++)
            {
                if (IsPrime(j,primes))
                {
                    primes.Add(j);
                }
            }
            return primes;
        }

        public static void LogUntil()
        {
            double mIndex = 100;
            double number = 2;
            float index = 0;
            Stopwatch timer = new Stopwatch();
            timer.Start();
            while (true)
            {
                number++;
                if (IsPrime(number))
                {
                    index++;
                    if (index > mIndex)
                    {
                        mIndex = Math.Floor(mIndex * 1.2);
                        Console.WriteLine($"[Time:{timer.Elapsed:g}]/[Index:{index:N}]:{number:N}");
                    }
                }
            }
        }
        public static double[] FilterByPrime(double[] i)
        {
            List<double> _ = new List<double>();
            foreach (double j in i)
            {
                _.Add(j);
            }

            return _.ToArray();
        }
    }
}