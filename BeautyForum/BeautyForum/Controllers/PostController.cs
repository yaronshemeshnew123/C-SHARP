using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeautyForum.Models;
using BeautyForum.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BeautyForum.Controllers
{
    public class PostController : BaseController
    {
        public PostController() : base() { }
       

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Create(int? id)
        {
            var p = new Post { ForumID = id.Value };
            return View(p);
        }

        [HttpPost]
        public ActionResult Create(Post post)
        {
            post.ID = 0;
            _context.Posts.Add(post);
            post.DateAdded = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction($"Details/{post.ID}", "BeautyForum");
        }

        public ActionResult Edit(int? id)
        {
            var post = _context.Posts.Single(f => f.ID == id);

            return View(post);
        }

        [HttpPost]
        public IActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                var postInDb = _context.Posts.Single(f => f.ID == post.ID);

                postInDb.Title = post.Title;
                postInDb.Massage = post.Massage;

                _context.SaveChanges();
                return RedirectToAction("Index", "BeautyForum");
            }

            return View(post);
        }

        public ActionResult Delete(int? id)
        {

            Post post = _context.Posts.Find(id);
            post.ForumID = 1;
            return View(post);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = _context.Posts.Find(id);
            post.ForumID = 1;
            _context.Posts.Remove(post);
            _context.SaveChanges();
            return RedirectToAction("Index", "BeautyForum");
        }
    }
}