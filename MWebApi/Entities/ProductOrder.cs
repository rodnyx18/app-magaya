using System;
using System.Collections.Generic;

namespace MWebApi.Entities
{
    public partial class ProductOrder
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }

        public ProductOrder(int productId, int orderId, int quantity)
        {
            this.ProductId = productId;
            this.OrderId = orderId;
            this.Quantity = quantity;
        }

        //public virtual Order Order { get; set; } = null!;
        public virtual Product? Product { get; set; } = null!;

        public ProductOrder DeepCopy()
        {
            return new ProductOrder(ProductId, OrderId, Quantity);
        }
    }
}
