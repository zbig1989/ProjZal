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
    public class MaszynyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Maszyny
        public ActionResult Index(string szukanaMaszyna)
        {
            if (string.IsNullOrEmpty(szukanaMaszyna))
            {
                var maszynies = db.Maszynies.Include(m => m.Hale).OrderBy(m => m.Maszyna_Nazwa);
                return View(maszynies.ToList());
            }
            else
            {
                var maszynies = db.Maszynies.Include(m => m.Hale).Where(m=>m.Maszyna_Nazwa.Contains(szukanaMaszyna)).OrderBy(m => m.Maszyna_Nazwa);
                return View(maszynies.ToList());
            }
        }

        // GET: Maszyny/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maszyny maszyny = db.Maszynies.Find(id);
            if (maszyny == null)
            {
                return HttpNotFound();
            }
            return View(maszyny);
        }

        // GET: Maszyny/Create
        public ActionResult Create()
        {
            ViewBag.HaleId = new SelectList(db.Hales, "Id", "Hala_Nazwa");
            return View();
        }

        // POST: Maszyny/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Maszyna_Nazwa,Numer_ewidencji,Data_uruchomienia,HalaId,HaleId")] Maszyny maszyny)
        {
            if (ModelState.IsValid)
            {
                db.Maszynies.Add(maszyny);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HaleId = new SelectList(db.Hales, "Id", "Hala_Nazwa", maszyny.HaleId);
            return View(maszyny);
        }

        // GET: Maszyny/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maszyny maszyny = db.Maszynies.Find(id);
            if (maszyny == null)
            {
                return HttpNotFound();
            }
            ViewBag.HaleId = new SelectList(db.Hales, "Id", "Hala_Nazwa", maszyny.HaleId);
            return View(maszyny);
        }

        // POST: Maszyny/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Maszyna_Nazwa,Numer_ewidencji,Data_uruchomienia,HalaId,HaleId")] Maszyny maszyny)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maszyny).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HaleId = new SelectList(db.Hales, "Id", "Hala_Nazwa", maszyny.HaleId);
            return View(maszyny);
        }

        // GET: Maszyny/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maszyny maszyny = db.Maszynies.Find(id);
            if (maszyny == null)
            {
                return HttpNotFound();
            }
            return View(maszyny);
        }

        // POST: Maszyny/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maszyny maszyny = db.Maszynies.Find(id);
            db.Maszynies.Remove(maszyny);
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
