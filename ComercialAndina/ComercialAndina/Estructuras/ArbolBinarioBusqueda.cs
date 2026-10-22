using System;
using ComercialAndina.ComercialAndina.Models;

namespace ComercialAndina.ComercialAndina
{
    /// <summary>
    /// Implementa un árbol binario de búsqueda para almacenar ventas
    /// y localizarlas mediante su código de operación.
    /// Los códigos menores se ubican en el subárbol izquierdo
    /// y los códigos mayores, en el subárbol derecho.
    /// </summary>
    public sealed class ArbolBinarioBusqueda
    {
        /// <summary>
        /// Representa un nodo del árbol.
        /// Cada nodo almacena una venta y referencias a sus hijos izquierdo y derecho.
        /// </summary>
        private sealed class Nodo
        {
            // Venta almacenada en este nodo del árbol.
            public Venta Valor { get; }

            // Referencia al hijo que contiene un código menor.
            // Es null si el nodo no tiene hijo izquierdo.
            public Nodo Izquierdo { get; set; }

            // Referencia al hijo que contiene un código mayor.
            // Es null si el nodo no tiene hijo derecho.
            public Nodo Derecho { get; set; }

            /// <summary>
            /// Crea un nodo que contiene la venta recibida.
            /// Inicialmente, el nodo no tiene hijos.
            /// </summary>
            /// <param name="venta">Venta que se almacenará en el nodo.</param>
            public Nodo(Venta venta)
            {
                Valor = venta;
            }
        }

        // Referencia al nodo principal del árbol.
        // Si el árbol está vacío, la raíz es null.
        private Nodo raiz;

        /// <summary>
        /// Inserta una venta en la posición que le corresponde
        /// según el orden de su código de operación.
        /// No permite registrar códigos duplicados.
        /// </summary>
        /// <param name="venta">Venta que se desea insertar.</param>
        /// <exception cref="InvalidOperationException">
        /// Se produce cuando ya existe una venta con el mismo código.
        /// </exception>
        public void Insertar(Venta venta)
        {
            // Si no existe una raíz, la venta se convierte en el primer nodo.
            if (raiz == null)
            {
                raiz = new Nodo(venta);
                return;
            }

            // Comenzar la búsqueda de la posición de inserción desde la raíz.
            Nodo actual = raiz;

            // Recorrer el árbol hasta encontrar una posición vacía.
            while (true)
            {
                // Comparar el código de la nueva venta con el código del nodo actual.
                // La comparación ignora diferencias entre mayúsculas y minúsculas.
                int comparacion = string.Compare(
                    venta.CodigoOperacion,
                    actual.Valor.CodigoOperacion,
                    StringComparison.OrdinalIgnoreCase);

                // No se permiten dos ventas con códigos equivalentes.
                if (comparacion == 0)
                {
                    throw new InvalidOperationException(
                        "El código de operación ya existe.");
                }

                // Si el código es menor, debe ubicarse en el subárbol izquierdo.
                if (comparacion < 0)
                {
                    // Si el hijo izquierdo está vacío, insertar aquí la venta.
                    if (actual.Izquierdo == null)
                    {
                        actual.Izquierdo = new Nodo(venta);
                        return;
                    }

                    // Si ya existe un hijo izquierdo, continuar el recorrido por esa rama.
                    actual = actual.Izquierdo;
                }
                else
                {
                    // Si el código es mayor, debe ubicarse en el subárbol derecho.
                    if (actual.Derecho == null)
                    {
                        actual.Derecho = new Nodo(venta);
                        return;
                    }

                    // Si ya existe un hijo derecho, continuar por esa rama.
                    actual = actual.Derecho;
                }
            }
        }

        /// <summary>
        /// Busca una venta utilizando su código de operación.
        /// En cada paso compara el código solicitado con el del nodo actual
        /// y continúa por la rama izquierda o derecha según el resultado.
        /// </summary>
        /// <param name="codigo">Código de operación que se desea localizar.</param>
        /// <returns>
        /// La venta encontrada o null si el código no existe en el árbol.
        /// </returns>
        public Venta Buscar(string codigo)
        {
            // Iniciar la búsqueda desde la raíz.
            Nodo actual = raiz;

            // Continuar mientras exista un nodo que pueda revisarse.
            while (actual != null)
            {
                // Comparar el código solicitado con el código almacenado.
                int comparacion = string.Compare(
                    codigo,
                    actual.Valor.CodigoOperacion,
                    StringComparison.OrdinalIgnoreCase);

                // Si ambos códigos coinciden, devolver la venta encontrada.
                if (comparacion == 0)
                {
                    return actual.Valor;
                }

                // Si el código buscado es menor, avanzar al hijo izquierdo.
                // Si es mayor, avanzar al hijo derecho.
                actual = comparacion < 0
                    ? actual.Izquierdo
                    : actual.Derecho;
            }

            // Si se llega a una referencia null, el código no está en el árbol.
            return null;
        }
    }
}