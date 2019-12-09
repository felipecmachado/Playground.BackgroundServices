using System;

namespace Playground.BackgroundServices.Shared.Models
{
    public class Item
    {
        public Item(string[] data)
        {
            this.Id = Int32.Parse(data[0]);
            this.Quantity = Int32.Parse(data[1]);
            this.Price = float.Parse(data[2]);
        }

        public int Id { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }
    }
}
