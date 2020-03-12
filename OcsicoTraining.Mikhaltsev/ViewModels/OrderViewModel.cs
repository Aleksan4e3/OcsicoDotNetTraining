using System;
using System.Collections.Generic;
using EntityModels.Enums;

namespace ViewModels
{
    public class OrderViewModel
    {
        public Guid UserId { get; set; }

        public string Address { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
        public double FinalPrice { get; set; }

        public ICollection<OrderDetailViewModel> OrderDetails { get; set; }
    }
}
