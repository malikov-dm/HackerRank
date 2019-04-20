namespace Solution
{
    using System;
    using System.Threading;
    using System.Linq;
    using System.Linq.Expressions;

    internal class BestQuarterResults
    {
        public decimal SoldItems { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal RevenuePerItem { get; set; }

        public bool Equals(BestQuarterResults other)
        {
            return SoldItems == other.SoldItems
                && TotalRevenue == other.TotalRevenue
                && RevenuePerItem == other.RevenuePerItem;
        }
    }

    internal static class TradeStats
    {
        private static readonly decimal[] SalesDb = { 1000m, 2043m, 926m, 1520m };
        private static readonly decimal[] RevenueDb = { 10000m, 20430m, 9260m, 15200m };

        public static decimal SoldItems(int quarter)
        {
            Thread.Sleep(100);
            return SalesDb[quarter - 1];
        }

        public static decimal TotalRevenue(int quarter)
        {
            Thread.Sleep(100);
            return RevenueDb[quarter - 1];
        }
    }

    static partial class Program
    {
        // the revenue analysis expression
        private static readonly Expression<Func<BestQuarterResults>> Calculate = () => new BestQuarterResults
        {
            SoldItems = new[] {
                TradeStats.SoldItems(1), TradeStats.SoldItems(2), TradeStats.SoldItems(3), TradeStats.SoldItems(4)
            }.Max(),
            TotalRevenue = new[] {
                TradeStats.TotalRevenue(1), TradeStats.TotalRevenue(2),
                TradeStats.TotalRevenue(3), TradeStats.TotalRevenue(4)
            }.Max(),
            RevenuePerItem = new[] {
                TradeStats.TotalRevenue(1) / TradeStats.SoldItems(1),
                TradeStats.TotalRevenue(2) / TradeStats.SoldItems(2),
                TradeStats.TotalRevenue(3) / TradeStats.SoldItems(3),
                TradeStats.TotalRevenue(4) / TradeStats.SoldItems(4)
            }.Max()
        };
    }
}

namespace Solution
{
    using System;
    using System.Threading;
    using System.Linq;
    using System.Linq.Expressions;

    static partial class Program
    {
        private static Expression<Func<BestQuarterResults>> Optimize(Expression<Func<BestQuarterResults>> expression)
        {
            // Implement this method
            throw new NotImplementedException();
            // return expression;
        }
    }
}

namespace Solution
{
    using System;
    using System.Diagnostics;

    static partial class Program
    {
        static void Main(string[] args)
        {
            var rawCalculate = Calculate.Compile();
            var timer = new Stopwatch();
            timer.Start();
            var rawResult = rawCalculate.Invoke();
            timer.Stop();
            var rawDuration = timer.Elapsed;
            timer.Reset();

            var optimizedCalculate = Optimize(Calculate).Compile();
            timer.Start();
            var optimizedResult = optimizedCalculate.Invoke();
            timer.Stop();
            var optimizedDuration = timer.Elapsed;

            if (rawResult.Equals(optimizedResult)
                && optimizedDuration.Add(TimeSpan.FromMilliseconds(500)) < rawDuration)
            {
                Console.WriteLine("Test passed.");
                return;
            }
            Console.WriteLine("Test failed.");
        }
    }
}