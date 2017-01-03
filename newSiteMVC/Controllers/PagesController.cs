using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using newSiteMVC.Models;

namespace newSiteMVC.Controllers
{
    public class PagesController : Controller
    {
        private StoreDB db = new StoreDB();

        public ActionResult LoadPageContent(string pageId, string id)
        {
            ViewBag.NewsId = id;

            List<tbl_UserControl> tbl_UserControls = db.tbl_UserControl.ToList();
            tbl_UserControls = tbl_UserControls.Where(it => it.Active == true && it.PageId == pageId).OrderBy(it => it.Priority).ToList();

            return View(tbl_UserControls);
            
        }

    }
}