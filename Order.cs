using System;
using System.Collections.Generic;

#nullable disable

namespace PizzasShopDuoTask
{
    public partial class Order
    {
        public Order()
        {
            Orderdetails = new HashSet<Orderdetail>();
        }

        public int OrderId { get; set; }
        public string UsersId { get; set; }
        public double? Total { get; set; }
        public int? DeliveryCharge { get; set; }
        public string Status { get; set; }

        public virtual UsersDetail Users { get; set; }
        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
    }
}
