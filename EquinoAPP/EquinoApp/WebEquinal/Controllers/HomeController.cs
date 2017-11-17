using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEquinal.Models;


namespace WebEquinal.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult InformacionEquino(string id)
        {
            InformacionEquino ie = new Models.InformacionEquino();
            DataTable dt = new DataTable();
           dt= ie.ObtenerInfo(id);
            
                Equino e = new Equino { idequino = dt.Rows[0]["idEquino"].ToString(), nomequino = dt.Rows[0]["NomEquino"].ToString(), modalidad = dt.Rows[0]["Modalidad"].ToString(), movimientos = dt.Rows[0]["Movimientos"].ToString(), pelaje = dt.Rows[0]["Pelaje"].ToString(), fenotipo = dt.Rows[0]["Fenotipo"].ToString(),fortalezasDebilidades = dt.Rows[0]["FortalezasDebilidades"].ToString() };
          return  Json(e, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EquinoInfo()
        {
            return View();
        }
    }
}