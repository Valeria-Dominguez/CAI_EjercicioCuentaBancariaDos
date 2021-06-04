using CuentaBancariaDos.Entidades.Dominio;
using CuentaBancariaDos.Entidades.Modelos;
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
    public partial class FormClientes : Form
    {
        ClienteNegocio _clienteNegocio;
        public FormClientes()
        {
            _clienteNegocio = new ClienteNegocio();
            InitializeComponent();
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void CargarLista()
        {
            lstClientes.DataSource = null;
            lstClientes.DataSource = _clienteNegocio.Traer();
            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            txtDNI.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDomicilio.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFechaNac.Text = string.Empty;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Validar();

                Cliente cliente = new Cliente();
                cliente.Dni = int.Parse(txtDNI.Text);
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.Domicilio = txtDomicilio.Text;
                cliente.Telefono = txtTelefono.Text;
                cliente.Email = txtEmail.Text; 
                cliente.FechaNacimiento = DateTime.Parse(txtFechaNac.Text+" 00:00:00");

                TransactionResult resultado = _clienteNegocio.Agregar(cliente);
                MessageBox.Show(resultado.ToString());
                CargarLista();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void Validar()
        {
            if 
                (
                txtDNI.Text == string.Empty ||
                txtNombre.Text == string.Empty ||
                txtApellido.Text == string.Empty ||
                txtDomicilio.Text == string.Empty ||
                txtTelefono.Text == string.Empty ||
                txtEmail.Text == string.Empty ||
                txtFechaNac.Text == string.Empty
                )
            throw new Exception("Ningún campo puede estar vacío");
            if
                (
                !int.TryParse(txtDNI.Text, out int entero)
                )
                throw new Exception("DNI: Debe ingresar un número");
            if
                (
                !DateTime.TryParse(txtFechaNac.Text+" 00:00:00", out DateTime fecha)
                )
                throw new Exception("Fecha inválida");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Validar();
                Cliente clienteSeleccionado = (Cliente)lstClientes.SelectedItem;

                Cliente cliente = new Cliente();
                cliente.Id = clienteSeleccionado.Id;
                cliente.Dni = int.Parse(txtDNI.Text);
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.Domicilio = txtDomicilio.Text;
                cliente.Telefono = txtTelefono.Text;
                cliente.Email = txtEmail.Text;
                cliente.FechaNacimiento = DateTime.Parse(txtFechaNac.Text + " 00:00:00");

                TransactionResult resultado = _clienteNegocio.Modificar(cliente);
                MessageBox.Show(resultado.ToString());
                CargarLista();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente clienteSeleccionado = (Cliente)lstClientes.SelectedItem;
                TransactionResult resultado = _clienteNegocio.Eliminar(clienteSeleccionado);
                MessageBox.Show(resultado.ToString());
                CargarLista();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }   
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCliente();
        }

        private void CargarCliente()
        {
            if(lstClientes.DataSource!=null)
            {
                Cliente clienteSeleccionado = (Cliente)lstClientes.SelectedItem;
                txtDNI.Text = clienteSeleccionado.Dni.ToString();
                txtNombre.Text = clienteSeleccionado.Nombre;
                txtApellido.Text = clienteSeleccionado.Apellido;
                txtDomicilio.Text = clienteSeleccionado.Domicilio;
                txtTelefono.Text = clienteSeleccionado.Telefono;
                txtEmail.Text = clienteSeleccionado.Email;
                txtFechaNac.Text = clienteSeleccionado.FechaNacimiento.ToString("dd/MM/yyyy");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
