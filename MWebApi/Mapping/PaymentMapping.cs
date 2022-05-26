using MWebApi.Entities;
using MWebApi.Dtos.Reponse;
using MWebApi.Dtos.Request;

namespace MWebApi.Mapping
{
    public static class PaymentMapping
    {
        public static PaymentTypeReponse ToPaymentTypeReponse(this Payment entity)
        {
            return new PaymentTypeReponse()
            {
                Id = entity.Id,
                Type = entity.Type
            };
        }

        public static Payment ToPaymentTypeReponse(this PaymentTypeRequest requete)
        {
            return new Payment()
            {
                Id = requete.Id,
                Type = requete.Type
            };
        }
    }
}
