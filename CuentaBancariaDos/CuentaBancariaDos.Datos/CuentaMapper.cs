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
    public class CuentaMapper
    {
        public CuentaMapper()
        {

        }

        public List<Cuenta> TraerTodos()
        {
            string json = WebHelper.Get("cuenta");
            List<Cuenta> lst = MapList(json);
            return lst;
        }

        private List<Cuenta> MapList(string json)
        {
            List<Cuenta> resultado = JsonConvert.DeserializeObject<List<Cuenta>>(json);
            return resultado;
        }

        public Cuenta Traer(int idCliente)
        {
            string json2 = WebHelper.Get("cuenta/" + idCliente);
            Cuenta cta = Map(json2);
            return cta;
        }
        private Cuenta Map(string json2)
        {
            Cuenta resultado = JsonConvert.DeserializeObject<Cuenta>(json2);
            return resultado;
        }

        public TransactionResult Insertar (Cuenta cuenta)
        {
            NameValueCollection nvc = ReverseMap(cuenta);
            string json3 = WebHelper.Post("cuenta", nvc);
            TransactionResult resultado = JsonConvert.DeserializeObject<TransactionResult>(json3);
            return resultado;
        }

        private NameValueCollection ReverseMap(Cuenta cuenta)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("nroCuenta", cuenta.Numero.ToString());
            n.Add("descripcion", cuenta.Descripcion);
            n.Add("saldo", cuenta.Saldo.ToString());
            n.Add("fechaApertura", cuenta.FechaApertura.ToString("yyyy-MM-dd"));
            n.Add("activo", cuenta.Activo.ToString());
            n.Add("idCliente", cuenta.IdCliente.ToString()); 
            n.Add("id", cuenta.Id.ToString());
            return n;
        }
    }
}
