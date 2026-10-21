namespace ComercialAndina
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabVentas = new System.Windows.Forms.TabPage();
            this.nudPrecio = new System.Windows.Forms.NumericUpDown();
            this.lstVentas = new System.Windows.Forms.ListBox();
            this.dtpFechaVenta = new System.Windows.Forms.DateTimePicker();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegistrarVenta = new System.Windows.Forms.Button();
            this.txtProductos = new System.Windows.Forms.TextBox();
            this.lblFechaVenta = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblProductos = new System.Windows.Forms.Label();
            this.txtClienteVenta = new System.Windows.Forms.TextBox();
            this.lblClienteVenta = new System.Windows.Forms.Label();
            this.txtCodigoVenta = new System.Windows.Forms.TextBox();
            this.lblCodigoVenta = new System.Windows.Forms.Label();
            this.lblTituloVentas = new System.Windows.Forms.Label();
            this.tabConsultas = new System.Windows.Forms.TabPage();
            this.tabSolicitudes = new System.Windows.Forms.TabPage();
            this.tabReversas = new System.Windows.Forms.TabPage();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblCodigoConsulta = new System.Windows.Forms.Label();
            this.txtCodigoConsulta = new System.Windows.Forms.TextBox();
            this.btnConsultarVenta = new System.Windows.Forms.Button();
            this.lblResultadoConsulta = new System.Windows.Forms.Label();
            this.lblCodigoSolicitud = new System.Windows.Forms.Label();
            this.txtCodigoSolicitud = new System.Windows.Forms.TextBox();
            this.lblClienteSolicitud = new System.Windows.Forms.Label();
            this.txtClienteSolicitud = new System.Windows.Forms.TextBox();
            this.lblTipoSolicitud = new System.Windows.Forms.Label();
            this.cmbTipoSolicitud = new System.Windows.Forms.ComboBox();
            this.lblDetalleSolicitud = new System.Windows.Forms.Label();
            this.txtDetalleSolicitud = new System.Windows.Forms.TextBox();
            this.btnRegistrarSolicitud = new System.Windows.Forms.Button();
            this.btnAtenderSolicitud = new System.Windows.Forms.Button();
            this.lstSolicitudes = new System.Windows.Forms.ListBox();
            this.lblCodigoReversa = new System.Windows.Forms.Label();
            this.txtCodigoReversa = new System.Windows.Forms.TextBox();
            this.lblMotivoReversa = new System.Windows.Forms.Label();
            this.lblSupervisor = new System.Windows.Forms.Label();
            this.txtMotivoReversa = new System.Windows.Forms.TextBox();
            this.txtSupervisor = new System.Windows.Forms.TextBox();
            this.btnAutorizarReversa = new System.Windows.Forms.Button();
            this.btnVerHistorialReversas = new System.Windows.Forms.Button();
            this.lstReversas = new System.Windows.Forms.ListBox();
            this.tabPrincipal.SuspendLayout();
            this.tabVentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.tabConsultas.SuspendLayout();
            this.tabSolicitudes.SuspendLayout();
            this.tabReversas.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.CausesValidation = false;
            this.tabPrincipal.Controls.Add(this.tabVentas);
            this.tabPrincipal.Controls.Add(this.tabConsultas);
            this.tabPrincipal.Controls.Add(this.tabSolicitudes);
            this.tabPrincipal.Controls.Add(this.tabReversas);
            this.tabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(720, 566);
            this.tabPrincipal.TabIndex = 0;
            // 
            // tabVentas
            // 
            this.tabVentas.Controls.Add(this.nudPrecio);
            this.tabVentas.Controls.Add(this.lstVentas);
            this.tabVentas.Controls.Add(this.dtpFechaVenta);
            this.tabVentas.Controls.Add(this.nudCantidad);
            this.tabVentas.Controls.Add(this.label1);
            this.tabVentas.Controls.Add(this.btnRegistrarVenta);
            this.tabVentas.Controls.Add(this.txtProductos);
            this.tabVentas.Controls.Add(this.lblFechaVenta);
            this.tabVentas.Controls.Add(this.txtPrecio);
            this.tabVentas.Controls.Add(this.lblCantidad);
            this.tabVentas.Controls.Add(this.lblProductos);
            this.tabVentas.Controls.Add(this.txtClienteVenta);
            this.tabVentas.Controls.Add(this.lblClienteVenta);
            this.tabVentas.Controls.Add(this.txtCodigoVenta);
            this.tabVentas.Controls.Add(this.lblCodigoVenta);
            this.tabVentas.Controls.Add(this.lblTituloVentas);
            this.tabVentas.Location = new System.Drawing.Point(4, 22);
            this.tabVentas.Name = "tabVentas";
            this.tabVentas.Padding = new System.Windows.Forms.Padding(3);
            this.tabVentas.Size = new System.Drawing.Size(712, 540);
            this.tabVentas.TabIndex = 0;
            this.tabVentas.Text = "Registrar Ventas";
            this.tabVentas.UseVisualStyleBackColor = true;
            // 
            // nudPrecio
            // 
            this.nudPrecio.DecimalPlaces = 2;
            this.nudPrecio.Location = new System.Drawing.Point(211, 209);
            this.nudPrecio.Name = "nudPrecio";
            this.nudPrecio.Size = new System.Drawing.Size(200, 20);
            this.nudPrecio.TabIndex = 19;
            this.nudPrecio.ValueChanged += new System.EventHandler(this.nudPrecio_ValueChanged);
            // 
            // lstVentas
            // 
            this.lstVentas.FormattingEnabled = true;
            this.lstVentas.Location = new System.Drawing.Point(63, 349);
            this.lstVentas.Name = "lstVentas";
            this.lstVentas.Size = new System.Drawing.Size(617, 95);
            this.lstVentas.TabIndex = 18;
            // 
            // dtpFechaVenta
            // 
            this.dtpFechaVenta.Location = new System.Drawing.Point(211, 251);
            this.dtpFechaVenta.Name = "dtpFechaVenta";
            this.dtpFechaVenta.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaVenta.TabIndex = 17;
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(211, 171);
            this.nudCantidad.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(200, 20);
            this.nudCantidad.TabIndex = 16;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 317);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Ventas registradas";
            // 
            // btnRegistrarVenta
            // 
            this.btnRegistrarVenta.Location = new System.Drawing.Point(441, 238);
            this.btnRegistrarVenta.Name = "btnRegistrarVenta";
            this.btnRegistrarVenta.Size = new System.Drawing.Size(75, 38);
            this.btnRegistrarVenta.TabIndex = 13;
            this.btnRegistrarVenta.Text = "Registrar Venta";
            this.btnRegistrarVenta.UseVisualStyleBackColor = true;
            this.btnRegistrarVenta.Click += new System.EventHandler(this.btnRegistrarVenta_Click);
            // 
            // txtProductos
            // 
            this.txtProductos.Location = new System.Drawing.Point(211, 133);
            this.txtProductos.Name = "txtProductos";
            this.txtProductos.Size = new System.Drawing.Size(200, 20);
            this.txtProductos.TabIndex = 9;
            this.txtProductos.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblFechaVenta
            // 
            this.lblFechaVenta.AutoSize = true;
            this.lblFechaVenta.Location = new System.Drawing.Point(60, 251);
            this.lblFechaVenta.Name = "lblFechaVenta";
            this.lblFechaVenta.Size = new System.Drawing.Size(82, 13);
            this.lblFechaVenta.TabIndex = 8;
            this.lblFechaVenta.Text = "Fecha de venta";
            // 
            // txtPrecio
            // 
            this.txtPrecio.AutoSize = true;
            this.txtPrecio.Location = new System.Drawing.Point(60, 211);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(95, 13);
            this.txtPrecio.TabIndex = 7;
            this.txtPrecio.Text = "Precio unitario (S/)";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(61, 171);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(49, 13);
            this.lblCantidad.TabIndex = 6;
            this.lblCantidad.Text = "Cantidad";
            // 
            // lblProductos
            // 
            this.lblProductos.AutoSize = true;
            this.lblProductos.Location = new System.Drawing.Point(61, 133);
            this.lblProductos.Name = "lblProductos";
            this.lblProductos.Size = new System.Drawing.Size(61, 13);
            this.lblProductos.TabIndex = 5;
            this.lblProductos.Text = "Producto(s)";
            // 
            // txtClienteVenta
            // 
            this.txtClienteVenta.Location = new System.Drawing.Point(211, 94);
            this.txtClienteVenta.Name = "txtClienteVenta";
            this.txtClienteVenta.Size = new System.Drawing.Size(200, 20);
            this.txtClienteVenta.TabIndex = 4;
            // 
            // lblClienteVenta
            // 
            this.lblClienteVenta.AutoSize = true;
            this.lblClienteVenta.Location = new System.Drawing.Point(60, 94);
            this.lblClienteVenta.Name = "lblClienteVenta";
            this.lblClienteVenta.Size = new System.Drawing.Size(116, 13);
            this.lblClienteVenta.TabIndex = 3;
            this.lblClienteVenta.Text = "Identificador del cliente";
            // 
            // txtCodigoVenta
            // 
            this.txtCodigoVenta.Location = new System.Drawing.Point(211, 56);
            this.txtCodigoVenta.Name = "txtCodigoVenta";
            this.txtCodigoVenta.Size = new System.Drawing.Size(200, 20);
            this.txtCodigoVenta.TabIndex = 2;
            // 
            // lblCodigoVenta
            // 
            this.lblCodigoVenta.AutoSize = true;
            this.lblCodigoVenta.Location = new System.Drawing.Point(61, 59);
            this.lblCodigoVenta.Name = "lblCodigoVenta";
            this.lblCodigoVenta.Size = new System.Drawing.Size(105, 13);
            this.lblCodigoVenta.TabIndex = 1;
            this.lblCodigoVenta.Text = "Código de operación";
            // 
            // lblTituloVentas
            // 
            this.lblTituloVentas.AutoSize = true;
            this.lblTituloVentas.Location = new System.Drawing.Point(166, 29);
            this.lblTituloVentas.Name = "lblTituloVentas";
            this.lblTituloVentas.Size = new System.Drawing.Size(127, 13);
            this.lblTituloVentas.TabIndex = 0;
            this.lblTituloVentas.Text = "REGISTRO DE VENTAS";
            // 
            // tabConsultas
            // 
            this.tabConsultas.Controls.Add(this.lblResultadoConsulta);
            this.tabConsultas.Controls.Add(this.btnConsultarVenta);
            this.tabConsultas.Controls.Add(this.txtCodigoConsulta);
            this.tabConsultas.Controls.Add(this.lblCodigoConsulta);
            this.tabConsultas.Location = new System.Drawing.Point(4, 22);
            this.tabConsultas.Name = "tabConsultas";
            this.tabConsultas.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsultas.Size = new System.Drawing.Size(712, 540);
            this.tabConsultas.TabIndex = 1;
            this.tabConsultas.Text = "Consultar Operación";
            this.tabConsultas.UseVisualStyleBackColor = true;
            this.tabConsultas.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // tabSolicitudes
            // 
            this.tabSolicitudes.Controls.Add(this.lstSolicitudes);
            this.tabSolicitudes.Controls.Add(this.btnAtenderSolicitud);
            this.tabSolicitudes.Controls.Add(this.btnRegistrarSolicitud);
            this.tabSolicitudes.Controls.Add(this.txtDetalleSolicitud);
            this.tabSolicitudes.Controls.Add(this.lblDetalleSolicitud);
            this.tabSolicitudes.Controls.Add(this.cmbTipoSolicitud);
            this.tabSolicitudes.Controls.Add(this.lblTipoSolicitud);
            this.tabSolicitudes.Controls.Add(this.txtClienteSolicitud);
            this.tabSolicitudes.Controls.Add(this.lblClienteSolicitud);
            this.tabSolicitudes.Controls.Add(this.txtCodigoSolicitud);
            this.tabSolicitudes.Controls.Add(this.lblCodigoSolicitud);
            this.tabSolicitudes.Location = new System.Drawing.Point(4, 22);
            this.tabSolicitudes.Name = "tabSolicitudes";
            this.tabSolicitudes.Size = new System.Drawing.Size(712, 540);
            this.tabSolicitudes.TabIndex = 2;
            this.tabSolicitudes.Text = "Solicitudes";
            this.tabSolicitudes.UseVisualStyleBackColor = true;
            // 
            // tabReversas
            // 
            this.tabReversas.Controls.Add(this.lstReversas);
            this.tabReversas.Controls.Add(this.btnVerHistorialReversas);
            this.tabReversas.Controls.Add(this.btnAutorizarReversa);
            this.tabReversas.Controls.Add(this.txtSupervisor);
            this.tabReversas.Controls.Add(this.txtMotivoReversa);
            this.tabReversas.Controls.Add(this.lblSupervisor);
            this.tabReversas.Controls.Add(this.lblMotivoReversa);
            this.tabReversas.Controls.Add(this.txtCodigoReversa);
            this.tabReversas.Controls.Add(this.lblCodigoReversa);
            this.tabReversas.Location = new System.Drawing.Point(4, 22);
            this.tabReversas.Name = "tabReversas";
            this.tabReversas.Size = new System.Drawing.Size(712, 540);
            this.tabReversas.TabIndex = 3;
            this.tabReversas.Text = "Reversas";
            this.tabReversas.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // lblCodigoConsulta
            // 
            this.lblCodigoConsulta.AutoSize = true;
            this.lblCodigoConsulta.Location = new System.Drawing.Point(67, 66);
            this.lblCodigoConsulta.Name = "lblCodigoConsulta";
            this.lblCodigoConsulta.Size = new System.Drawing.Size(108, 13);
            this.lblCodigoConsulta.TabIndex = 0;
            this.lblCodigoConsulta.Text = "Código de operación:";
            // 
            // txtCodigoConsulta
            // 
            this.txtCodigoConsulta.Location = new System.Drawing.Point(70, 93);
            this.txtCodigoConsulta.Name = "txtCodigoConsulta";
            this.txtCodigoConsulta.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoConsulta.TabIndex = 1;
            // 
            // btnConsultarVenta
            // 
            this.btnConsultarVenta.Location = new System.Drawing.Point(79, 133);
            this.btnConsultarVenta.Name = "btnConsultarVenta";
            this.btnConsultarVenta.Size = new System.Drawing.Size(75, 23);
            this.btnConsultarVenta.TabIndex = 2;
            this.btnConsultarVenta.Text = "Consultar";
            this.btnConsultarVenta.UseVisualStyleBackColor = true;
            this.btnConsultarVenta.Click += new System.EventHandler(this.btnConsultarVenta_Click);
            // 
            // lblResultadoConsulta
            // 
            this.lblResultadoConsulta.AutoSize = true;
            this.lblResultadoConsulta.Location = new System.Drawing.Point(209, 66);
            this.lblResultadoConsulta.Name = "lblResultadoConsulta";
            this.lblResultadoConsulta.Size = new System.Drawing.Size(0, 13);
            this.lblResultadoConsulta.TabIndex = 3;
            // 
            // lblCodigoSolicitud
            // 
            this.lblCodigoSolicitud.AutoSize = true;
            this.lblCodigoSolicitud.Location = new System.Drawing.Point(79, 64);
            this.lblCodigoSolicitud.Name = "lblCodigoSolicitud";
            this.lblCodigoSolicitud.Size = new System.Drawing.Size(108, 13);
            this.lblCodigoSolicitud.TabIndex = 0;
            this.lblCodigoSolicitud.Text = "Código de operación:";
            // 
            // txtCodigoSolicitud
            // 
            this.txtCodigoSolicitud.Location = new System.Drawing.Point(82, 80);
            this.txtCodigoSolicitud.Name = "txtCodigoSolicitud";
            this.txtCodigoSolicitud.Size = new System.Drawing.Size(121, 20);
            this.txtCodigoSolicitud.TabIndex = 1;
            // 
            // lblClienteSolicitud
            // 
            this.lblClienteSolicitud.AutoSize = true;
            this.lblClienteSolicitud.Location = new System.Drawing.Point(79, 107);
            this.lblClienteSolicitud.Name = "lblClienteSolicitud";
            this.lblClienteSolicitud.Size = new System.Drawing.Size(42, 13);
            this.lblClienteSolicitud.TabIndex = 2;
            this.lblClienteSolicitud.Text = "Cliente:";
            // 
            // txtClienteSolicitud
            // 
            this.txtClienteSolicitud.Location = new System.Drawing.Point(82, 125);
            this.txtClienteSolicitud.Name = "txtClienteSolicitud";
            this.txtClienteSolicitud.Size = new System.Drawing.Size(121, 20);
            this.txtClienteSolicitud.TabIndex = 3;
            // 
            // lblTipoSolicitud
            // 
            this.lblTipoSolicitud.AutoSize = true;
            this.lblTipoSolicitud.Location = new System.Drawing.Point(79, 154);
            this.lblTipoSolicitud.Name = "lblTipoSolicitud";
            this.lblTipoSolicitud.Size = new System.Drawing.Size(87, 13);
            this.lblTipoSolicitud.TabIndex = 4;
            this.lblTipoSolicitud.Text = "Tipo de solicitud:";
            // 
            // cmbTipoSolicitud
            // 
            this.cmbTipoSolicitud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoSolicitud.FormattingEnabled = true;
            this.cmbTipoSolicitud.Items.AddRange(new object[] {
            "Consulta",
            "Reclame",
            "Cambio o devolución"});
            this.cmbTipoSolicitud.Location = new System.Drawing.Point(82, 171);
            this.cmbTipoSolicitud.Name = "cmbTipoSolicitud";
            this.cmbTipoSolicitud.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoSolicitud.TabIndex = 5;
            // 
            // lblDetalleSolicitud
            // 
            this.lblDetalleSolicitud.AutoSize = true;
            this.lblDetalleSolicitud.Location = new System.Drawing.Point(79, 200);
            this.lblDetalleSolicitud.Name = "lblDetalleSolicitud";
            this.lblDetalleSolicitud.Size = new System.Drawing.Size(43, 13);
            this.lblDetalleSolicitud.TabIndex = 6;
            this.lblDetalleSolicitud.Text = "Detalle:";
            // 
            // txtDetalleSolicitud
            // 
            this.txtDetalleSolicitud.Location = new System.Drawing.Point(82, 216);
            this.txtDetalleSolicitud.Name = "txtDetalleSolicitud";
            this.txtDetalleSolicitud.Size = new System.Drawing.Size(121, 20);
            this.txtDetalleSolicitud.TabIndex = 7;
            // 
            // btnRegistrarSolicitud
            // 
            this.btnRegistrarSolicitud.Location = new System.Drawing.Point(245, 225);
            this.btnRegistrarSolicitud.Name = "btnRegistrarSolicitud";
            this.btnRegistrarSolicitud.Size = new System.Drawing.Size(75, 42);
            this.btnRegistrarSolicitud.TabIndex = 8;
            this.btnRegistrarSolicitud.Text = "Registrar Solicitud";
            this.btnRegistrarSolicitud.UseVisualStyleBackColor = true;
            this.btnRegistrarSolicitud.Click += new System.EventHandler(this.btnRegistrarSolicitud_Click);
            // 
            // btnAtenderSolicitud
            // 
            this.btnAtenderSolicitud.Location = new System.Drawing.Point(326, 225);
            this.btnAtenderSolicitud.Name = "btnAtenderSolicitud";
            this.btnAtenderSolicitud.Size = new System.Drawing.Size(75, 42);
            this.btnAtenderSolicitud.TabIndex = 9;
            this.btnAtenderSolicitud.Text = "Atender Siguiente";
            this.btnAtenderSolicitud.UseVisualStyleBackColor = true;
            this.btnAtenderSolicitud.Click += new System.EventHandler(this.btnAtenderSolicitud_Click);
            // 
            // lstSolicitudes
            // 
            this.lstSolicitudes.FormattingEnabled = true;
            this.lstSolicitudes.Location = new System.Drawing.Point(245, 57);
            this.lstSolicitudes.Name = "lstSolicitudes";
            this.lstSolicitudes.Size = new System.Drawing.Size(396, 147);
            this.lstSolicitudes.TabIndex = 10;
            // 
            // lblCodigoReversa
            // 
            this.lblCodigoReversa.AutoSize = true;
            this.lblCodigoReversa.Location = new System.Drawing.Point(67, 60);
            this.lblCodigoReversa.Name = "lblCodigoReversa";
            this.lblCodigoReversa.Size = new System.Drawing.Size(108, 13);
            this.lblCodigoReversa.TabIndex = 0;
            this.lblCodigoReversa.Text = "Código de operación:";
            // 
            // txtCodigoReversa
            // 
            this.txtCodigoReversa.Location = new System.Drawing.Point(70, 76);
            this.txtCodigoReversa.Name = "txtCodigoReversa";
            this.txtCodigoReversa.Size = new System.Drawing.Size(150, 20);
            this.txtCodigoReversa.TabIndex = 1;
            // 
            // lblMotivoReversa
            // 
            this.lblMotivoReversa.AutoSize = true;
            this.lblMotivoReversa.Location = new System.Drawing.Point(67, 113);
            this.lblMotivoReversa.Name = "lblMotivoReversa";
            this.lblMotivoReversa.Size = new System.Drawing.Size(106, 13);
            this.lblMotivoReversa.TabIndex = 2;
            this.lblMotivoReversa.Text = "Motivo de la reversa:";
            // 
            // lblSupervisor
            // 
            this.lblSupervisor.AutoSize = true;
            this.lblSupervisor.Location = new System.Drawing.Point(67, 162);
            this.lblSupervisor.Name = "lblSupervisor";
            this.lblSupervisor.Size = new System.Drawing.Size(112, 13);
            this.lblSupervisor.TabIndex = 3;
            this.lblSupervisor.Text = "Supervisor autorizado:";
            // 
            // txtMotivoReversa
            // 
            this.txtMotivoReversa.Location = new System.Drawing.Point(70, 129);
            this.txtMotivoReversa.Name = "txtMotivoReversa";
            this.txtMotivoReversa.Size = new System.Drawing.Size(150, 20);
            this.txtMotivoReversa.TabIndex = 4;
            // 
            // txtSupervisor
            // 
            this.txtSupervisor.Location = new System.Drawing.Point(70, 178);
            this.txtSupervisor.Name = "txtSupervisor";
            this.txtSupervisor.Size = new System.Drawing.Size(150, 20);
            this.txtSupervisor.TabIndex = 5;
            // 
            // btnAutorizarReversa
            // 
            this.btnAutorizarReversa.Location = new System.Drawing.Point(257, 210);
            this.btnAutorizarReversa.Name = "btnAutorizarReversa";
            this.btnAutorizarReversa.Size = new System.Drawing.Size(75, 36);
            this.btnAutorizarReversa.TabIndex = 6;
            this.btnAutorizarReversa.Text = "Autorizar Reversa";
            this.btnAutorizarReversa.UseVisualStyleBackColor = true;
            this.btnAutorizarReversa.Click += new System.EventHandler(this.btnAutorizarReversa_Click);
            // 
            // btnVerHistorialReversas
            // 
            this.btnVerHistorialReversas.Location = new System.Drawing.Point(356, 210);
            this.btnVerHistorialReversas.Name = "btnVerHistorialReversas";
            this.btnVerHistorialReversas.Size = new System.Drawing.Size(75, 36);
            this.btnVerHistorialReversas.TabIndex = 7;
            this.btnVerHistorialReversas.Text = "Ver historial";
            this.btnVerHistorialReversas.UseVisualStyleBackColor = true;
            this.btnVerHistorialReversas.Click += new System.EventHandler(this.btnVerHistorialReversas_Click);
            // 
            // lstReversas
            // 
            this.lstReversas.FormattingEnabled = true;
            this.lstReversas.Location = new System.Drawing.Point(257, 76);
            this.lstReversas.Name = "lstReversas";
            this.lstReversas.Size = new System.Drawing.Size(385, 108);
            this.lstReversas.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 566);
            this.Controls.Add(this.tabPrincipal);
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPrincipal.ResumeLayout(false);
            this.tabVentas.ResumeLayout(false);
            this.tabVentas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.tabConsultas.ResumeLayout(false);
            this.tabConsultas.PerformLayout();
            this.tabSolicitudes.ResumeLayout(false);
            this.tabSolicitudes.PerformLayout();
            this.tabReversas.ResumeLayout(false);
            this.tabReversas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPrincipal;
        private System.Windows.Forms.TabPage tabConsultas;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TabPage tabVentas;
        private System.Windows.Forms.TabPage tabSolicitudes;
        private System.Windows.Forms.TabPage tabReversas;
        private System.Windows.Forms.Label lblFechaVenta;
        private System.Windows.Forms.Label txtPrecio;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblProductos;
        private System.Windows.Forms.TextBox txtClienteVenta;
        private System.Windows.Forms.Label lblClienteVenta;
        private System.Windows.Forms.TextBox txtCodigoVenta;
        private System.Windows.Forms.Label lblCodigoVenta;
        private System.Windows.Forms.Label lblTituloVentas;
        private System.Windows.Forms.TextBox txtProductos;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegistrarVenta;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.DateTimePicker dtpFechaVenta;
        private System.Windows.Forms.ListBox lstVentas;
        private System.Windows.Forms.NumericUpDown nudPrecio;
        private System.Windows.Forms.Label lblResultadoConsulta;
        private System.Windows.Forms.Button btnConsultarVenta;
        private System.Windows.Forms.TextBox txtCodigoConsulta;
        private System.Windows.Forms.Label lblCodigoConsulta;
        private System.Windows.Forms.ComboBox cmbTipoSolicitud;
        private System.Windows.Forms.Label lblTipoSolicitud;
        private System.Windows.Forms.TextBox txtClienteSolicitud;
        private System.Windows.Forms.Label lblClienteSolicitud;
        private System.Windows.Forms.TextBox txtCodigoSolicitud;
        private System.Windows.Forms.Label lblCodigoSolicitud;
        private System.Windows.Forms.ListBox lstSolicitudes;
        private System.Windows.Forms.Button btnAtenderSolicitud;
        private System.Windows.Forms.Button btnRegistrarSolicitud;
        private System.Windows.Forms.TextBox txtDetalleSolicitud;
        private System.Windows.Forms.Label lblDetalleSolicitud;
        private System.Windows.Forms.Label lblMotivoReversa;
        private System.Windows.Forms.TextBox txtCodigoReversa;
        private System.Windows.Forms.Label lblCodigoReversa;
        private System.Windows.Forms.ListBox lstReversas;
        private System.Windows.Forms.Button btnVerHistorialReversas;
        private System.Windows.Forms.Button btnAutorizarReversa;
        private System.Windows.Forms.TextBox txtSupervisor;
        private System.Windows.Forms.TextBox txtMotivoReversa;
        private System.Windows.Forms.Label lblSupervisor;
    }
}

