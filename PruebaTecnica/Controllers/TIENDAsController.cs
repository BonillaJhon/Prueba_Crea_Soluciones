using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaTecnica;

namespace PruebaTecnica.Controllers
{
    public class TIENDAsController : Controller
    {
        private PPRACTICAEntities2 db = new PPRACTICAEntities2();

        // GET: TIENDAs
        public ActionResult Index()
        {
            return View(db.TIENDA.ToList());
        }

        // GET: TIENDAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIENDA tIENDA = db.TIENDA.Find(id);
            if (tIENDA == null)
            {
                return HttpNotFound();
            }
            return View(tIENDA);
        }

        // GET: TIENDAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIENDAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,FECHADEAPERTURA")] TIENDA tIENDA)
        {
            if (ModelState.IsValid)
            {
                db.TIENDA.Add(tIENDA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIENDA);
        }

        // GET: TIENDAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIENDA tIENDA = db.TIENDA.Find(id);
            if (tIENDA == null)
            {
                return HttpNotFound();
            }
            return View(tIENDA);
        }

        // POST: TIENDAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,FECHADEAPERTURA")] TIENDA tIENDA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIENDA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIENDA);
        }

        // GET: TIENDAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIENDA tIENDA = db.TIENDA.Find(id);
            if (tIENDA == null)
            {
                return HttpNotFound();
            }
            return View(tIENDA);
        }

        // POST: TIENDAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIENDA tIENDA = db.TIENDA.Find(id);
            db.TIENDA.Remove(tIENDA);
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
