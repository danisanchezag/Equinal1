using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LogicaNegocio.wsInicio;
using System.Data;
namespace LogicaNegocio
{
  public  class LogicaInicioSesion
    {
        WsInicioSesion ws;
        public string CrearUsuario(string Nomusuario,string Contrasenia, int codEmpresa, string Instancia)
        {
             ws = new WsInicioSesion();
            string mensaje;
            
           mensaje= ws.CrearUsuario(Nomusuario, Contrasenia, codEmpresa, Instancia);


        return mensaje;
        }
        public string verificarUsuario(string nombre, string contrasena)
        {
            ws = new WsInicioSesion();
         string mensaje=   ws.verificarUsuario(nombre, contrasena);

            return mensaje;
        }

    }
}
