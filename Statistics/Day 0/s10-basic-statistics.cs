using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Statistics
{
    class s10_basic_statistics
    {
        public static void Solve()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));

            //Console.WriteLine("Printing s10_basic_statistics challenge solution");
            Console.WriteLine("{0:F1}", CalcMean(n, ar));
            Console.WriteLine("{0:F1}", CalcMedian(n, ar));
            Console.WriteLine("{0}", CalcMode(n, ar));
        }
        static decimal CalcMean(int n, int[] ar)
        {
            decimal res = 0;
            res = Convert.ToDecimal(ar.Sum()) / n;
            return res;
        }
        static decimal CalcMedian(int n, int[] ar)
        {
            decimal res = 1;
            Array.Sort(ar);
            if (n % 2 == 1)
            {
                res = ar[n / 2];
            }
            else
            {
                res = Convert.ToDecimal(ar[n / 2 - 1] + ar[n / 2]) / 2;
            }
            return res;
        }
        static int CalcMode(int n, int[] ar)
        {
            //int res = 2;
            var t = ar.GroupBy(v => v)
                .OrderByDescending(g => g.Count())
                .ThenBy(g => g.Key).First().Key;
                //.SelectMany(g => g);
            //Console.WriteLine(t); //String.Join(" ", t));
            int mode = ar.GroupBy(v => v)
                .OrderByDescending(g => g.Count())
                .ThenBy(g => g.Key)
                .First().Key;
            return mode;
        }
    }

}