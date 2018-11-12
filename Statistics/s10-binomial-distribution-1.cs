using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MathNet.Numerics;
namespace Statistics
{
    class s10_binomial_distribution_1
    {
        public static void Solve()
        {
            double ratio = 1.09d;

            double br = ratio / (1 + ratio);

            double res = 0;

            for (int i = 1; i <= 6; i++)
            {
                for (int j = 1; j <= i & j <= 3; j++)
                {
                    //res += (SpecialFunctions.Factorial(i) / (SpecialFunctions.Factorial(j) * SpecialFunctions.Factorial(i - j))) * Math.Pow(br, j) * Math.Pow(1- br, i - j) ;
                    Console.Write("{0}.{1} ", i, j);

                }
                Console.WriteLine();
            }
            Console.WriteLine(res);
        }
    }

    public class Solution
    {
        public static double BR = 1.09;
        public static double GR = 1;
        static int factorial(int n)
        {
            if (n == 0)
                return 1;
            return n * factorial(n - 1);
        }

        static double combination(int r)
        {
            return (factorial(6) / (factorial(r) * factorial(6 - r)));
        }
        public static void Start()
        {
            double p = (BR) / (BR + GR);
            double q = 1 - p;

            double probability = 0.0;
            for (int i = 6; i >= 3; i--)
            {
                probability += combination(i) * Math.Pow(p, i) * Math.Pow(q, 6 - i);
            }
            Console.WriteLine("{0:F3}", probability);
        }
    }
}