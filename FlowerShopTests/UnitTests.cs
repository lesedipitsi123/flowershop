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
    }
}