using CuentaBancariaDos.Entidades.Dominio;
using CuentaBancariaDos.Negocio;
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
    public partial class FormCuentas : Form
    {
        ClienteNegocio _clienteNegocio;
        CuentaNegocio _cuentaNegocio;
        public FormCuentas()
        {
            _clienteNegocio = new ClienteNegocio();
            _cuentaNegocio = new CuentaNegocio();
            InitializeComponent();
        }

        private void FormCuentas_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                cmbClientes.DataSource = null;
                cmbClientes.DataSource = _clienteNegocio.TraerConCuentas();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDatosCuenta();
        }

        private void CargarDatosCuenta()
        {
            if(cmbClientes.DataSource!=null)
            {
                Cuenta cuentaClienteSeleccionado = ((Cliente)cmbClientes.SelectedItem).Cuenta;
                if(cuentaClienteSeleccionado!=null)
                {
                    txtNumCta.Text = cuentaClienteSeleccionado.Numero.ToString();
                    txtDescripcion.Text = cuentaClienteSeleccionado.Descripcion;
                    txtSaldo.Text = cuentaClienteSeleccionado.Saldo.ToString("0.00");
                    txtFechaAp.Text = cuentaClienteSeleccionado.FechaApertura.ToString("dd/MM/yyyy");
                    chkActivo.Checked = cuentaClienteSeleccionado.Activo;
                    txtSaldo.Enabled = true;
                    txtDescripcion.Enabled = false;
                }
                else
                {
                    LimpiarCampos();
                    txtSaldo.Enabled = false;
                    txtDescripcion.Enabled = true;
                }
            }
        }

        private void LimpiarCampos()
        {
            txtNumCta.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtSaldo.Text = string.Empty;
            txtFechaAp.Text = string.Empty;
            chkActivo.Checked = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            try
            {
                Cliente clienteSeleccionado = (Cliente)cmbClientes.SelectedItem;
                if(clienteSeleccionado.Cuenta==null)
                {
                    ValidarDescripcion();

                    clienteSeleccionado.Cuenta = new Cuenta();
                    clienteSeleccionado.Cuenta.Descripcion = txtDescripcion.Text;
                    clienteSeleccionado.Cuenta.IdCliente = clienteSeleccionado.Id;

                    clienteSeleccionado.Cuenta = _cuentaNegocio.Agregar(clienteSeleccionado.Cuenta);
                    MessageBox.Show("Cuenta agregada");                    
                }
                else
                {
                    ValidarSaldo();

                    clienteSeleccionado.Cuenta.Saldo = Convert.ToDouble(txtSaldo.Text);

                    clienteSeleccionado.Cuenta = _cuentaNegocio.Agregar(clienteSeleccionado.Cuenta);
                    MessageBox.Show("Cuenta actualizada");
                }

                cmbClientes.SelectedIndex = 0;
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void ValidarSaldo()
        {
            if(!double.TryParse(txtSaldo.Text, out double valor))
                throw new Exception("Debe ingresar un número");
        }

        private void ValidarDescripcion()
        {
            if (txtDescripcion.Text == string.Empty)
                throw new Exception("El campo no puede estar vacío");
        }

        private void Volver_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
