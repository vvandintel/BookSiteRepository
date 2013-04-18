using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using System.IO;


namespace BookSite.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            foreach (string upload in Request.Files)
            {
                if (!Request.Files[upload].HasFile()) continue;

                string mimeType = Request.Files[upload].ContentType;
                Stream fileStream = Request.Files[upload].InputStream;
                string fileName = Path.GetFileName(Request.Files[upload].FileName);
                int fileLength = Request.Files[upload].ContentLength;
                byte[] fileData = new byte[fileLength];
                fileStream.Read(fileData, 0, fileLength);

                SqlConnection connect = new SqlConnection();
                connect.ConnectionString = "integrated security=false;data source=jeff.cedarville.edu; user id=itm3500;password=itm3500;"
                + "persist security info=False;database=Harris-VanDintel_PDF";
                using (connect)
                {
                    var qry = "INSERT INTO FileStore (FileContent, MimeType, FileName) VALUES (@FileContent, @MimeType, @FileName)";
                    var cmd = new SqlCommand(qry, connect);
                    cmd.Parameters.AddWithValue("@FileContent", fileData);
                    cmd.Parameters.AddWithValue("@MimeType", mimeType);
                    cmd.Parameters.AddWithValue("@FileName", fileName);
                    connect.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return View();
        }
        public FileContentResult GetFile(int id)
        {
            SqlDataReader rdr; byte[] fileContent = null;
            string mimeType = ""; string fileName = "";
            SqlConnection connect = new SqlConnection();
            connect.ConnectionString = "integrated security=false;data source=jeff.cedarville.edu; user id=itm3500;password=itm3500;"
            + "persist security info=False;database=Harris-VanDintel_PDF";

            using (connect)
            {
                var qry = "SELECT FileContent, MimeType, FileName FROM FileStore WHERE ID = @ID";
                var cmd = new SqlCommand(qry, connect);
                cmd.Parameters.AddWithValue("@ID", id);
                connect.Open();
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    fileContent = (byte[])rdr["FileContent"];
                    mimeType = rdr["MimeType"].ToString();
                    fileName = rdr["FileName"].ToString();
                }
            }
            return File(fileContent, mimeType, fileName);
        }
    }
}
