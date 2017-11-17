using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogicaNegocio.wsadmin;
using System.Data;

namespace LogicaNegocio
{
   public class LogicaAdminEmpresas
    {

        public DataTable traerEmpresas()
        {
            WsAdminEmpresas ws = new WsAdminEmpresas();
            DataTable dt = new DataTable();
                dt=ws.TraerEmpresa();
            return dt;
        }
        public string CrearEmpresa(string nombre, string nit, string replegal, string direccion, string ciudad, string correo, string telefono, string estado,string instancia)
        {

            string mensaje;
           
            WsAdminEmpresas ws = new WsAdminEmpresas();
           
           mensaje= ws.CrearEmpresa(nombre, nit, replegal, direccion, ciudad, correo, telefono, estado,instancia);
         
            return mensaje;

        }
    }
}
