    using CuentaBancariaDos.Entidades.Dominio;
using CuentaBancariaDos.Entidades.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancariaDos.Datos
{
    public class ClienteMapper
    {
        public ClienteMapper()
        {

        }

        public List<Cliente> TraerTodos()
        {
            string json = WebHelper.Get("cliente/847004");
            List<Cliente> lst = MapList(json);
            return lst;
        }

        private List<Cliente> MapList (string json)
        {
            List<Cliente> resultado = JsonConvert.DeserializeObject<List<Cliente>>(json);
            return resultado;
        }

        public TransactionResult Agregar (Cliente cliente)
        {
            NameValueCollection n = ReverseMap(cliente);
            string json = WebHelper.Post("cliente", n);
            TransactionResult resultado = JsonConvert.DeserializeObject<TransactionResult>(json);
            return resultado;
        }
        public TransactionResult Modificar(Cliente cliente)
        {
            NameValueCollection n = ReverseMap(cliente);
            string json = WebHelper.Put("cliente", n);
            TransactionResult resultado = JsonConvert.DeserializeObject<TransactionResult>(json);
            return resultado;
        }

        public TransactionResult Eliminar(Cliente cliente)
        {
            NameValueCollection n = ReverseMap(cliente);
            string json = WebHelper.Delete("cliente", n);
            TransactionResult resultado = JsonConvert.DeserializeObject<TransactionResult>(json);
            return resultado;
        }

        private NameValueCollection ReverseMap(Cliente cliente)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("id", cliente.Id.ToString());
            n.Add("usuario", "847004");
            n.Add("dni", cliente.Dni.ToString());
            n.Add("nombre", cliente.Nombre);
            n.Add("apellido", cliente.Apellido);
            n.Add("direccion", cliente.Domicilio);
            n.Add("telefono", cliente.Telefono);
            n.Add("email", cliente.Email);
            n.Add("fechaNacimiento", cliente.FechaNacimiento.ToString("yyyy-MM-dd"));
            return n;
        }
    }
}
