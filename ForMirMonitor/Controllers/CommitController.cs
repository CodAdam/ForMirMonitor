using System.Web.Mvc;
using FMM.Model.Statistics;
using FMM.Service.Statistics;
using Microsoft.Practices.Unity;
using System;

namespace ForMirMonitor.Controllers
{

    public class CommitController : Controller
    {
        ISTATInfoService STATInfoService = STATInfoServiceContainer.Instance.Container.Resolve<ISTATInfoService>();


        // GET: Commit
        public ActionResult Index()
        {
            return View();
        }

        // post: 
        public ActionResult CommitSTATInfo()
        {
            STATInfo statInfo = new STATInfo();
            ////statInfo.QQ=long.Parse(Request["QQ"]) ;            
            ////statInfo.GroupNo = int.Parse(Request["group"]);
            ////statInfo.UserName =Request["group"];
            ////statInfo.Tag = int.Parse(Request["group"]);
            ////statInfo.Tips = Request["tips"];
            try
            {
                STATInfoService.AddSTATInfo(statInfo);
            }
            catch(Exception ex) {
                return Content(ex.Message);
                
            }
            return View();

        }

    }
}
