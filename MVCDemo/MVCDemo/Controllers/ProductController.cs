using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models.Product;

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

        public IActionResult All()
        {
            return View(products);
        }
    }
}
