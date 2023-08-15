using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using PNF;

while (true)
{
    Console.WriteLine("[1]-Log Until\n[2]-Write Until\n[3]-Is Prime");
    switch (Console.ReadKey().Key)
    {
        case ConsoleKey.D1:
        {
            Console.Clear();
            Engine.LogUntil();
            break;
        }
        case ConsoleKey.D2:
        {
            Console.Clear();
            Console.Write("Path:");
            Engine.FileCont(Console.ReadLine());
            break;
        }
        case ConsoleKey.D3:
        {
            Console.Clear();
            Console.Write("Number:");
            Console.WriteLine(Engine.IsPrime(double.Parse(Console.ReadLine())));
            break;
        }
        default:
        {
            Console.Write("Error:(Value Not Found)");
            break;
        }
    }
}

namespace PNF
{
    public static class Engine
    {
        public static bool IsPrime(double i)
        {
            if (i == 2){return true;}
            for (double j = 2; j < Math.Ceiling(Math.Sqrt(i)) + 1; j++)
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
            return checkSet.Any(j => i % j != 0);
        }

        public static IEnumerable<double> GetUntil(double i)
        {
            HashSet<double> primes = new HashSet<double>(){ 2 };
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
                if (IsPrime(number))
                {
                    index++;
                    if (index > mIndex)
                    {
                        mIndex = Math.Floor(mIndex * 1.01);
                        Console.WriteLine($"[Time:{timer.Elapsed:g}]/[Index:{index:N}]:{number:N}");
                    }
                }
                number++;
            }
        }

        public static void FileCont(string path)
        {
            if (File.Exists(path))
            {
                string[] _ = File.ReadAllText(path).Split(',');
                string[] __ = _[_.Length-1].Split(':');
                WriteUntil(double.Parse(__[0]),float.Parse(__[1]),path);
            }
            else
            {
                WriteUntil(2,0,path);
            }
        }
        private static void WriteUntil(double n,float i,string path)
        {
            double number = n;
            float index = i;
            while (true)
            {
                if (IsPrime(number))
                {
                    index++;
                    File.AppendAllText(path,$"{index}:{number},");
                }
                number++;
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