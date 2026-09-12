using Microsoft.AspNetCore.Mvc;
using PVK_NetCoreMVC_Lab4.Models;

namespace PVK_NetCoreMVC_Lab4.ViewComponents
{
    public class BookViewComponent:ViewComponent
    {
        protected Book book = new Book();
        public IViewComponentResult Invoke()
        {
            var books = book.GetBookList();
            return View(books);
        }
    }
}
