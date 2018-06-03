using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Task1KodiSoft.Data;

namespace Task1KodiSoft.Models
{
    public static class SampleData
    {
        private static Random random = new Random();
        public static void Initialize(ApplicationDbContext context)
        {
            context.Orders.RemoveRange(context.Orders);
            context.OrderItems.RemoveRange(context.OrderItems);
            context.OrderItemOrders.RemoveRange(context.OrderItemOrders);
            context.SaveChanges();

            InitializeOrderItems(context);
            InitializeOrders(context);
        }
        private static void InitializeOrderItems(ApplicationDbContext context)
        {
            foreach (string path in Directory.GetFiles("wwwroot\\images\\Orders"))
            {
                context.OrderItems.Add(
                    new OrderItem
                    {
                        Media = path.Replace("wwwroot\\images", ""),
                        Name = Path.GetFileNameWithoutExtension(path),
                        Price = random.NextDouble() * 100
                    }
                );
            }
            context.SaveChanges();
        }
        private static void InitializeOrders(ApplicationDbContext context)
        {
            DateTime now = DateTime.Now;
            List<OrderItem> orderItems = context.OrderItems.ToList();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < random.Next(5); j++)
                {
                    Order order = new Order
                    {
                        ClosedDate = now.AddDays(-i),
                        isCash = random.Next(1) <1 ,
                        TipsAmount = random.NextDouble() * 10
                    };
                    for (int k = 0; k < random.Next(10); k++)
                    {
                        OrderItemOrder orderItemOrder = new OrderItemOrder
                        {
                            OrderItem = orderItems[random.Next(orderItems.Count)],
                            Order = order
                        };
                        orderItemOrder.CurrentPrice = orderItemOrder.OrderItem.Price;
                        order.Items.Add(orderItemOrder);
                    }
                    order.TotalPrice = order.Items.Sum(oio => oio.CurrentPrice);
                    context.Orders.Add(order);
                }
            }
            context.SaveChanges();
        }
    }
}
