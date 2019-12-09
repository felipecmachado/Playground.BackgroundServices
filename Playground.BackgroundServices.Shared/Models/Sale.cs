﻿using System;
using System.Collections.Generic;

namespace Playground.BackgroundServices.Shared.Models
{
    public class Sale
    {
        private readonly char ITEM_SEPARATOR = ',';
        private readonly char INTERNAL_ITEM_SEPARATOR = '-';

        public Sale(string[] data)
        {
            this.ID = Int32.Parse(data[1]);
            this.Parse(data[2]);
            this.SellerName = data[3];
        }

        public int ID { get; set; }

        public IList<Item> Items { get; set; }

        public string SellerName { get; set; }

        private void Parse(string data)
        {
            this.Items = new List<Item>();

            var records = data.Substring(1, data.Length-2).Split(ITEM_SEPARATOR);

            foreach (var record in records)
            {
                this.Items.Add(new Item(record.Split(INTERNAL_ITEM_SEPARATOR)));
            }
        }
    }
}
