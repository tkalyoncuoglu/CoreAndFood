using CoreAndFood.Data.Models;
using CoreAndFood.DTOs;
using CoreAndFood.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace CoreAndFood.Controllers
{
    public class ProductController : Controller
    {
        private ProductRepository _productRepository;

        private CategoryRepository _categoryRepository;

        public ProductController(ProductRepository productRepository, CategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;   
        }

        public IActionResult Index(int page=1)
        {  
            return View(_productRepository.Get("Category").ToPagedList(page, 3));
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<SelectListItem> values = (from x in _categoryRepository.Get()
                                           select new SelectListItem
                                           {
                                                Text = x.Name,
                                                Value = x.Id.ToString(),
                                           }).ToList();
            ViewBag.v1 = values;
            return View();
        }

        [HttpPost]
        public IActionResult Add(urunekle p)
        {
            Product f = new Product();
            if(p != null)
            {
                var extension = Path.GetExtension(p.ImageURL.FileName);
                var newimagename = Guid.NewGuid() + extension;  
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/resimler", newimagename);

                var stream = new FileStream(location, FileMode.Create);
                p.ImageURL.CopyTo(stream);
                f.ImageURL = "/resimler/" + newimagename;
            }
            f.Name= p.Name;
            f.Price = p.Price;
            f.Stock = p.Stock;
            f.CategoryId = p.CategoryId;
            f.Description = p.Description;
            _productRepository.Add(f);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
          
            _productRepository.Delete(new Product { Id = id });
            return RedirectToAction("Index");   
        }

        public IActionResult Get(int id)
        {
            var values = _productRepository.Get(id);

            List<SelectListItem> value = (from y in _categoryRepository.Get()
                                           select new SelectListItem
                                           {
                                               Text = y.Name,
                                               Value = y.Id.ToString(),
                                           }).ToList();
            ViewBag.v1 = value;

            Product food = new Product()
            {
                Id = values.Id,
                CategoryId = values.CategoryId,
                Name = values.Name, 
                Price = values.Price,   
                Stock = values.Stock,
                Description = values.Description,
                ImageURL    = values.ImageURL
            };

            return View(food);
        }
        [HttpPost]
        public IActionResult Update(Product p)
        {
            var values = _productRepository.Get(p.Id);
            values.Name = p.Name;
            values.Stock    = p.Stock;
            values.Price    = p.Price;
            values.ImageURL = p.ImageURL;
            values.Description = p.Description;
            values.Id = p.Id;

            _productRepository.Update(values);
            return RedirectToAction("Index");  
        }
    }
}
