namespace Playground.BackgroundServices.Shared.Models
{
    public class Seller
    {
        public Seller(string[] data)
        {
            this.CPF = data[1];
            this.Name = data[2];
            this.Salary = decimal.Parse(data[3]);
        }

        public string CPF { get; set; }

        public string Name { get; set; }

        public decimal Salary { get; set; }
    }
}
