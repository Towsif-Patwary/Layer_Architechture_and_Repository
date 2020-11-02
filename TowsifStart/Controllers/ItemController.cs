using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Towsif_BLL.ChildManagers;
using Towsif_Entity.Entity;

namespace TowsifStart.Controllers
{
    public class ItemController : Controller
    {
        private ItemManager itemManager = new ItemManager();
        private SampleEntities db = new SampleEntities();
        public ActionResult Index()
        {
            return View(itemManager.GetAll());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Towsif_Item itm = itemManager.GetById((int)id);
            if (itm == null)
            {
                return HttpNotFound();
            }
            return View(itm);
        }
        public ActionResult Create()
        {
            //ViewBag.CategoryId = new SelectList(db.TowsifPos_ItemCategory, "CategoryId", "Name");
            Towsif_Item itm = new Towsif_Item();
            Towsif_Item lastitm = itemManager.GetAll().OrderByDescending(c => c.ItemId).FirstOrDefault();

            if (lastitm == null)
            {
                itm.Code = "ITM1";
            }
            else
            {
                itm.Code = "ITM" + (lastitm.ItemId + 1).ToString();
            }
            return View(itm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Towsif_Item itm)
        {
            if (ModelState.IsValid)
            {
                itemManager.Save(itm);
                return RedirectToAction("Index");
            }
            //ViewBag.CategoryId = new SelectList(db.TowsifPos_ItemCategory, "CategoryId", "Name", itm.CategoryId);
            return View(itm);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Towsif_Item itm = itemManager.GetById((int)id);
            if (itm == null)
            {
                return HttpNotFound();
            }
            //ViewBag.CategoryId = new SelectList(db.TowsifPos_ItemCategory, "CategoryId", "Name", itm.CategoryId);
            return View(itm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Towsif_Item itm)
        {
            if (ModelState.IsValid)
            {
                itemManager.Update(itm);
                return RedirectToAction("Index");
            }
            //ViewBag.CategoryId = new SelectList(db.TowsifPos_ItemCategory, "CategoryId", "Name", itm.CategoryId);
            return View(itm);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Towsif_Item itm = itemManager.GetById((int)id);
            if (itm == null)
            {
                return HttpNotFound();
            }
            return View(itm);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Towsif_Item itm = itemManager.GetById(id);
            itemManager.Remove(itm);
            return RedirectToAction("Index");
        }
        
    }
}