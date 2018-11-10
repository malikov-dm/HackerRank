
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Statistics
{
    class s10_quartiles
    {
        public static void Solve()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));

            var q2 = GetMedian(ar);

            var hl = n / 2;

            var flar = ar.Take(hl).ToArray();
            var q1 = GetMedian(flar);
            
            
            var slar = ar.Skip(hl + n % 2).Take(hl).ToArray();
            var q3 = GetMedian(slar);
            //Console.WriteLine(String.Join(" ", slar));


            Console.WriteLine("{0:F0}", q1);
            Console.WriteLine("{0:F0}", q2);
            Console.WriteLine("{0:F0}", q3);
        }

        public static int GetMedian(int[] ar)
        {
            int res = 0;
            var n = ar.Length;
            Array.Sort(ar);
            if (n % 2 == 1)
            {
                res = ar[n / 2];
            }
            else
            {
                res = (ar[n / 2 - 1] + ar[n / 2]) / 2;
            }

            return res;
        }
    }
}