using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWebApi.Entities
{
    public partial class Order
    {
        public Order()
        {
            ProductOrders = new HashSet<ProductOrder>();
        }

        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public int PaymentId { get; set; }

        [NotMapped]
        public decimal TotalValue { get; set; }

        public Customer? Customer { get; set; } = null!;
        public Payment? Payment { get; set; } = null!;
        public ICollection<ProductOrder>? ProductOrders { get; set; }

        public void CalculateTotalValue()
        {
            if (ProductOrders == null)
            {
                return;
            }

            decimal totalValue = 0;

            foreach (var item in ProductOrders)
            {
                totalValue += item.Product!.Price * item.Quantity;
            }

            TotalValue = totalValue;
        }
    }
}
