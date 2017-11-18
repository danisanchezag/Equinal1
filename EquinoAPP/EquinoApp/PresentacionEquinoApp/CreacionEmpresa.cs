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
    public partial class CreacionEmpresa : Form
    { // Prueba lince
        public CreacionEmpresa()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogicaAdminEmpresas la = new LogicaAdminEmpresas();
            string mensaje;
       mensaje= la.CrearEmpresa(Tbnomempresa.Text, Tbnit.Text, Tbreplegal.Text, TbDireccion.Text, Tbciudad.Text, Tbcorreo.Text, tbTelefono.Text, cbEstado.Text,tbInstancia.Text);
            if(mensaje!= null)
            {
                MessageBox.Show(mensaje);
            }
        }

        private void CreacionEmpresa_Load(object sender, EventArgs e)
        {

        }
    }
}
