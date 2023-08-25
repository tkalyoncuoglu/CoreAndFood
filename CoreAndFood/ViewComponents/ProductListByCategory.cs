using CoreAndFood.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.ViewComponents
{
	public class ProductListByCategory : ViewComponent
	{
		private ProductRepository _productRepository;

		public ProductListByCategory(ProductRepository productRepository)
		{
			_productRepository = productRepository;
		}
		public IViewComponentResult Invoke(int id)
		{
			var foodlist = _productRepository.Get(x=>x.CategoryId == id);
			return View(foodlist);
		}
	}
}
