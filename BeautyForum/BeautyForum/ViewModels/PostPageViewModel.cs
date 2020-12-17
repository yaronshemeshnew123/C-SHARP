using BeautyForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyForum.ViewModels
{
    public class PostPageViewModel
    {
        public IEnumerable<Post> Post { get; set; }
        public Forum Forum { get; set; }
        public Post P { get; set; }
    }
}
