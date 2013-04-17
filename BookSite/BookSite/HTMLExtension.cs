using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace BookSite
{
    public static class HTMLExtensions
    {
        public static bool HasFile(this HttpPostedFileBase file)
        {
            return (file != null && file.ContentLength > 0) ? true : false;
        }
    }
}