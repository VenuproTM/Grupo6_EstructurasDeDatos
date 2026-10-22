using System;

namespace ComercialAndina.ComercialAndina.Models
{
    /// <summary>
    /// Representa una venta registrada en el sistema comercial.
    /// Contiene los datos de la operación, su importe total,
    /// la fecha de registro y el estado actual de la venta.
    /// </summary>
    public sealed class Venta
    {
        /// <summary>
        /// Código único que identifica la operación de venta.
        /// Se establece al crear el objeto y no puede reasignarse después.
        /// </summary>
        public string CodigoOperacion { get; }

        /// <summary>
        /// Identificador del cliente que realizó la compra.
        /// </summary>
        public string IdentificadorCliente { get; }

        /// <summary>
        /// Descripción de los productos asociados a la venta.
        /// </summary>
        public string Productos { get; }

        /// <summary>
        /// Cantidad de unidades registradas en la operación.
        /// </summary>
        public int Cantidad { get; }

        /// <summary>
        /// Precio correspondiente a cada unidad vendida.
        /// </summary>
        public decimal PrecioUnitario { get; }

        /// <summary>
        /// Calcula el importe total multiplicando la cantidad
        /// por el precio unitario.
        /// El resultado se obtiene a partir de los datos de la venta.
        /// </summary>
        public decimal Total => Cantidad * PrecioUnitario;

        /// <summary>
        /// Fecha y hora en que se registró la venta.
        /// </summary>
        public DateTime Fecha { get; }

        /// <summary>
        /// Estado actual de la operación.
        /// Una venta nueva comienza como "Registrada".
        /// El estado puede actualizarse mediante MarcarReversada().
        /// </summary>
        public string Estado { get; private set; } = "Registrada";

        /// <summary>
        /// Construye una venta con los datos de la operación comercial.
        /// Inicializa las propiedades con los valores recibidos.
        /// </summary>
        /// <param name="codigo">Código de operación de la venta.</param>
        /// <param name="cliente">Identificador del cliente.</param>
        /// <param name="productos">Descripción de los productos vendidos.</param>
        /// <param name="cantidad">Cantidad de unidades vendidas.</param>
        /// <param name="precio">Precio unitario de los productos.</param>
        /// <param name="fecha">Fecha y hora de registro de la venta.</param>
        public Venta(
            string codigo,
            string cliente,
            string productos,
            int cantidad,
            decimal precio,
            DateTime fecha)
        {
            // Guardar el código que identifica la operación.
            CodigoOperacion = codigo;

            // Asociar la venta con el cliente correspondiente.
            IdentificadorCliente = cliente;

            // Registrar la descripción de los productos vendidos.
            Productos = productos;

            // Guardar la cantidad de unidades de la operación.
            Cantidad = cantidad;

            // Establecer el precio por unidad.
            PrecioUnitario = precio;

            // Registrar la fecha y hora de la venta.
            Fecha = fecha;
        }

        /// <summary>
        /// Actualiza el estado de la venta para indicar que ha sido reversada.
        /// El cambio se realiza mediante este método, ya que la propiedad
        /// Estado tiene un modificador private set.
        /// </summary>
        public void MarcarReversada()
        {
            // Actualizar el estado de la operación comercial.
            Estado = "Reversada";
        }

        /// <summary>
        /// Devuelve una representación textual de la venta,
        /// incluyendo el código, cliente, productos, cantidad,
        /// importe total, fecha y estado.
        /// Se utiliza para mostrar los datos de forma legible.
        /// </summary>
        /// <returns>Cadena con el resumen de la venta.</returns>
        public override string ToString()
        {
            return $"{CodigoOperacion} | Cliente: {IdentificadorCliente} | " +
                   $"{Productos} | Cantidad: {Cantidad} | Total: S/ {Total:F2} | " +
                   $"Fecha: {Fecha:dd/MM/yyyy HH:mm} | Estado: {Estado}";
        }
    }
}