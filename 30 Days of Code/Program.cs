using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
public interface AdvancedArithmetic{
    int divisorSum(int n);
}
public class Calculator : AdvancedArithmetic
{
    public int divisorSum(int n)
    {
        var res = 0;
        for(int i = 1; i <= n / 2; i++)
        {
            if(n % i == 0)
            {
                res += i;
            }
        }

        res += n;
        return res;
    }
}

class Solution
{
    static void Main(String[] args)
    {
#if DEBUG
            Console.SetIn(File.OpenText("input.txt"));
#endif

        int n = Int32.Parse(Console.ReadLine());
      	AdvancedArithmetic myCalculator = new Calculator();
        int sum = myCalculator.divisorSum(n);
        Console.WriteLine("I implemented: AdvancedArithmetic\n" + sum); 
    }
}

