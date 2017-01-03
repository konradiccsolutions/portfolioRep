using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Caching;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using newSiteMVC.Models;
using newSiteMVC.Controllers;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace newSiteMVC.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private StoreDB db = new StoreDB();

        public ActionResult Index()
        {
            List<tbl_UserControl> tbl_UserControl = db.tbl_UserControl.Where(it => it.PageId == "Home").OrderBy(it => it.Priority).ToList();

            return View("Index", tbl_UserControl);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            tbl_UserControl tblUserControl = db.tbl_UserControl.Find(id);

            if (tblUserControl == null)
            {
                return HttpNotFound();
            }
            return View(tblUserControl);
        }


        public ActionResult Create()
        {
            return View("Create");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="Id,Title,Subtitle,MainText,ButtonText,ImageUrl,UrlLink,PageId,TypeId,Active,BackgroundColour,ButtonColour,ButtonTextColour,TitleColour,MainTextColour")] tbl_UserControl tbl_UserControl)
        {
            if (ModelState.IsValid)
            {
                tbl_UserControl.PageId = Request.QueryString["pageType"];
                tbl_UserControl.TypeId = Request.QueryString["TypeId"];

                db.tbl_UserControl.Add(tbl_UserControl);
                db.SaveChanges();

                return Redirect("/Admin/GetActionResultForPage/" + Request.QueryString["pageType"]);
            }

            return View(tbl_UserControl);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            tbl_UserControl tbl_UserControl = db.tbl_UserControl.Find(id);

            if (tbl_UserControl == null)
            {
                return HttpNotFound();
            }

            return View(tbl_UserControl);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id,[Bind(Include ="Id,Title,Subtitle,MainText,ButtonText,ImageUrl,UrlLink,PageId,TypeId,Active,BackgroundColour,ButtonColour,ButtonTextColour,TitleColour,MainTextColour,SectionBackgroundColour,SectionTextColour,SectionTextUnderlineColour,Priority")] tbl_UserControl tbl_UserControl)
        {
            if (ModelState.IsValid)
            {
                var list = db.tbl_UserControl.Where(i => i.Id == id);

                foreach (var el in list)
                {
                    el.Title = tbl_UserControl.Title;
                    el.MainText = tbl_UserControl.MainText;
                    el.Subtitle = tbl_UserControl.Subtitle;
                    el.ButtonText = tbl_UserControl.ButtonText;
                    el.ImageUrl = tbl_UserControl.ImageUrl;
                    el.UrlLink = tbl_UserControl.UrlLink;
                    el.BackgroundColour = tbl_UserControl.BackgroundColour;
                    el.ButtonColour = tbl_UserControl.ButtonColour;
                    el.ButtonTextColour = tbl_UserControl.ButtonTextColour;
                    el.TitleColour = tbl_UserControl.TitleColour;
                    el.MainTextColour = tbl_UserControl.MainTextColour;
                    el.Active = tbl_UserControl.Active;
                }

                db.SaveChanges();

            }
            return Redirect("/Admin/GetActionResultForPage/" + Request.QueryString["pageType"]);
        }


        public ActionResult EditSection(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            tbl_UserControl tbl_UserControl = db.tbl_UserControl.Find(id);

            if (tbl_UserControl == null)
            {
                return HttpNotFound();
            }

            return View(tbl_UserControl);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSection([Bind(Include ="BackgroundColour,ButtonColour,ButtonTextColour,TitleColour,MainTextColour,SectionBackgroundColour,SectionTextColour,SectionTextUnderlineColour")] tbl_UserControl tbl_UserControl, int id)
        {
            if (ModelState.IsValid)
            {
                List<tbl_UserControl> lstControlsl = db.tbl_UserControl.ToList();
                tbl_UserControl userControl = lstControlsl.Single(it => it.Id == id);

                string typeId = userControl.TypeId;
                string pageId = userControl.PageId;

                using (var newContext = new StoreDB())
                {
                    var list = newContext.tbl_UserControl;

                    foreach (var el in list.Where(el => (el.TypeId == typeId) && (el.PageId == pageId)))
                    {
                        el.BackgroundColour = tbl_UserControl.BackgroundColour;
                        el.ButtonColour = tbl_UserControl.ButtonColour;
                        el.ButtonTextColour = tbl_UserControl.ButtonTextColour;
                        el.TitleColour = tbl_UserControl.TitleColour;
                        el.MainTextColour = tbl_UserControl.MainTextColour;
                        el.SectionBackgroundColour = tbl_UserControl.SectionBackgroundColour;
                        el.SectionTextColour = tbl_UserControl.SectionTextColour;
                        el.SectionTextUnderlineColour = tbl_UserControl.SectionTextUnderlineColour;
                    }

                    newContext.SaveChanges();

                }
                return Redirect("/Admin/GetActionResultForPage/" + Request.QueryString["pageType"]);
            }
            return View(tbl_UserControl);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            tbl_UserControl tbl_UserControl = db.tbl_UserControl.Find(id);

            if (tbl_UserControl == null)
            {
                return HttpNotFound();
            }

            return View(tbl_UserControl);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_UserControl tbl_UserControl = db.tbl_UserControl.Find(id);

            db.tbl_UserControl.Remove(tbl_UserControl);
            db.SaveChanges();

            return Redirect("/Admin/GetActionResultForPage/" + Request.QueryString["pageType"]);
        }


        [HttpPost, ActionName("UpdateTableOrder")]
        public ActionResult UpdateTableOrder()
        {
            string[] newOrder = Request.Form["item.Priority"].ToString().Split(',');
            string[] id = Request.Form["item.Id"].ToString().Split(',');
            string pageId = null;

            for (int i = 0; i <= newOrder.Length - 1; i++)
            {
                tbl_UserControl newTbls = db.tbl_UserControl.Find(Int32.Parse(id[i]));

                newTbls.Priority = Int32.Parse(newOrder[i]);

                pageId = newTbls.PageId;

                db.SaveChanges();
            }
            return Redirect("/Admin/GetActionResultForPage/" + pageId);
        }


        public ActionResult GetActionResultForPage(string id)
        {
            List<tbl_UserControl> tbl_UserControl = db.tbl_UserControl.Where(it => it.PageId == id).OrderBy(it => it.Priority).ToList();

            return View("Index", tbl_UserControl);
        }


        [HttpPost]
        public ActionResult Check(tbl_UserControl tbl_UserControl)
        {
            return Json(new {success = true});
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult Upload(IEnumerable<HttpPostedFileBase> file, string returnurl, string fileType)
        {
            try
            {
                var path = string.Empty;
                var fileName = string.Empty;

                if (fileType == "image")
                {
                    foreach (var item in file)
                    { 
                        if (item.ContentLength > 0)
                        {
                            fileName = Path.GetFileName(item.FileName);

                            path = Path.Combine(Server.MapPath("~/Img/"), fileName);

                            item.SaveAs(path);
                        }
                    }

                    ViewBag.Message = "Upload successful";
                    returnurl = returnurl + "&Upload=success&ImageUrl=/Img/" + fileName;

                    return Redirect(returnurl);
                }
                else
                {
                    foreach (var item in file)
                    { 
                        if (item.ContentLength > 0)
                        {
                            fileName = Path.GetFileName(item.FileName);

                            path = Path.Combine(Server.MapPath("~/Files/"), fileName);

                            item.SaveAs(path);
                        }
                    }

                    ViewBag.Message = "Upload successful";
                    returnurl = returnurl + "?Upload=success";

                    return Redirect(returnurl);
                }
            }
            catch
            {
                ViewBag.Message = "Upload failed";
                return Redirect(returnurl + "?Upload=fail");
            }
        }
    }
}
