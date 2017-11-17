using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using AccesoDatos;
using System.Data;

namespace ServiciosEquinal
{
    /// <summary>
    /// Descripción breve de WsInicioSesion
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WsInicioSesion : System.Web.Services.WebService
    {

   
        [WebMethod]
        public String CrearUsuario(string Nomusuario, string Contrasenia, int codEmpresa, string Instancia)
        {
            List<string> li = new List<string>();
            string mensaje;
            Usuario u;
           

            if (string.IsNullOrWhiteSpace(Nomusuario))
            {

                li.Add("* Debe llenar el nombre del usuario");
            }

                if (string.IsNullOrWhiteSpace(Contrasenia))
                {
                li.Add("* Debe llenar la contraseña");
                }
                
                if (string.IsNullOrWhiteSpace(Instancia))
                {
                li.Add("* Debe llenar la instancia");
                }

            if (li.Count == 0)
            {

                string newpass = PasswordStorage.CreateHash(Contrasenia);
                u = new Usuario { NomUsuario = Nomusuario, Contrasenia = newpass, codEmpresa = codEmpresa, Instancia = Instancia };
                InicioSesion i = new InicioSesion();
              bool creado=  i.CrearUsuario(u);
                if (creado == false)
                {
                    mensaje = "El usuario no fue creado por que el nombre de usuario ya existe.";
                }
                else
                {
                    mensaje = null;
                }
            }
            else
            {
                mensaje = String.Join("\n" , li);
            }

            return mensaje;

        }
        [WebMethod]
        public string verificarUsuario(string nombre, string contrasena)
        {
            InicioSesion i = new InicioSesion();
            DataTable dt = new DataTable();
            dt = i.VerificarUsuario(nombre, contrasena);
            string mensaje;
            if (dt.Rows.Count > 0)
            {
                string pass = dt.Rows[0]["Contrasenia"].ToString();
                bool psw = PasswordStorage.VerifyPassword(contrasena, pass);
                if (psw == true)
                {
                    mensaje = "";
                   
                }
                else
                {
                    mensaje = "Contraseña incorrecta";
                }
            }
            else
            {
                mensaje = "Usuario incorrecto";
            }
            return mensaje;
        }
        [WebMethod]
        public string TraerInstancia(string nombre)
        {
            InicioSesion i = new InicioSesion();
            DataTable dt = new DataTable();
            dt = i.TraerInstancia(nombre);
            string instancia = dt.Rows[0]["Instancia"].ToString();
            return instancia;
        }

        }
}