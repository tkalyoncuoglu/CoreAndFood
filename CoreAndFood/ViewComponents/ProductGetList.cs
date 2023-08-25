using CoreAndFood.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.ViewComponents
{
    public class ProductGetList : ViewComponent
    {
        private ProductRepository _productRepository;

        public ProductGetList(ProductRepository productRepository)
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
