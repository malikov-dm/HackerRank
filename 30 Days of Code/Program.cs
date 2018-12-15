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
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string strOdd = string.Empty;
            string strEven = string.Empty;
            string input = Console.ReadLine();
            for (int j = 0; j < input.Length; j++)
            {
                var t = j % 2 == 0 ? strEven += input[j] : strOdd += input[j];

            }
            Console.WriteLine($"{strEven} {strOdd}");

        }
    }
}
