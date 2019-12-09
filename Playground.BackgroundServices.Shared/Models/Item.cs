using System;

namespace Playground.BackgroundServices.Shared.Models
{
    public class Item
    {
        public Item(int id, int quantity, float price)
        {
            this.Id = id;
            this.Quantity = quantity;
            this.Price = price;
        }

        public Item(string[] data) : this(Int32.Parse(data[0]), Int32.Parse(data[1]), float.Parse(data[2])) { }
  
        public int Id { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }
    }
}
