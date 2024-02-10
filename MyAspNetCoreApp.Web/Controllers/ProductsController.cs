using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class ProductsController : Controller
    {

        private AppDbContext _context;  
        private readonly ProductRepository _productRepository;

        public ProductsController(AppDbContext context)
        {
            _productRepository = new ProductRepository();
            _context = context;

            if (!_context.Products.Any())
            {
                _context.Products.Add(new Product() { Name = "Kalem1", Price = 100, Stock = 100,Color="Red",Width=20,Height=10 });
                _context.Products.Add(new Product() { Name = "Kalem2", Price = 200, Stock = 200, Color = "Blue", Width = 20, Height = 10 });
                _context.Products.Add(new Product() {Name = "Kalem3", Price = 300, Stock = 300, Color = "Yellow", Width = 20, Height = 10 });
                _context.SaveChanges();
            }
        }
        public IActionResult Index()
        {
            var products = _context.Products.ToList();

            return View(products);
        }

        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add() 
        {
            return View();  
        }
        [HttpPost]
        public IActionResult Add(string Name, decimal Price, int Stok, string Color, int Width, int Height)
        {
            //1.yöntem

            //var name = HttpContext.Request.Form["Name"].ToString();
            //var price = decimal.Parse( HttpContext.Request.Form["Price"].ToString());
            //var stock =int.Parse( HttpContext.Request.Form["Stock"].ToString());
            //var color = HttpContext.Request.Form["Color"].ToString();
            //var width =int.Parse( HttpContext.Request.Form["Width"].ToString());
            //var height =int.Parse( HttpContext.Request.Form["Height"].ToString());

            Product newProduct = new Product()
            {
                Name= Name,
                Price= Price,    
                Stock= Stok,    
                Color= Color,
                Width= Width,
                Height= Height
            };

            _context.Products.Add(newProduct);
            _context.SaveChanges();
            TempData["status"] = "Ürün Başarı bir şekilde Eklendi!!";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id) 
        {
            var product = _context.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            TempData["status"] = "Ürün Başarı bir şekilde güncellendi!!";
            return RedirectToAction("Index");
        }
    }
}
