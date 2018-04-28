using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1KodiSoft.Models
{
    public class OrderItemOrder
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public OrderItem OrderItem { get; set; }
        public double CurrentPrice { get; set; }
    }
}
