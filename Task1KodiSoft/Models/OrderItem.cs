using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1KodiSoft.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Media { get; set; }

        public virtual List<OrderItemOrder> Items { get; set; }

        public OrderItem()
        {
            Items = new List<OrderItemOrder>();
        }
    }
}
