using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EntityModels.Enums;

namespace ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Comment")]
        public string Comment { get; set; }

        [Display(Name = "DeliveryTime")]
        public DateTime Date { get; set; }

        [Display(Name = "OrderStatus")]
        public OrderStatus Status { get; set; }

        [Display(Name = "FinalPrice")]
        public double FinalPrice { get; set; }

        public virtual UserViewModel User { get; set; }
        public ICollection<OrderDetailViewModel> OrderDetails { get; set; }
    }
}
