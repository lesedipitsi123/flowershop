using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShop
{
    public interface IOrder
    {
        void Deliver();
        double Price { get; }
        double Profit { get; }
        IOrderDAO OrderDAO { get; }
        IReadOnlyList<IFlower> Ordered { get; }
        void AddFlowers(IFlower flower, int n);
        IClient Client { get; }
    }
}
