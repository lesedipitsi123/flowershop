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
                var order = Substitute.For<IOrder, IIdentified>();
                var flower = Substitute.For<IFlower>();
                order.AddFlowers(flower, 1);
                
                // ACT here ====
                order.Deliver();

                // Assertion here ====
                orderDAO.Received().SetDelivered(order);
    
            
        }
    }
}