using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Identity.Models;

namespace MVC_Identity.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext _context;

        public BaseController()
        {
            _context = new ApplicationDbContext();
        }
    }
}