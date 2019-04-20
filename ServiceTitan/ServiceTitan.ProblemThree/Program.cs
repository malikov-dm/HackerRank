using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTitan.ProblemThree
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Simple() { I = 5, S = "eqwe" };
            var res = s.Computed;

            Console.WriteLine(res);
            Console.ReadLine();
        }
    }

    class Simple
    {
        public string S { get; set; }
        public int I { get; set; }

        public string Computed => S + I;

    }
}
