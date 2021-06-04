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
    public class CuentaNegocio
    {
        CuentaMapper _cuentaMapper;

        public CuentaNegocio()
        {
            _cuentaMapper = new CuentaMapper();
        }

        public Cuenta Agregar (Cuenta cuenta)
        {
            TransactionResult resultado = _cuentaMapper.Insertar(cuenta);
            if (resultado.IsOk)
                return _cuentaMapper.Traer(cuenta.IdCliente);
            else
                return null;
        }

        public Cuenta Modificar (Cuenta cuenta)
        {
            TransactionResult resultado = _cuentaMapper.Insertar(cuenta);
            if (resultado.IsOk)
                return cuenta;
            else
                return _cuentaMapper.Traer(cuenta.IdCliente);
        }
    }
}
