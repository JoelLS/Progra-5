using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    public class HomeController : Controller
    {
        private INDEPENDENT_EMPLOYEE_DBEntities db = new INDEPENDENT_EMPLOYEE_DBEntities();
        public ActionResult Index()
        {
            var usuario = db.Usuario.Include(u => u.Canton).Include(u => u.Categoria).Include(u => u.Cita).Include(u => u.Distrito).Include(u => u.Provincia);
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "NombreCategoria");
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public class ConexionBD
        {

        }

