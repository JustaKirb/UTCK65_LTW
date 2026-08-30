namespace IT1_PVK_03.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public string ProductType { get; set; }
        public string Images { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime Posted { get; set; }

    }
}
