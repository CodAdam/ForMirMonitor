using System;
using System.Web.Mvc;
using FMM.Model.Statistics;
using ForMirMonitor.ViewModels;
using System.Collections.Generic;

namespace ForMirMonitor.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {

            SearchViewModels si = new SearchViewModels();
            si.QQ = 1910347321;
            si.STATId = 1;
            si.GroupNo = 1;
            si.Eidtdate = DateTime.Now;
            si.Indate = DateTime.Now;
            si.Status = 1;
            si.Tag = 1;
            si.UserName = "0";
            si.Tips = "hi~";
            si.OperatorName = "0";
            //ViewData["SearchViewModels"] = si;
            
            
            SearchViewListModels sil = new SearchViewListModels();
            sil.STATInfoList = new List<SearchViewModels>();
            //foreach (var i in sil.STATInfoList) {
            //    i.QQ = si.QQ;
            //    i.STATId = si.STATId;
            //    //i.GroupNo = si.GroupNo;
            //    i.GroupName = "高级班";
            //    i.Indate = si.Indate;
            //    //i.Operator = si.Operator;
            //    i.OperatorName = "我自己";
            //    i.StatusName = "有效";



            //}
            sil.STATInfoList.Add(si);
            sil.UserName = "ykl";
            
            return View(sil);
        }

        // GET: Search
        public ActionResult getView()
        {
            STATInfo stat = new STATInfo();

            SearchViewModels si = new SearchViewModels();
            si.QQ =1910347321;
            si.STATId = 1;
            si.GroupNo = 1;
            si.Eidtdate = DateTime.Now;
            si.Indate = DateTime.Now;
            si.Status = 1;
            si.Tag = 1;
            si.UserName = "0";
            si.Tips = "hi~";
            si.OperatorName = "0";
            
            return View(si);
        }
    }
}