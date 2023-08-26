using CoreAndFood.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.ViewComponents
{
	public class CategoryGetList : ViewComponent
	{
		private ICategoryRepository _categoryRepository;

		public CategoryGetList(ICategoryRepository categoryRepository)
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
