using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrowProject.Models
{
    [Table("OderDetails")]
    public class OderDetail
    {
        [Key]
        public int OderDetailID { set; get; }
        [Required]
        [StringLength(15)]
        public string OrderID { set; get; }
        [Required]
        [StringLength(15)]
        public string ProductID { set; get; }
        public decimal UnitPrice { set; get; }

        public float Quantity { set; get; }
     
        public float Discount { set; get; }
        public virtual Product Product { set; get; }
        public virtual Order Order { set; get; }
    }
}