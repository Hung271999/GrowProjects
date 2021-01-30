using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrowProject.Models
{
    [Table("Posts")]
    public class Post
    {

        [Key]
        [StringLength(15)]
        public string PostID { set; get; }
        [Required]
        [StringLength(50)]
        public string Titile { set; get; }
        [Required]
        public DateTime CreateDate { set; get; }
        public DateTime? PublishDate { set; get; }
        public string Picture { set; get; }
        public Boolean Status { set; get; }
        public string CategoryPostID { set; get; }
        public virtual CategoryPost CategoryPost { set; get; }


    }
}