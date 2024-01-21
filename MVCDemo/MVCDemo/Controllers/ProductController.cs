using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MVCDemo.Models.Product;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace MVCDemo.Controllers
{
    public class ProductController : Controller
    {
        private readonly IEnumerable<ProductViewModel> products = new List<ProductViewModel>()
        {
           new ProductViewModel()
           { Id = 1,
               Name = "Cheese",
               Price = 7.00M
           },
           new ProductViewModel()
           { Id = 2,
               Name = "Ham",
               Price = 5.50M
           },
           new ProductViewModel()
           { Id = 3,
               Name = "Bread",
               Price = 1.50M
           }
        };

        public IActionResult Index()
        {
            return View();
        }

        [ActionName("My-Product")]
        public IActionResult GetAll(string keyword)
        {
            if (products.Any(p => p.Name.ToLower() == keyword.ToLower()))
            {
                var product = products
                .Where(p => p.Name.ToLower().Contains(keyword.ToLower()));
                return View(product);
            }
            return View(products);
        }

        public IActionResult Get(int id)
        {
            if (products.Any(p => p.Id == id))
            {
                var product = products.FirstOrDefault(p => p.Id == id);
                return View(product);
            }
            return BadRequest();
        }

        public IActionResult AllAsJason() 
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            return Json(products, options);
        }

        public IActionResult AllAsText()
        {
            var plainText = new StringBuilder();
            foreach (var product in products)
            {
                plainText.AppendLine($"Product {product.Id}: {product.Name} - {product.Price} lv.");
            }
            return Content(plainText.ToString(), "text/plain");
        }

        public IActionResult AllAsTextFile()
        {
            var plainText = new StringBuilder();
            foreach (var product in products)
            {
                plainText.AppendLine($"Product {product.Id}: {product.Name} - {product.Price} lv.");
            }

            byte[] fileContents = Encoding.UTF8.GetBytes(plainText.ToString());

            return File(fileContents, "text/plain", "Products.txt");
        }
    }
}
