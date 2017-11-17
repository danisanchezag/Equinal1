using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using AccesoDatos;
using System.Data;

namespace ServiciosEquinal
{
    /// <summary>
    /// Descripción breve de WsAdministrarEquinos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WsAdministrarEquinos : System.Web.Services.WebService
    {

        [WebMethod]
        public string CrearEquino(string nomequino,string modalidad,string pelaje,string movimientos,string fenotipo, string fortalezasDebilidades, string instancia)
        {
            List<string> li = new List<string>();
            string mensaje;
            if (string.IsNullOrEmpty(nomequino.Trim()) || string.IsNullOrWhiteSpace(nomequino.Trim()))
            {
                li.Add("* Debe ingresar el nombre del equino \n");

            }
            if (string.IsNullOrEmpty(modalidad.Trim()) || string.IsNullOrWhiteSpace(modalidad.Trim()))
            {
                li.Add("* Debe ingresar la modalidad de paso del equino \n");
            }
            if (string.IsNullOrEmpty(pelaje.Trim()) || string.IsNullOrWhiteSpace(pelaje.Trim()))
            {
                li.Add("* Debe ingresar las caracteristicas del pelaje del equino \n");
            }
            if (string.IsNullOrEmpty(movimientos.Trim()) || string.IsNullOrWhiteSpace(movimientos.Trim()))
            {
                li.Add("* Debe ingresar las caracteristicas de los movimientos del equino \n");
            }
            if (string.IsNullOrEmpty(fenotipo.Trim()) || string.IsNullOrWhiteSpace(fenotipo.Trim()))
            {
                li.Add("* Debe ingresar las caracteristicas del fenotipo del equino \n");
            }
            if (string.IsNullOrEmpty(fortalezasDebilidades.Trim()) || string.IsNullOrWhiteSpace(fortalezasDebilidades.Trim()))
            {
                li.Add("Debe ingresar las fortalezas y debilidades del equino \n");
            }
            if (li.Count == 0)
            {
                Equino e = new Equino { nomequino = nomequino, modalidad = modalidad, pelaje = pelaje, fenotipo = fenotipo, movimientos = movimientos, fortalezasDebilidades = fortalezasDebilidades };
               AdministracionEquinos admon = new AdministracionEquinos();
                bool creado = admon.CrearEquino(e,instancia);
                if (creado == false)
                {
                    mensaje = "El equino no fue creado porque ya existe.";
                }
                else
                {
                    mensaje = null;
                }

            }
            else
            {
                mensaje = String.Join("\n" + " * ", li);
            }




            return mensaje;
        }
        [WebMethod]
        public DataTable TraerEquinos(string instancia)
        {
            DataTable dt = new DataTable();
            AdministracionEquinos admon = new AdministracionEquinos();
            dt = admon.TraerEquinos(instancia);
            return dt;
        }
        public DataTable TraerEquinosVideo(string instancia)
        {
            DataTable dt = new DataTable();
            AdministracionEquinos admon = new AdministracionEquinos();
            dt = admon.TraerEquinosVideo(instancia);
            return dt;
        }
    }
}
