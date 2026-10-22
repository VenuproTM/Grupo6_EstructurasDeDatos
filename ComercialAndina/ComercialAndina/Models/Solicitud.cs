using System;

namespace ComercialAndina.ComercialAndina.Models
{
    /// <summary>
    /// Representa una solicitud comercial recibida por el sistema.
    /// Almacena la operación relacionada, los datos del cliente,
    /// el tipo de solicitud, su detalle y la fecha de recepción.
    /// </summary>
    public sealed class Solicitud
    {
        /// <summary>
        /// Código de la operación de venta relacionada con la solicitud.
        /// </summary>
        public string CodigoOperacion { get; }

        /// <summary>
        /// Identificador del cliente que presenta la solicitud.
        /// </summary>
        public string IdentificadorCliente { get; }

        /// <summary>
        /// Clasificación o tipo de solicitud comercial.
        /// </summary>
        public string Tipo { get; }

        /// <summary>
        /// Descripción de la solicitud y de la atención requerida.
        /// </summary>
        public string Detalle { get; }

        /// <summary>
        /// Fecha y hora en que se crea y recibe la solicitud.
        /// Se establece automáticamente durante la construcción del objeto.
        /// </summary>
        public DateTime FechaRecepcion { get; }

        /// <summary>
        /// Construye una solicitud con los datos proporcionados.
        /// La fecha de recepción se asigna automáticamente con la fecha y hora actuales.
        /// </summary>
        /// <param name="codigo">Código de la operación relacionada.</param>
        /// <param name="cliente">Identificador del cliente solicitante.</param>
        /// <param name="tipo">Tipo de solicitud comercial.</param>
        /// <param name="detalle">Descripción de la solicitud.</param>
        public Solicitud(
            string codigo,
            string cliente,
            string tipo,
            string detalle)
        {
            // Asociar la solicitud con el código de operación correspondiente.
            CodigoOperacion = codigo;

            // Registrar qué cliente presenta la solicitud.
            IdentificadorCliente = cliente;

            // Guardar la clasificación de la solicitud.
            Tipo = tipo;

            // Almacenar la descripción del requerimiento.
            Detalle = detalle;

            // Registrar automáticamente la fecha y hora de recepción.
            FechaRecepcion = DateTime.Now;
        }

        /// <summary>
        /// Genera una representación textual de la solicitud
        /// para facilitar su visualización en la interfaz.
        /// Incluye la hora de recepción, el tipo, la operación,
        /// el cliente y el detalle.
        /// </summary>
        /// <returns>Cadena con el resumen de la solicitud.</returns>
        public override string ToString()
        {
            return $"{FechaRecepcion:HH:mm:ss} | {Tipo} | " +
                   $"Operación: {CodigoOperacion} | " +
                   $"Cliente: {IdentificadorCliente} | {Detalle}";
        }
    }
}
