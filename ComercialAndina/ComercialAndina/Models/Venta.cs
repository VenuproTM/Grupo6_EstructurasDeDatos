using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercialAndina.ComercialAndina.Models
{
    public sealed class Venta
    {
        public string CodigoOperacion { get; }
        public string IdentificadorCliente { get; }
        public string Productos { get; }
        public int Cantidad { get; }
        public decimal PrecioUnitario { get; }
        public decimal Total => Cantidad * PrecioUnitario;
        public DateTime Fecha { get; }
        public string Estado { get; private set; } = "Registrada";

        public Venta(
            string codigo,
            string cliente,
            string productos,
            int cantidad,
            decimal precio,
            DateTime fecha)
        {
            CodigoOperacion = codigo;
            IdentificadorCliente = cliente;
            Productos = productos;
            Cantidad = cantidad;
            PrecioUnitario = precio;
            Fecha = fecha;
        }

        public void MarcarReversada()
        {
            Estado = "Reversada";
        }

        public override string ToString()
        {
            return $"{CodigoOperacion} | Cliente: {IdentificadorCliente} | " +
                   $"{Productos} | Cantidad: {Cantidad} | Total: S/ {Total:F2} | " +
                   $"Fecha: {Fecha:dd/MM/yyyy HH:mm} | Estado: {Estado}";
        }
    }
}
