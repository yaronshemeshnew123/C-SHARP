using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyForum.Models
{
    public class Post
    {
        public int ID { get; set; }
        
        public int ForumID { get; set; }

        [Required]
        public string Title { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Required]
        public string Massage { get; set; }

        public int UserID { get; set; }

        public bool IsVisible { get; set; }

        public virtual Forum Forum { get; set; }
    }
}
