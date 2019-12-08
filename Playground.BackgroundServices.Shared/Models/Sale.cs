using System;
using System.Collections.Generic;

namespace Playground.BackgroundServices.Shared.Models
{
    public class Sale
    {
        public int ID { get; set; }

        public IEnumerable<Item> Items { get; set; }

        public string SellerName { get; set; }
    }
}
