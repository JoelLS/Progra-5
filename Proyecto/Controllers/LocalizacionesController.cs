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
    public class LocalizacionesController : Controller
    {
        private INDEPENDENT_EMPLOYEE_DBEntities db = new INDEPENDENT_EMPLOYEE_DBEntities();

        // GET: Localizaciones
        public ActionResult Index()
        {
            return View(db.Localizaciones.ToList());
        }

        // GET: Localizaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localizaciones localizaciones = db.Localizaciones.Find(id);
            if (localizaciones == null)
            {
                return HttpNotFound();
            }
            return View(localizaciones);
        }

        // GET: Localizaciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Localizaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLocalizacion,Longitud,Latitud")] Localizaciones localizaciones)
        {
            if (ModelState.IsValid)
            {
                db.Localizaciones.Add(localizaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(localizaciones);
        }

        // GET: Localizaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localizaciones localizaciones = db.Localizaciones.Find(id);
            if (localizaciones == null)
            {
                return HttpNotFound();
            }
            return View(localizaciones);
        }

        // POST: Localizaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLocalizacion,Longitud,Latitud")] Localizaciones localizaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(localizaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(localizaciones);
        }

        // GET: Localizaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localizaciones localizaciones = db.Localizaciones.Find(id);
            if (localizaciones == null)
            {
                return HttpNotFound();
            }
            return View(localizaciones);
        }

        // POST: Localizaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Localizaciones localizaciones = db.Localizaciones.Find(id);
            db.Localizaciones.Remove(localizaciones);
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
