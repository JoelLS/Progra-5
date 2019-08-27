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
    public class UsuarioController : Controller
    {
        private INDEPENDENT_EMPLOYEE_DBEntities db = new INDEPENDENT_EMPLOYEE_DBEntities();

        // GET: Usuario
        public ActionResult Index()
        {
            var usuario = db.Usuario.Include(u => u.Canton).Include(u => u.Categoria).Include(u => u.Cita).Include(u => u.Distrito).Include(u => u.Provincia);
            return View(usuario.ToList());
        }

        [HttpPost]
        public ActionResult Index(int idcategoria)
        {
            var listafiltrada = db.Usuario.Include(u => u.Canton).Include(u => u.Categoria).Include(u => u.Cita).Include(u => u.Distrito).Include(u => u.Provincia).Where(o => o.IdCategoria == idcategoria).ToList();
            return View(listafiltrada);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.IdCanton = new SelectList(db.Canton, "IdCanton", "Nombre");
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "NombreCategoria");
            ViewBag.IdCita = new SelectList(db.Cita, "IdCita", "Descripcion");
            ViewBag.IdDistrito = new SelectList(db.Distrito, "IdDistrito", "Nombre");
            ViewBag.IdProvincia = new SelectList(db.Provincia, "IdProvincia", "Nombre");
            return View();
        }

        // POST: Usuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUsuario,CedulaUsuario,Nombre,Apellido1,Apellido2,IdCategoria,Telefono1,Telefono2,ServicioAdomicilio,Calificacion,Edad,Email,IdCita,Descripcion,IdProvincia,IdCanton,Detalle,IdDistrito,Longitud,Latitud")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCanton = new SelectList(db.Canton, "IdCanton", "Nombre", usuario.IdCanton);
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "NombreCategoria", usuario.IdCategoria);
            ViewBag.IdCita = new SelectList(db.Cita, "IdCita", "Descripcion", usuario.IdCita);
            ViewBag.IdDistrito = new SelectList(db.Distrito, "IdDistrito", "Nombre", usuario.IdDistrito);
            ViewBag.IdProvincia = new SelectList(db.Provincia, "IdProvincia", "Nombre", usuario.IdProvincia);
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCanton = new SelectList(db.Canton, "IdCanton", "Nombre", usuario.IdCanton);
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "NombreCategoria", usuario.IdCategoria);
            ViewBag.IdCita = new SelectList(db.Cita, "IdCita", "Descripcion", usuario.IdCita);
            ViewBag.IdDistrito = new SelectList(db.Distrito, "IdDistrito", "Nombre", usuario.IdDistrito);
            ViewBag.IdProvincia = new SelectList(db.Provincia, "IdProvincia", "Nombre", usuario.IdProvincia);
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsuario,CedulaUsuario,Nombre,Apellido1,Apellido2,IdCategoria,Telefono1,Telefono2,ServicioAdomicilio,Calificacion,Edad,Email,IdCita,Descripcion,IdProvincia,IdCanton,Detalle,IdDistrito,Longitud,Latitud")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCanton = new SelectList(db.Canton, "IdCanton", "Nombre", usuario.IdCanton);
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "NombreCategoria", usuario.IdCategoria);
            ViewBag.IdCita = new SelectList(db.Cita, "IdCita", "Descripcion", usuario.IdCita);
            ViewBag.IdDistrito = new SelectList(db.Distrito, "IdDistrito", "Nombre", usuario.IdDistrito);
            ViewBag.IdProvincia = new SelectList(db.Provincia, "IdProvincia", "Nombre", usuario.IdProvincia);
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
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
