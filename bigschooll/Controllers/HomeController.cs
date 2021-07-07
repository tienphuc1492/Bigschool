using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bigschooll.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace bigschooll.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            bigschoolContext context = new bigschoolContext();
            var upcommingCouser = context.Cousers.Where(p => p.DateTime > DateTime.Now).OrderBy(p => p.DateTime).ToList();
            foreach (Couser i in upcommingCouser)
            {
                ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(i.LectuserId);
                i.Name = user.Name;
            }
            return View(upcommingCouser);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}