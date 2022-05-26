using System;
using System.Collections.Generic;

namespace MWebApi.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int AddressId { get; set; }

        public Address? Address { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
