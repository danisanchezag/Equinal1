using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace AccesoDatos
{
 public class EquinalSingleton
    {

        static Database Instancia;
        private EquinalSingleton()
        {

        }
        public static Database getInstancia()
        {
            if (Instancia == null)
            {
                Instancia = DatabaseFactory.CreateDatabase("Equinal");

            }
            return Instancia;
        }
    }
}
