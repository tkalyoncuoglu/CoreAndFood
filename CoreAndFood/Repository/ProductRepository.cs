using CoreAndFood.Data.Models;

namespace CoreAndFood.Repository
{
    public class ProductRepository: GenericRepository<Product>
    {
        public ProductRepository(CoreAndFoodContext context) : base(context) { }
    }
}
