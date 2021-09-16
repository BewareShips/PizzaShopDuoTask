using System;
using System.Collections.Generic;

#nullable disable

namespace PizzasShopDuoTask
{
    public partial class Pizza
    {
        public Pizza()
        {
            Orderdetails = new HashSet<Orderdetail>();
        }

        public int PizzaNumber { get; set; }
        public string PizzaName { get; set; }
        public int? Price { get; set; }
        public string PizzaType { get; set; }

        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
    }
}
