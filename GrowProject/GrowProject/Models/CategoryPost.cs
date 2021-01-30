using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrowProject.Models
{
    [Table("CategoryPosts")]
    public class CategoryPost
    {
        [Key]
        [StringLength(15)]
        public string CategoryPostID { set; get; }
        [Required]
        [StringLength(50)]
        public string Titile { set; get; }
        [Required]
        public Boolean Status { set; get; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}