namespace Order_Management.Models
{
    public class OrderList
    {
        public int OrderId { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public string ShippingType { get; set; }
        public decimal TotalAmount { get; set; }
        public string CustomerName { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
    }
    public class OrderListViewModel
    {
        public List<OrderList> Orders { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public string SortColumn { get; set; }
        public bool SortAscending { get; set; }
    }

}
