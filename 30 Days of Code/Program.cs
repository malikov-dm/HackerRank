using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

internal class Calculator
{
    internal int power(int p, int n)
    {
        if (p < 0 || n < 0)
        {
            throw new Exception("n and p should be non-negative");
        }
        return (int)Math.Pow(p, n);
    }
}

//Write your code here

class Solution
{
    static void Main(String[] args)
    {
        Calculator myCalculator = new Calculator();
        int T = Int32.Parse(Console.ReadLine());
        while (T-- > 0)
        {
            string[] num = Console.ReadLine().Split();
            int n = int.Parse(num[0]);
            int p = int.Parse(num[1]);
            try
            {
                int ans = myCalculator.power(n, p);
                Console.WriteLine(ans);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }



    }
}

