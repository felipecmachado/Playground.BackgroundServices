using Playground.BackgroundServices.Shared.Layouts;
using System;
using System.Linq;

namespace Playground.BackgroundServices.Reports.Analytics
{
    public static class MostExpensiveSale
    {
        public static string Run(SalesLayout data)
        {
            if (data == null)
                throw new ArgumentNullException();

            var response = data.Sales
                .ToDictionary
                (
                    k => k.ID,
                    v => v.Items.Sum(s => s.Price * s.Quantity)
                ).OrderByDescending(x => x.Value)
                .FirstOrDefault();

            return $"MostExpensiveSale: ID {response.Key} - Sold {response.Value}";
        }
    }
}
