using MWebApi.Entities;
using MWebApi.Dtos.Reponse;
using MWebApi.Dtos.Request;

namespace MWebApi.Mapping
{
    public static class OrderMapping
    {
        public static OrderReponse ToOrderReponse(this Order entity)
        {
            return new OrderReponse()
            {
                Id = entity.Id,
                Number = entity.Number,
                Date = entity.Date,
                CustomerId = entity.CustomerId,
                PaymentId = entity.PaymentId,
                TotalValue = entity.TotalValue,
                //Customer = entity.Customer?.ToCustomerReponse(),
                Payment = entity.Payment?.ToPaymentTypeReponse(),
                ProductOrders = entity.ProductOrders?.Select(po => po.ToProductOrderReponse()).ToList()
            };
        }

        public static Order ToOrder(this OrderRequest requete)
        {
            return new Order()
            {
                Id = requete.Id,
                Number = requete.Number,
                Date = requete.Date,
                CustomerId = requete.CustomerId,
                PaymentId = requete.PaymentId,
                TotalValue = requete.TotalValue,
                ProductOrders = requete.ProductOrders?.Select(po => po.ToProductOrder()).ToList()
            };
        }
    }
}
