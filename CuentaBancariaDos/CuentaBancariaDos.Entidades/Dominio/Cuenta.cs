using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancariaDos.Entidades.Dominio
{
    [DataContract]
    public class Cuenta
    {
        int _id;
        int _idCliente;
        int _numero;
        string _descripcion;
        bool _Activo;
        double _saldo;
        DateTime _fechaApertura;

        [DataMember(Name = "id")]
        public int Id { get => _id; set => _id = value; }
        [DataMember(Name = "idCliente")]
        public int IdCliente { get => _idCliente; set => _idCliente = value; }
        [DataMember(Name = "nroCuenta")]
        public int Numero { get => _numero; set => _numero = value; }
        [DataMember(Name = "descripcion")]
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        [DataMember(Name = "activo")]
        public bool Activo { get => _Activo; set => _Activo = value; }
        [DataMember(Name = "saldo")]
        public double Saldo { get => _saldo; set => _saldo = value; }
        [DataMember(Name = "fechaApertura")]
        public DateTime FechaApertura { get => _fechaApertura; set => _fechaApertura = value; }

        public Cuenta()
        {

        }
    }
}
