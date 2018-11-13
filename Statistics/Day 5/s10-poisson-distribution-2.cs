using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MathNet.Numerics;
namespace Statistics
{
    class s10_poisson_distribution_2
    {
        public static void Solve()
        {

            double estX = 0.88d;
            double estY = 1.55d;

            Console.WriteLine("{0:F3}", 160 + 40 * (estX + Math.Pow(estX, 2)));
            Console.WriteLine("{0:F3}", 128 + 40 * (estY + Math.Pow(estY, 2)));
        }

    }

}