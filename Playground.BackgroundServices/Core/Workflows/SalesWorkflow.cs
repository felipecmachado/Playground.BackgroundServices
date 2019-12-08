using Playground.BackgroundServices.Services;
using Playground.BackgroundServices.Shared.Layouts;
using Playground.BackgroundServices.Shared.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Playground.BackgroundServices.Core
{
    public class SalesWorkflow : WorkflowBase
    {
        public SalesWorkflow(FileInfo file) : base(file) { }

        public override void Execute()
        {
            // Step 1: Parse file
            var layout = BuildLayout();

            // Step 2: Generate reports
            var report = SalesReport.Run(layout);
        }

        private SalesLayout BuildLayout()
        {
            var layout = new SalesLayout();

            using var fileStream = new FileStream(this.FileInfo.FullName, FileMode.Open, FileAccess.Read);
            using StreamReader reader = new StreamReader(fileStream);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();

                var arr = line.Split(layout.Separator);

                switch (arr[0])
                {
                    case "001":
                        layout.Sellers.Add(new Seller(arr));
                        break;

                    case "002":
                        layout.Customers.Add(new Customer(arr));
                        break;

                    case "003":
                        layout.Sales.Add(new Sale(arr));
                        break;

                    // Line not expected - Skip it instead of throw an exception;
                    default:
                        continue;
                }

            }

            return layout;
        }
    }
}
