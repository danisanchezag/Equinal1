using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace AccesoDatos

{
  public class AdministracionEmpresas
    {


        public bool CrearEmpresa(Empresa e)
        {
            bool creado;
           
            Database Obj1 = EquinalSingleton.getInstancia();
            if (e != null)
            {
                DataTable dt = new DataTable();
                dt = Obj1.ExecuteDataSet("usp_SeleccionarEmpresa",e.NomEmpresa.ToUpper()).Tables[0];
                if (dt.Rows.Count == 0)
                {
                    creado = true;

                    Obj1.ExecuteDataSet("usp_CrearEmpresa", e.NomEmpresa, e.NitEmpresa, e.RepresentanteLegal, e.DireccionEmpresa, e.CiudadEmpresa, e.CorreoEmpresa, e.TelefonoEmpresa, e.EstadoEmpresa,e.InstanciaEmpresa);
                }
                else
                {
                    creado = false;

                }
               
            }
            else
            {
                creado = false;
            }
            return creado;
        }
        public DataTable TraerEmpresas()
        {
            Database Obj1 = EquinalSingleton.getInstancia();
            DataTable dt = new DataTable();
           dt= Obj1.ExecuteDataSet("usp_SeleccionarEmpresas").Tables[0];
            return dt;
        }
    }
}
