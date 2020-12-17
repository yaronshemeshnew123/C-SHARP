using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Identity.Models
{
    // Add profile data for application users
    //by adding properties to the ApplicationUser class
    public class ApplicationRole : IdentityRole<Guid>
    {
        //add more prop...
    }

}
