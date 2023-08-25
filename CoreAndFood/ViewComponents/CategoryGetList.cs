using CoreAndFood.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.ViewComponents
{
	public class CategoryGetList : ViewComponent
	{
		private CategoryRepository _categoryRepository;

		public CategoryGetList(CategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}
		public IViewComponentResult Invoke()
		{
			var categorylist = _categoryRepository.Get();
			return View(categorylist);	
		}
	}
}
