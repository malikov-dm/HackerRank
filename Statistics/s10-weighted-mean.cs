using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Statistics
{
    class s10_weighted_mean
    {
        public static void Solve(){
            int n = Convert.ToInt32(Console.ReadLine());
            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));
            int[] weigth = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));

            int[] res = new int[n];
            for(int i = 0; i < n; i++){
                res[i] = ar[i]*weigth[i];
            }
            Console.WriteLine("{0:F1}", Convert.ToDecimal(res.Sum()) / weigth.Sum());

        }
    }
}