using NUnit.Framework;
using Playground.BackgroundServices.Reports.Analytics;
using Playground.BackgroundServices.Shared.Layouts;
using Playground.BackgroundServices.Shared.Models;

namespace Playground.BackgroundServices.Tests
{
    public class AnalyticsTests
    {
        private SalesLayout mock;

        [SetUp]
        public void Setup()
        {
            this.mock = new SalesLayout();

            this.mock.Customers.Add(new Customer("000", "Customer1", "Industrial"));
            this.mock.Customers.Add(new Customer("001", "Customer2", "Rural"));
            this.mock.Customers.Add(new Customer("002", "Customer3", "Industrial"));
            this.mock.Customers.Add(new Customer("003", "Customer4", "Industrial"));

            this.mock.Sellers.Add(new Seller("001", "Seller1", 1600.5m));
            this.mock.Sellers.Add(new Seller("002", "Seller2", 3500));
            this.mock.Sellers.Add(new Seller("003", "Seller3", 1310.75m));

            var sale1 = new Sale(1, "Seller1");
            var sale2 = new Sale(2, "Seller2");
            var sale3 = new Sale(3, "Seller3");

            sale1.Items.Add(new Item(1, 100, 1.5f));
            sale2.Items.Add(new Item(2, 50, 1.5f));
            sale3.Items.Add(new Item(3, 1000, 1.5f));

            this.mock.Sales.Add(sale1);
            this.mock.Sales.Add(sale2);
            this.mock.Sales.Add(sale3);        
        }

        [Test]
        public void WorstSellerIsOk()
        {
            var expected = "Seller2";

            var response = WorstSeller.Run(mock);

            Assert.AreEqual(expected, response.Seller);
        }

        [Test]
        public void SellersCounterIsOk()
        {
            var expected = 3;

            var response = SellersCounter.Run(mock);

            Assert.AreEqual(expected, response);
        }

        [Test]
        public void CustomersCountIsOk()
        {
            var expected = 4;

            var response = CustomersCount.Run(mock);

            Assert.AreEqual(expected, response);
        }

        [Test]
        public void MostExpensiveSaleIsOk()
        {
            var expected = 1500.0;

            var response = MostExpensiveSale.Run(mock);

            Assert.AreEqual(expected, response.Value);
        }
    }
}