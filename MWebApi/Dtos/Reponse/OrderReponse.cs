using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWebApi.Dtos.Reponse
{
    public partial class OrderReponse
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public int PaymentId { get; set; }
        public decimal TotalValue { get; set; }
        public CustomerReponse? Customer { get; set; } = null!;
        public PaymentTypeReponse? Payment { get; set; } = null!;
        public virtual ICollection<ProductOrderReponse>? ProductOrders { get; set; }
    }
}
