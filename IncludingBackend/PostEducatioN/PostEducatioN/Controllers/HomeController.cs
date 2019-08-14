using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PostEducatioN.Models;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PostEducatioN.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                using (var db = new ApplicationDbContext())
                {
                    var userid = User.Identity.GetUserId();
                    var thisuser = db.Users.FirstOrDefault(b => b.Id == userid);

                    ViewBag.LoggedUser = thisuser;
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Login","Account");
            }

            
        }
        
    }
}