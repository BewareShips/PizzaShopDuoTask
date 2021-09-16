using System;
using System.Collections.Generic;

#nullable disable

namespace PizzasShopDuoTask
{
    public partial class UsersDetail
    {
        public UsersDetail()
        {
            Orders = new HashSet<Order>();
        }

        public string UserEmail { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
