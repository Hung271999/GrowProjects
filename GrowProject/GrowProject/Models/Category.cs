using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrowProject.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [StringLength(15)]
        public string CategoryID { set; get; }
        [Required]
        [StringLength(50)]
        public string CategoryName { set; get; }
        public string Description { set; get; }
        [StringLength(50)]
        public string Picture { set; get; }

        public ICollection<Product> Products { get; set; }

    }
}