using Microsoft.AspNet.Identity;
using PostEducatioN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostEducatioN.Controllers
{
    public class VideosController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Videos
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (db.Videos.FirstOrDefault(a => a.Id == id) == null)
                {
                    return RedirectToAction("Error404", "Error");
                }
                AllViewModel model = new AllViewModel();
                model.Videos = db.Videos.Where(a => a.Id == id).ToList();
                model.Comments = db.Comments.Where(a => a.VideoId == id).ToList();
                model.Categories = db.Categories.ToList();
                model.Likes = db.Likes.Where(a => a.VideoId == id).ToList();
                model.Users = db.Users.ToList();
                var userid = User.Identity.GetUserId();
                model.ApplicationUser = db.Users.FirstOrDefault(a => a.Id == userid);
                return View(model);
            }
        }


        public ActionResult Like(int? id, int videoid)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Like likepost = new Like();
                likepost.AuthorId = User.Identity.GetUserId();
                likepost.VideoId = (int)id;
                db.Likes.Add(likepost);
                db.SaveChanges();
            }
            return RedirectToAction("Index", new { id = videoid });
        }


        public ActionResult Dislike(int Id, int videoId)
        {
            Like like = db.Likes.Find(Id);
            db.Likes.Remove(like);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = videoId });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComment(Comment comment)
        {
            Comment com = new Comment();
            com.AuthorId = User.Identity.GetUserId();
            com.Text = comment.Text;
            com.VideoId = comment.VideoId;
            db.Comments.Add(com);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = comment.VideoId });
        }
    }
}