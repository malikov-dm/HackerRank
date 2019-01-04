using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{

    public static int minimum_index(int[] seq)
    {
        if (seq.Length == 0)
        {
            throw new ArgumentException("Cannot get the minimum value index from an empty sequence");
        }
        int min_idx = 0;
        for (int i = 1; i < seq.Length; ++i)
        {
            if (seq[i] < seq[min_idx])
            {
                min_idx = i;
            }
        }
        return min_idx;
    }

    static class TestDataEmptyArray
    {
        public static int[] get_array()
        {
            return new int[] { };
        }
    }

    static class TestDataUniqueValues
    {
        public static int[] get_array()
        {
            return new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        }

        public static int get_expected_result()
        {
            return 0;
        }
    }

    static class TestDataExactlyTwoDifferentMinimums
    {
        public static int[] get_array()
        {
            return new int[] { 3, 2, 3, 1, 1, 6, 7, 8, 9, 10 };
        }

        public static int get_expected_result()
        {
            return 3;
        }
    }
    public static void TestWithEmptyArray()
    {
        try
        {
            int[] seq = TestDataEmptyArray.get_array();
            int result = minimum_index(seq);
        }
        catch (ArgumentException)
        {
            return;
        }
        throw new InvalidOperationException("Exception wasn't thrown as expected");
    }

    public static void TestWithUniqueValues()
    {
        int[] seq = TestDataUniqueValues.get_array();
        if (seq.Length < 2)
        {
            throw new InvalidOperationException("less than 2 elements in the array");
        }

        int[] tmp = new int[seq.Length];
        for (int i = 0; i < seq.Length; ++i)
        {
            tmp[i] = Convert.ToInt32(seq[i]);
        }
        if (!((new LinkedList<int>(tmp.ToList())).Count() == seq.Length))
        {
            throw new InvalidOperationException("not all values are unique");
        }

        int expected_result = TestDataUniqueValues.get_expected_result();
        int result = minimum_index(seq);
        if (result != expected_result)
        {
            throw new InvalidOperationException("result is different than the expected result");
        }
    }

    public static void TestWithExactlyTwoDifferentMinimums()
    {
        int[] seq = TestDataExactlyTwoDifferentMinimums.get_array();
        if (seq.Length < 2)
        {
            throw new InvalidOperationException("less than 2 elements in the array");
        }

        int[] tmp = (int[])seq.Clone();
        Array.Sort(tmp);
        if (!(tmp[0] == tmp[1] && (tmp.Length == 2 || tmp[1] < tmp[2])))
        {
            throw new InvalidOperationException("there are not exactly two minimums in the array");
        }

        int expected_result = TestDataExactlyTwoDifferentMinimums.get_expected_result();
        int result = minimum_index(seq);
        if (result != expected_result)
        {
            throw new InvalidOperationException("result is different than the expected result");
        }
    }

    public static void Main(String[] args)
    {
        TestWithEmptyArray();
        TestWithUniqueValues();
        TestWithExactlyTwoDifferentMinimums();
        Console.WriteLine("OK");
    }
}