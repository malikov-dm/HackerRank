using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Security
{
    class security_bijective_functions
    {
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));

            var grar = ar.GroupBy(e => e);

            string res = ar.Length != grar.Count() ? "NO" : "YES";
            Console.WriteLine(res);

        }
    }
}