using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BookSite.Controllers
{
    public class BookController : Controller
    {   
        

        //
        // GET: /Book/
        public int ChapterIndex { get; set; }

        public ActionResult Index()
        {
            ViewBag.Message = "Your book page.";

          //  book.DisplayBook(book.ChangeChapter());
            //if (chapter next chapter selected, change chapter index for display parameter)

            return View();
        }

        public ActionResult CreatePost()
        {
            
            
            return View();
        }

    }
}