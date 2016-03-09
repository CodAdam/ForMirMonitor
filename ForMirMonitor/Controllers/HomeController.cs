using System;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using System.Net.Mail;
using FMM.Service.Common;

namespace ForMirMonitor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult test() {

            
            return View();
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

        public ActionResult InfoCommit()
        {
            return View("Index");
        }

        public void sendEmail() {
            try
            {
                string seFrom = "ForMirMonitor@163.com"; 
                string seTo = "329996324@qq.com";
                SendEmail se = new SendEmail(seTo, seFrom, "From ForMirMoniter", "Dear "+ seTo+":\n 以下是您的订阅信息，如有附件请注意查收。\n祝您愉快~");
                string filePath = Request.PhysicalApplicationPath + "Download\\Commit_STATModel.xlsx";
                se.Attachments(filePath);
                se.SetSmtp("formirmonit0r", "smtp.163.com"); //必须在所有参数设置完后调用此方法  
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            
        }

        public void DownLoad(string strName, string strPath)
        {

        }
    }
}