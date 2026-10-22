using System;
using System.Collections.Generic;
using System.Linq;
using ComercialAndina.ComercialAndina.Models;

namespace ComercialAndina.ComercialAndina.Estructuras
{
    /// <summary>
    /// Administra las solicitudes comerciales mediante una cola FIFO
    /// (First In, First Out), donde la primera solicitud que ingresa
    /// es la primera que se atiende.
    /// </summary>
    public sealed class ColaSolicitudes
    {
        // Cola que almacena las solicitudes pendientes de atención.
        // Queue<T> proporciona las operaciones Enqueue y Dequeue
        // para agregar elementos al final y retirar elementos del inicio.
        private Queue<Solicitud> elementos = new Queue<Solicitud>();

        /// <summary>
        /// Obtiene la cantidad de solicitudes que están pendientes de atención.
        /// El valor se calcula a partir del número de elementos de la cola.
        /// </summary>
        public int Cantidad => elementos.Count;

        /// <summary>
        /// Agrega una solicitud al final de la cola para que sea atendida
        /// después de las solicitudes que ya estaban registradas.
        /// </summary>
        /// <param name="solicitud">Solicitud comercial que se desea encolar.</param>
        public void Encolar(Solicitud solicitud)
        {
            // Insertar la solicitud al final de la cola.
            elementos.Enqueue(solicitud);
        }

        /// <summary>
        /// Retira y devuelve la siguiente solicitud pendiente de atención.
        /// Respeta el orden FIFO: se atiende primero la solicitud más antigua.
        /// </summary>
        /// <returns>
        /// La solicitud que estaba al inicio de la cola, o null si está vacía.
        /// </returns>
        public Solicitud AtenderSiguiente()
        {
            // Comprobar si existen solicitudes pendientes antes de retirar una.
            if (elementos.Count == 0)
            {
                // No hay solicitudes disponibles para atender.
                return null;
            }

            // Retirar y devolver la primera solicitud de la cola.
            return elementos.Dequeue();
        }

        /// <summary>
        /// Obtiene una lista con las solicitudes que todavía están pendientes.
        /// La lista devuelta conserva el orden de atención de la cola.
        /// La operación no elimina solicitudes de la cola original.
        /// </summary>
        /// <returns>Lista de solicitudes pendientes, de la más antigua a la más reciente.</returns>
        public List<Solicitud> ObtenerPendientes()
        {
            // Crear una lista a partir de los elementos de la cola.
            // ToList copia la colección, por lo que consultar los pendientes
            // no modifica la cola original.
            return elementos.ToList();
        }
    }
}