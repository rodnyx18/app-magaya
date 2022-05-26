using System;
using System.Collections.Generic;

namespace MWebApi.Dtos.Reponse
{
    public partial class ProductOrderReponse
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
    }
}
