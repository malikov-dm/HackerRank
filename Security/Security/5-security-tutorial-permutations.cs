//security-tutorial-permutations
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Security
{
    class security_tutorial_permutations
    {
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));

            var res = Permutate(n, ar);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(res[i]);
            }

        }

        static int[] Permutate(int n, int[] ar)
        {
            int[] res = new int[n];
            for (var i = 0; i < n; i++)
            {
                res[i] = ar[ar[i] - 1];
            }
            return res;
        }

    }
}