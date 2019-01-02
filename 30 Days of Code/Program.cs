using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
#if DEBUG
        Console.SetIn(File.OpenText("input.txt"));
#endif

        var t = Convert.ToInt32(Console.ReadLine());

        while (t-- > 0)
        {
            var n = Convert.ToInt32(Console.ReadLine());
            var res = CheckPrime(n);
            Console.WriteLine(res);
        }
    }

    static string CheckPrime(int n)
    {
        if (n == 2)
        {
            return "Prime";
        }
        else if (n == 1 || n % 2 == 0)
        {
            return "Not prime";
        }
        

        for (int i = 3; i <= Math.Sqrt(n); i += 2)
        {
            if (n % i == 0)
            {
                return "Not prime";
            }
        }

        return "Prime";
    }
}

