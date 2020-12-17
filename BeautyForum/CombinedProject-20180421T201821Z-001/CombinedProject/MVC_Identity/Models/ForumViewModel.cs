using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Identity.Models
{
    public class ForumViewModel
    {
            [Required]
            [StringLength(10, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [Display (Name ="Forum Name")]
            public string ForumName { get; set; }
            
    }


    
}
