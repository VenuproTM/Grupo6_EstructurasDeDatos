using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComercialAndina.ComercialAndina.Models;
using ComercialAndina.ComercialAndina.Estructuras;

namespace ComercialAndina.ComercialAndina.Servicios
{
    public sealed class GestorComercial
    {
        public ListaEnlazadaVentas Ventas { get; } = new ListaEnlazadaVentas();
        public ArbolBinarioBusqueda IndicePorCodigo { get; } = new ArbolBinarioBusqueda();
        public ColaSolicitudes Solicitudes { get; } = new ColaSolicitudes();
        public PilaReversas Reversas { get; } = new PilaReversas();

        public Venta RegistrarVenta(
            string codigo,
            string cliente,
            string productos,
            int cantidad,
            decimal precio,
            DateTime fecha)
        {
            codigo = codigo.Trim();
            cliente = cliente.Trim();
            productos = productos.Trim();

            if (codigo.Length < 3)
                throw new ArgumentException(
                    "El código debe tener al menos 3 caracteres.");

            if (cliente.Length < 3)
                throw new ArgumentException(
                    "El nombre del cliente debe tener al menos 3 caracteres.");

            if (productos.Length < 3)
                throw new ArgumentException(
                    "El nombre del producto debe tener al menos 3 caracteres.");

            if (precio <= 0)
                throw new ArgumentException(
                    "El precio debe ser mayor que cero.");


            if (string.IsNullOrWhiteSpace(codigo) ||
                string.IsNullOrWhiteSpace(cliente) ||
                string.IsNullOrWhiteSpace(productos))
            {
                throw new ArgumentException(
                    "Complete el código, cliente y producto.");
            }

            if (cantidad <= 0)
                throw new ArgumentException(
                    "La cantidad debe ser mayor que cero.");

            if (precio < 0)
                throw new ArgumentException(
                    "El precio no puede ser negativo.");

            if (Ventas.Buscar(codigo) != null)
                throw new ArgumentException(
                    "El código de operación ya existe.");

            Venta venta = new Venta(
                codigo, cliente, productos, cantidad, precio, fecha);

            IndicePorCodigo.Insertar(venta);
            Ventas.Agregar(venta);

            return venta;
        }


        public Solicitud RegistrarSolicitud(
            string codigo,
            string cliente,
            string tipo,
            string detalle)
        {
            if (string.IsNullOrWhiteSpace(codigo) ||
                string.IsNullOrWhiteSpace(cliente) ||
                string.IsNullOrWhiteSpace(tipo) ||
                string.IsNullOrWhiteSpace(detalle))
            {
                throw new ArgumentException(
                    "Completa el código, cliente, tipo y detalle de la solicitud.");
            }

            codigo = codigo.Trim();
            cliente = cliente.Trim();
            tipo = tipo.Trim();
            detalle = detalle.Trim();

            if (IndicePorCodigo.Buscar(codigo) == null)
                throw new ArgumentException(
                    "No existe una venta registrada con ese código.");

            Venta venta = IndicePorCodigo.Buscar(codigo);

            if (venta == null)
            {
                throw new ArgumentException(
                    "No existe una venta registrada con ese código.");
            }

            if (!string.Equals(
                venta.IdentificadorCliente.Trim(),
                cliente.Trim(),
                StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(
                    "El cliente ingresado no coincide con el cliente registrado en la venta.");
            }

            // Evitar códigos de solicitud repetidos.
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

            // Solo permitir los tipos definidos por el sistema.
            string[] tiposPermitidos = {"Consulta","Reclamo","Devolución","Garantía"};

            bool tipoValido = false;

            foreach (string tipoPermitido in tiposPermitidos)
            {
                if (string.Equals(
                    tipo,
                    tipoPermitido,
                    StringComparison.OrdinalIgnoreCase))
                {
                    tipo = tipoPermitido;
                    tipoValido = true;
                    break;
                }
            }

            if (!tipoValido)
            {
                throw new ArgumentException(
                    "El tipo de solicitud no es válido. Selecciona Consulta, Reclamo, Devolución o Garantía.");
            }

            Solicitud solicitud = new Solicitud(
                codigo,
                cliente,
                tipo,
                detalle);

            Solicitudes.Encolar(solicitud);

            return solicitud;
        }


        public Solicitud AtenderSiguienteSolicitud()
        {
            return Solicitudes.AtenderSiguiente();
        }

        public Reversa AutorizarReversa(
            string codigo,
            string motivo,
            string supervisor)
        {
            if (string.IsNullOrWhiteSpace(motivo) ||
                string.IsNullOrWhiteSpace(supervisor))
            {
                throw new ArgumentException(
                    "El motivo y el supervisor son obligatorios.");
            }

            Venta venta = IndicePorCodigo.Buscar(codigo.Trim());

            if (venta == null)
                throw new ArgumentException(
                    "No se encontró la operación.");

            if (venta.Estado == "Reversada")
                throw new ArgumentException(
                    "La operación ya está reversada.");

            Reversa reversa = new Reversa(
                venta.CodigoOperacion,
                motivo.Trim(),
                supervisor.Trim());

            venta.MarcarReversada();
            Reversas.Apilar(reversa);

            return reversa;
        }
    }
}
