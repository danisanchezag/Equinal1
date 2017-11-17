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
    public partial class MenuAdministrador : Form
    {
        public MenuAdministrador()
        {
            InitializeComponent();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreacionUsuario cu = new CreacionUsuario();
            cu.Show();

        }

        private void MenuAdministrador_Load(object sender, EventArgs e)
        {
            LogicaAdminEmpresas la = new LogicaAdminEmpresas();
            dgEmpresas.DataSource= la.traerEmpresas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreacionEmpresa ce = new CreacionEmpresa();
            ce.Show();

        }
    }
}
