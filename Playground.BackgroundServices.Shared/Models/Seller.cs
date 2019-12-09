namespace Playground.BackgroundServices.Shared.Models
{
    public class Seller
    {
        public Seller(string cpf, string name, decimal salary)
        {
            this.CPF = cpf;
            this.Name = name;
            this.Salary = salary;
        }

        public Seller(string[] data) : this(data[1], data[2], decimal.Parse(data[3])) { }

        public string CPF { get; set; }

        public string Name { get; set; }

        public decimal Salary { get; set; }
    }
}
