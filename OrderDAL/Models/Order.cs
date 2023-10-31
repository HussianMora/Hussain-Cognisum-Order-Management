using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDAL.Models
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

}
