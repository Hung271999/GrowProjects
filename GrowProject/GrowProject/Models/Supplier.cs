using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrowProject.Models
{
    [Table("Suppliers")]
    public class Supplier
    {
        [Key]
        [StringLength(15)]
        public string SupplierID { set; get; }
        [Required]
        [StringLength(50)]
        public string CompanyName { set; get; }
        [StringLength(30)]
        public string ContacName { set; get; }
        [StringLength(30)]
        public string ContacTitle { set; get; }
        [StringLength(60)]
        public string Address { set; get; }
        [StringLength(15)]
        public string City { set; get; }
        [StringLength(15)]
        public string Region { set; get; }
        [StringLength(10)]
        public string PostalCode { set; get; }
        [StringLength(15)]
        public string Conuntry { set; get; }
        [StringLength(24)]
        public string Phone { set; get; }
        [StringLength(24)]
        public string Fax { set; get; }
        public string HomePage { set; get; }
        public virtual ICollection<Product> Products { get; set; }
    }
}