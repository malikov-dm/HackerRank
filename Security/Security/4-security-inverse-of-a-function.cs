//security-inverse-of-a-function
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Security
{
    class security_inverse_of_a_function
    {
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));

            int[] res = InverseFn(n, ar);
            
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(res[i]);
            }

        }

        static int[] InverseFn(int n, int[] ar)
        {
            var list = new Dictionary<int, int>();
            for (int i = 1; i < n + 1; i++)
            {
                list.Add(i, ar[i - 1]);
            }

            return list.OrderBy(x => x.Value).Select(p => p.Key).ToArray();//.ToArray();
        }
    }
}