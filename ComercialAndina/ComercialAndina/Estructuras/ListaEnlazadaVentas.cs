using System;
using System.Collections.Generic;
using ComercialAndina.ComercialAndina.Models;

namespace ComercialAndina.ComercialAndina.Estructuras
{
    /// <summary>
    /// Implementa una lista enlazada simple para almacenar y administrar ventas.
    /// Cada nodo contiene una venta y una referencia al siguiente nodo.
    /// Permite agregar, buscar, consultar, ordenar y combinar ventas.
    /// </summary>
    public sealed class ListaEnlazadaVentas
    {
        /// <summary>
        /// Representa un nodo de la lista enlazada.
        /// Almacena una venta y la referencia al siguiente nodo.
        /// Esta clase es privada porque solo se utiliza dentro de la lista.
        /// </summary>
        private sealed class Nodo
        {
            // Venta almacenada en el nodo. No se puede reasignar después de construirlo.
            public Venta Valor { get; }

            // Referencia al siguiente nodo; es null cuando no existe otro nodo.
            public Nodo Siguiente { get; set; }

            /// <summary>
            /// Crea un nodo que contiene la venta recibida.
            /// </summary>
            /// <param name="valor">Venta que se almacenará en el nodo.</param>
            public Nodo(Venta valor)
            {
                Valor = valor;
            }
        }

        // Referencia al primer nodo de la lista.
        // Si la lista está vacía, cabeza es null.
        private Nodo cabeza;

        // Referencia al último nodo de la lista.
        // Permite agregar nuevas ventas al final sin recorrer todos los nodos.
        private Nodo cola;

        /// <summary>
        /// Obtiene la cantidad de ventas almacenadas en la lista.
        /// El valor solo puede modificarse desde esta clase.
        /// </summary>
        public int Cantidad { get; private set; }

        /// <summary>
        /// Agrega una venta al final de la lista enlazada.
        /// Si la lista está vacía, el nuevo nodo será el primero.
        /// En caso contrario, se enlaza después del último nodo existente.
        /// </summary>
        /// <param name="venta">Venta que se desea agregar.</param>
        /// <exception cref="ArgumentNullException">
        /// Se produce si se intenta agregar una venta nula.
        /// </exception>
        public void Agregar(Venta venta)
        {
            // Evitar almacenar referencias nulas en la estructura.
            if (venta == null)
                throw new ArgumentNullException(nameof(venta));

            // Crear el nodo que contendrá la nueva venta.
            Nodo nuevo = new Nodo(venta);

            // Si no hay primer nodo, la lista está vacía.
            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                // Enlazar el último nodo con el nuevo nodo.
                cola.Siguiente = nuevo;
            }

            // El nuevo nodo pasa a ser el último de la lista.
            cola = nuevo;

            // Actualizar el número de elementos almacenados.
            Cantidad++;
        }

        /// <summary>
        /// Busca una venta utilizando su código de operación.
        /// Recorre secuencialmente la lista desde el primer nodo.
        /// La comparación ignora diferencias entre mayúsculas y minúsculas.
        /// </summary>
        /// <param name="codigo">Código de operación que se desea buscar.</param>
        /// <returns>
        /// La venta encontrada o null si el código está vacío
        /// o no existe una venta con ese código.
        /// </returns>
        public Venta Buscar(string codigo)
        {
            // No se realiza la búsqueda si el código está vacío o contiene espacios.
            if (string.IsNullOrWhiteSpace(codigo))
                return null;

            // Comenzar el recorrido desde el primer nodo.
            Nodo actual = cabeza;

            // Continuar mientras existan nodos por revisar.
            while (actual != null)
            {
                // Comparar el código solicitado con el código de la venta actual.
                if (string.Equals(
                    actual.Valor.CodigoOperacion,
                    codigo.Trim(),
                    StringComparison.OrdinalIgnoreCase))
                {
                    // Devolver la venta cuando se encuentra una coincidencia.
                    return actual.Valor;
                }

                // Avanzar al siguiente nodo de la lista.
                actual = actual.Siguiente;
            }

            // Devolver null si se recorrió toda la lista sin encontrar la venta.
            return null;
        }

        /// <summary>
        /// Obtiene todas las ventas almacenadas y las devuelve en una lista
        /// de tipo List<Venta>, conservando el orden actual de los nodos.
        /// La colección devuelta es independiente de la estructura enlazada,
        /// aunque contiene referencias a los mismos objetos Venta.
        /// </summary>
        /// <returns>Lista con las ventas almacenadas.</returns>
        public List<Venta> ObtenerTodas()
        {
            // Crear una colección que recibirá las ventas encontradas.
            List<Venta> resultado = new List<Venta>();

            // Iniciar el recorrido desde la cabeza.
            Nodo actual = cabeza;

            // Copiar las referencias a las ventas en la colección de resultado.
            while (actual != null)
            {
                resultado.Add(actual.Valor);

                // Avanzar al siguiente nodo.
                actual = actual.Siguiente;
            }

            // Entregar la colección con todas las ventas.
            return resultado;
        }

