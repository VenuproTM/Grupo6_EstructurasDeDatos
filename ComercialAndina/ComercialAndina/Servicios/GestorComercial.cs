using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComercialAndina.ComercialAndina.Models;
using ComercialAndina.ComercialAndina.Estructuras;

namespace ComercialAndina.ComercialAndina.Servicios
{
    /// <summary>
    /// Coordina las operaciones principales del sistema comercial.
    /// Administra el registro de ventas, las solicitudes de los clientes
    /// y las autorizaciones de reversa mediante las estructuras de datos
    /// definidas en el proyecto.
    /// </summary>
    public sealed class GestorComercial
    {
        // Contador consecutivo utilizado para generar códigos de venta.
        // Comienza en 1 y aumenta después de registrar una venta correctamente.
        private int siguienteCodigoVenta = 1;

        /// <summary>
        /// Genera el código de la siguiente venta con el formato V-0001, V-0002, etc.
        /// El formato D4 representa el número con al menos cuatro dígitos.
        /// </summary>
        /// <returns>Código de operación generado automáticamente.</returns>
        private string GenerarCodigoVenta()
        {
            return "V-" + siguienteCodigoVenta.ToString("D4");
        }

        // Lista enlazada que almacena las ventas registradas.
        // Permite agregar ventas, consultarlas y ordenarlas por código.
        public ListaEnlazadaVentas Ventas { get; } = new ListaEnlazadaVentas();

        // Árbol binario de búsqueda que funciona como índice para localizar ventas
        // a partir de su código de operación.
        public ArbolBinarioBusqueda IndicePorCodigo { get; } = new ArbolBinarioBusqueda();

        // Cola FIFO que administra las solicitudes pendientes de atención.
        public ColaSolicitudes Solicitudes { get; } = new ColaSolicitudes();

        // Pila LIFO que conserva el historial de reversas registradas.
        public PilaReversas Reversas { get; } = new PilaReversas();

        /// <summary>
        /// Valida los datos recibidos, genera un código de operación
        /// y registra una nueva venta en las estructuras correspondientes.
        /// </summary>
        /// <param name="cliente">Nombre o identificador del cliente.</param>
        /// <param name="productos">Descripción de los productos vendidos.</param>
        /// <param name="cantidad">Cantidad de unidades vendidas.</param>
        /// <param name="precio">Precio unitario de los productos.</param>
        /// <param name="fecha">Fecha y hora de la operación.</param>
        /// <returns>Objeto Venta creado y registrado.</returns>
        /// <exception cref="ArgumentException">
        /// Se produce cuando los datos no cumplen las validaciones.
        /// </exception>

        public Venta RegistrarVenta(
            string cliente,
            string productos,
            int cantidad,
            decimal precio,
            DateTime fecha)
        {
            // Validar que los campos obligatorios contengan texto.
            // Se realiza antes de Trim() para evitar problemas con valores nulos.
            if (string.IsNullOrWhiteSpace(cliente) ||
                string.IsNullOrWhiteSpace(productos))
            {
                throw new ArgumentException(
                    "Complete el nombre del cliente y el producto.");
            }

            // Eliminar espacios al inicio y al final de los textos.
            cliente = cliente.Trim();
            productos = productos.Trim();

            // Validar la longitud mínima de los textos normalizados.
            if (cliente.Length < 3)
            {
                throw new ArgumentException(
                    "El nombre del cliente debe tener al menos 3 caracteres.");
            }

            if (productos.Length < 3)
            {
                throw new ArgumentException(
                    "El nombre del producto debe tener al menos 3 caracteres.");
            }

            // Validar que la cantidad sea mayor que cero.
            if (cantidad <= 0)
            {
                throw new ArgumentException(
                    "La cantidad debe ser mayor que cero.");
            }

            // Validar que el precio sea mayor que cero.
            if (precio <= 0)
            {
                throw new ArgumentException(
                    "El precio debe ser mayor que cero.");
            }

            // Generar automáticamente el código de la nueva venta.
            string codigo = GenerarCodigoVenta();

            // Crear la venta con los datos validados.
            Venta venta = new Venta(
                codigo, cliente, productos, cantidad, precio, fecha);

            // Insertar la venta en el árbol binario para buscar por código.
            IndicePorCodigo.Insertar(venta);

            // Agregar la venta a la lista enlazada para su consulta.
            Ventas.Agregar(venta);

            // Incrementar el contador para la siguiente venta.
            siguienteCodigoVenta++;

            // Devolver la venta registrada.
            return venta;
        }


