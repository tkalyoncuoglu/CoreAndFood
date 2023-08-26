using CoreAndFood.Data.Models;

namespace CoreAndFood.Repository
{
    public class ProductRepository: GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(CoreAndFoodContext context) : base(context) { }
    }
}
