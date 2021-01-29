using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrowProject.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int OrderID { set; get; }
        [Required]
        [StringLength(15)]
        public string CustomerID { set; get; }
        [Required]
        public DateTime OrderDate { set; get; }
        [Required]
        [StringLength(50)]
        public string ShipName { set; get; }
        [Required]
        [StringLength(60)]
        public string ShipAddress { set; get; }
        [Required]
        [StringLength(15)]
        public string ShipCity { set; get; }
        [Required]
        [StringLength(24)]
        public string Phone { set; get; }
    }
}