using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
   public class ConexionInstancia
    {
        static Database Instancia;
        private ConexionInstancia()
        {

        }
        public static Database getInstancia(string instancia)
        {
            if (Instancia == null)
            {
                Instancia = DatabaseFactory.CreateDatabase(instancia);

            }
            return Instancia;
        }

    }
}
