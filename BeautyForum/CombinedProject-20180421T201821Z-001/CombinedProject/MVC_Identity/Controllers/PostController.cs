using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Identity.Models;

namespace MVC_Identity.Controllers
{
    public class PostController : BaseController
    {
        public PostController() : base() { }


        //public IActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Create(Guid? id)
        {
            var p = new Post { ForumID = id.Value };
            return View(p);
        }

        [HttpPost]
        public ActionResult Create(Post post)
        {
            post.Id = Guid.NewGuid();
            post.PublisherID = _context.Users.First(u => u.UserName == User.Identity.Name).Id;
            _context.Posts.Add(post);
            post.DateAdded = DateTime.Now;
            _context.SaveChanges();

            return RedirectToAction($"Details/{post.Id}", "BeautyForum");
        }

        public ActionResult Edit(Guid? id)
        {
            var post = _context.Posts.Single(f => f.Id == id);

            return View(post);
        }

        [HttpPost]
        public IActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                var postInDb = _context.Posts.Single(f => f.Id == post.Id);

                postInDb.Title = post.Title;
                postInDb.Massage = post.Massage;

                _context.SaveChanges();
                return RedirectToAction("Index", "BeautyForum");
            }

            return View(post);
        }

        public ActionResult Delete(Guid? id)
        {

            Post post = _context.Posts.Find(id);
            //post.ForumID = 1;
            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Post post = _context.Posts.Find(id);
            //post.ForumID = 1;
            _context.Posts.Remove(post);
            _context.SaveChanges();
            return RedirectToAction("Index", "BeautyForum");
        }
    }
}