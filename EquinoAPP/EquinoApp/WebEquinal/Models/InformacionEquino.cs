using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace WebEquinal.Models
{
    public class InformacionEquino
    {

        Database obj = EquinalConexion.getInstancia();

        public DataTable ObtenerInfo(string idequino) {
            DataTable dt = new DataTable();
         
            dt = obj.ExecuteDataSet("usp_SeleccionarEquino",idequino).Tables[0];
            return dt;
        }
    }
}