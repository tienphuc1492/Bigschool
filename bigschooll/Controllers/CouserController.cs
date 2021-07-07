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
    public class CouserController : Controller
    {
        // GET: Couser
        bigschoolContext context = new bigschoolContext();
        public ActionResult Create()
        {
            Couser objCourse = new Couser();
            objCourse.ListCategory = context.Categories.ToList();
            return View(objCourse);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Couser objCourse)
        {
            ModelState.Remove("LectuserId");
            if (!ModelState.IsValid)
            {
                objCourse.ListCategory = context.Categories.ToList();
                return View("Create", objCourse);
            }

            ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().
                GetUserManager<ApplicationUserManager>().
                FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            objCourse.LectuserId = user.Id;

            context.Cousers.Add(objCourse);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}