        /// <summary>
        /// Valida y registra una solicitud relacionada con una venta existente.
        /// Comprueba los datos obligatorios, la existencia de la operación,
        /// la coincidencia del cliente, la ausencia de solicitudes duplicadas
        /// y que el tipo pertenezca a los permitidos.
        /// Finalmente, agrega la solicitud a la cola de atención.
        /// </summary>
        /// <param name="codigo">Código de la venta relacionada.</param>
        /// <param name="cliente">Cliente que presenta la solicitud.</param>
        /// <param name="tipo">Tipo de solicitud comercial.</param>
        /// <param name="detalle">Descripción del requerimiento.</param>
        /// <returns>Solicitud creada y agregada a la cola.</returns>
        /// <exception cref="ArgumentException">
        /// Se produce cuando los datos son incompletos o no cumplen las reglas.
        /// </exception>
        public Solicitud RegistrarSolicitud(
            string codigo,
            string cliente,
            string tipo,
            string detalle)
        {
            // Comprobar que todos los campos obligatorios estén completos.
            if (string.IsNullOrWhiteSpace(codigo) ||
                string.IsNullOrWhiteSpace(cliente) ||
                string.IsNullOrWhiteSpace(tipo) ||
                string.IsNullOrWhiteSpace(detalle))
            {
                throw new ArgumentException(
                    "Completa el código, cliente, tipo y detalle de la solicitud.");
            }

            // Normalizar los datos de texto eliminando espacios exteriores.
            codigo = codigo.Trim();
            cliente = cliente.Trim();
            tipo = tipo.Trim();
            detalle = detalle.Trim();

            // Verificar que el código corresponda a una venta registrada.
            if (IndicePorCodigo.Buscar(codigo) == null)
                throw new ArgumentException(
                    "No existe una venta registrada con ese código.");

            // Recuperar la venta para comprobar los datos del cliente.
            Venta venta = IndicePorCodigo.Buscar(codigo);

            // Validar nuevamente que se haya obtenido una venta.
            if (venta == null)
            {
                throw new ArgumentException(
                    "No existe una venta registrada con ese código.");
            }

            // Verificar que el cliente de la solicitud coincida con el
            // cliente asociado a la venta, sin distinguir mayúsculas y minúsculas.
            if (!string.Equals(
                venta.IdentificadorCliente.Trim(),
                cliente.Trim(),
                StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(
                    "El cliente ingresado no coincide con el cliente registrado en la venta.");
            }

            // Recorrer las solicitudes pendientes para evitar registrar
            // más de una solicitud pendiente con el mismo código de operación.
            foreach (Solicitud pendiente in Solicitudes.ObtenerPendientes())
            {
                if (string.Equals(
                    pendiente.CodigoOperacion,
                    codigo,
                    StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException(
                        "Ya existe una solicitud pendiente con ese código.");
                }
            }

            // Definir los tipos de solicitud aceptados por el sistema.
            string[] tiposPermitidos = { "Consulta", "Reclamo", "Devolución", "Garantía" };

            // Esta variable indica si el tipo ingresado es válido.
            bool tipoValido = false;

            // Comparar el tipo recibido con cada opción permitida.
            foreach (string tipoPermitido in tiposPermitidos)
            {
                if (string.Equals(
                    tipo,
                    tipoPermitido,
                    StringComparison.OrdinalIgnoreCase))
                {
                    // Utilizar la escritura oficial del tipo seleccionado.
                    tipo = tipoPermitido;
                    tipoValido = true;
                    break;
                }
            }

            // Rechazar la solicitud si su tipo no pertenece a las opciones definidas.
            if (!tipoValido)
            {
                throw new ArgumentException(
                    "El tipo de solicitud no es válido. Selecciona Consulta, Reclamo, Devolución o Garantía.");
            }

            // Crear el objeto Solicitud con los datos validados.
            Solicitud solicitud = new Solicitud(
                codigo,
                cliente,
                tipo,
                detalle);

            // Encolar la solicitud para que se atienda respetando el orden FIFO.
            Solicitudes.Encolar(solicitud);

            // Devolver la solicitud registrada.
            return solicitud;
        }

        /// <summary>
        /// Atiende la siguiente solicitud pendiente.
        /// La cola determina cuál es la más antigua y la retira al atenderla.
        /// </summary>
        /// <returns>
        /// La solicitud atendida o null si no hay solicitudes pendientes.
        /// </returns>
        public Solicitud AtenderSiguienteSolicitud()
        {
            // Delegar la atención a la cola, que aplica el principio FIFO.
            return Solicitudes.AtenderSiguiente();
        }

        /// <summary>
        /// Autoriza la reversa de una venta registrada.
        /// Verifica los datos obligatorios, la existencia de la operación
        /// y que la venta no haya sido reversada anteriormente.
        /// Después registra la reversa y actualiza el estado de la venta.
        /// </summary>
        /// <param name="codigo">Código de la operación que se desea reversar.</param>
        /// <param name="motivo">Justificación de la reversa.</param>
        /// <param name="supervisor">Supervisor responsable de la autorización.</param>
        /// <returns>Registro de reversa creado y almacenado en la pila.</returns>
        /// <exception cref="ArgumentException">
        /// Se produce si faltan datos, la operación no existe
        /// o la venta ya fue reversada.
        /// </exception>
        public Reversa AutorizarReversa(
            string codigo,
            string motivo,
            string supervisor)
        {
            // Comprobar que el motivo y el supervisor sean obligatorios.
            if (string.IsNullOrWhiteSpace(motivo) ||
                string.IsNullOrWhiteSpace(supervisor))
            {
                throw new ArgumentException(
                    "El motivo y el supervisor son obligatorios.");
            }

            // Buscar la venta por su código, eliminando espacios exteriores.
            Venta venta = IndicePorCodigo.Buscar(codigo.Trim());

            // No se puede autorizar una reversa para una operación inexistente.
            if (venta == null)
                throw new ArgumentException(
                    "No se encontró la operación.");

            // Evitar que una misma venta sea reversada más de una vez.
            if (venta.Estado == "Reversada")
                throw new ArgumentException(
                    "La operación ya está reversada.");

            // Crear el registro con los datos de la operación y la autorización.
            Reversa reversa = new Reversa(
                venta.CodigoOperacion,
                motivo.Trim(),
                supervisor.Trim());

            // Actualizar el estado de la venta para reflejar la reversa autorizada.
            venta.MarcarReversada();

            // Guardar la reversa en la pila para conservar el historial.
            Reversas.Apilar(reversa);

            // Devolver el registro de reversa creado.
            return reversa;
        }
    }
}