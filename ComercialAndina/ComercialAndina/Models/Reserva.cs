using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercialAndina.ComercialAndina.Models
{
    public sealed class Reversa
    {
        public string CodigoOperacion { get; }
        public string Motivo { get; }
        public string Supervisor { get; }
        public DateTime FechaAutorizacion { get; }

        public Reversa(
            string codigo,
            string motivo,
            string supervisor)
        {
            CodigoOperacion = codigo;
            Motivo = motivo;
            Supervisor = supervisor;
            FechaAutorizacion = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{FechaAutorizacion:dd/MM/yyyy HH:mm:ss} | " +
                   $"Operación: {CodigoOperacion} | " +
                   $"Supervisor: {Supervisor} | Motivo: {Motivo}";
        }
    }
}
