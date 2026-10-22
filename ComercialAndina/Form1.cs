using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComercialAndina.ComercialAndina.Servicios;
using System.IO;

namespace ComercialAndina
{

    public partial class Form1 : Form
    {
        private readonly GestorComercial gestor = new GestorComercial();

        public Form1()
        {
            InitializeComponent();
            // El código de venta lo genera automáticamente el gestor.
            txtCodigoVenta.ReadOnly = true;
            txtCodigoVenta.Clear();
        }
        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                // RegistrarVenta genera automáticamente el código de la venta.
                var venta = gestor.RegistrarVenta(
                    txtClienteVenta.Text,
                    txtProductos.Text,
                    (int)nudCantidad.Value,
                    nudPrecio.Value,
                    dtpFechaVenta.Value
                );

                // Mostrar el código automático generado.
                txtCodigoVenta.Text = venta.CodigoOperacion;

                // Actualizar la lista visual de ventas.
                ActualizarListaVentas();

                MessageBox.Show(
                    "Venta registrada correctamente.\n" +
                    "Código: " + venta.CodigoOperacion + "\n" +
                    "Total: S/ " + venta.Total.ToString("F2"),
                    "Registro exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Limpiar los campos para registrar otra venta.
                txtCodigoVenta.Clear();
                txtClienteVenta.Clear();
                txtProductos.Clear();
                nudCantidad.Value = nudCantidad.Minimum;
                nudPrecio.Value = nudPrecio.Minimum;

                // Dejar el foco en el campo del cliente.
                txtClienteVenta.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "No se pudo registrar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        // Actualiza la lista visual con todas las ventas registradas.
        private void ActualizarListaVentas()
        {
            lstVentas.Items.Clear();

            foreach (var venta in gestor.Ventas.ObtenerTodas())
            {
                lstVentas.Items.Add(venta.ToString());
            }
        }


        private void nudPrecio_ValueChanged(object sender, EventArgs e)
        {

        }


        private void btnConsultarVenta_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigoConsulta.Text.Trim();

            if (string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show(
                    "Ingresa el código de la operación.",
                    "Campo requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Búsqueda secuencial en la lista enlazada.
            var venta = gestor.Ventas.Buscar(codigo);

            if (venta != null)
            {
                lblResultadoConsulta.Text =
                    "Código: " + venta.CodigoOperacion +
                    "\nCliente: " + venta.IdentificadorCliente +
                    "\nProducto(s): " + venta.Productos +
                    "\nCantidad: " + venta.Cantidad +
                    "\nPrecio unitario: S/ " +
                    venta.PrecioUnitario.ToString("F2") +
                    "\nTotal: S/ " + venta.Total.ToString("F2") +
                    "\nFecha: " + venta.Fecha.ToShortDateString() +
                    "\nEstado: " + venta.Estado;
            }
            else
            {
                lblResultadoConsulta.Text =
                    "No se encontró la operación " + codigo;
            }
        }


        private void btnRegistrarSolicitud_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCodigoSolicitud.Text) ||
                    string.IsNullOrWhiteSpace(txtClienteSolicitud.Text) ||
                    string.IsNullOrWhiteSpace(txtDetalleSolicitud.Text) ||
                    cmbTipoSolicitud.SelectedIndex == -1)
                {
                    MessageBox.Show(
                        "Completa todos los campos de la solicitud.",
                        "Campos requeridos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                gestor.RegistrarSolicitud(
                    txtCodigoSolicitud.Text.Trim(),
                    txtClienteSolicitud.Text.Trim(),
                    cmbTipoSolicitud.SelectedItem.ToString(),
                    txtDetalleSolicitud.Text.Trim()
                );

                lstSolicitudes.Items.Clear();

                foreach (var solicitud in gestor.Solicitudes.ObtenerPendientes())
                {
                    lstSolicitudes.Items.Add(
                        solicitud.CodigoOperacion + " | Cliente: " +
                        solicitud.IdentificadorCliente + " | Tipo: " +
                        solicitud.Tipo + " | Detalle: " +
                        solicitud.Detalle
                    );
                }

                MessageBox.Show(
                    "Solicitud registrada correctamente.",
                    "Registro exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                txtCodigoSolicitud.Clear();
                txtClienteSolicitud.Clear();
                txtDetalleSolicitud.Clear();
                cmbTipoSolicitud.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al registrar solicitud",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void btnAtenderSolicitud_Click(object sender, EventArgs e)
        {
            try
            {
                var solicitud = gestor.AtenderSiguienteSolicitud();

                if (solicitud == null)
                {
                    MessageBox.Show(
                        "No hay solicitudes pendientes para atender.",
                        "Cola vacía",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                lstSolicitudes.Items.Clear();

                foreach (var pendiente in gestor.Solicitudes.ObtenerPendientes())
                {
                    lstSolicitudes.Items.Add(
                        pendiente.CodigoOperacion + " | Cliente: " +
                        pendiente.IdentificadorCliente + " | Tipo: " +
                        pendiente.Tipo + " | Detalle: " +
                        pendiente.Detalle
                    );
                }

                MessageBox.Show(
                    "Solicitud atendida:\n" +
                    "Código: " + solicitud.CodigoOperacion + "\n" +
                    "Cliente: " + solicitud.IdentificadorCliente + "\n" +
                    "Tipo: " + solicitud.Tipo,
                    "Atención de solicitud",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al atender solicitud",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void btnAutorizarReversa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCodigoReversa.Text) ||
                    string.IsNullOrWhiteSpace(txtMotivoReversa.Text) ||
                    string.IsNullOrWhiteSpace(txtSupervisor.Text))
                {
                    MessageBox.Show(
                        "Completa el código, el motivo y el supervisor.",
                        "Campos requeridos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                gestor.AutorizarReversa(
                    txtCodigoReversa.Text.Trim(),
                    txtMotivoReversa.Text.Trim(),
                    txtSupervisor.Text.Trim()
                );
                // Actualizar las ventas para reflejar el estado Reversada.
                ActualizarListaVentas();

                lstReversas.Items.Clear();

                foreach (var reversa in gestor.Reversas.ObtenerHistorial())
                {
                    lstReversas.Items.Add(
                        reversa.CodigoOperacion +
                        " | Motivo: " + reversa.Motivo +
                        " | Supervisor: " + reversa.Supervisor +
                        " | Fecha: " + reversa.FechaAutorizacion.ToString()
                    );
                }

                MessageBox.Show(
                    "Reversa autorizada y registrada correctamente.",
                    "Operación exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                txtCodigoReversa.Clear();
                txtMotivoReversa.Clear();
                txtSupervisor.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al autorizar reversa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void btnVerHistorialReversas_Click(object sender, EventArgs e)
        {
            lstReversas.Items.Clear();

            var historial = gestor.Reversas.ObtenerHistorial();

            foreach (var reversa in historial)
            {
                string detalle =
                    "Operación: " + reversa.CodigoOperacion +
                    " | Motivo: " + reversa.Motivo +
                    " | Supervisor: " + reversa.Supervisor +
                    " | Fecha: " + reversa.FechaAutorizacion.ToString();

                lstReversas.Items.Add(detalle);
            }

            MessageBox.Show(
                "Elementos agregados a la lista: " + lstReversas.Items.Count,
                "Verificación del historial",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }



        private void btnRegistrarReporte_Click(object sender, EventArgs e)
        {
            var ventas = gestor.Ventas.ObtenerTodas();
            var solicitudes = gestor.Solicitudes.ObtenerPendientes();
            var reversas = gestor.Reversas.ObtenerHistorial();

            if (ventas.Count == 0)
            {
                MessageBox.Show(
                    "Todavía no hay ventas registradas.",
                    "Reporte comercial",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            StringBuilder reporte = new StringBuilder();

            reporte.AppendLine("========== REPORTE COMERCIAL ==========");
            reporte.AppendLine("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            reporte.AppendLine("Total de ventas: " + ventas.Count);
            reporte.AppendLine();

            // Agrupar las ventas por cliente.
            var ventasPorCliente = ventas
                .GroupBy(v => v.IdentificadorCliente)
                .OrderBy(g => g.Key);

            foreach (var grupo in ventasPorCliente)
            {
                reporte.AppendLine("CLIENTE: " + grupo.Key);
                reporte.AppendLine("--------------------------------------");

                foreach (var venta in grupo)
                {
                    reporte.AppendLine("Código: " + venta.CodigoOperacion);
                    reporte.AppendLine("Producto(s): " + venta.Productos);
                    reporte.AppendLine("Cantidad: " + venta.Cantidad);
                    reporte.AppendLine(
                        "Precio unitario: S/ " +
                        venta.PrecioUnitario.ToString("F2")
                    );
                    reporte.AppendLine(
                        "Total: S/ " + venta.Total.ToString("F2")
                    );
                    reporte.AppendLine(
                        "Fecha: " + venta.Fecha.ToString("dd/MM/yyyy")
                    );
                    reporte.AppendLine("Estado: " + venta.Estado);
                    reporte.AppendLine();
                }

                reporte.AppendLine();
            }

            reporte.AppendLine("========== RESUMEN ==========");
            reporte.AppendLine("Solicitudes pendientes: " + solicitudes.Count);
            reporte.AppendLine("Reversas registradas: " + reversas.Count);

            // Mostrar el reporte en una ventana, sin generar archivos.
            Form ventanaReporte = new Form();
            ventanaReporte.Text = "Reporte de ventas por cliente";
            ventanaReporte.Width = 650;
            ventanaReporte.Height = 600;
            ventanaReporte.StartPosition = FormStartPosition.CenterParent;
            ventanaReporte.MinimizeBox = false;

            TextBox contenido = new TextBox();
            contenido.Multiline = true;
            contenido.ReadOnly = true;
            contenido.ScrollBars = ScrollBars.Both;
            contenido.WordWrap = false;
            contenido.Dock = DockStyle.Fill;
            contenido.Font = new System.Drawing.Font("Consolas", 10);
            contenido.Text = reporte.ToString();

            ventanaReporte.Controls.Add(contenido);
            ventanaReporte.ShowDialog(this);
        }


    }
}
