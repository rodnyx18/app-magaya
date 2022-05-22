using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWebApi.Dto.Requete
{
    public partial class OrderRequete
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public int PaymentId { get; set; }
        public decimal TotalValue { get; set; }
        public virtual ICollection<ProductOrderRequete>? ProductOrders { get; set; }
    }
}
