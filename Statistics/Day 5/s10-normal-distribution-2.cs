using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MathNet.Numerics;

namespace Statistics
{
    class s10_normal_distribution_2
    {
        public static void Solve()
        {
            double mu = 70d;
            double sigma = 10d;

            double v1 = 80d;
            double v2 = 60d;


            Console.WriteLine("{0:F2}", (1 - normal(v1, mu, sigma)) * 100);
            Console.WriteLine("{0:F2}", (1 - normal(v2, mu, sigma)) * 100);
            Console.WriteLine("{0:F2}", normal(v2, mu, sigma) * 100);
        }

        private static double normal(double x, double mu, double sigma)
        {
            return 0.5 * (1 + Erf((x - mu) / (sigma * Math.Sqrt(2))));
        }


        static double Erf(double x)
        {
            // constants
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;

            // Save the sign of x
            int sign = 1;
            if (x < 0)
                sign = -1;
            x = Math.Abs(x);

            // A&S formula 7.1.26
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

            return sign * y;
        }
    }

}