using MVC_Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Identity.ViewModels
{
    public class PostPageViewModel
    {
        public IEnumerable<Post> Post { get; set; }
        public Forum Forum { get; set; }
        public Post P { get; set; }
    }
}
