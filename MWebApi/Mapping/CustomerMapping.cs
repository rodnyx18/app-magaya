using MWebApi.Entities;
using MWebApi.Dtos.Reponse;
using MWebApi.Dtos.Request;

namespace MWebApi.Mapping
{
    public static class CustomerMapping
    {
        public static CustomerReponse ToCustomerReponse(this Customer entity)
        {
            return new CustomerReponse()
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Phone = entity.Phone,
                Address = entity.Address?.ToAddressReponse(),
                AddressId = entity.AddressId,
                Orders = entity.Orders?.Select(o => o.ToOrderReponse()).ToList()
            };
        }

        public static Customer ToCustomer(this CustomerRequest requete)
        {
            return new Customer()
            {
                Id = requete.Id,
                Name = requete.Name,
                Email = requete.Email,
                Phone = requete.Phone,
                Address = requete.Address.ToAddress(),
                AddressId = requete.AddressId,
            };
        }
    }
}
