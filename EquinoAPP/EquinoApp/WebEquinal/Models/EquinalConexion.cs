using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEquinal.Models
{
    public class EquinalConexion
    {
        static Database Instancia;
        private EquinalConexion()
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
