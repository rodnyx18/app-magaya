using MWebApi.Entities;
using MWebApi.Dtos.Reponse;
using MWebApi.Dtos.Request;

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

        public static Product ToProduct(this ProductRequest requete)
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
