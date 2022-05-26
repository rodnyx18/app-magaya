using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWebApi.Dtos.Request
{
    public partial class OrderRequest
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public int PaymentId { get; set; }
        public decimal TotalValue { get; set; }
        public virtual ICollection<ProductOrderRequest>? ProductOrders { get; set; }
    }
}
