using CoreAndFood.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.ViewComponents
{
    public class ProductGetList : ViewComponent
    {
        private IProductRepository _productRepository;

        public ProductGetList(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IViewComponentResult Invoke()
        {
            var foodlist = _productRepository.Get();
            return View(foodlist);
        }
    }
}
