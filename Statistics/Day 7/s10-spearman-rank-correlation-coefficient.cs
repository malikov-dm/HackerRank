using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
namespace Statistics
{
    class s10_spearman_rank_correlation_coefficient
    {
        public static void Solve()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            double[] arX = Array.ConvertAll(Console.ReadLine().TrimEnd().Split(' '), arTemp => Double.Parse(arTemp, CultureInfo.InvariantCulture));
            double[] arY = Array.ConvertAll(Console.ReadLine().TrimEnd().Split(' '), arTemp => Double.Parse(arTemp, CultureInfo.InvariantCulture));
            //Console.WriteLine();
            int[] rX = GetRankArray(arX);
            //Console.WriteLine(String.Join(' ', rX));
            int[] rY = GetRankArray(arY);
            //Console.WriteLine(String.Join(' ', rY));

            var darr = rX.Zip(rY, (x, y) => (x - y) * (x - y));

            //Console.WriteLine(String.Join(' ', darr));
            var srcc = 1 - Convert.ToDouble(6 * darr.Sum()) / (n * (n * n - 1));

            Console.WriteLine("{0:F3}", srcc);
        }

        static int[] GetRankArray(double[] ar)
        {
            var res = new int[ar.Length];
            int n = 0;
            foreach (var item in ar.Select((x, i) => new { OldIndex = i, Value = x, NewIndex = -1 })
                                  .OrderBy(x => x.Value)
                                  .Select((x, i) => new { OldIndex = x.OldIndex, Value = x.Value, NewIndex = i + 1 })
                                  .OrderBy(x => x.OldIndex))
            {
                res[n] = item.NewIndex;
                n++;
            }
            return res;
        }
    }
}