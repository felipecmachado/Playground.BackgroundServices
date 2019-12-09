using Playground.BackgroundServices.Shared.Models;
using System.Collections.Generic;
using System.IO;

namespace Playground.BackgroundServices.Shared.Layouts
{
    public class SalesLayout : LayoutBase
    {
        public SalesLayout()
        {
            this.Separator = 'ç';

            this.Sellers = new List<Seller>();

            this.Customers = new List<Customer>();

            this.Sales = new List<Sale>();
        }

        public IList<Seller> Sellers { get; private set; }

        public IList<Customer> Customers { get; private set; }

        public IList<Sale> Sales { get; private set; }

        public void Parse(FileInfo file)
        {
            using (var fileStream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
            using (StreamReader reader = new StreamReader(fileStream))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    var arr = line.Split(this.Separator);

                    switch (arr[0])
                    {
                        case "001":
                            this.Sellers.Add(new Seller(arr));
                            break;

                        case "002":
                            this.Customers.Add(new Customer(arr));
                            break;

                        case "003":
                            this.Sales.Add(new Sale(arr));
                            break;

                        // Line not expected - Skip it instead of throw an exception;
                        default:
                            continue;
                    }
                }
            }
        }
    }
}
