using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComercialAndina.ComercialAndina.Models;

namespace ComercialAndina.ComercialAndina
{
    public sealed class ArbolBinarioBusqueda
    {
        private sealed class Nodo
        {
            public Venta Valor { get; }
            public Nodo Izquierdo { get; set; }
            public Nodo Derecho { get; set; }

            public Nodo(Venta venta)
            {
                Valor = venta;
            }
        }

        private Nodo raiz;

        public void Insertar(Venta venta)
        {
            if (raiz == null)
            {
                raiz = new Nodo(venta);
                return;
            }

            Nodo actual = raiz;

            while (true)
            {
                int comparacion = string.Compare(
                    venta.CodigoOperacion,
                    actual.Valor.CodigoOperacion,
                    StringComparison.OrdinalIgnoreCase);

                if (comparacion == 0)
                {
                    throw new InvalidOperationException(
                        "El código de operación ya existe.");
                }

                if (comparacion < 0)
                {
                    if (actual.Izquierdo == null)
                    {
                        actual.Izquierdo = new Nodo(venta);
                        return;
                    }

                    actual = actual.Izquierdo;
                }
                else
                {
                    if (actual.Derecho == null)
                    {
                        actual.Derecho = new Nodo(venta);
                        return;
                    }

                    actual = actual.Derecho;
                }
            }
        }

        public Venta Buscar(string codigo)
        {
            Nodo actual = raiz;

            while (actual != null)
            {
                int comparacion = string.Compare(
                    codigo,
                    actual.Valor.CodigoOperacion,
                    StringComparison.OrdinalIgnoreCase);

                if (comparacion == 0)
                {
                    return actual.Valor;
                }

                actual = comparacion < 0
                    ? actual.Izquierdo
                    : actual.Derecho;
            }

            return null;
        }
    }
}
