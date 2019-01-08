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
#endif

        int N = Convert.ToInt32(Console.ReadLine());

        string pattern = "[a-z]@gmail.com";

        var list = new List<String>();

        for (int NItr = 0; NItr < N; NItr++)
        {
            string[] firstNameEmailID = Console.ReadLine().Split(' ');

            string firstName = firstNameEmailID[0];

            string emailID = firstNameEmailID[1];

            Match m = Regex.Match(emailID, pattern, RegexOptions.IgnoreCase);
            if (m.Success)
            {
               list.Add(firstName);
            }
        }

        list.Sort();

        foreach(var str in list)
            Console.WriteLine(str);
    }
}
