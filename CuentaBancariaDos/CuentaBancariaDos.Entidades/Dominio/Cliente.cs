using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancariaDos.Entidades.Dominio
{
    [DataContract]
    public class Cliente: Persona
    {
        int _id;
        string _usuario;
        Cuenta _cuenta;

        [DataMember(Name = "id")]
        public int Id { get => _id; set => _id = value; }
        [DataMember(Name = "usuario")]
        public string Usuario { get => _usuario; set => _usuario = value; }
        public Cuenta Cuenta { get => _cuenta; set => _cuenta = value; }

        public Cliente()
        {
        }

        public override string ToString()
        {
            return $"{this.Nombre}, {this.Apellido} - DNI: {this.Dni} // {this.Id}";
        }
    }
}
