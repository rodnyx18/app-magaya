using System;
using System.Collections.Generic;

namespace MWebApi.Entities
{
    public partial class Payment
    {
        public Payment()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Type { get; set; } = null!;

        public virtual ICollection<Order>? Orders { get; set; }
    }
}
