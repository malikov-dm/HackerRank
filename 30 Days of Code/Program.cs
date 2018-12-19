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
        int[][] arr = new int[6][];

        for (int i = 0; i < 6; i++)
        {
            arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        }

        int maxSum = Int32.MinValue, currSum = 0;

        int x0 = 0, y0 = 0;


        bool flag = true;

        while (flag)
        {
            
            if (x0 + 2 < 6)
            {
                //Console.WriteLine($"{arr[y0][x0]} {arr[y0][x0 + 1]} {arr[y0][x0 + 2]}");
                //Console.WriteLine($"  {arr[y0 + 1][x0 + 1]}  ");
                //Console.WriteLine($"{arr[y0 + 2][x0]} {arr[y0 + 2][x0 + 1]} {arr[y0 + 2][x0 + 2]}");
                currSum = arr[y0][x0] + arr[y0][x0 + 1] + arr[y0][x0 + 2] + arr[y0 + 1][x0 + 1] + arr[y0 + 2][x0] + arr[y0 + 2][x0 + 1] + arr[y0 + 2][x0 + 2];
                //Console.WriteLine();
                //Console.WriteLine(currSum);
                //Console.WriteLine();
                maxSum = currSum > maxSum ? currSum : maxSum;
                x0++;
            }
            else
            {
                x0 = 0;
                y0++;
            }

            //Console.WriteLine($"x0 = {x0}, y0 = {y0}");


            if (y0 + 2 >= 6) flag = false;


        }

        Console.WriteLine(maxSum);

        /* for (int x = 0; x < 6; x++)
        {
            for (int y = 0; y < 6; y++)
            {
                Console.Write($"{arr[x][y]} ");
            }

            Console.WriteLine();
        } */

    }
}
