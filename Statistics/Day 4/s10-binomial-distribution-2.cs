using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MathNet.Numerics;
namespace Statistics
{
    class s10_binomial_distribution_2
    {
        public static void Solve()
        {

            double p = 0.12d;

            double res = 0;

            for (int i = 0; i <= 2; i++)
            {
                res += Binomial(i, 10, p);
            }
            Console.WriteLine("{0:F3}", res);

            res = 0;
            for (int i = 2; i <= 10; i++)
            {
                res += Binomial(i, 10, p);
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