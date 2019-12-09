using Playground.BackgroundServices.Shared.Layouts;
using System;
using System.Linq;

namespace Playground.BackgroundServices.Reports.Analytics
{
    public static class WorstSeller
    {
        public static string Run(SalesLayout data)
        {
            if (data == null)
                throw new ArgumentNullException();

            var worst = data.Sales
                .GroupBy(x => x.SellerName)
                .ToDictionary
                (
                    k => k.Key,
                    v => v.Sum(d => d.Items.Sum(s => s.Price * s.Quantity))
                ).OrderByDescending(x => x.Value).FirstOrDefault();

            return $"WorstSaller: {worst.Key} - Sold {worst.Value}";
        }
    }
}
