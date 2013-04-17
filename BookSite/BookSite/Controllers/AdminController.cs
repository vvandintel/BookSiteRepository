using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Linq;

namespace BookSite.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult FileUpload()
        //{
        //    DBContext dataContext = new DBContext();
        //    var returnData = dataContext.FileDumps;
        //    ViewData.Model = returnData.ToList();
        //    return View(); }
    }
}
