using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancariaDos.Entidades.Dominio
{
    [DataContract]
    public abstract class Persona
    {
        int _dni;
        string _nombre;
        string _apellido;
        string _domicilio;
        string _telefono;
        string _email;
        DateTime _fechaNacimiento;

        [DataMember(Name = "dni")]
        public int Dni { get => _dni; set => _dni = value; }
        [DataMember(Name = "nombre")]
        public string Nombre { get => _nombre; set => _nombre = value; }
        [DataMember(Name = "apellido")]
        public string Apellido { get => _apellido; set => _apellido = value; }
        [DataMember(Name = "direccion")]
        public string Domicilio { get => _domicilio; set => _domicilio = value; }
        [DataMember(Name = "telefono")]
        public string Telefono { get => _telefono; set => _telefono = value; }
        [DataMember(Name = "email")]
        public string Email { get => _email; set => _email = value; }
        [DataMember(Name = "fechaNacimiento")]
        public DateTime FechaNacimiento { get => _fechaNacimiento; set => _fechaNacimiento = value; }

        protected Persona ()
        {

        }

    }
}
