using CuentaBancariaDos.Datos;
using CuentaBancariaDos.Entidades.Dominio;
using CuentaBancariaDos.Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancariaDos.Negocio
{
    public class ClienteNegocio
    {
        private ClienteMapper _clienteMapper;
        private CuentaMapper _cuentaMapper;
        private List<Cliente> _listaClientes;
        private List<Cuenta> _listaCuentas;
        
        public ClienteNegocio()
        {
            _clienteMapper = new ClienteMapper();
            _cuentaMapper = new CuentaMapper();
            _listaClientes = new List<Cliente>();
            _listaCuentas = new List<Cuenta>();
        }

        public List<Cliente> Traer()
        {
            _listaClientes = _clienteMapper.TraerTodos();
            if (_listaClientes.Count == 0)
                throw new Exception("No existen clientes");
            return _listaClientes;
        }
        public List<Cliente> TraerConCuentas()
        {
            _listaClientes = _clienteMapper.TraerTodos();

            if (_listaClientes.Count == 0)
                throw new Exception("No existen clientes");

            _listaCuentas = _cuentaMapper.TraerTodos();

            foreach(Cliente cliente in _listaClientes)
            {
                foreach (Cuenta cuenta in _listaCuentas)
                {
                    if (cliente.Id==cuenta.IdCliente)
                    {
                        cliente.Cuenta = cuenta;
                    }
                }
            }
            return _listaClientes;
        }

        public TransactionResult Agregar(Cliente cliente)
        {
            BuscarCliente(cliente);
            TransactionResult resultado = _clienteMapper.Agregar(cliente);
            return resultado;
        }

        private void BuscarCliente(Cliente cliente)
        {
            foreach(Cliente clie in _listaClientes)
            {
                if (cliente.Dni == clie.Dni)
                    throw new Exception("Ya existe un cliente dado de alta con ese DNI");
            }
        }

        public TransactionResult Modificar(Cliente cliente)
        {
            TransactionResult resultado = _clienteMapper.Modificar(cliente);
            return resultado;
        }

        public TransactionResult Eliminar(Cliente cliente)
        {
            BuscarCuenta(cliente.Id);
            TransactionResult resultado = _clienteMapper.Eliminar(cliente);
            return resultado;
        }

        private void BuscarCuenta(int idCliente)
        {
            Cuenta cuenta = _cuentaMapper.Traer(idCliente);
            if (cuenta !=null)
                throw new Exception("El cliente no puede eliminarse, posee cuentas a su nombre");
        }
    }
}
