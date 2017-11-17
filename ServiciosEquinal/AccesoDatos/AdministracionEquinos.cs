using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
   public class AdministracionEquinos
    {
        public bool CrearEquino ( Equino e, string instancia)
        {
            bool creado;
            Database Obj1 = ConexionInstancia.getInstancia(instancia);
            if(e != null)
            {
                DataTable dt = new DataTable();
                dt = Obj1.ExecuteDataSet("usp_SeleccionarEquino", e.nomequino.ToUpper()).Tables[0];
                if (dt.Rows.Count == 0)
                {
                    creado = true;

                    Obj1.ExecuteDataSet("usp_crearEquino", e.nomequino, e.pelaje, e.movimientos, e.modalidad, e.fenotipo, e.fortalezasDebilidades,instancia);
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
        public DataTable TraerEquinos(string instancia)
        {
            Database Obj1 = ConexionInstancia.getInstancia(instancia);
            DataTable dt = new DataTable();
            dt = Obj1.ExecuteDataSet("usp_SeleccionarEquinos").Tables[0];
            return dt;
        }
        public DataTable TraerEquinosVideo(string instancia)
        {
            Database Obj1 = ConexionInstancia.getInstancia(instancia);
            DataTable dt = new DataTable();
            dt = Obj1.ExecuteDataSet("usp_SeleccionarEquinosVideo").Tables[0];
            return dt;
        }


    }
}
