namespace Playground.BackgroundServices.Shared.Models
{
    public class Customer
    {
        public Customer(string[] data)
        {
            this.CNPJ = data[1];
            this.Name = data[2];
            this.BusinessArea = data[3];
        }

        public string CNPJ { get; set; }

        public string Name { get; set; }

        public string BusinessArea { get; set; }
    }
}
