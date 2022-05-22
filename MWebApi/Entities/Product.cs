using System;
using System.Collections.Generic;

namespace MWebApi.Entities
{
    public partial class Product
    {
        public Product()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }

        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public double Weight { get; set; }

        public virtual ICollection<ProductOrder>? ProductOrders { get; set; }
    }
}
