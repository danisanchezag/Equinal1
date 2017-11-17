using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using AccesoDatos;
using System.Data;

namespace ServiciosEquinal
{
    /// <summary>
    /// Descripción breve de WsAdminEmpresas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WsAdminEmpresas : System.Web.Services.WebService
    {

        [WebMethod]
        public String CrearEmpresa (string nombre, string nit, string replegal, string direccion, string ciudad, string correo , string telefono, string estado,string instancia)
        {
            StringBuilder sb = new StringBuilder();
            
            List<string> li = new List<string>();
            string mensaje;
            //sb = null;
            if (string.IsNullOrEmpty(nombre.Trim())|| string.IsNullOrWhiteSpace(nombre.Trim()))
            {
                li.Add("Debe ingresar el nombre de la empresa \n");

            } if (string.IsNullOrEmpty(nit.Trim()) || string.IsNullOrWhiteSpace(nit.Trim()))
            {
                li.Add("Debe ingresar el NIT de la empresa \n");
            }
             if (string.IsNullOrEmpty(replegal.Trim()) || string.IsNullOrWhiteSpace(replegal.Trim()))
            {
                li.Add("Debe ingresar el representante legal de la empresa \n");
            }
             if (string.IsNullOrEmpty(direccion.Trim()) || string.IsNullOrWhiteSpace(direccion.Trim()))
            {
                li.Add("Debe ingresar la direccion de la empresa \n");
            }
             if (string.IsNullOrEmpty(ciudad.Trim()) || string.IsNullOrWhiteSpace(ciudad.Trim()))
            {
                li.Add("Debe ingresar la ciudad de la empresa \n");
            }
             if (string.IsNullOrEmpty(correo.Trim()) || string.IsNullOrWhiteSpace(correo.Trim()))
            {
                li.Add("Debe ingresar el correo electrónico de la empresa \n");
            }
             if (string.IsNullOrEmpty(telefono.Trim()) || string.IsNullOrWhiteSpace(telefono.Trim()))
            {
                li.Add("Debe ingresar el teléfono de la empresa \n");
            }
             if (string.IsNullOrEmpty(estado.Trim()) || string.IsNullOrWhiteSpace(estado.Trim()))
            {
                li.Add("Debe ingresar el estado de la empresa \n");
            }
            if (string.IsNullOrEmpty(instancia.Trim()) || string.IsNullOrWhiteSpace(instancia.Trim()))
            {
                li.Add("Debe ingresar la instancia de la empresa \n");
            }

            if (li.Count == 0)
            {
                Empresa e = new Empresa { NomEmpresa = nombre, NitEmpresa = nit, RepresentanteLegal = replegal, DireccionEmpresa = direccion, CiudadEmpresa = ciudad, CorreoEmpresa = correo, TelefonoEmpresa = telefono, EstadoEmpresa = estado, InstanciaEmpresa=instancia };
                AdministracionEmpresas admon = new AdministracionEmpresas();
               bool creado= admon.CrearEmpresa(e);
                if (creado == false)
                {
                    mensaje = "La empresa no fue creada porque la empresa ya existe.";
                }
                else
                {
                    mensaje = null;
                }
                
            }
            else {
                mensaje = String.Join("\n"+" * ", li);
            }
            return mensaje;  
        }
        [WebMethod]
        public DataTable TraerEmpresa()
        {
            DataTable dt = new DataTable();
            AdministracionEmpresas admon = new AdministracionEmpresas();
            dt= admon.TraerEmpresas();
            return dt;
        }
        }
}
