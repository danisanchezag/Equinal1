using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using AccesoDatos;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ServiciosEquinal
{
    /// <summary>
    /// Descripción breve de WsSincronizacion
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WsSincronizacion : System.Web.Services.WebService
    {

        [WebMethod]
        public string SincronizarEquinos()
        {
            String instancia;
            Database Obj1 = EquinalSingleton.getInstancia();
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            dt = Obj1.ExecuteDataSet("usp_SeleccionarEmpresas").Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                instancia = dt.Rows[i]["InstanciaEmpresa"].ToString();
               Database obj2= ConexionInstancia.getInstancia(instancia);
                dt1 = obj2.ExecuteDataSet("usp_SeleccionEquinos").Tables[0];
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    string idEquino = dt1.Rows[i]["IdEquino"].ToString();
                    string NomEquino = dt1.Rows[i]["NomEquino"].ToString();
                    string modalidad = dt1.Rows[i]["Modalidad"].ToString();
                    string pelaje = dt1.Rows[i]["Pelaje"].ToString();
                    string Movimientos = dt1.Rows[i]["Movimientos"].ToString();
                    string Fenotipo = dt1.Rows[i]["Fenotipo"].ToString();
                    string FortalezasDebilidades = dt1.Rows[i]["FortalezasDebilidades"].ToString();
                    Obj1.ExecuteDataSet("usp_crearEquino", idEquino, NomEquino, modalidad, pelaje, Movimientos, Fenotipo, FortalezasDebilidades);
                    obj2.ExecuteDataSet("usp_ActualizarEquino", idEquino);
                }



            }
          



            return "Sincronizados Equinos";
        }
        [WebMethod]
        public string SincronizarVideosEquinos()
        {
            String instancia;
            Database Obj1 = EquinalSingleton.getInstancia();
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            dt = Obj1.ExecuteDataSet("usp_SeleccionarEmpresas").Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                instancia = dt.Rows[i]["InstanciaEmpresa"].ToString();
                Database obj2 = ConexionInstancia.getInstancia(instancia);
                dt1 = obj2.ExecuteDataSet("[usp_SeleccionarEquinosVideo").Tables[0];
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    string idVideo = dt1.Rows[i]["idVideo"].ToString();
                    string idEquino = dt1.Rows[i]["idEquino"].ToString();
                    string RutaVideo = dt1.Rows[i]["RutaVideo"].ToString();
                    Obj1.ExecuteDataSet("usp_AgregarVideo", idVideo,idEquino,RutaVideo);
                    obj2.ExecuteDataSet("usp_ActualizarVideo", idVideo);
                }



            }




            return "Sincrronizados Videos";
        }
    }
}
