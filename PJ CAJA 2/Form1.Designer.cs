
namespace PJ_CAJA_2
{
    partial class frmInicioSesion
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
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.clndFecha = new System.Windows.Forms.MonthCalendar();
            this.lblAdTiempo = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlTiposCambio = new System.Windows.Forms.Panel();
            this.btnCancelarCambio = new System.Windows.Forms.Button();
            this.btnAceptarCambio = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVenta = new System.Windows.Forms.TextBox();
            this.lblCambios = new System.Windows.Forms.Label();
            this.lvlCompra = new System.Windows.Forms.Label();
            this.txtCompra = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.grpInicio = new System.Windows.Forms.GroupBox();
            this.lblHoras = new System.Windows.Forms.Label();
            this.pnlEntSal = new System.Windows.Forms.Panel();
            this.pnlSumadora = new System.Windows.Forms.Panel();
            this.btnCancelarSum = new System.Windows.Forms.Button();
            this.btnAceptarSum = new System.Windows.Forms.Button();
            this.btnImprimirSum = new System.Windows.Forms.Button();
            this.txtSumaTotal = new System.Windows.Forms.TextBox();
            this.txtSuma5 = new System.Windows.Forms.TextBox();
            this.txtSuma4 = new System.Windows.Forms.TextBox();
            this.txtSuma3 = new System.Windows.Forms.TextBox();
            this.txtSuma2 = new System.Windows.Forms.TextBox();
            this.txtSuma1 = new System.Windows.Forms.TextBox();
            this.lblSumadora = new System.Windows.Forms.Label();
            this.grpMotivo = new System.Windows.Forms.GroupBox();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.btnCancelarEntSal = new System.Windows.Forms.Button();
            this.btnAceptarInSa = new System.Windows.Forms.Button();
            this.grpEntSal = new System.Windows.Forms.GroupBox();
            this.rdbSalida = new System.Windows.Forms.RadioButton();
            this.rdbEntrada = new System.Windows.Forms.RadioButton();
            this.grpDolares = new System.Windows.Forms.GroupBox();
            this.btnSumD = new System.Windows.Forms.Button();
            this.lblTotalD = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMorD = new System.Windows.Forms.TextBox();
            this.txtTotalD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUmD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCpD = new System.Windows.Forms.TextBox();
            this.grpPesos = new System.Windows.Forms.GroupBox();
            this.btnSumP = new System.Windows.Forms.Button();
            this.lblTotalP = new System.Windows.Forms.Label();
            this.txtTotalP = new System.Windows.Forms.TextBox();
            this.lblMor = new System.Windows.Forms.Label();
            this.txtMorP = new System.Windows.Forms.TextBox();
            this.lblUm = new System.Windows.Forms.Label();
            this.txtUmP = new System.Windows.Forms.TextBox();
            this.lblCp = new System.Windows.Forms.Label();
            this.txtCpP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalida = new System.Windows.Forms.Button();
            this.pnlTiposCambio.SuspendLayout();
            this.grpInicio.SuspendLayout();
            this.pnlEntSal.SuspendLayout();
            this.pnlSumadora.SuspendLayout();
            this.grpMotivo.SuspendLayout();
            this.grpEntSal.SuspendLayout();
            this.grpDolares.SuspendLayout();
            this.grpPesos.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(289, 41);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(6);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(151, 29);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsuario_KeyDown_1);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(223, 366);
            this.btnIniciar.Margin = new System.Windows.Forms.Padding(6);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(193, 42);
            this.btnIniciar.TabIndex = 1;
            this.btnIniciar.Text = "INICIAR SESION";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(179, 44);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(98, 24);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "USUARIO:";
            // 
            // clndFecha
            // 
            this.clndFecha.Location = new System.Drawing.Point(190, 144);
            this.clndFecha.Name = "clndFecha";
            this.clndFecha.TabIndex = 3;
            // 
            // lblAdTiempo
            // 
            this.lblAdTiempo.AutoSize = true;
            this.lblAdTiempo.Location = new System.Drawing.Point(179, 89);
            this.lblAdTiempo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAdTiempo.Name = "lblAdTiempo";
            this.lblAdTiempo.Size = new System.Drawing.Size(271, 48);
            this.lblAdTiempo.TabIndex = 4;
            this.lblAdTiempo.Text = "REVISA QUE FECHA Y HORA\r\nSEAN CORRECTOS";
            this.lblAdTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnlTiposCambio
            // 
            this.pnlTiposCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTiposCambio.Controls.Add(this.btnCancelarCambio);
            this.pnlTiposCambio.Controls.Add(this.btnAceptarCambio);
            this.pnlTiposCambio.Controls.Add(this.label5);
            this.pnlTiposCambio.Controls.Add(this.txtVenta);
            this.pnlTiposCambio.Controls.Add(this.lblCambios);
            this.pnlTiposCambio.Controls.Add(this.lvlCompra);
            this.pnlTiposCambio.Controls.Add(this.txtCompra);
            this.pnlTiposCambio.Location = new System.Drawing.Point(622, 180);
            this.pnlTiposCambio.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTiposCambio.Name = "pnlTiposCambio";
            this.pnlTiposCambio.Size = new System.Drawing.Size(349, 236);
            this.pnlTiposCambio.TabIndex = 7;
            this.pnlTiposCambio.Visible = false;
            // 
            // btnCancelarCambio
            // 
            this.btnCancelarCambio.Location = new System.Drawing.Point(186, 164);
            this.btnCancelarCambio.Name = "btnCancelarCambio";
            this.btnCancelarCambio.Size = new System.Drawing.Size(140, 54);
            this.btnCancelarCambio.TabIndex = 20;
            this.btnCancelarCambio.Text = "CANCELAR";
            this.btnCancelarCambio.UseVisualStyleBackColor = true;
            this.btnCancelarCambio.Click += new System.EventHandler(this.btnCancelarCambio_Click);
            // 
            // btnAceptarCambio
            // 
            this.btnAceptarCambio.Location = new System.Drawing.Point(20, 164);
            this.btnAceptarCambio.Name = "btnAceptarCambio";
            this.btnAceptarCambio.Size = new System.Drawing.Size(140, 54);
            this.btnAceptarCambio.TabIndex = 19;
            this.btnAceptarCambio.Text = "ACEPTAR";
            this.btnAceptarCambio.UseVisualStyleBackColor = true;
            this.btnAceptarCambio.Click += new System.EventHandler(this.btnAceptarCambio_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(78, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = "VENTA:";
            // 
            // txtVenta
            // 
            this.txtVenta.Location = new System.Drawing.Point(164, 103);
            this.txtVenta.Name = "txtVenta";
            this.txtVenta.Size = new System.Drawing.Size(136, 29);
            this.txtVenta.TabIndex = 11;
            this.txtVenta.Text = "00.00";
            this.txtVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVenta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVenta_KeyDown);
            this.txtVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVenta_KeyPress);
            // 
            // lblCambios
            // 
            this.lblCambios.AutoSize = true;
            this.lblCambios.Location = new System.Drawing.Point(96, 11);
            this.lblCambios.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCambios.Name = "lblCambios";
            this.lblCambios.Size = new System.Drawing.Size(162, 24);
            this.lblCambios.TabIndex = 12;
            this.lblCambios.Text = "TIPO DE CAMBIO";
            this.lblCambios.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvlCompra
            // 
            this.lvlCompra.AutoSize = true;
            this.lvlCompra.Location = new System.Drawing.Point(63, 53);
            this.lvlCompra.Name = "lvlCompra";
            this.lvlCompra.Size = new System.Drawing.Size(97, 24);
            this.lvlCompra.TabIndex = 13;
            this.lvlCompra.Text = "COMPRA:";
            // 
            // txtCompra
            // 
            this.txtCompra.Location = new System.Drawing.Point(164, 50);
            this.txtCompra.Name = "txtCompra";
            this.txtCompra.Size = new System.Drawing.Size(136, 29);
            this.txtCompra.TabIndex = 10;
            this.txtCompra.Text = "00.00";
            this.txtCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCompra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCompra_KeyDown);
            this.txtCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCompra_KeyPress);
            // 
            // grpInicio
            // 
            this.grpInicio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpInicio.Controls.Add(this.lblUsuario);
            this.grpInicio.Controls.Add(this.lblHoras);
            this.grpInicio.Controls.Add(this.txtUsuario);
            this.grpInicio.Controls.Add(this.lblAdTiempo);
            this.grpInicio.Controls.Add(this.clndFecha);
            this.grpInicio.Controls.Add(this.btnIniciar);
            this.grpInicio.Location = new System.Drawing.Point(439, 87);
            this.grpInicio.Name = "grpInicio";
            this.grpInicio.Size = new System.Drawing.Size(695, 503);
            this.grpInicio.TabIndex = 8;
            this.grpInicio.TabStop = false;
            // 
            // lblHoras
            // 
            this.lblHoras.AutoSize = true;
            this.lblHoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoras.Location = new System.Drawing.Point(247, 315);
            this.lblHoras.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHoras.Name = "lblHoras";
            this.lblHoras.Size = new System.Drawing.Size(127, 33);
            this.lblHoras.TabIndex = 5;
            this.lblHoras.Text = "00:00:00";
            // 
            // pnlEntSal
            // 
            this.pnlEntSal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEntSal.Controls.Add(this.pnlSumadora);
            this.pnlEntSal.Controls.Add(this.grpMotivo);
            this.pnlEntSal.Controls.Add(this.btnCancelarEntSal);
            this.pnlEntSal.Controls.Add(this.btnAceptarInSa);
            this.pnlEntSal.Controls.Add(this.grpEntSal);
            this.pnlEntSal.Controls.Add(this.grpDolares);
            this.pnlEntSal.Controls.Add(this.grpPesos);
            this.pnlEntSal.Controls.Add(this.label1);
            this.pnlEntSal.Location = new System.Drawing.Point(471, 130);
            this.pnlEntSal.Name = "pnlEntSal";
            this.pnlEntSal.Size = new System.Drawing.Size(631, 428);
            this.pnlEntSal.TabIndex = 21;
            this.pnlEntSal.Visible = false;
            // 
            // pnlSumadora
            // 
            this.pnlSumadora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSumadora.Controls.Add(this.btnCancelarSum);
            this.pnlSumadora.Controls.Add(this.btnAceptarSum);
            this.pnlSumadora.Controls.Add(this.btnImprimirSum);
            this.pnlSumadora.Controls.Add(this.txtSumaTotal);
            this.pnlSumadora.Controls.Add(this.txtSuma5);
            this.pnlSumadora.Controls.Add(this.txtSuma4);
            this.pnlSumadora.Controls.Add(this.txtSuma3);
            this.pnlSumadora.Controls.Add(this.txtSuma2);
            this.pnlSumadora.Controls.Add(this.txtSuma1);
            this.pnlSumadora.Controls.Add(this.lblSumadora);
            this.pnlSumadora.Location = new System.Drawing.Point(76, 36);
            this.pnlSumadora.Name = "pnlSumadora";
            this.pnlSumadora.Size = new System.Drawing.Size(480, 332);
            this.pnlSumadora.TabIndex = 22;
            this.pnlSumadora.Visible = false;
            this.pnlSumadora.VisibleChanged += new System.EventHandler(this.pnlSumadora_VisibleChanged);
            // 
            // btnCancelarSum
            // 
            this.btnCancelarSum.Location = new System.Drawing.Point(358, 270);
            this.btnCancelarSum.Name = "btnCancelarSum";
            this.btnCancelarSum.Size = new System.Drawing.Size(106, 46);
            this.btnCancelarSum.TabIndex = 28;
            this.btnCancelarSum.Text = "Cancelar";
            this.btnCancelarSum.UseVisualStyleBackColor = true;
            this.btnCancelarSum.Click += new System.EventHandler(this.btnCancelarSum_Click);
            // 
            // btnAceptarSum
            // 
            this.btnAceptarSum.Location = new System.Drawing.Point(358, 220);
            this.btnAceptarSum.Name = "btnAceptarSum";
            this.btnAceptarSum.Size = new System.Drawing.Size(106, 44);
            this.btnAceptarSum.TabIndex = 27;
            this.btnAceptarSum.Text = "Aceptar";
            this.btnAceptarSum.UseVisualStyleBackColor = true;
            this.btnAceptarSum.Click += new System.EventHandler(this.btnAceptarSum_Click);
            // 
            // btnImprimirSum
            // 
            this.btnImprimirSum.Location = new System.Drawing.Point(358, 46);
            this.btnImprimirSum.Name = "btnImprimirSum";
            this.btnImprimirSum.Size = new System.Drawing.Size(106, 44);
            this.btnImprimirSum.TabIndex = 29;
            this.btnImprimirSum.Text = "Imprimir";
            this.btnImprimirSum.UseVisualStyleBackColor = true;
            this.btnImprimirSum.Click += new System.EventHandler(this.btnImprimirSum_Click);
            // 
            // txtSumaTotal
            // 
            this.txtSumaTotal.BackColor = System.Drawing.Color.Gainsboro;
            this.txtSumaTotal.ForeColor = System.Drawing.Color.DarkRed;
            this.txtSumaTotal.Location = new System.Drawing.Point(137, 275);
            this.txtSumaTotal.Name = "txtSumaTotal";
            this.txtSumaTotal.Size = new System.Drawing.Size(199, 29);
            this.txtSumaTotal.TabIndex = 80;
            this.txtSumaTotal.TabStop = false;
            this.txtSumaTotal.Text = "00.00";
            this.txtSumaTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSuma5
            // 
            this.txtSuma5.Location = new System.Drawing.Point(137, 227);
            this.txtSuma5.Name = "txtSuma5";
            this.txtSuma5.Size = new System.Drawing.Size(199, 29);
            this.txtSuma5.TabIndex = 25;
            this.txtSuma5.Text = "00.00";
            this.txtSuma5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSuma5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSuma5_KeyDown);
            // 
            // txtSuma4
            // 
            this.txtSuma4.Location = new System.Drawing.Point(137, 183);
            this.txtSuma4.Name = "txtSuma4";
            this.txtSuma4.Size = new System.Drawing.Size(199, 29);
            this.txtSuma4.TabIndex = 24;
            this.txtSuma4.Text = "00.00";
            this.txtSuma4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSuma4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSuma4_KeyDown);
            // 
            // txtSuma3
            // 
            this.txtSuma3.Location = new System.Drawing.Point(137, 137);
            this.txtSuma3.Name = "txtSuma3";
            this.txtSuma3.Size = new System.Drawing.Size(199, 29);
            this.txtSuma3.TabIndex = 23;
            this.txtSuma3.Text = "00.00";
            this.txtSuma3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSuma3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSuma3_KeyDown);
            // 
            // txtSuma2
            // 
            this.txtSuma2.Location = new System.Drawing.Point(137, 96);
            this.txtSuma2.Name = "txtSuma2";
            this.txtSuma2.Size = new System.Drawing.Size(199, 29);
            this.txtSuma2.TabIndex = 22;
            this.txtSuma2.Text = "00.00";
            this.txtSuma2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSuma2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSuma2_KeyDown);
            // 
            // txtSuma1
            // 
            this.txtSuma1.Location = new System.Drawing.Point(137, 53);
            this.txtSuma1.Name = "txtSuma1";
            this.txtSuma1.Size = new System.Drawing.Size(199, 29);
            this.txtSuma1.TabIndex = 21;
            this.txtSuma1.Text = "00.00";
            this.txtSuma1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSuma1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSuma1_KeyDown);
            // 
            // lblSumadora
            // 
            this.lblSumadora.AutoSize = true;
            this.lblSumadora.Location = new System.Drawing.Point(179, 13);
            this.lblSumadora.Name = "lblSumadora";
            this.lblSumadora.Size = new System.Drawing.Size(130, 24);
            this.lblSumadora.TabIndex = 20;
            this.lblSumadora.Text = "SUMADORAS";
            // 
            // grpMotivo
            // 
            this.grpMotivo.Controls.Add(this.txtMotivo);
            this.grpMotivo.Location = new System.Drawing.Point(322, 44);
            this.grpMotivo.Name = "grpMotivo";
            this.grpMotivo.Size = new System.Drawing.Size(243, 82);
            this.grpMotivo.TabIndex = 20;
            this.grpMotivo.TabStop = false;
            this.grpMotivo.Text = "----";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(24, 32);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(196, 29);
            this.txtMotivo.TabIndex = 17;
            // 
            // btnCancelarEntSal
            // 
            this.btnCancelarEntSal.Location = new System.Drawing.Point(327, 360);
            this.btnCancelarEntSal.Name = "btnCancelarEntSal";
            this.btnCancelarEntSal.Size = new System.Drawing.Size(189, 54);
            this.btnCancelarEntSal.TabIndex = 18;
            this.btnCancelarEntSal.Text = "CANCELAR";
            this.btnCancelarEntSal.UseVisualStyleBackColor = true;
            this.btnCancelarEntSal.Click += new System.EventHandler(this.btnCancelarEntSal_Click);
            // 
            // btnAceptarInSa
            // 
            this.btnAceptarInSa.Location = new System.Drawing.Point(109, 360);
            this.btnAceptarInSa.Name = "btnAceptarInSa";
            this.btnAceptarInSa.Size = new System.Drawing.Size(189, 54);
            this.btnAceptarInSa.TabIndex = 17;
            this.btnAceptarInSa.Text = "ACEPTAR";
            this.btnAceptarInSa.UseVisualStyleBackColor = true;
            this.btnAceptarInSa.Click += new System.EventHandler(this.btnAceptarInSa_Click);
            // 
            // grpEntSal
            // 
            this.grpEntSal.Controls.Add(this.rdbSalida);
            this.grpEntSal.Controls.Add(this.rdbEntrada);
            this.grpEntSal.Location = new System.Drawing.Point(43, 42);
            this.grpEntSal.Name = "grpEntSal";
            this.grpEntSal.Size = new System.Drawing.Size(261, 82);
            this.grpEntSal.TabIndex = 19;
            this.grpEntSal.TabStop = false;
            // 
            // rdbSalida
            // 
            this.rdbSalida.AutoSize = true;
            this.rdbSalida.Location = new System.Drawing.Point(151, 34);
            this.rdbSalida.Name = "rdbSalida";
            this.rdbSalida.Size = new System.Drawing.Size(93, 28);
            this.rdbSalida.TabIndex = 1;
            this.rdbSalida.TabStop = true;
            this.rdbSalida.Text = "SALIDA";
            this.rdbSalida.UseVisualStyleBackColor = true;
            // 
            // rdbEntrada
            // 
            this.rdbEntrada.AutoSize = true;
            this.rdbEntrada.Location = new System.Drawing.Point(15, 34);
            this.rdbEntrada.Name = "rdbEntrada";
            this.rdbEntrada.Size = new System.Drawing.Size(119, 28);
            this.rdbEntrada.TabIndex = 0;
            this.rdbEntrada.TabStop = true;
            this.rdbEntrada.Text = "ENTRADA";
            this.rdbEntrada.UseVisualStyleBackColor = true;
            this.rdbEntrada.CheckedChanged += new System.EventHandler(this.rdbEntrada_CheckedChanged);
            // 
            // grpDolares
            // 
            this.grpDolares.Controls.Add(this.btnSumD);
            this.grpDolares.Controls.Add(this.lblTotalD);
            this.grpDolares.Controls.Add(this.label2);
            this.grpDolares.Controls.Add(this.txtMorD);
            this.grpDolares.Controls.Add(this.txtTotalD);
            this.grpDolares.Controls.Add(this.label3);
            this.grpDolares.Controls.Add(this.txtUmD);
            this.grpDolares.Controls.Add(this.label4);
            this.grpDolares.Controls.Add(this.txtCpD);
            this.grpDolares.Location = new System.Drawing.Point(9, 124);
            this.grpDolares.Name = "grpDolares";
            this.grpDolares.Size = new System.Drawing.Size(295, 225);
            this.grpDolares.TabIndex = 15;
            this.grpDolares.TabStop = false;
            this.grpDolares.Text = "DOLARES";
            // 
            // btnSumD
            // 
            this.btnSumD.BackgroundImage = global::PJ_CAJA_2.Properties.Resources.calcu;
            this.btnSumD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSumD.Location = new System.Drawing.Point(19, 71);
            this.btnSumD.Name = "btnSumD";
            this.btnSumD.Size = new System.Drawing.Size(71, 39);
            this.btnSumD.TabIndex = 9;
            this.btnSumD.UseVisualStyleBackColor = true;
            this.btnSumD.Click += new System.EventHandler(this.btnSumD_Click);
            // 
            // lblTotalD
            // 
            this.lblTotalD.AutoSize = true;
            this.lblTotalD.Location = new System.Drawing.Point(63, 176);
            this.lblTotalD.Name = "lblTotalD";
            this.lblTotalD.Size = new System.Drawing.Size(77, 24);
            this.lblTotalD.TabIndex = 15;
            this.lblTotalD.Text = "TOTAL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 24);
            this.label2.TabIndex = 14;
            this.label2.Text = "MORRALLA:";
            // 
            // txtMorD
            // 
            this.txtMorD.Location = new System.Drawing.Point(146, 24);
            this.txtMorD.Name = "txtMorD";
            this.txtMorD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMorD.Size = new System.Drawing.Size(136, 29);
            this.txtMorD.TabIndex = 8;
            this.txtMorD.Text = "00.00";
            this.txtMorD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMorD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMorD_KeyDown);
            // 
            // txtTotalD
            // 
            this.txtTotalD.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTotalD.ForeColor = System.Drawing.Color.DarkRed;
            this.txtTotalD.Location = new System.Drawing.Point(146, 173);
            this.txtTotalD.Name = "txtTotalD";
            this.txtTotalD.ReadOnly = true;
            this.txtTotalD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotalD.Size = new System.Drawing.Size(136, 29);
            this.txtTotalD.TabIndex = 16;
            this.txtTotalD.TabStop = false;
            this.txtTotalD.Text = "00.00";
            this.txtTotalD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "UM:";
            // 
            // txtUmD
            // 
            this.txtUmD.Location = new System.Drawing.Point(146, 75);
            this.txtUmD.Name = "txtUmD";
            this.txtUmD.ReadOnly = true;
            this.txtUmD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUmD.Size = new System.Drawing.Size(136, 29);
            this.txtUmD.TabIndex = 11;
            this.txtUmD.TabStop = false;
            this.txtUmD.Text = "00.00";
            this.txtUmD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUmD.Click += new System.EventHandler(this.txtUmD_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "CP:";
            // 
            // txtCpD
            // 
            this.txtCpD.Location = new System.Drawing.Point(146, 124);
            this.txtCpD.Name = "txtCpD";
            this.txtCpD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCpD.Size = new System.Drawing.Size(136, 29);
            this.txtCpD.TabIndex = 10;
            this.txtCpD.Text = "00.00";
            this.txtCpD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCpD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCpD_KeyDown);
            // 
            // grpPesos
            // 
            this.grpPesos.Controls.Add(this.btnSumP);
            this.grpPesos.Controls.Add(this.lblTotalP);
            this.grpPesos.Controls.Add(this.txtTotalP);
            this.grpPesos.Controls.Add(this.lblMor);
            this.grpPesos.Controls.Add(this.txtMorP);
            this.grpPesos.Controls.Add(this.lblUm);
            this.grpPesos.Controls.Add(this.txtUmP);
            this.grpPesos.Controls.Add(this.lblCp);
            this.grpPesos.Controls.Add(this.txtCpP);
            this.grpPesos.Location = new System.Drawing.Point(322, 124);
            this.grpPesos.Name = "grpPesos";
            this.grpPesos.Size = new System.Drawing.Size(295, 225);
            this.grpPesos.TabIndex = 16;
            this.grpPesos.TabStop = false;
            this.grpPesos.Text = "PESOS";
            // 
            // btnSumP
            // 
            this.btnSumP.BackgroundImage = global::PJ_CAJA_2.Properties.Resources.calcu;
            this.btnSumP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSumP.Location = new System.Drawing.Point(27, 71);
            this.btnSumP.Name = "btnSumP";
            this.btnSumP.Size = new System.Drawing.Size(71, 39);
            this.btnSumP.TabIndex = 9;
            this.btnSumP.UseVisualStyleBackColor = true;
            this.btnSumP.Click += new System.EventHandler(this.btnSumP_Click);
            // 
            // lblTotalP
            // 
            this.lblTotalP.AutoSize = true;
            this.lblTotalP.Location = new System.Drawing.Point(71, 176);
            this.lblTotalP.Name = "lblTotalP";
            this.lblTotalP.Size = new System.Drawing.Size(77, 24);
            this.lblTotalP.TabIndex = 17;
            this.lblTotalP.Text = "TOTAL:";
            // 
            // txtTotalP
            // 
            this.txtTotalP.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTotalP.ForeColor = System.Drawing.Color.DarkRed;
            this.txtTotalP.Location = new System.Drawing.Point(154, 173);
            this.txtTotalP.Name = "txtTotalP";
            this.txtTotalP.ReadOnly = true;
            this.txtTotalP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotalP.Size = new System.Drawing.Size(136, 29);
            this.txtTotalP.TabIndex = 18;
            this.txtTotalP.TabStop = false;
            this.txtTotalP.Text = "00.00";
            this.txtTotalP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMor
            // 
            this.lblMor.AutoSize = true;
            this.lblMor.Location = new System.Drawing.Point(30, 27);
            this.lblMor.Name = "lblMor";
            this.lblMor.Size = new System.Drawing.Size(118, 24);
            this.lblMor.TabIndex = 14;
            this.lblMor.Text = "MORRALLA:";
            // 
            // txtMorP
            // 
            this.txtMorP.Location = new System.Drawing.Point(154, 24);
            this.txtMorP.Name = "txtMorP";
            this.txtMorP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMorP.Size = new System.Drawing.Size(136, 29);
            this.txtMorP.TabIndex = 8;
            this.txtMorP.Text = "00.00";
            this.txtMorP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMorP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMorP_KeyDown);
            // 
            // lblUm
            // 
            this.lblUm.AutoSize = true;
            this.lblUm.Location = new System.Drawing.Point(104, 78);
            this.lblUm.Name = "lblUm";
            this.lblUm.Size = new System.Drawing.Size(44, 24);
            this.lblUm.TabIndex = 12;
            this.lblUm.Text = "UM:";
            // 
            // txtUmP
            // 
            this.txtUmP.Location = new System.Drawing.Point(154, 75);
            this.txtUmP.Name = "txtUmP";
            this.txtUmP.ReadOnly = true;
            this.txtUmP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUmP.Size = new System.Drawing.Size(136, 29);
            this.txtUmP.TabIndex = 11;
            this.txtUmP.TabStop = false;
            this.txtUmP.Text = "00.00";
            this.txtUmP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUmP.Click += new System.EventHandler(this.txtUmP_Click);
            // 
            // lblCp
            // 
            this.lblCp.AutoSize = true;
            this.lblCp.Location = new System.Drawing.Point(108, 127);
            this.lblCp.Name = "lblCp";
            this.lblCp.Size = new System.Drawing.Size(40, 24);
            this.lblCp.TabIndex = 9;
            this.lblCp.Text = "CP:";
            // 
            // txtCpP
            // 
            this.txtCpP.Location = new System.Drawing.Point(153, 124);
            this.txtCpP.Name = "txtCpP";
            this.txtCpP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCpP.Size = new System.Drawing.Size(136, 29);
            this.txtCpP.TabIndex = 10;
            this.txtCpP.Text = "00.00";
            this.txtCpP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCpP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCpP_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "ENTRADAS / SALIDAS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSalida
            // 
            this.btnSalida.Location = new System.Drawing.Point(1152, 536);
            this.btnSalida.Name = "btnSalida";
            this.btnSalida.Size = new System.Drawing.Size(189, 54);
            this.btnSalida.TabIndex = 21;
            this.btnSalida.Text = "Salida";
            this.btnSalida.UseVisualStyleBackColor = true;
            this.btnSalida.Click += new System.EventHandler(this.btnSalida_Click);
            // 
            // frmInicioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1596, 686);
            this.Controls.Add(this.pnlTiposCambio);
            this.Controls.Add(this.pnlEntSal);
            this.Controls.Add(this.btnSalida);
            this.Controls.Add(this.grpInicio);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInicioSesion";
            this.Text = "INICIO DE SESION";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInicioSesion_FormClosing);
            this.Load += new System.EventHandler(this.frmInicioSesion_Load);
            this.pnlTiposCambio.ResumeLayout(false);
            this.pnlTiposCambio.PerformLayout();
            this.grpInicio.ResumeLayout(false);
            this.grpInicio.PerformLayout();
            this.pnlEntSal.ResumeLayout(false);
            this.pnlEntSal.PerformLayout();
            this.pnlSumadora.ResumeLayout(false);
            this.pnlSumadora.PerformLayout();
            this.grpMotivo.ResumeLayout(false);
            this.grpMotivo.PerformLayout();
            this.grpEntSal.ResumeLayout(false);
            this.grpEntSal.PerformLayout();
            this.grpDolares.ResumeLayout(false);
            this.grpDolares.PerformLayout();
            this.grpPesos.ResumeLayout(false);
            this.grpPesos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.MonthCalendar clndFecha;
        private System.Windows.Forms.Label lblAdTiempo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlTiposCambio;
        private System.Windows.Forms.Button btnAceptarCambio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtVenta;
        private System.Windows.Forms.Label lblCambios;
        private System.Windows.Forms.Label lvlCompra;
        private System.Windows.Forms.TextBox txtCompra;
        private System.Windows.Forms.Button btnCancelarCambio;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox grpInicio;
        private System.Windows.Forms.Label lblHoras;
        private System.Windows.Forms.Panel pnlEntSal;
        private System.Windows.Forms.GroupBox grpMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Button btnCancelarEntSal;
        private System.Windows.Forms.Button btnAceptarInSa;
        private System.Windows.Forms.GroupBox grpEntSal;
        private System.Windows.Forms.RadioButton rdbSalida;
        private System.Windows.Forms.RadioButton rdbEntrada;
        private System.Windows.Forms.GroupBox grpDolares;
        private System.Windows.Forms.Button btnSumD;
        private System.Windows.Forms.Label lblTotalD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMorD;
        private System.Windows.Forms.TextBox txtTotalD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUmD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCpD;
        private System.Windows.Forms.GroupBox grpPesos;
        private System.Windows.Forms.Button btnSumP;
        private System.Windows.Forms.Label lblTotalP;
        private System.Windows.Forms.TextBox txtTotalP;
        private System.Windows.Forms.Label lblMor;
        private System.Windows.Forms.TextBox txtMorP;
        private System.Windows.Forms.Label lblUm;
        private System.Windows.Forms.TextBox txtUmP;
        private System.Windows.Forms.Label lblCp;
        private System.Windows.Forms.TextBox txtCpP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalida;
        private System.Windows.Forms.Label lblSumadora;
        private System.Windows.Forms.TextBox txtSuma1;
        private System.Windows.Forms.TextBox txtSuma2;
        private System.Windows.Forms.TextBox txtSuma3;
        private System.Windows.Forms.TextBox txtSuma4;
        private System.Windows.Forms.TextBox txtSuma5;
        private System.Windows.Forms.TextBox txtSumaTotal;
        private System.Windows.Forms.Button btnImprimirSum;
        private System.Windows.Forms.Button btnAceptarSum;
        private System.Windows.Forms.Button btnCancelarSum;
        private System.Windows.Forms.Panel pnlSumadora;
    }
}

