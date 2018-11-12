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
            double br = 1.09d;

            double gr = 1d;

            double p = br / (br + gr);

            double res = 0;
            string str = string.Empty;
            for (int i = 3; i <= 6; i++)
            {
                res += Binomial(i, 6, p);
            }
            Console.WriteLine("{0:F3}", res);
        }
        static long Fctrl(int n)
        {
            if (n == 0)
                return 1;
            return n * Fctrl(n - 1);
        }

        static long Combination(int n, int x)
        {
            return Fctrl(n) / (Fctrl(x) * Fctrl(n - x));
        }

        static double Binomial(int x, int n, double p)
        {
            double res = 0;
            res = Combination(n, x) * Math.Pow(p, x) * Math.Pow(1 - p, n - x);
            return res;
        }
    }

}