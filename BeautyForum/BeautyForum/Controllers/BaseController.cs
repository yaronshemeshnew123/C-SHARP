using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyForum.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeautyForum.Controllers
{
    public class BaseController : Controller
    {
        protected BeautyForumContext _context;

        public BaseController()
        {
            _context = new BeautyForumContext();
        }
    }
}