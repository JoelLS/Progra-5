using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class DistritoController : Controller
    {
        private INDEPENDENT_EMPLOYEE_DBEntities db = new INDEPENDENT_EMPLOYEE_DBEntities();

        // GET: Distrito
        public ActionResult Index()
        {
            var distrito = db.Distrito.Include(d => d.Canton);
            return View(distrito.ToList());
        }

        // GET: Distrito/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distrito distrito = db.Distrito.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // GET: Distrito/Create
        public ActionResult Create()
        {
            ViewBag.IdCanton = new SelectList(db.Canton, "IdCanton", "Nombre");
            return View();
        }

        // POST: Distrito/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDistrito,Nombre,IdCanton")] Distrito distrito)
        {
            if (ModelState.IsValid)
            {
                db.Distrito.Add(distrito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCanton = new SelectList(db.Canton, "IdCanton", "Nombre", distrito.IdCanton);
            return View(distrito);
        }

        // GET: Distrito/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distrito distrito = db.Distrito.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCanton = new SelectList(db.Canton, "IdCanton", "Nombre", distrito.IdCanton);
            return View(distrito);
        }

        // POST: Distrito/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDistrito,Nombre,IdCanton")] Distrito distrito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(distrito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCanton = new SelectList(db.Canton, "IdCanton", "Nombre", distrito.IdCanton);
            return View(distrito);
        }

        // GET: Distrito/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distrito distrito = db.Distrito.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // POST: Distrito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Distrito distrito = db.Distrito.Find(id);
            db.Distrito.Remove(distrito);
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
