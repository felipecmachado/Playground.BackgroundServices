namespace Playground.BackgroundServices.Shared.Models
{
    public class Customer
    {
        public Customer(string cnpj, string name, string businessArea)
        {
            this.CNPJ = cnpj;
            this.Name = name;
            this.BusinessArea = businessArea;
        }

        public Customer(string[] data) : this(data[1], data[2], data[3]) { }

        public string CNPJ { get; set; }

        public string Name { get; set; }

        public string BusinessArea { get; set; }
    }
}
