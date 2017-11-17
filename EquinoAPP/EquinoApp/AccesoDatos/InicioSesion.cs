using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data;


namespace AccesoDatos
{
  public class InicioSesion
    {

        public DataTable VerificarUsuario (string NomUsuario, string Contrasena)
        {
            string mensaje;
            Database Obj1 = EquinalSingleton.getInstancia(); 
      
            DataTable dt = new DataTable();
            dt = Obj1.ExecuteDataSet("usp_traerContrasena", NomUsuario).Tables[0];
            return dt;
        }
        public void CrearUsuario(Usuario u)
        {
            Database Obj2 = EquinalSingleton.getInstancia();
            if (u != null)
            {
                Obj2.ExecuteDataSet("usp_CrearUsuario", u.NomUsuario, u.Contrasenia, u.NomEmpresa, u.Instancia);
            }
        }

    }
}
