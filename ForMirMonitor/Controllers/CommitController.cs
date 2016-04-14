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
            statInfo.QQ=long.Parse(Request["QQ"]) ;            
            statInfo.GroupNo = int.Parse(Request["GroupNo"]);
            statInfo.UserName =Request["ID"];
            statInfo.Tag = int.Parse(Request["Tag"]);
            statInfo.Tips = Request["Tips"];
            //statInfo.Indate = "";
            //statInfo.Eidtdate = "";
            //statInfo.Operator = "0";
            //statInfo.OperatorId = "0";
            statInfo.Status = 1;
            try
            {
                STATInfoService.AddSTATInfo(statInfo);
            }
            catch(Exception ex) {
                return Content(ex.Message);
                //log
            }
            return View("Search/Index");

        }

    }
}
