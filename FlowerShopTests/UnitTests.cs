using NUnit.Framework;
using NSubstitute;
using FlowerShop;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

                // Arrange here ====
                
                var orderDAO = Substitute.For<IOrderDAO>();
                var client = Substitute.For<IClient>();
                var flower = Substitute.For<IFlower>();
                var order = new Order(orderDAO, client);

                // ACT here ====

                order.Deliver();

                // Assertion here ====

                orderDAO.Received().SetDelivered(order);
    
            
        }

        [Test]
        public void Test2()
        {
            // ARRANGE
                var orderDAO = Substitute.For<IOrderDAO>();
                var client = Substitute.For<IClient>();
                var flower = Substitute.For<IFlower>();
                var order = Substitute.For<IOrder, IIdentified>();
                order.AddFlowers(flower, 2);
                var cost = flower.Cost;
                double test_price = cost + (0.2 * cost);

            // ACT 
                var price = order.Price;

            // ASSERTION
                Assert.AreEqual(test_price, price);

        }
    }
}