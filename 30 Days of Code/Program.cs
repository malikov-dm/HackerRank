using System;
using System.Linq;

class Difference
{
    private int[] elements;
    public int maximumDifference;

    internal int elemntsLen
    {
        get
        {
            if (elements == null)
                return 0;
            return elements.Length;
        }
    }

    public Difference(int[] arr)
    {
        this.elements = arr;
    }

    internal void computeDifference()
    {
        int res = 0;
        for (int i = 0; i < elemntsLen - 1; i++)
        {
            for (int j = i + 1; j < elemntsLen; j++)
            {
                var cdiff = Math.Abs(elements[i] - elements[j]);
                res = res > cdiff ? res : cdiff;
            }
        }
        maximumDifference = res;
    }

    // Add your code here

} // End of Difference Class

class Solution
{
    static void Main(string[] args)
    {
        Convert.ToInt32(Console.ReadLine());

        int[] a = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

        Difference d = new Difference(a);

        d.computeDifference();

        Console.Write(d.maximumDifference);
    }
}