using Playground.BackgroundServices.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Playground.BackgroundServices.Shared.Layouts
{
    public class SalesLayout : LayoutBase
    {
        public SalesLayout()
        {
            this.Separator = "Ç";

            this.Sellers = new List<Seller>();

            this.Customers = new List<Customer>();

            this.Sales = new List<Sale>();
        }

        public IList<Seller> Sellers { get; private set; }

        public IList<Customer> Customers { get; private set; }

        public IList<Sale> Sales { get; private set; }

    }
}
