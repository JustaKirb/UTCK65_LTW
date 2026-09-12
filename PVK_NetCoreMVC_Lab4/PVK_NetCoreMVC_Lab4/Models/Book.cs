using Microsoft.AspNetCore.Mvc.Rendering;

namespace PVK_NetCoreMVC_Lab4.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Summary { get; set; }

        public List<Book> GetBookList()
        {
            List<Book> list = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "Chí Phèo",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/products/b1.jpg",
                    Price = 500000,
                    Summary = "",
                    TotalPage = 250
                },
                 new Book()
                 {
                    Id = 2,
                    Title = "Lão Hạc",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/products/b2.jpg",
                    Price = 500000,
                    Summary = "",
                    TotalPage = 250
                 },
                 new Book()
                 {
                    Id = 3,
                    Title = "Conan Phiêu lưu ký",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/products/b3.jpg",
                    Price = 500000,
                    Summary = "",
                    TotalPage = 250
                 },
                 new Book()
                 {
                    Id = 4,
                    Title = "Đường Xưa Mây Trắng",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/products/b4.jpg",
                    Price = 500000,
                    Summary = "",
                    TotalPage = 250
                 }
            };
            return list;
        }

        public Book GetBookById(int id)
        {
            Book book = this.GetBookList().FirstOrDefault(x => x.Id == id);
            return book;
        }

        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value ="1 ",Text="Nam cao"},
            new SelectListItem {Value ="2 ",Text="Ngô Tất Tố"},
            new SelectListItem {Value ="3 ",Text="Adamkhoom"},
            new SelectListItem {Value ="4 ",Text="Thiền sư Thích Nhất Hạnh"}
        };

        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value ="1 ",Text="Truyện tranh"},
            new SelectListItem {Value ="2 ",Text="Văn học đương đại"},
            new SelectListItem {Value ="3 ",Text="Phật học phổ thông"},
            new SelectListItem {Value ="4 ",Text="Truyện cười"}
        };

    }
}
