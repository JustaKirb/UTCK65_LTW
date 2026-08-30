using IT1_PVK_03.Models;
using Microsoft.AspNetCore.Mvc;

namespace IT1_PVK_03.Controllers
{
    public class PVKProductController : Controller
    {
        [Route("/products", Name = "Index")]
        public IActionResult Index(string ProductType = "")
        {
            List<Product> tempProducts = new List<Product>()
            {
                new Product()
                {
                    Id = 1,ProductName="Iphone 13",
                    Price=50000,Discount=0.3,
                    ProductType="Phone",
                    Images=Url.Content("~/product/01.webp"),
                    Description="Đây là 1 dòng mô tả",
                    Status=1,
                    Posted=new DateTime(2026,12,15,12,0,0)
                },
                new Product()
                {
                    Id = 2,ProductName="Túi xách",
                    Price=50000,Discount=0.3,
                    ProductType="Handbag",
                    Images=Url.Content("~/product/02.webp"),
                    Description="Đây là 1 dòng mô tả",
                    Status=1,
                    Posted=new DateTime(2026,12,15,12,0,0)
                },
                new Product()
                {
                    Id = 1,ProductName="Iphone 13",
                    Price=50000,Discount=0.3,
                    ProductType="Clothing",
                    Images=Url.Content("~/product/03.webp"),
                    Description="Đây là 1 dòng mô tả",
                    Status=1,
                    Posted=new DateTime(2026,12,15,12,0,0)
                }
            };
            List<Product> product = tempProducts.FindAll(p => p.ProductType.Contains(ProductType));
            ViewBag.Products = product;
            return View();
        }
        [Route("chi-tiet-san-pham", Name = "Detail")]
        public IActionResult Detail(int id)
        {
            List<Product> tempProducts = new List<Product>()
            {
                new Product()
                {
                    Id = 1,ProductName="Iphone 13",
                    Price=50000,Discount=0.3,
                    ProductType="Phone",
                    Images=Url.Content("~/product/01.webp"),
                    Description="Đây là 1 dòng mô tả",
                    Status=1,
                    Posted=new DateTime(2026,12,15,12,0,0)
                },
                new Product()
                {
                    Id = 2,ProductName="Túi xách",
                    Price=50000,Discount=0.3,
                    ProductType="Handbag",
                    Images=Url.Content("~/product/02.webp"),
                    Description="Đây là 1 dòng mô tả",
                    Status=1,
                    Posted=new DateTime(2026,12,15,12,0,0)
                },
                new Product()
                {
                    Id = 3,ProductName="Iphone 13",
                    Price=50000,Discount=0.3,
                    ProductType="Clothing",
                    Images=Url.Content("~/product/03.webp"),
                    Description="Đây là 1 dòng mô tả",
                    Status=1,
                    Posted=new DateTime(2026,12,15,12,0,0)
                }
            };
            Product product = tempProducts.Find(p => p.Id == id);
            ViewBag.Product = product;
            return View();
        }
    }
}
