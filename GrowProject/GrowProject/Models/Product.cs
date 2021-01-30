using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrowProject.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [StringLength(15)]
        public string ProductID { set; get; }
        [Required]
        [StringLength(50)]
        public string ProductName { set; get; }
        public string SupplierID { set; get; }
        public string  CategoryID { set; get; }
        [Required]
        [StringLength(10)]
        public string  QuantityPerUnit { set; get; }
        [Required]
        public decimal  UnitPrice { set; get; }
        public int  UnitsInStock { set; get; }
        public int UnitsOnOrder { set; get; }
        public int  ReorderLevel { set; get; }
        public float? Discounts { set; get; }
        public virtual Supplier Supplier { set; get; }
        public virtual Category Category { set; get; }
        public virtual ICollection<OderDetail> OderDetails { get; set; }

    }
}