using System;
using System.Collections.Generic;

namespace ViewModels
{
    public class OrderViewModel
    {
        public Guid UserId { get; set; }

        public string Address { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }

        public ICollection<OrderDetailViewModel> OrderDetails { get; set; }
    }
}
