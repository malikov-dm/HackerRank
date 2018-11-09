using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Statistics
{
    class s10_basic_statistics
    {
        public static void Solve(int n, int[] ar){
            Console.WriteLine("Printing s10_basic_statistics challenge solution");
            Console.WriteLine("{0:n1}", CalcMean(n, ar));
            Console.WriteLine("{0:n1}", CalcMedian(n, ar));
            Console.WriteLine("{0:n1}", CalcMode(n, ar));
        }
        static decimal CalcMean(int n, int[] ar){
            decimal res = 0;
            res = ar.Sum() / n;
            return res;
        }
        static decimal CalcMedian(int n, int[] ar){
            decimal res = 1;
            Array.Sort(ar);
            if(n % 2 == 1){
                res = ar[n / 2];
            } else {
                res = (ar[n / 2 - 1] + ar[n / 2]) / 2;
            }
            return res; 
        }
        static decimal CalcMode(int n, int[] ar){
            decimal res = 2;
            return res;
        }
    }

}