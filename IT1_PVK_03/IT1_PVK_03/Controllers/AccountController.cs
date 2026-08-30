using IT1_PVK_03.Models;
using Microsoft.AspNetCore.Mvc;

namespace IT1_PVK_03.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            List<Account> accounts = new List<Account>()
            {
                new Account()
                {
                    Id=1,Name="Hoàng Anh",
                    Email="anh@gmail.com",
                    Phone="0986456789",
                    Address="Hà Nội",
                    Avatar=Url.Content("~/Avatar/01.png"),
                    Gender=1,Bio="My name is small",
                    Birthday=new DateTime(1998,7,15)
                },
                new Account()
                {
                    Id=2,Name="Trường Giang",
                    Email="giang@gmail.com",
                    Phone="0986456789",
                    Address="Hà Nội",
                    Avatar=Url.Content("~/Avatar/02.png"),
                    Gender=1,Bio="My name is small",
                    Birthday=new DateTime(1998,7,15)
                },
                new Account()
                {
                    Id=3,Name="Hoàng Thúy",
                    Email="thuy@gmail.com",
                    Phone="0986456789",
                    Address="Hà Nội",
                    Avatar=Url.Content("~/Avatar/03.png"),
                    Gender=1,Bio="My name is small",
                    Birthday=new DateTime(1998,7,15)
                }
            };
            ViewBag.Accounts = accounts;
            return View();
        }
        [Route("ho-so-cua-toi",Name ="profile")]
        public IActionResult Profile(int id)
        {
            List<Account> accounts = new List<Account>()
            {
                new Account()
                {
                    Id=1,Name="Hoàng Anh",
                    Email="anh@gmail.com",
                    Phone="0986456789",
                    Address="Hà Nội",
                    Avatar=Url.Content("~/Avatar/01.png"),
                    Gender=1,Bio="My name is small",
                    Birthday=new DateTime(1998,7,15)
                },
                new Account()
                {
                    Id=2,Name="Trường Giang",
                    Email="giang@gmail.com",
                    Phone="0986456789",
                    Address="Hà Nội",
                    Avatar=Url.Content("~/Avatar/02.png"),
                    Gender=1,Bio="My name is small",
                    Birthday=new DateTime(1998,7,15)
                },
                new Account()
                {
                    Id=3,Name="Hoàng Thúy",
                    Email="thuy@gmail.com",
                    Phone="0986456789",
                    Address="Hà Nội",
                    Avatar=Url.Content("~/Avatar/03.png"),
                    Gender=1,Bio="My name is small",
                    Birthday=new DateTime(1998,7,15)
                }
            };
            Account account = accounts.FirstOrDefault(ac => ac.Id ==id);
            ViewBag.Account = account;
            return View();
        }
    }
}
