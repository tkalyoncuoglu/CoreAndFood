using CoreAndFood.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.ViewComponents
{
	public class ProductListByCategory : ViewComponent
	{
		private IProductRepository _productRepository;

		public ProductListByCategory(IProductRepository productRepository)
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
