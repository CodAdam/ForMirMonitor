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
        public ActionResult Invalid() {
            return View();
        }

        
        ////public ActionResult STATInfoExport()
        ////{
        ////    HSSFWorkbook hssfworkbook = new HSSFWorkbook();

        ////    DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
        ////    dsi.Company = "NPOI Team";

        ////    SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
        ////    si.Subject = "NPOI SDK Example";

        ////    hssfworkbook.DocumentSummaryInformation = dsi;
        ////    hssfworkbook.SummaryInformation = si;

        ////    hssfworkbook.CreateSheet("Sheet1");
        ////    //HSSFRow row1 = sheet1.CreateRow(0);
        ////    //row1.CreateCell(0).SetCellValue(1);
        ////    //sheet1.GetRow(0).CreateCell(0).SetCellValue("This is a Sample");

        ////    hssfworkbook.CreateSheet("Sheet2");
        ////    hssfworkbook.CreateSheet("Sheet3");
        ////    FileStream file = new FileStream(@"test.xls", FileMode.Create);
        ////    hssfworkbook.Write(file);
        ////    file.Close();
        ////    return View();
        //}
        
    }
}