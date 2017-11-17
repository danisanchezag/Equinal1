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
        public DataTable TraerInstancia(string NomUsuario)
        {
            string mensaje;
            Database Obj1 = EquinalSingleton.getInstancia();

            DataTable dt = new DataTable();
            dt = Obj1.ExecuteDataSet("usp_traerContrasena", NomUsuario).Tables[0];



            return dt;
        }
        public DataTable VerificarUsuario (string NomUsuario, string Contrasena)
        {
            string mensaje;
            Database Obj1 = EquinalSingleton.getInstancia(); 
      
            DataTable dt = new DataTable();
            dt = Obj1.ExecuteDataSet("usp_traerContrasena", NomUsuario).Tables[0];



            return dt;
        }
        public bool CrearUsuario(Usuario u)
        {
            bool creado;
            Database Obj2 = EquinalSingleton.getInstancia();
            if (u != null)
            {
                DataTable dt = new DataTable();
                dt = Obj2.ExecuteDataSet("usp_traerContrasena", u.NomUsuario).Tables[0];
                if (dt.Rows.Count != 0)
                {
                    creado = false;
                }
                else
                {
                    Obj2.ExecuteDataSet("usp_CrearUsuario", u.NomUsuario, u.Contrasenia, u.codEmpresa, u.Instancia);
                    creado = true;
                }

            }
            else
            {
                creado = false;
            }
            return creado;
        }

    }
}
