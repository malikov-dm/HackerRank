using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            Console.WriteLine("Input array length");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Input array of integers");
            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp));

            s10_basic_statistics.Solve(n, ar);
        }
    }
}
