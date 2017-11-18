﻿using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
   public class ConexionInstancia
    { //ClaseActualizada
        static Database Instancia;
        private ConexionInstancia()
        {

        }
      //Garantizar una sola instancia
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
