using MWebApi.Entities;
using MWebApi.Dto.Reponse;
using MWebApi.Dto.Requete;

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

        public static Payment ToPaymentTypeReponse(this PaymentTypeRequete requete)
        {
            return new Payment()
            {
                Id = requete.Id,
                Type = requete.Type
            };
        }
    }
}
