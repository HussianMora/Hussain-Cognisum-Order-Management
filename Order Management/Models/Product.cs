namespace Order_Management.Models
{
    public class Product
    {
        public string Category { get; set; }
        public string ProductName { get; set; }
        public int SKU { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
    }
}
