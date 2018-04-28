using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task1KodiSoft.Models
{
    public class Order
    {
        public int Id { get; set; }
        public double TipsAmount { get; set; }
        public double TotalPrice { get; set; }
        public virtual State State { get; set; }
        public bool ForOne { get; set; }
        public DateTime OpenedDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public bool isCash { get; set; }
        
        public virtual List<OrderItemOrder> Items { get; set; }
        public Order()
        {
            Items = new List<OrderItemOrder>();

        }
    }
}
