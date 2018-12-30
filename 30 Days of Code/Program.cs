using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    static void Main(String[] args)
    {
#if DEBUG
        Console.SetIn(File.OpenText("input.txt"));
#endif
        int n = Convert.ToInt32(Console.ReadLine());
        string[] a_temp = Console.ReadLine().Split(' ');
        int[] a = Array.ConvertAll(a_temp, Int32.Parse);

        int numSwaps = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (a[i] > a[j])
                {
                    var t = a[i];
                    a[i] = a[j];
                    a[j] = t;
                    numSwaps++;
                }
            }
        }
        int firstElement = a[0];
        int lastElement = a[n - 1];

        Console.WriteLine($"Array is sorted in {numSwaps} swaps.");
        Console.WriteLine($"First Element: {firstElement}");
        Console.WriteLine($"Last Element: {lastElement}");
    }
}

