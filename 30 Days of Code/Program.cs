using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{
    static void Main(string[] args)
    {
#if DEBUG
        Console.SetIn(File.OpenText("input.txt"));
        FileStream filestream = new FileStream("output.txt", FileMode.OpenOrCreate);
        var streamwriter = new StreamWriter(filestream);
        streamwriter.AutoFlush = true;
        Console.SetOut(streamwriter);
        Console.SetError(streamwriter);
#endif
        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] nk = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            int maxSum = 0;
            for (int a = 1; a <= n - 1; a++)
            {
                for (int b = a + 1; b <= n; b++)
                {
                    var s = a & b;
                    maxSum = s > maxSum & s < k ? s : maxSum;
                }
            }

            Console.WriteLine(maxSum);
        }
    }
}
