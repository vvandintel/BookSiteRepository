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

                const string connect = @"Data Source=jeff.cedarville.edu; Database=Harris-VanDintel_PDF Persist Security Info=True;User ID=itm3500;Password=itm3500; MultipleActiveResultSets=True; Trusted_Connection=True;";
                using (var conn = new SqlConnection(connect))
                {
                    var qry = "INSERT INTO FileStore (FileContent, MimeType, FileName) VALUES (@FileContent, @MimeType, @FileName)";
                    var cmd = new SqlCommand(qry, conn);
                    cmd.Parameters.AddWithValue("@FileContent", fileData);
                    cmd.Parameters.AddWithValue("@MimeType", mimeType);
                    cmd.Parameters.AddWithValue("@FileName", fileName);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return View();
        }
        //
        // GET: /Admin/
        //[HttpPost]
        //public ActionResult Index()
        //{
        //    ////string filePath = Server.MapPath("Content/pdf/chapter3-prototype.pdf");
        //    ////string filename = Path.GetFileName(filePath);
        //    ////FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        //    ////BinaryReader br = new BinaryReader(fs);
        //    ////Byte[] bytes = br.ReadBytes((Int32)fs.Length);
        //    ////br.Close();
        //    ////fs.Close();

        //    return View();
        //}
        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            //// Verify that the user selected a file
            //if (file != null && file.ContentLength > 0)
            //{
            //    // extract only the fielname
            //    var fileName = Path.GetFileName(file.FileName);
            //    // store the file inside ~/App_Data/uploads folder
            //    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
            //    file.SaveAs(path);
            //}

            //foreach (string upload in Request.Files)
            //{
            //  //  if (!Request.Files[upload].HasFile()) continue;
            //    string path = AppDomain.CurrentDomain.BaseDirectory + "uploads/";
            //    string filename = Path.GetFileName(Request.Files[upload].FileName);
            //    Request.Files[upload].SaveAs(Path.Combine(path, filename));
            //}

            //// redirect back to the index action to show the form once again
            return RedirectToAction("Index");
        }
        ////public ActionResult Index(IEnumerable<HttpPostedFileBase> files)
        ////{
        ////    // Read the file and convert it to Byte Array
        ////    string filePath = Server.MapPath("APP_DATA/TestDoc.docx");
        ////    string filename = Path.GetFileName(filePath);

        ////    FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        ////    BinaryReader br = new BinaryReader(fs);
        ////    Byte[] bytes = br.ReadBytes((Int32)fs.Length);
        ////    br.Close();
        ////    fs.Close();

        ////    //insert the file into database
        ////    string strQuery = "insert into PDF_Chapter(FileName, FileData) values (@FileName, @FileData)";
        ////    SqlCommand cmd = new SqlCommand(strQuery);
        ////    cmd.Parameters.Add("@FileName", SqlDbType.VarChar).Value = filename;
        //////    cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = "application/vnd.ms-word";
        ////    cmd.Parameters.Add("@FileData", SqlDbType.Binary).Value = bytes;


        ////    try
        ////    {
        ////        cmd.ExecuteNonQuery();

        ////    }
        ////    catch (SqlException sqlEx)
        ////    {
        ////        //MessageBox.Show("error was generated" + err);
        ////        //MessageBox.Show("Exception Data" + err.Data); 

        ////        //sqlErrorLabel.Text = sqlEx.ToString();
        ////        //sqlErrorLabel.ForeColor = System.Drawing.Color.Red;
        ////    }
        ////    finally
        ////    {
        ////        //MessageBox.Show("updated!!" + dayvals);
        ////        //DBConn.Close();

        ////    //    cmd.EndExecuteNonQuery(cmd);
        ////    }
        ////  //  InsertUpdateData(cmd);

        ////    //foreach (var file in files)
        ////    //{
        ////    //    if (file.ContentLength > 0)
        ////    //    {
        ////    //        var fileName = Path.GetFileName(file.FileName);
        ////    //        var path = Path.Combine(Server.MapPath("~/App_Data/Uploads"), fileName);
        ////    //        file.SaveAs(path);
        ////    //    }
        ////    //}
        ////    return RedirectToAction("Index");


        //LocalReport localReport = new LocalReport();
        //localReport.ReportPath = Server.MapPath("~/Reports/rptCustomer.rdlc");
        //ReportDataSource reportDataSource = new ReportDataSource("Customer",
        //    new CustomerModel().GetAllCustomer());
        //localReport.DataSources.Add(reportDataSource);

        //string reportType = "pdf";
        //string mimeType;
        //string encoding;
        //string fileNameExtension;
        ////The DeviceInfo settings should be changed based on the reportType
        ////http://msdn2.microsoft.com/en-us/library/ms155397.aspx
        //string deviceInfo =
        //    "" +
        //    "  PDF" +
        //    "  8.5in" +
        //    "  11in" +
        //    "  0.5in" +
        //    "  1in" +
        //    "  1in" +
        //    "  0.5in" +
        //    "";
        //Warning[] warnings;
        //string[] streams;
        //byte[] renderedBytes;
        ////Render the report
        //renderedBytes = localReport.Render(
        //    reportType,
        //    deviceInfo,
        //    out mimeType,
        //    out encoding,
        //    out fileNameExtension,
        //    out streams,
        //    out warnings);

        //// Save to Database
        //DataFile dataFile = new DataFile {
        //    FileName = "Customer",
        //    FileData = renderedBytes,
        //    FileExtension = ".pdf"
        //};

        //bool Status;
        //try
        //{
        //    context.DataFiles.AddObject(dataFile);
        //    context.SaveChanges();
        //    ViewBag.Status = true;
        //    return View();
        //}
        //catch {
        //    ViewBag.Status = false;
        //    return View();
        //}

        //}

        //protected ActionResult FileUpload
        //{

        //    //string filePath = bookUpload.PostedFile.FileName;          // getting the file path of uploaded file
        //    //string filename1 = Path.GetFileName(filePath);               // getting the file name of uploaded file
        //    //string ext = Path.GetExtension(filename1);                      // getting the file extension of uploaded file
        //    //string type = String.Empty;
        //}


        //public ActionResult FileUpload()
        //{
        //    DBContext dataContext = new DBContext();
        //    var returnData = dataContext.FileDumps;
        //    ViewData.Model = returnData.ToList();
        //    return View(); }
    }
}
