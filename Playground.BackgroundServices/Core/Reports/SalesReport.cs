using Playground.BackgroundServices.Reports.Analytics;
using Playground.BackgroundServices.Shared.Layouts;
using System.IO;

namespace Playground.BackgroundServices.Core.Reports
{
    public class SalesReport
    {
        private string DATA_OUT = "data/out";

        public SalesReport()
        {
            if (!Directory.Exists(DATA_OUT))
                Directory.CreateDirectory(DATA_OUT);
        }

        public void Run(SalesLayout layout)
        {
            var path = $"{DATA_OUT}\\Output{layout.FileName}.txt";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (StreamWriter stream = File.CreateText(path))
            {
                stream.WriteLine(CustomersCount.Run(layout));
                stream.WriteLine(SellersCounter.Run(layout));
                stream.WriteLine(MostExpensiveSale.Run(layout));
                stream.WriteLine(WorstSeller.Run(layout));
            }
        }
    }
}
