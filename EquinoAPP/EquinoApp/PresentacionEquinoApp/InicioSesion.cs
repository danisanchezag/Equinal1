using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicaNegocio;

namespace PresentacionEquinoApp
{
    public partial class InicioSesion : Form
    {
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogicaInicioSesion li = new LogicaInicioSesion();

            if (string.IsNullOrWhiteSpace(Tb_nomusuario.Text.Trim()))
            {
                MessageBox.Show("Debe llenar el nombre del usuario");
            }
            else if (string.IsNullOrEmpty(Tb_Contrasena.Text.Trim()))
            {
                MessageBox.Show("Debe llenar el campo de contraseña");
            }
            else
            {
                string mensaje = li.verificarUsuario(Tb_nomusuario.Text, Tb_Contrasena.Text);
                if (string.IsNullOrWhiteSpace(mensaje))
                {
                    this.Hide();
                    MenuAdministrador ma = new MenuAdministrador();
                    ma.Show();

                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }

        private void InicioSesion_Load(object sender, EventArgs e)
        {
            
        }

        private void Tb_Contrasena_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Tb_nomusuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
