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

        var t1s = Console.ReadLine();
        var t2s = Console.ReadLine();
        DateTime dt1 = TryParseDate(t1s);
        DateTime dt2 = TryParseDate(t2s);

        if (dt1 < dt2 || (dt1 - dt2).TotalDays == 0)
        {
            Console.WriteLine(0);
        }
        else
        {
            if (dt1.Month == dt2.Month && dt1.Year == dt2.Year)
            {
                Console.WriteLine((dt1 - dt2).TotalDays * 15);
            }
            else if (dt1.Year == dt2.Year)
            {
                Console.WriteLine((dt1.Month - dt2.Month) * 500);
            }
            else
            {
                Console.WriteLine(10000);
            }
        }


    }

    static DateTime TryParseDate(string s)
    {

        int[] ar = Array.ConvertAll(s.Split(' '), t => Convert.ToInt32(t));
        var dt = new DateTime(ar[2], ar[1], ar[0]);
        return dt;
    }
}