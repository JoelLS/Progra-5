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
            
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "NombreCategoria");
            return View();

           
        }

        public ActionResult index()
        {
            var prueba = db.Usuario.ToList();
            ViewBag.pb = prueba;

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

    }
}

