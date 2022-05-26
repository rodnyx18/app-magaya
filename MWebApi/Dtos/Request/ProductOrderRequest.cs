using System;
using System.Collections.Generic;

namespace MWebApi.Dtos.Request
{
    public partial class ProductOrderRequest
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
    }
}
