using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyForum.Models
{
    public class Forum
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        //public int AdminID { get; set; }

        public ICollection<Post> PostList { get; set; }
    }
}
