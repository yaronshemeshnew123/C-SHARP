using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BeautyForum.Models;
using BeautyForum.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeautyForum.Controllers
{
    public class BeautyForumController : BaseController
    {
        
        public BeautyForumController() : base() { }
       
                      
        public IActionResult Index()
        {
            var forum = _context.Forums.Include(f => f.PostList).ToList();
            
            return View(forum);
        }

        public IActionResult Details(int id)
        {
            var forum =_context.Forums.SingleOrDefault(f => f.ID == id);
            var post = _context.Posts.Where(p => p.ForumID == id).ToList();
            
            var viewmodel = new PostPageViewModel
            {
                Post= post,
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
            _context.Forums.Add(forum);
            _context.SaveChanges();
            return RedirectToAction("Index", "BeautyForum");
        }

        public ActionResult Update(int? id)
        {
            var forum = _context.Forums.Single(f => f.ID == id);

            return View(forum);
        }

        [HttpPost]
        public IActionResult Update(Forum forum)
        {
            if (ModelState.IsValid)
            {
                var forumInDb = _context.Forums.Single(f => f.ID == forum.ID);
                forumInDb.Name = forum.Name;
                forumInDb.Description = forum.Description;

                _context.SaveChanges();
                return RedirectToAction("Index", "BeautyForum");
            }

            return View(forum);
        }

        public ActionResult Delete(int? id)
        {

            Forum forum = _context.Forums.Find(id);

            return View(forum);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Forum forum = _context.Forums.Find(id);
            _context.Forums.Remove(forum);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}