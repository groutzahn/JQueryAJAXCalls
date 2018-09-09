using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace JQueryAJAXCalls.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public EmptyResult ReturnFileContentResult() //FileContentResult
        {
            return new EmptyResult();
        }
        public FileContentResult ReturnFileContentResultText() // downloads a file directly into the window (not a download) and replaces the form completely. probably not desirable.
        {
            var mapFilePath = Server.MapPath("~/scripts/test.js");

            var fileStream = new FileStream(mapFilePath, FileMode.Open);
            BinaryReader br = new BinaryReader(fileStream);
            long numBytes = new FileInfo(mapFilePath).Length;

            byte[] fileBytes = br.ReadBytes((int) numBytes);


            return new FileContentResult(fileBytes,"text");
        }

        public FileContentResult ReturnFileContentResultWord() // this downloads to the download area. downloaded and opened perfectly
        {
            var mapFilePath = Server.MapPath("~\\Docs\\word doc.docx");

            var fileStream = new FileStream(mapFilePath, FileMode.Open);
            BinaryReader br = new BinaryReader(fileStream);
            long numBytes = new FileInfo(mapFilePath).Length;

            byte[] fileBytes = br.ReadBytes((int) numBytes);


            return new FileContentResult(fileBytes,"application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        }

        public FileContentResult ReturnFileContentResultExcel() // this downloads to the download area. downloaded and opened perfectly
        {
            var mapFilePath = Server.MapPath("~\\Docs\\obama care options.xlsx");

            var fileStream = new FileStream(mapFilePath, FileMode.Open);
            BinaryReader br = new BinaryReader(fileStream);
            long numBytes = new FileInfo(mapFilePath).Length;

            byte[] fileBytes = br.ReadBytes((int) numBytes);


            return new FileContentResult(fileBytes,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public FileStreamResult ReturnFileStreamResultText() // downloads a file directly into the window (not a download) and replaces the form completely. probably not desirable.
        {
            var fileStream = new FileStream(Server.MapPath("~/scripts/test.js"), FileMode.Open);
            return new FileStreamResult(fileStream, "text");
        }

        public FileStreamResult ReturnFileStreamResultWord() // this downloads to the download area. downloaded and opened perfectly
        {
            var fileStream = new FileStream(Server.MapPath("~\\Docs\\word doc.docx"), FileMode.Open);
            return new FileStreamResult(fileStream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        }

        public FileStreamResult ReturnFileStreamResultExcel() // this downloads to the download area. downloaded and opened perfectly
        {
            var fileStream = new FileStream(Server.MapPath("~\\Docs\\obama care options.xlsx"), FileMode.Open);
            return new FileStreamResult(fileStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public FilePathResult ReturnFilePathResultText() // downloads a file directly into the window (not a download) and replaces the form completely. probably not desirable.
        {
            return new FilePathResult(@"~\scripts\test.js","text");
        }

        public FilePathResult ReturnFilePathResultWord() // this downloads to the download area. downloaded and opened perfectly
        {
            return new FilePathResult(@"~\Docs\word doc.docx","application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        }

        public FilePathResult ReturnFilePathResultExcel() // this downloads to the download area. downloaded and opened perfectly
        {
            return new FilePathResult(@"~\Docs\obama care options.xlsx","application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public int MyProperty { get; set; }
    }
}