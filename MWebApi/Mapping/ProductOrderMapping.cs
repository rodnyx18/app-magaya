using MWebApi.Entities;
using MWebApi.Dtos.Reponse;
using MWebApi.Dtos.Request;

namespace MWebApi.Mapping
{
    public static class ProductOrderMapping
    {
        public static ProductOrderReponse ToProductOrderReponse(this ProductOrder entity)
        {
            return new ProductOrderReponse()
            {
                ProductId = entity.ProductId,
                OrderId = entity.OrderId,
                Quantity = entity.Quantity
            };
        }

        public static ProductOrder ToProductOrder(this ProductOrderRequest requete)
        {
            return new ProductOrder(requete.ProductId, requete.OrderId, requete.Quantity);
        }
    }
}
