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

namespace ComercialAndina
{

    public partial class Form1 : Form
    {
        private readonly GestorComercial gestor = new GestorComercial();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                var venta = gestor.RegistrarVenta(
                    txtCodigoVenta.Text,
                    txtClienteVenta.Text,
                    txtProductos.Text,
                    (int)nudCantidad.Value,
                    nudPrecio.Value,
                    dtpFechaVenta.Value
                );

                lstVentas.Items.Clear();

                foreach (var v in gestor.Ventas.ObtenerTodas())
                {
                    lstVentas.Items.Add(v.ToString());
                }

                MessageBox.Show(
                    $"Venta registrada correctamente.\nTotal: S/ {venta.Total:F2}",
                    "Registro exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
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
                    MessageBoxIcon.Warning
                );
                return;
            }

            var venta = gestor.IndicePorCodigo.Buscar(codigo);

            if (venta != null)
            {
                lblResultadoConsulta.Text =
                    "Código: " + venta.CodigoOperacion +
                    "\nCliente: " + venta.IdentificadorCliente +
                    "\nProducto(s): " + venta.Productos +
                    "\nCantidad: " + venta.Cantidad +
                    "\nPrecio unitario: S/ " + venta.PrecioUnitario.ToString("F2") +
                    "\nTotal: S/ " + venta.Total.ToString("F2") +
                    "\nFecha: " + venta.Fecha.ToShortDateString() +
                    "\nEstado: " + venta.Estado;
            }
            else
            {
                lblResultadoConsulta.Text = "No se encontró la operación " + codigo;
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
    }
}
