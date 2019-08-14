using PostEducatioN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostEducatioN.Controllers
{
    public class AuthorsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Authors
        public ActionResult Index(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                AllViewModel model = new AllViewModel();
                var UserId = id;
                if (db.Users.FirstOrDefault(m => m.Id == id) == null)
                {
                    return RedirectToAction("Error404", "Error");
                }
                else
                {
                    model.Author = db.Users.FirstOrDefault(m => m.Id == id);
                    return View(model);
                }
            }
        }
    }
}