using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Statistics
{
    class s10_standard_deviation
    {
        public static void Solve()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));

            var mean = Convert.ToDouble(ar.Sum()) / n;

            var sqdist = new double[n];
            for(int i = 0; i < n; i++)
            {
                sqdist[i] = Math.Pow(ar[i] - mean, 2);
            }
            var res = Math.Sqrt(sqdist.Sum() / n);
            Console.WriteLine("{0:F1}", res);
        }
    }
}