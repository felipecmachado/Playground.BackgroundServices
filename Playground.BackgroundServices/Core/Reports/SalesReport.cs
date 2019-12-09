using Playground.BackgroundServices.Reports.Analytics;
using Playground.BackgroundServices.Shared.Layouts;
using System;

namespace Playground.BackgroundServices.Core.Reports
{
    public static class SalesReport
    {
        public static void Run(SalesLayout layout)
        {
            WorstSeller.Run(layout);
        }
    }
}
