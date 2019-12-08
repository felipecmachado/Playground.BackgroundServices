using Playground.BackgroundServices.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Playground.BackgroundServices.Shared.Layouts
{
    public class DataLayout : LayoutBase
    {
        public DataLayout()
        {
            this.Separator = "Ç";

            this.Pattern = "*.txt";

            this.Sellers = new List<Seller>();

            this.Clients = new List<Client>();

            this.Sales = new List<Sale>();
        }

        public IList<Seller> Sellers { get; private set; }

        public IList<Client> Clients { get; private set; }

        public IList<Sale> Sales { get; private set; }

    }
}
