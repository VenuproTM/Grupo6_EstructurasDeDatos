using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercialAndina.ComercialAndina.Models
{
    public sealed class Solicitud
    {
        public string CodigoOperacion { get; }
        public string IdentificadorCliente { get; }
        public string Tipo { get; }
        public string Detalle { get; }
        public DateTime FechaRecepcion { get; }

        public Solicitud(
            string codigo,
            string cliente,
            string tipo,
            string detalle)
        {
            CodigoOperacion = codigo;
            IdentificadorCliente = cliente;
            Tipo = tipo;
            Detalle = detalle;
            FechaRecepcion = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{FechaRecepcion:HH:mm:ss} | {Tipo} | " +
                   $"Operación: {CodigoOperacion} | " +
                   $"Cliente: {IdentificadorCliente} | {Detalle}";
        }
    }
}
