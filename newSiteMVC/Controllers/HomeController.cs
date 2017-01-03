using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using newSiteMVC.Models;


namespace newSiteMVC.Controllers
{
    public class HomeController : Controller
    {
        private StoreDB db = new StoreDB();

        public ActionResult Index()
        {
            List<tbl_UserControl> tbl_UserControls = db.tbl_UserControl.ToList();
            tbl_UserControls = tbl_UserControls.Where(it => it.Active == true).OrderBy(it => it.Priority).ToList();

            return View(tbl_UserControls);
        }
    }
}