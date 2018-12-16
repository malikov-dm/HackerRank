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
        IDictionary<string, string> dic = new Dictionary<string, string>();
        IList<string> list = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string[] arr = Console.ReadLine().Split(' ');
            dic.Add(arr[0], arr[1]);
        }
        for (int i = 0; i < n; i++)
        {
            var str = Console.ReadLine();
            if(dic.ContainsKey(str)){
                Console.WriteLine($"{str}={dic[str]}");
            }else{
                Console.WriteLine("Not Found");
            }
        }
    }
}
