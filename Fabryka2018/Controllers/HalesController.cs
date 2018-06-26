using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fabryka2018.Models;

namespace Fabryka2018.Controllers
{
    public class HalesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Hales
        public ActionResult Index(string szukanaHala)
        {
            if (string.IsNullOrEmpty(szukanaHala))
            {
                return View(db.Hales.ToList());
            }
            else
            {
                var hales = db.Hales.Where(h=>h.Hala_Nazwa.Contains(szukanaHala)).OrderBy(h=> h.Hala_Nazwa);
                return View(hales.ToList());
            }
        }

        // GET: Hales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hale hale = db.Hales.Find(id);
            if (hale == null)
            {
                return HttpNotFound();
            }
            return View(hale);
        }

        // GET: Hales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hales/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Hala_Nazwa,Adres")] Hale hale)
        {
            if (ModelState.IsValid)
            {
                db.Hales.Add(hale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hale);
        }

        // GET: Hales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hale hale = db.Hales.Find(id);
            if (hale == null)
            {
                return HttpNotFound();
            }
            return View(hale);
        }

        // POST: Hales/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Hala_Nazwa,Adres")] Hale hale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hale);
        }

        // GET: Hales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hale hale = db.Hales.Find(id);
            if (hale == null)
            {
                return HttpNotFound();
            }
            return View(hale);
        }

        // POST: Hales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hale hale = db.Hales.Find(id);
            db.Hales.Remove(hale);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
