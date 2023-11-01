using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDAL.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Category { get; set; }
        public string ProductName { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public decimal NetPrice { get; set; }
        public int Quantity { get; set; }
        public string Tax { get; set; }
        public string ShippingType { get; set; }
        public decimal ShippingCharges { get; set; }
        public decimal TotalAmountCharged { get; set; }
        public DateTime EstimatedDelivery { get; set; }
        public bool ReceiveStatusUpdates { get; set; }
        public bool DeliverySignatureRequired { get; set; }
        public string CustomerName { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        // Add more properties as needed.
    }
}
