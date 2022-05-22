using MWebApi.Entities;
using MWebApi.Dto.Reponse;
using MWebApi.Dto.Requete;

namespace MWebApi.Mapping
{
    public static class AddressMapping
    {
        public static AddressReponse ToAddressReponse(this Address entity)
        {
            return new AddressReponse()
            {
                Id = entity.Id,
                Number = entity.Number,
                Street = entity.Street,
                City = entity.City,
                ZipCode = entity.ZipCode,
                State = entity.State,
                Country = entity.Country
            };
        }

        public static Address ToAddress(this AddressRequete requete)
        {
            return new Address()
            {
                Id = requete.Id,
                Number = requete.Number,
                Street = requete.Street,
                City = requete.City,
                ZipCode = requete.ZipCode,
                State = requete.State,
                Country = requete.Country
            };
        }
    }
}
