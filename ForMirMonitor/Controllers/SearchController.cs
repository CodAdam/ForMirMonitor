using System;
using System.Web.Mvc;
using FMM.Model.Statistics;
using ForMirMonitor.ViewModels;
using FMM.Service.Statistics;
using Microsoft.Practices.Unity;
using FMM.Common.Paging;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data;
using System.Web;
using System.Text;
using FMM.Common.Helper;

namespace ForMirMonitor.Controllers
{
    public class SearchController : Controller
    {


        ISTATInfoService STATInfoService = STATInfoServiceContainer.Instance.Container.Resolve<ISTATInfoService>();
        
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetStatInfoTable(int limit, int offset, STATInfoSearchCriteria criteria)
        {
            List<STATInfo> statInfoList = new List<STATInfo>();
            statInfoList = STATInfoService.getSTATInfoListbyCriteria(criteria);
            var total = statInfoList.Count;
            var rows = statInfoList.Skip(offset).Take(limit).ToList();
            return Json(new { total = total, rows = rows }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EditStatInfoById(STATInfo statInfo)
        {
            if (statInfo == null) {
                return View();
            }
            STATInfoService.EditStatInfoById(statInfo);

            return View();
        }

        [HttpPost]
        public ActionResult Invalid(List<long> STATIdlist) {
            return View();
        }


        public void ExportSTATInfo(STATInfoSearchCriteria criteria)
        { 

            string strHeaderText="";
            string strFileName="";
            List<STATInfo> statInfoList = new List<STATInfo>();
            DataTable dtSource = STATInfoService.ExportSTATInfo(criteria);
            // = statInfoList;
            // 设置编码和附件格式   
            HttpContext.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Response.ContentEncoding = Encoding.UTF8;
            HttpContext.Response.Charset = "";
            HttpContext.Response.AppendHeader("Content-Disposition",
            "attachment;filename=" + HttpUtility.UrlEncode(strFileName, Encoding.UTF8));
            Excelhelper eh = new Excelhelper();
            HttpContext.Response.BinaryWrite(eh.Export(dtSource, strHeaderText).GetBuffer());
            HttpContext.Response.End();

        }

        /// <summary>读取excel   
        /// 默认第一行为标头   
        /// </summary>   
        /// <param name="strFileName">excel文档路径</param>   
        /// <returns></returns>   
        public DataTable ImportSTATInfo(string strFileName)
        {
            Excelhelper eh = new Excelhelper();
            return eh.Import(strFileName);
        }
    }
}