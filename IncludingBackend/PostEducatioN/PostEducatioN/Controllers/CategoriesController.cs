using PostEducatioN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostEducatioN.Controllers
{
    public class CategoriesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Section
        
        public ActionResult Index()
        {
            AllViewModel model = new AllViewModel();
            model.Categories = db.Categories.ToList();
            return View(model);
        }
        public ActionResult SpecialCategory(int? Id)
        {
            if(Id == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (db.Categories.FirstOrDefault(m => m.Id == Id) == null)
                {
                    return RedirectToAction("Error404","Error");
                }
                AllViewModel model = new AllViewModel();
                model.Videos = db.Videos.Where(v => v.CategoryId == Id).ToList();
                if (model.Videos != null)
                {
                    return View(model);
                }
                return RedirectToAction("Index");
            }
            
        }
    }
}