        /// <summary>
        /// Ordena los nodos por código de operación ascendente.
        /// Utiliza el método de inserción sobre una lista enlazada:
        /// toma cada nodo y lo coloca en su posición dentro de la lista ordenada.
        /// Reorganiza los enlaces existentes sin crear nodos nuevos.
        /// </summary>
        public void OrdenarPorCodigo()
        {
            // Lista auxiliar que se irá construyendo en orden.
            Nodo ordenada = null;

            // Nodo que se procesará de la lista original.
            Nodo actual = cabeza;

            // Procesar todos los nodos de la lista.
            while (actual != null)
            {
                // Guardar el siguiente nodo para no perder el resto de la lista
                // al modificar el enlace del nodo actual.
                Nodo siguiente = actual.Siguiente;

                // Si la lista ordenada está vacía o el código actual
                // es menor que el primero, insertar el nodo al principio.
                if (ordenada == null ||
                    CompararCodigos(
                        actual.Valor.CodigoOperacion,
                        ordenada.Valor.CodigoOperacion) < 0)
                {
                    actual.Siguiente = ordenada;
                    ordenada = actual;
                }
                else
                {
                    // Buscar el nodo después del cual debe insertarse el actual.
                    Nodo posicion = ordenada;

                    // Avanzar mientras el siguiente código sea menor o igual
                    // al código del nodo que se está insertando.
                    while (posicion.Siguiente != null &&
                           CompararCodigos(
                               posicion.Siguiente.Valor.CodigoOperacion,
                               actual.Valor.CodigoOperacion) <= 0)
                    {
                        posicion = posicion.Siguiente;
                    }

                    // Insertar el nodo actual en la posición encontrada.
                    actual.Siguiente = posicion.Siguiente;
                    posicion.Siguiente = actual;
                }

                // Continuar con el nodo guardado antes de modificar los enlaces.
                actual = siguiente;
            }

            // Actualizar la cabeza para que apunte al inicio de la lista ordenada.
            cabeza = ordenada;

            // Recalcular la cola porque los nodos cambiaron de posición.
            cola = cabeza;

            // Recorrer hasta el último nodo para actualizar la referencia final.
            if (cola != null)
            {
                while (cola.Siguiente != null)
                    cola = cola.Siguiente;
            }
        }

        /// <summary>
        /// Combina dos listas de ventas en una nueva lista y la ordena por código.
        /// Las listas originales conservan sus nodos y su orden.
        /// Los objetos Venta se comparten mediante referencias; no se duplican.
        /// </summary>
        /// <param name="primera">Primera lista de ventas.</param>
        /// <param name="segunda">Segunda lista de ventas.</param>
        /// <returns>Una nueva lista con las ventas de ambas listas, ordenadas.</returns>
        /// <exception cref="ArgumentNullException">
        /// Se produce si alguna de las listas recibidas es null.
        /// </exception>
        public static ListaEnlazadaVentas Mezclar(
            ListaEnlazadaVentas primera,
            ListaEnlazadaVentas segunda)
        {
            // Validar que se haya proporcionado la primera lista.
            if (primera == null)
                throw new ArgumentNullException(nameof(primera));

            // Validar que se haya proporcionado la segunda lista.
            if (segunda == null)
                throw new ArgumentNullException(nameof(segunda));

            // Crear una lista nueva para almacenar el resultado de la combinación.
            ListaEnlazadaVentas resultado =
                new ListaEnlazadaVentas();

            // Recorrer la primera lista y agregar sus ventas al resultado.
            Nodo actual = primera.cabeza;

            while (actual != null)
            {
                resultado.Agregar(actual.Valor);
                actual = actual.Siguiente;
            }

            // Recorrer la segunda lista y agregar sus ventas al resultado.
            actual = segunda.cabeza;

            while (actual != null)
            {
                resultado.Agregar(actual.Valor);
                actual = actual.Siguiente;
            }

            // Ordenar todas las ventas combinadas por código de operación.
            resultado.OrdenarPorCodigo();

            // Devolver la nueva lista sin modificar los nodos de las originales.
            return resultado;
        }

        /// <summary>
        /// Compara dos códigos de operación en orden alfabético,
        /// ignorando diferencias entre mayúsculas y minúsculas.
        /// </summary>
        /// <param name="primero">Primer código que se va a comparar.</param>
        /// <param name="segundo">Segundo código que se va a comparar.</param>
        /// <returns>
        /// Un número negativo si el primer código precede al segundo,
        /// cero si son equivalentes o un número positivo si lo sigue.
        /// </returns>
        private static int CompararCodigos(string primero, string segundo)
        {
            // Utilizar comparación ordinal para obtener un orden consistente
            // sin depender de las reglas lingüísticas de la configuración regional.
            return StringComparer.OrdinalIgnoreCase.Compare(
                primero,
                segundo);
        }
    }
}