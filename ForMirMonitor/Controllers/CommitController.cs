using System.Web.Mvc;

namespace ForMirMonitor.Controllers
{
    public class CommitController : Controller
    {
        // GET: Commit
        public ActionResult Index()
        {
            return View();
        }

        // GET: Commit/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Commit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Commit/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Commit/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Commit/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Commit/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Commit/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
