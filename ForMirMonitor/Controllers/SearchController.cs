using System;
using System.Web.Mvc;
using FMM.Model.Statistics;
using ForMirMonitor.ViewModels;
using FMM.Service.Statistics;
using Microsoft.Practices.Unity;
using FMM.Common.Paging;


namespace ForMirMonitor.Controllers
{
    public class SearchController : Controller
    {


        ISTATInfoService STATInfoService = STATInfoServiceContainer.Instance.Container.Resolve<ISTATInfoService>();
        
        // GET: Search
        public ActionResult Index()
        {
            Pager<STATInfo> statInfoList = new Pager<STATInfo>();
            try
            {
                STATInfoSearchCriteria criteria = new STATInfoSearchCriteria();

                statInfoList = STATInfoService.getSTATInfoPagerListByCriteria(criteria, 1, 10);
            }
            catch (Exception ex)
            {
                //Yintai.ERP.Log.LogService.Instance.Warn("RMA规则页面失败！原因：" + ex.Message + "\r\n" + ex.StackTrace);
            }
            return View(new SearchViewListModels(statInfoList, new PageItem { TotalItemCount = (int)statInfoList.TotalRecords, PageSize = 10, CurrentPage = 1 }));
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

        public ActionResult Query(STATInfoSearchCriteria Criteria, PageItem pager)
        {
            Pager<STATInfo> statInfoList = new Pager<STATInfo>();

            statInfoList = STATInfoService.getSTATInfoPagerListByCriteria(Criteria, pager.CurrentPage, pager.PageSize);
            pager.TotalItemCount = (int)statInfoList.TotalRecords;

            SearchViewListModels model = new SearchViewListModels(statInfoList, pager);
            return Json(new { PagersRMARuleHtml = model.STATInfoListHtml, PagersTopHtml = model.PagersTopHtml, PagersBottomHtml = model.PagersBottomHtml });
        }
    }
}