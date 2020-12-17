using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MVC_Identity.Models;
using Microsoft.Extensions.Logging;

namespace MVC_Identity.Controllers
{
    [Authorize]
    public class AddForumController : Controller
    {
        private readonly ILogger _logger;

        public AddForumController(ILogger<AddForumController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View ("AddForumView");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ForumViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                Forum forum = new Forum();
                forum.Name = model.ForumName;

                string userId = User.Identity.Name;

                using (var dbConnection = new ApplicationDbContext())
                {
                    var userFromDb = dbConnection.Users.Where(user => user.UserName.Equals(userId)).FirstOrDefault();

                    forum.ManagerID = userFromDb.Id;

                    dbConnection.Forums.Add(forum);
                    dbConnection.SaveChanges();
                }
            
            }

            // If we got this far, something failed, redisplay form
            return View("AddForumView", model);
        }

        [Authorize]
        public string AdminOnly()
        {
            return "in AddForumController/AdminOnly (Authorize)";
        }


    }
}