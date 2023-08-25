using CoreAndFood.Data.Models;
using CoreAndFood.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
    public class CategoriesController : Controller
    {
        private CategoryRepository _categoryRepository;
        //[Authorize]

        public CategoriesController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
       
        public IActionResult Index(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View(_categoryRepository.Get(x=>x.Name == p));
            }
           return View(_categoryRepository.Get());
        }

        [HttpGet]
        public IActionResult CategoriesAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoriesAdd(Category p)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoriesAdd");
            }
            _categoryRepository.Add(p);
            return RedirectToAction("Index");
        }

        public IActionResult CategoriesGet(int id)
        {
            var values = _categoryRepository.Get(id);
            Category category = new Category()
            {
                Name = values.Name,
                Description = values.Description,   
                Id = values.Id      
            };
            return View(category);
        }

        [HttpPost]
        public IActionResult CategoriesUpdate(Category p)
        {
            var x = _categoryRepository.Get(p.Id);
            x.Name = p.Name;
            x.Description = p.Description;
            x.Status = true;
            _categoryRepository.Update(x);
            return RedirectToAction("Index");
        }

        public IActionResult CategoriesDelete(int id)
        {
            var x = _categoryRepository.Get(id);
            x.Status = false;
            _categoryRepository.Update(x);

            return RedirectToAction("Index");
        }
    }
}
