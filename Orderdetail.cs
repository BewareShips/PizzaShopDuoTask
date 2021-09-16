using System;
using System.Collections.Generic;

#nullable disable

namespace PizzasShopDuoTask
{
    public partial class Orderdetail
    {
        public int ItemNumber { get; set; }
        public int? OrderId { get; set; }
        public int? PizzaNumber { get; set; }

        public virtual Order Order { get; set; }
        public virtual Pizza PizzaNumberNavigation { get; set; }
    }
}
