using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComercialAndina.ComercialAndina.Models;

namespace ComercialAndina.ComercialAndina.Estructuras
{
    public sealed class ListaEnlazadaVentas
    {
        private sealed class Nodo
        {
            public Venta Valor { get; }
            public Nodo Siguiente { get; set; }

            public Nodo(Venta valor)
            {
                Valor = valor;
            }
        }

        private Nodo cabeza;
        private Nodo cola;

        public int Cantidad { get; private set; }

        public void Agregar(Venta venta)
        {
            Nodo nuevo = new Nodo(venta);

            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                cola.Siguiente = nuevo;
            }

            cola = nuevo;
            Cantidad++;
        }

        public Venta Buscar(string codigo)
        {
            Nodo actual = cabeza;

            while (actual != null)
            {
                if (string.Equals(
                    actual.Valor.CodigoOperacion,
                    codigo,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return actual.Valor;
                }

                actual = actual.Siguiente;
            }

            return null;
        }

        public List<Venta> ObtenerTodas()
        {
            List<Venta> resultado = new List<Venta>();
            Nodo actual = cabeza;

            while (actual != null)
            {
                resultado.Add(actual.Valor);
                actual = actual.Siguiente;
            }

            return resultado;
        }
    }
}
