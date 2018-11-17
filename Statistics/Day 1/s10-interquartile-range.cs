
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Statistics
{
    class s10_interquartile_range
    {
        public static void Solve()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));
            int[] weigth = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));

            var slen = weigth.Sum();

            int[] s = new int[slen];

            var offset = 0;
            for(int i = 0; i < n; i++)
            {
                offset += i > 0 ? weigth[i - 1] : 0; 
                for(int j = 0; j < weigth[i]; j++)
                {
                    s[offset + j] = ar[i];
                }
                
            }
            
            Array.Sort(s);

            var hl = s.Length / 2;

            var flar = s.Take(hl).ToArray();
            var q1 = GetMedian(flar);
            
            
            var slar = s.Skip(hl + n % 2).Take(hl).ToArray();
            var q3 = GetMedian(slar);

            decimal res = q3 - q1;

            Console.WriteLine("{0:F1}", res);

        }

        public static decimal GetMedian(int[] ar)
        {
            decimal res = 0;
            var n = ar.Length;
            Array.Sort(ar);
            if (n % 2 == 1)
            {
                res = Convert.ToDecimal(ar[n / 2]);
            }
            else
            {
                res = Convert.ToDecimal(ar[n / 2 - 1] + ar[n / 2]) / 2;
            }

            return res;
        }
    }
}