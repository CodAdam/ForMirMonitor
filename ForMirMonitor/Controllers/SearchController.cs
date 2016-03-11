using System;
using System.Web.Mvc;
using FMM.Model.Statistics;
using ForMirMonitor.ViewModels;
using System.Collections.Generic;
using FMM.Service.Statistics;
using Microsoft.Practices.Unity;

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

        public ActionResult Query(STATInfoSearchCriteria Criteria)
        {
            SearchViewListModels sil = new SearchViewListModels(Criteria,"STATInfo");
            return View(sil);
        }
    }
}