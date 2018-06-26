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
    public class OperatorzyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Operatorzy
        public ActionResult Index(string szukanyOperator)
        {
            if (string.IsNullOrEmpty(szukanyOperator))
            {
                return View(db.Operatorzies.ToList());
            }
            else
            {
                var operatorzies = db.Operatorzies.Where(o => o.Nazwisko.Contains(szukanyOperator)).OrderBy(o => o.Nazwisko);
                return View(operatorzies.ToList());
            }

        }


        // GET: Operatorzy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operatorzy operatorzy = db.Operatorzies.Find(id);
            if (operatorzy == null)
            {
                return HttpNotFound();
            }
            return View(operatorzy);
        }

        // GET: Operatorzy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Operatorzy/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Imie,Nazwisko,Placa,Data_zatrrudnienia")] Operatorzy operatorzy)
        {
            if (ModelState.IsValid)
            {
                db.Operatorzies.Add(operatorzy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(operatorzy);
        }

        // GET: Operatorzy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operatorzy operatorzy = db.Operatorzies.Find(id);
            if (operatorzy == null)
            {
                return HttpNotFound();
            }
            return View(operatorzy);
        }

        // POST: Operatorzy/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Imie,Nazwisko,Placa,Data_zatrrudnienia")] Operatorzy operatorzy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operatorzy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(operatorzy);
        }

        // GET: Operatorzy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Operatorzy operatorzy = db.Operatorzies.Find(id);
            if (operatorzy == null)
            {
                return HttpNotFound();
            }
            return View(operatorzy);
        }

        // POST: Operatorzy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Operatorzy operatorzy = db.Operatorzies.Find(id);
            db.Operatorzies.Remove(operatorzy);
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
