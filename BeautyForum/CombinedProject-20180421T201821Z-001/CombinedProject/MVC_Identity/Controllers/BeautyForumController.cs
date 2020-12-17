using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Identity.Models;
using MVC_Identity.ViewModels;

namespace MVC_Identity.Controllers
{
    public class BeautyForumController : BaseController
    {

        public BeautyForumController() : base() { }


        public IActionResult Index()
        {
            var forum = _context.Forums.Include(f => f.MyPosts).ToList();

            return View(forum);
        }

        public IActionResult Details(Guid id)
        {
            var forum = _context.Forums.SingleOrDefault(f => f.Id == id);
            var post = _context.Posts.Where(p => p.ForumID == id).ToList();

            var viewmodel = new PostPageViewModel
            {
                Post = post,
                Forum = forum
            };
            return View(viewmodel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Forum forum)
        {
            forum.ManagerID = _context.Users.First(u => u.UserName == User.Identity.Name).Id;
            _context.Forums.Add(forum);
            _context.SaveChanges();
            return RedirectToAction("Index", "BeautyForum");
        }

        public ActionResult Update(Guid? id)
        {
            var forum = _context.Forums.Single(f => f.Id == id);

            return View(forum);
        }

        [HttpPost]
        public IActionResult Update(Forum forum)
        {
            if (ModelState.IsValid)
            {
                var forumInDb = _context.Forums.Single(f => f.Id == forum.Id);
                forumInDb.Name = forum.Name;
                forumInDb.Description = forum.Description;

                _context.SaveChanges();
                return RedirectToAction("Index", "BeautyForum");
            }

            return View(forum);
        }

        public ActionResult Delete(Guid? id)
        {

            Forum forum = _context.Forums.Find(id);

            return View(forum);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Forum forum = _context.Forums.Find(id);
            _context.Forums.Remove(forum);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}