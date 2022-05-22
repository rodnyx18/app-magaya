using MWebApi.Entities;
using MWebApi.Dto.Reponse;
using MWebApi.Dto.Requete;

namespace MWebApi.Mapping
{
    public static class ProductMapping
    {
        public static ProductReponse ToProductReponse(this Product entity)
        {
            return new ProductReponse()
            {
                Id = entity.Id,
                Description = entity.Description,
                Price = entity.Price,
                Weight = entity.Weight
            };
        }

        public static Product ToProduct(this ProductRequete requete)
        {
            return new Product()
            {
                Id = requete.Id,
                Description = requete.Description,
                Price = requete.Price,
                Weight = requete.Weight
            };
        }
    }
}
