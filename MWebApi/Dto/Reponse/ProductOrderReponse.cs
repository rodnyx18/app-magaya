using System;
using System.Collections.Generic;

namespace MWebApi.Dto.Reponse
{
    public partial class ProductOrderReponse
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
    }
}
