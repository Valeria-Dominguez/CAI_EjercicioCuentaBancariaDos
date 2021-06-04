using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuentaBancariaDos.GUI
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormClientes frmClientes = new FormClientes();
            frmClientes.Owner = this;
            frmClientes.Show();
            this.Hide();
        }

        private void btnCuentas_Click(object sender, EventArgs e)
        {
            FormCuentas frmCuentas = new FormCuentas();
            frmCuentas.Owner = this;
            frmCuentas.Show();
            this.Hide();
        }
    }
}
