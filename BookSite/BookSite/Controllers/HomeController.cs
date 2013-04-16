using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult AuthorBio()
        {
            ViewBag.Message = "Your author bio page.";

            return View();
        }

        public ActionResult DownloadPDF()
        {
            ViewBag.Message = "Link to downloadable PDF.";

            return View();
        }

        public ActionResult Account()
        {
            ViewBag.Message = "Your book page.";

            return View();
        }
    }
}
