using CoreAndFood.Data.Models;
using System.Linq;

namespace CoreAndFood.Repository
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(CoreAndFoodContext context) : base(context) { }
        internal object TDelete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
