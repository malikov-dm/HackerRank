using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MathNet.Numerics;
namespace Statistics
{
    class s10_poisson_distribution_1
    {
        public static void Solve()
        {

            double lambda = 2.5d;
            int k = 5;

            double res = PoissonDist(k, lambda);
            
            Console.WriteLine("{0:F3}", res);
        }


        static double PoissonDist(int k, double lambda)
        {
            double res = 0;
            res = Math.Pow(lambda, k) * Math.Pow(Math.E, -lambda) / Fctrl(k);
            return res;
        }

        static long Fctrl(int n)
        {
            if (n == 0)
                return 1;
            return n * Fctrl(n - 1);
        }
    }

}