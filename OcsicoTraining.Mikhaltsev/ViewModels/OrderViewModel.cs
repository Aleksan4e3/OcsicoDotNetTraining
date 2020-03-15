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

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Комментарий")]
        public string Comment { get; set; }

        [Display(Name = "Время доставки")]
        public DateTime Date { get; set; }

        [Display(Name = "Статус заказа")]
        public OrderStatus Status { get; set; }

        [Display(Name = "Итоговая цена")]
        public double FinalPrice { get; set; }

        public virtual UserViewModel User { get; set; }
        public ICollection<OrderDetailViewModel> OrderDetails { get; set; }
    }
}
