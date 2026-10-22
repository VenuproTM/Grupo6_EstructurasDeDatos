using System;

namespace ComercialAndina.ComercialAndina.Models
{
    /// <summary>
    /// Representa el registro de una reversa de una operación comercial.
    /// Almacena el código de la operación, el motivo de la reversa,
    /// el supervisor responsable y la fecha y hora de autorización.
    /// </summary>
    public sealed class Reversa
    {
        /// <summary>
        /// Código de la operación comercial que se desea reversar.
        /// </summary>
        public string CodigoOperacion { get; }

        /// <summary>
        /// Motivo indicado para justificar la reversa de la operación.
        /// </summary>
        public string Motivo { get; }

        /// <summary>
        /// Nombre o identificador del supervisor que autoriza la reversa.
        /// </summary>
        public string Supervisor { get; }

        /// <summary>
        /// Fecha y hora en que se crea el registro de autorización.
        /// Se asigna automáticamente al construir el objeto.
        /// </summary>
        public DateTime FechaAutorizacion { get; }

        /// <summary>
        /// Construye un registro de reversa con los datos proporcionados.
        /// La fecha de autorización se establece con la fecha y hora actuales.
        /// </summary>
        /// <param name="codigo">Código de la operación que se reversará.</param>
        /// <param name="motivo">Justificación de la reversa.</param>
        /// <param name="supervisor">Supervisor responsable de la autorización.</param>
        public Reversa(
            string codigo,
            string motivo,
            string supervisor)
        {
            // Asociar el registro de reversa con la operación correspondiente.
            CodigoOperacion = codigo;

            // Guardar la justificación de la reversa.
            Motivo = motivo;

            // Registrar al supervisor responsable.
            Supervisor = supervisor;

            // Registrar automáticamente la fecha y hora de autorización.
            FechaAutorizacion = DateTime.Now;
        }

        /// <summary>
        /// Devuelve una representación textual del registro de reversa.
        /// Incluye la fecha de autorización, el código de operación,
        /// el supervisor responsable y el motivo.
        /// </summary>
        /// <returns>Cadena con el resumen de la reversa.</returns>
        public override string ToString()
        {
            return $"{FechaAutorizacion:dd/MM/yyyy HH:mm:ss} | " +
                   $"Operación: {CodigoOperacion} | " +
                   $"Supervisor: {Supervisor} | Motivo: {Motivo}";
        }
    }
}