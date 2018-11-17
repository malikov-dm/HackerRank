using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MathNet.Numerics;
namespace Statistics
{
    class s10_geometric_distribution_2
    {
        public static void Solve()
        {

            double p = (double) 1 / 3;
            //Console.WriteLine(p);
            int n = 5;
            double res = 0;
            for(int i = 1; i <= n; i++)
            {
                res += GeomDist(i, p);
            }
            Console.WriteLine("{0:F3}", res);
        }


        static double GeomDist(int n, double p)
        {
            double res = 0;
            res = p * Math.Pow(1 - p, n - 1);
            return res;
        }
    }

}