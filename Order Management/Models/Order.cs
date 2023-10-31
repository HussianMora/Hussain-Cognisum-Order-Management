namespace Order_Management.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public int SKU { get; set; }

        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Discount { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal NetPrice { get; set; }

        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Tax { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string ShippingType { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal ShippingCharges { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal TotalAmountCharged { get; set; }

        [Required]
        public DateTime EstimatedDelivery { get; set; }

        [Required]
        public bool ReceiveStatusUpdates { get; set; }

        [Required]
        public bool DeliverySignatureRequired { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public bool TermsAndConditions { get; set; }
    }

}
