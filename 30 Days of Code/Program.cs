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
        int currentCons = 0;
        int maxCons = 0;
        while (n > 0)
        {
            var reminder = n % 2;
            if (reminder > 0)
            {
                currentCons++;
                if (currentCons > maxCons)
                {
                    maxCons = currentCons;
                }
            }
            else
            {
                currentCons = 0;
            }

            n /= 2;
        }
        Console.WriteLine(maxCons);
    }
}
