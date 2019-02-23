using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShop
{
    public class Order : IOrder, IIdentified
    {
        private List<IFlower> flowers;
        private bool isDelivered = false;

        public IOrderDAO OrderDAO { get; }

        public int Id { get; }

        // should apply a 20% mark-up to each flower.
        public double Price {
            get {
              
                double total_cost=0;
                for(int i=0; i< flowers.Count; i++)
                {
                    total_cost+= flowers[i].Cost;
                }

                return total_cost + (0.2 * total_cost);
            }
        }

        public double Profit {
            get {
                return 0;
            }
        }

        public IReadOnlyList<IFlower> Ordered {
            get {
                return flowers.AsReadOnly();
            }
        }

        public IClient Client { get; private set; }

        public Order(IOrderDAO dao, IClient client)
        {
            OrderDAO=dao;
            Id = OrderDAO.AddOrder(client);
        }

        // used when we already have an order with an Id.
        public Order(IOrderDAO dao, IClient client, bool isDelivered = false)
        {
            this.flowers = new List<IFlower>();
            this.isDelivered = isDelivered;
            OrderDAO=dao;
            Client = client;
            Id = OrderDAO.AddOrder(client);
        }

        public void AddFlowers(IFlower flower, int stock)
        {
          
          for(int i =0; i< stock; i++)
          {
              flowers.Add(flower);
          }

        }

        public void Deliver()
        {
            OrderDAO.SetDelivered(this);
        }
    }
}
