using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Identity.Models
{
    public class Post
    {
        public Guid Id { set; get; }
        //public string Body { set; get; }

        public Guid PublisherID { set; get; }
        public Guid ForumID { set; get; }

        public virtual Forum ForumPosts { get; set; }
        public virtual ApplicationUser MyPublisher { get; set; }

        [Required]
        public string Title { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Required]
        public string Massage { get; set; }


        public bool IsVisible { get; set; }

    }

}
