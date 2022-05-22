using System;
using System.Collections.Generic;

namespace MWebApi.Dto.Requete
{
    public partial class ProductOrderRequete
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
    }
}
