using System;
using System.Collections.Generic;
using System.Linq;
using ComercialAndina.ComercialAndina.Models;

namespace ComercialAndina.ComercialAndina.Estructuras
{
    /// <summary>
    /// Administra el historial de reversas comerciales mediante una pila.
    /// Utiliza el principio LIFO (Last In, First Out), según el cual
    /// la última reversa registrada es la primera que se consulta en la cima.
    /// </summary>
    public sealed class PilaReversas
    {
        // Pila que almacena las reversas registradas.
        // Stack<T> permite agregar elementos en la cima mediante Push
        // y consultar o retirar el elemento superior mediante Peek o Pop.
        private Stack<Reversa> elementos = new Stack<Reversa>();

        /// <summary>
        /// Obtiene la cantidad de reversas almacenadas en la pila.
        /// El valor se actualiza automáticamente según el contenido de la pila.
        /// </summary>
        public int Cantidad => elementos.Count;

        /// <summary>
        /// Agrega una reversa a la cima de la pila.
        /// La reversa recién registrada será la primera en consultarse.
        /// </summary>
        /// <param name="reversa">Reversa que se desea almacenar.</param>
        public void Apilar(Reversa reversa)
        {
            // Incorporar la reversa en la parte superior de la pila.
            elementos.Push(reversa);
        }

        /// <summary>
        /// Consulta la reversa ubicada en la cima de la pila
        /// sin eliminarla del historial.
        /// </summary>
        /// <returns>
        /// La reversa más recientemente apilada, o null si la pila está vacía.
        /// </returns>
        public Reversa VerUltima()
        {
            // Comprobar si existen reversas antes de consultar la cima.
            if (elementos.Count == 0)
            {
                // No hay reversas registradas.
                return null;
            }

            // Peek devuelve el elemento superior sin retirarlo de la pila.
            return elementos.Peek();
        }

        /// <summary>
        /// Obtiene una lista con todas las reversas almacenadas.
        /// La enumeración de Stack<T> comienza por la cima,
        /// por lo que las reversas aparecen de la más reciente a la más antigua.
        /// La operación no elimina elementos de la pila original.
        /// </summary>
        /// <returns>Lista con el historial de reversas.</returns>
        public List<Reversa> ObtenerHistorial()
        {
            // Convertir el contenido de la pila en una lista independiente.
            // Esta consulta conserva la pila original y su contenido.
            return elementos.ToList();
        }
    }
}