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
    public partial class CreacionUsuario : Form
    {
        public CreacionUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogicaInicioSesion li = new LogicaInicioSesion();
           string mensaje=(( li.CrearUsuario(Tbnomusuario.Text, TbContrasenia.Text, Convert.ToInt32(cbEmpresas.SelectedValue.ToString()), Tbinstancia.Text)).ToString());
            if (mensaje == null)
            {

            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void CreacionUsuario_Load(object sender, EventArgs e)
        {
            LogicaAdminEmpresas la = new LogicaAdminEmpresas();
            DataTable dt = new DataTable();
            dt = la.traerEmpresas();

           cbEmpresas.DataSource= dt;
            cbEmpresas.DisplayMember = "NomEmpresa";
            cbEmpresas.ValueMember = "CodEmpresa";
        }
    }
}
