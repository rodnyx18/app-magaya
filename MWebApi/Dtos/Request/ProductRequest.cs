using System;
using System.Collections.Generic;

namespace MWebApi.Dtos.Request
{
    public partial class ProductRequest
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public double Weight { get; set; }
    }
}
