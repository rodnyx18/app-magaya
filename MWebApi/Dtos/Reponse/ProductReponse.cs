using System;
using System.Collections.Generic;

namespace MWebApi.Dtos.Reponse
{
    public partial class ProductReponse
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public double Weight { get; set; }
    }
}
