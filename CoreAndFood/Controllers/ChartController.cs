using CoreAndFood.Data.Models;
using CoreAndFood.DTOs;
using CoreAndFood.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


namespace CoreAndFood.Controllers
{
    [AllowAnonymous]

    public class ChartController : Controller
    {
        private ProductRepository _productRepository;

        private CategoryRepository _categoryRepository;
        public ChartController(ProductRepository productRepository, CategoryRepository categoryRepository) 
        { 
            _productRepository = productRepository;

            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var products = _productRepository.Get().Select(x =>
            new ProductDto
            {
                Name = x.Name,
                Stock = x.Stock,
            }).ToList();
           
            ViewData["data"] = JsonSerializer.Serialize(products);
            ViewData["chartTitle"] = "Ürün - Stok Grafiği";
            ViewData["chartType"] = "PieChart";


            return View("index");
        }
  
        public IActionResult Index2()
        {
            var products = _productRepository.Get().Select(x =>
            new ProductDto
            {
                Name = x.Name,
                Stock = x.Stock,
            }).ToList();

            ViewData["data"] = JsonSerializer.Serialize(products);
            ViewData["chartTitle"] = "Ürün - Stok Grafiği";
            ViewData["chartType"] = "ColumnChart";

            return View("index");
        }

        

        public IActionResult Statistics()
        {
            
            var deger1 = _productRepository.Get().Count();
            ViewBag.d1 = deger1;

            var deger2 = _categoryRepository.Get().Count();
            ViewBag.d2 = deger2;

            var fruitCategory = _categoryRepository.Get(x => x.Name == "Fruit").FirstOrDefault();
            var fruitCount = _productRepository.Get(x => x.CategoryId == (fruitCategory != null ? fruitCategory.Id : -1) ).Count();
            ViewBag.d3 = fruitCount;

            var vegetableCategory = _categoryRepository.Get(x => x.Name == "Vegetables").FirstOrDefault();
            var vegetableCount = _productRepository.Get(x => x.CategoryId == (vegetableCategory != null ? vegetableCategory.Id : -1)).Count();
            ViewBag.d4 = vegetableCount;

            var foodCategory = _categoryRepository.Get(x => x.Name == "Food").FirstOrDefault();
            var foodSum = _productRepository.Get(x => x.CategoryId == (foodCategory != null ? foodCategory.Id : -1)).Sum(x => x.Stock);
            ViewBag.d5 = foodSum;
            /*
            var deger6 = _context.Foods.Where(x => x.Id == _context.Categories.Where(y => y.Name == "Legumes").Select(z => z.Id).FirstOrDefault()).Count();
            ViewBag.d6 = deger6;

            var deger7 = _context.Foods.OrderByDescending(x=>x.Stock).Select(y=>y.FoodName).FirstOrDefault();
            ViewBag.d7 = deger7;

            var deger8 = _context.Foods.OrderBy(x=>x.Stock).Select(z=>z.FoodName).FirstOrDefault();
            ViewBag.d8 = deger8;
            
            var deger9 = _context.Foods.Average(x => x.Price).ToString("0.00");
            ViewBag.d9 = deger9;    

            var deger10 = _context.Categories.Where(x=>x.Name=="Fruit").Select(y=>y.Id).FirstOrDefault();
            var deger10p = _context.Foods.Where(y => y.Id == deger10).Sum(x => x.Stock);
            ViewBag.d10 = deger10p;

            var deger11 = _context.Categories.Where(x => x.Name == "Vegetables").Select(y => y.Id).FirstOrDefault();
            var deger11p = _context.Foods.Where(y => y.Id == deger11).Sum(x => x.Stock);
            ViewBag.d11 = deger11p;

            var deger12 = _context.Foods.OrderByDescending(x => x.Price).Select(y => y.FoodName).FirstOrDefault();
            ViewBag.d12 = deger12;
            */
            return View();
        }
    }
}
