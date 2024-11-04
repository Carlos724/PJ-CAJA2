
namespace PJ_CAJA_2
{
    partial class frmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnVenta = new System.Windows.Forms.Button();
            this.btnCompra = new System.Windows.Forms.Button();
            this.btnSumadora = new System.Windows.Forms.Button();
            this.btnEntSal = new System.Windows.Forms.Button();
            this.btnListOperaciones = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblCompra = new System.Windows.Forms.Label();
            this.lblTCCompra = new System.Windows.Forms.Label();
            this.lblVenta = new System.Windows.Forms.Label();
            this.lblTCVenta = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlElegirDes = new System.Windows.Forms.Panel();
            this.lblDes = new System.Windows.Forms.Label();
            this.btnSinDes = new System.Windows.Forms.Button();
            this.btnConDes = new System.Windows.Forms.Button();
            this.pnlTransaccionSin = new System.Windows.Forms.Panel();
            this.pnlContinuarSin = new System.Windows.Forms.Panel();
            this.btnCancContSin = new System.Windows.Forms.Button();
            this.btnEspContiSin = new System.Windows.Forms.Button();
            this.btnNoContiSin = new System.Windows.Forms.Button();
            this.btnSiContiSin = new System.Windows.Forms.Button();
            this.lblContinuarSin = new System.Windows.Forms.Label();
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.txtPago = new System.Windows.Forms.TextBox();
            this.lblCambio = new System.Windows.Forms.Label();
            this.lblPago = new System.Windows.Forms.Label();
            this.txtConversion = new System.Windows.Forms.TextBox();
            this.txtTC = new System.Windows.Forms.TextBox();
            this.lblConversion = new System.Windows.Forms.Label();
            this.lblTC = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblTransSin = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.tmrHora = new System.Windows.Forms.Timer(this.components);
            this.lblFecha = new System.Windows.Forms.Label();
            this.pnlConSinFin = new System.Windows.Forms.Panel();
            this.btnCancSinFin = new System.Windows.Forms.Button();
            this.btnNoSinFin = new System.Windows.Forms.Button();
            this.btnSiSinFin = new System.Windows.Forms.Button();
            this.lblConSinFin = new System.Windows.Forms.Label();
            this.pnlMenu.SuspendLayout();
            this.pnlElegirDes.SuspendLayout();
            this.pnlTransaccionSin.SuspendLayout();
            this.pnlContinuarSin.SuspendLayout();
            this.pnlConSinFin.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVenta
            // 
            this.btnVenta.Location = new System.Drawing.Point(18, 69);
            this.btnVenta.Margin = new System.Windows.Forms.Padding(6);
            this.btnVenta.Name = "btnVenta";
            this.btnVenta.Size = new System.Drawing.Size(197, 84);
            this.btnVenta.TabIndex = 0;
            this.btnVenta.Text = "[1] VENTA";
            this.btnVenta.UseVisualStyleBackColor = true;
            this.btnVenta.Click += new System.EventHandler(this.btnVenta_Click);
            // 
            // btnCompra
            // 
            this.btnCompra.Location = new System.Drawing.Point(18, 222);
            this.btnCompra.Margin = new System.Windows.Forms.Padding(6);
            this.btnCompra.Name = "btnCompra";
            this.btnCompra.Size = new System.Drawing.Size(197, 84);
            this.btnCompra.TabIndex = 1;
            this.btnCompra.Text = "[2] COMPRA";
            this.btnCompra.UseVisualStyleBackColor = true;
            this.btnCompra.Click += new System.EventHandler(this.btnCompra_Click);
            // 
            // btnSumadora
            // 
            this.btnSumadora.Location = new System.Drawing.Point(253, 141);
            this.btnSumadora.Margin = new System.Windows.Forms.Padding(6);
            this.btnSumadora.Name = "btnSumadora";
            this.btnSumadora.Size = new System.Drawing.Size(150, 85);
            this.btnSumadora.TabIndex = 2;
            this.btnSumadora.Text = "[F11] SUMADORA";
            this.btnSumadora.UseVisualStyleBackColor = true;
            // 
            // btnEntSal
            // 
            this.btnEntSal.Location = new System.Drawing.Point(433, 69);
            this.btnEntSal.Margin = new System.Windows.Forms.Padding(6);
            this.btnEntSal.Name = "btnEntSal";
            this.btnEntSal.Size = new System.Drawing.Size(197, 84);
            this.btnEntSal.TabIndex = 3;
            this.btnEntSal.Text = "[F5] ENTRADAS/ \r\nSALIDAS";
            this.btnEntSal.UseVisualStyleBackColor = true;
            // 
            // btnListOperaciones
            // 
            this.btnListOperaciones.Location = new System.Drawing.Point(433, 222);
            this.btnListOperaciones.Margin = new System.Windows.Forms.Padding(6);
            this.btnListOperaciones.Name = "btnListOperaciones";
            this.btnListOperaciones.Size = new System.Drawing.Size(197, 84);
            this.btnListOperaciones.TabIndex = 4;
            this.btnListOperaciones.Text = "[F2] LISTADO DE OPERACIONES";
            this.btnListOperaciones.UseVisualStyleBackColor = true;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(152, 80);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(86, 25);
            this.lblUsuario.TabIndex = 5;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Location = new System.Drawing.Point(897, 80);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(102, 25);
            this.lblHora.TabIndex = 6;
            this.lblHora.Text = " 00:00:00";
            // 
            // lblCompra
            // 
            this.lblCompra.AutoSize = true;
            this.lblCompra.Location = new System.Drawing.Point(95, 5);
            this.lblCompra.Name = "lblCompra";
            this.lblCompra.Size = new System.Drawing.Size(110, 25);
            this.lblCompra.TabIndex = 7;
            this.lblCompra.Text = "COMPRA:";
            // 
            // lblTCCompra
            // 
            this.lblTCCompra.AutoSize = true;
            this.lblTCCompra.Location = new System.Drawing.Point(211, 5);
            this.lblTCCompra.Name = "lblTCCompra";
            this.lblTCCompra.Size = new System.Drawing.Size(66, 25);
            this.lblTCCompra.TabIndex = 8;
            this.lblTCCompra.Text = "00.00";
            // 
            // lblVenta
            // 
            this.lblVenta.AutoSize = true;
            this.lblVenta.Location = new System.Drawing.Point(391, 5);
            this.lblVenta.Name = "lblVenta";
            this.lblVenta.Size = new System.Drawing.Size(88, 25);
            this.lblVenta.TabIndex = 9;
            this.lblVenta.Text = "VENTA:";
            // 
            // lblTCVenta
            // 
            this.lblTCVenta.AutoSize = true;
            this.lblTCVenta.Location = new System.Drawing.Point(485, 5);
            this.lblTCVenta.Name = "lblTCVenta";
            this.lblTCVenta.Size = new System.Drawing.Size(66, 25);
            this.lblTCVenta.TabIndex = 10;
            this.lblTCVenta.Text = "00.00";
            // 
            // pnlMenu
            // 
            this.pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMenu.Controls.Add(this.pnlElegirDes);
            this.pnlMenu.Controls.Add(this.lblTCVenta);
            this.pnlMenu.Controls.Add(this.lblVenta);
            this.pnlMenu.Controls.Add(this.lblTCCompra);
            this.pnlMenu.Controls.Add(this.lblCompra);
            this.pnlMenu.Controls.Add(this.btnListOperaciones);
            this.pnlMenu.Controls.Add(this.btnEntSal);
            this.pnlMenu.Controls.Add(this.btnSumadora);
            this.pnlMenu.Controls.Add(this.btnCompra);
            this.pnlMenu.Controls.Add(this.btnVenta);
            this.pnlMenu.Location = new System.Drawing.Point(246, 139);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(645, 351);
            this.pnlMenu.TabIndex = 11;
            // 
            // pnlElegirDes
            // 
            this.pnlElegirDes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlElegirDes.Controls.Add(this.lblDes);
            this.pnlElegirDes.Controls.Add(this.btnSinDes);
            this.pnlElegirDes.Controls.Add(this.btnConDes);
            this.pnlElegirDes.Location = new System.Drawing.Point(141, 92);
            this.pnlElegirDes.Name = "pnlElegirDes";
            this.pnlElegirDes.Size = new System.Drawing.Size(379, 151);
            this.pnlElegirDes.TabIndex = 12;
            this.pnlElegirDes.Visible = false;
            // 
            // lblDes
            // 
            this.lblDes.AutoSize = true;
            this.lblDes.Location = new System.Drawing.Point(26, 18);
            this.lblDes.Name = "lblDes";
            this.lblDes.Size = new System.Drawing.Size(321, 25);
            this.lblDes.TabIndex = 8;
            this.lblDes.Text = "¿COMO DESEAS CONTINUAR?";
            // 
            // btnSinDes
            // 
            this.btnSinDes.Location = new System.Drawing.Point(207, 56);
            this.btnSinDes.Name = "btnSinDes";
            this.btnSinDes.Size = new System.Drawing.Size(151, 70);
            this.btnSinDes.TabIndex = 1;
            this.btnSinDes.Text = "SIN DESGLOCE";
            this.btnSinDes.UseVisualStyleBackColor = true;
            this.btnSinDes.Click += new System.EventHandler(this.btnSinDes_Click);
            // 
            // btnConDes
            // 
            this.btnConDes.Location = new System.Drawing.Point(20, 56);
            this.btnConDes.Name = "btnConDes";
            this.btnConDes.Size = new System.Drawing.Size(151, 70);
            this.btnConDes.TabIndex = 0;
            this.btnConDes.Text = "CON DESGLOCE";
            this.btnConDes.UseVisualStyleBackColor = true;
            // 
            // pnlTransaccionSin
            // 
            this.pnlTransaccionSin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTransaccionSin.Controls.Add(this.pnlContinuarSin);
            this.pnlTransaccionSin.Controls.Add(this.txtCambio);
            this.pnlTransaccionSin.Controls.Add(this.txtPago);
            this.pnlTransaccionSin.Controls.Add(this.lblCambio);
            this.pnlTransaccionSin.Controls.Add(this.lblPago);
            this.pnlTransaccionSin.Controls.Add(this.txtConversion);
            this.pnlTransaccionSin.Controls.Add(this.txtTC);
            this.pnlTransaccionSin.Controls.Add(this.lblConversion);
            this.pnlTransaccionSin.Controls.Add(this.lblTC);
            this.pnlTransaccionSin.Controls.Add(this.lblCantidad);
            this.pnlTransaccionSin.Controls.Add(this.lblTransSin);
            this.pnlTransaccionSin.Controls.Add(this.txtCantidad);
            this.pnlTransaccionSin.Location = new System.Drawing.Point(265, 115);
            this.pnlTransaccionSin.Name = "pnlTransaccionSin";
            this.pnlTransaccionSin.Size = new System.Drawing.Size(515, 400);
            this.pnlTransaccionSin.TabIndex = 12;
            this.pnlTransaccionSin.Visible = false;
            // 
            // pnlContinuarSin
            // 
            this.pnlContinuarSin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContinuarSin.Controls.Add(this.btnCancContSin);
            this.pnlContinuarSin.Controls.Add(this.btnEspContiSin);
            this.pnlContinuarSin.Controls.Add(this.btnNoContiSin);
            this.pnlContinuarSin.Controls.Add(this.btnSiContiSin);
            this.pnlContinuarSin.Controls.Add(this.lblContinuarSin);
            this.pnlContinuarSin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlContinuarSin.Location = new System.Drawing.Point(96, 259);
            this.pnlContinuarSin.Name = "pnlContinuarSin";
            this.pnlContinuarSin.Size = new System.Drawing.Size(335, 100);
            this.pnlContinuarSin.TabIndex = 17;
            // 
            // btnCancContSin
            // 
            this.btnCancContSin.Location = new System.Drawing.Point(232, 38);
            this.btnCancContSin.Name = "btnCancContSin";
            this.btnCancContSin.Size = new System.Drawing.Size(97, 47);
            this.btnCancContSin.TabIndex = 17;
            this.btnCancContSin.Text = "Cancelar";
            this.btnCancContSin.UseVisualStyleBackColor = true;
            this.btnCancContSin.Click += new System.EventHandler(this.btnCancContSin_Click);
            // 
            // btnEspContiSin
            // 
            this.btnEspContiSin.Location = new System.Drawing.Point(143, 38);
            this.btnEspContiSin.Name = "btnEspContiSin";
            this.btnEspContiSin.Size = new System.Drawing.Size(83, 47);
            this.btnEspContiSin.TabIndex = 16;
            this.btnEspContiSin.Text = "Especial";
            this.btnEspContiSin.UseVisualStyleBackColor = true;
            this.btnEspContiSin.Click += new System.EventHandler(this.btnEspContiSin_Click);
            // 
            // btnNoContiSin
            // 
            this.btnNoContiSin.Location = new System.Drawing.Point(77, 38);
            this.btnNoContiSin.Name = "btnNoContiSin";
            this.btnNoContiSin.Size = new System.Drawing.Size(60, 47);
            this.btnNoContiSin.TabIndex = 15;
            this.btnNoContiSin.Text = "No";
            this.btnNoContiSin.UseVisualStyleBackColor = true;
            this.btnNoContiSin.Click += new System.EventHandler(this.btnNoContiSin_Click);
            // 
            // btnSiContiSin
            // 
            this.btnSiContiSin.Location = new System.Drawing.Point(10, 38);
            this.btnSiContiSin.Name = "btnSiContiSin";
            this.btnSiContiSin.Size = new System.Drawing.Size(61, 47);
            this.btnSiContiSin.TabIndex = 14;
            this.btnSiContiSin.Text = "Si";
            this.btnSiContiSin.UseVisualStyleBackColor = true;
            this.btnSiContiSin.Click += new System.EventHandler(this.btnSiContiSin_Click);
            // 
            // lblContinuarSin
            // 
            this.lblContinuarSin.AutoSize = true;
            this.lblContinuarSin.Location = new System.Drawing.Point(120, 9);
            this.lblContinuarSin.Name = "lblContinuarSin";
            this.lblContinuarSin.Size = new System.Drawing.Size(100, 20);
            this.lblContinuarSin.TabIndex = 13;
            this.lblContinuarSin.Text = "¿Continuar?";
            // 
            // txtCambio
            // 
            this.txtCambio.Enabled = false;
            this.txtCambio.Location = new System.Drawing.Point(283, 309);
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.Size = new System.Drawing.Size(152, 31);
            this.txtCambio.TabIndex = 20;
            this.txtCambio.Text = "00.00";
            // 
            // txtPago
            // 
            this.txtPago.Enabled = false;
            this.txtPago.Location = new System.Drawing.Point(283, 259);
            this.txtPago.Name = "txtPago";
            this.txtPago.Size = new System.Drawing.Size(152, 31);
            this.txtPago.TabIndex = 19;
            this.txtPago.Text = "00.00";
            // 
            // lblCambio
            // 
            this.lblCambio.AutoSize = true;
            this.lblCambio.Location = new System.Drawing.Point(168, 312);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(100, 25);
            this.lblCambio.TabIndex = 18;
            this.lblCambio.Text = "CAMBIO:";
            // 
            // lblPago
            // 
            this.lblPago.AutoSize = true;
            this.lblPago.Location = new System.Drawing.Point(190, 262);
            this.lblPago.Name = "lblPago";
            this.lblPago.Size = new System.Drawing.Size(78, 25);
            this.lblPago.TabIndex = 17;
            this.lblPago.Text = "PAGO:";
            // 
            // txtConversion
            // 
            this.txtConversion.Location = new System.Drawing.Point(298, 163);
            this.txtConversion.Name = "txtConversion";
            this.txtConversion.Size = new System.Drawing.Size(152, 31);
            this.txtConversion.TabIndex = 16;
            this.txtConversion.Text = "00.00";
            // 
            // txtTC
            // 
            this.txtTC.Location = new System.Drawing.Point(298, 113);
            this.txtTC.Name = "txtTC";
            this.txtTC.Size = new System.Drawing.Size(152, 31);
            this.txtTC.TabIndex = 15;
            this.txtTC.Text = "00.00";
            // 
            // lblConversion
            // 
            this.lblConversion.AutoSize = true;
            this.lblConversion.Location = new System.Drawing.Point(32, 166);
            this.lblConversion.Name = "lblConversion";
            this.lblConversion.Size = new System.Drawing.Size(260, 25);
            this.lblConversion.TabIndex = 14;
            this.lblConversion.Text = "DOLARES A ENTREGAR:";
            // 
            // lblTC
            // 
            this.lblTC.AutoSize = true;
            this.lblTC.Location = new System.Drawing.Point(103, 116);
            this.lblTC.Name = "lblTC";
            this.lblTC.Size = new System.Drawing.Size(189, 25);
            this.lblTC.TabIndex = 13;
            this.lblTC.Text = "TIPO DE CAMBIO:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(83, 67);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(209, 25);
            this.lblCantidad.TabIndex = 12;
            this.lblCantidad.Text = "PESOS RECIBIDOS:";
            // 
            // lblTransSin
            // 
            this.lblTransSin.AutoSize = true;
            this.lblTransSin.Location = new System.Drawing.Point(187, 23);
            this.lblTransSin.Name = "lblTransSin";
            this.lblTransSin.Size = new System.Drawing.Size(179, 25);
            this.lblTransSin.TabIndex = 11;
            this.lblTransSin.Text = "VENTA DIRECTA";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(298, 64);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(152, 31);
            this.txtCantidad.TabIndex = 0;
            this.txtCantidad.Text = "00.00";
            this.txtCantidad.Leave += new System.EventHandler(this.txtCantidad_Leave);
            // 
            // tmrHora
            // 
            this.tmrHora.Tick += new System.EventHandler(this.tmrHora_Tick);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(795, 80);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(96, 25);
            this.lblFecha.TabIndex = 13;
            this.lblFecha.Text = "##/##/##";
            // 
            // pnlConSinFin
            // 
            this.pnlConSinFin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConSinFin.Controls.Add(this.btnCancSinFin);
            this.pnlConSinFin.Controls.Add(this.btnNoSinFin);
            this.pnlConSinFin.Controls.Add(this.btnSiSinFin);
            this.pnlConSinFin.Controls.Add(this.lblConSinFin);
            this.pnlConSinFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlConSinFin.Location = new System.Drawing.Point(782, 412);
            this.pnlConSinFin.Name = "pnlConSinFin";
            this.pnlConSinFin.Size = new System.Drawing.Size(253, 100);
            this.pnlConSinFin.TabIndex = 18;
            this.pnlConSinFin.Visible = false;
            // 
            // btnCancSinFin
            // 
            this.btnCancSinFin.Location = new System.Drawing.Point(143, 38);
            this.btnCancSinFin.Name = "btnCancSinFin";
            this.btnCancSinFin.Size = new System.Drawing.Size(97, 47);
            this.btnCancSinFin.TabIndex = 17;
            this.btnCancSinFin.Text = "Cancelar";
            this.btnCancSinFin.UseVisualStyleBackColor = true;
            this.btnCancSinFin.Click += new System.EventHandler(this.btnCancSinFin_Click);
            // 
            // btnNoSinFin
            // 
            this.btnNoSinFin.Location = new System.Drawing.Point(77, 38);
            this.btnNoSinFin.Name = "btnNoSinFin";
            this.btnNoSinFin.Size = new System.Drawing.Size(60, 47);
            this.btnNoSinFin.TabIndex = 15;
            this.btnNoSinFin.Text = "No";
            this.btnNoSinFin.UseVisualStyleBackColor = true;
            this.btnNoSinFin.Click += new System.EventHandler(this.btnNoSinFin_Click);
            // 
            // btnSiSinFin
            // 
            this.btnSiSinFin.Location = new System.Drawing.Point(10, 38);
            this.btnSiSinFin.Name = "btnSiSinFin";
            this.btnSiSinFin.Size = new System.Drawing.Size(61, 47);
            this.btnSiSinFin.TabIndex = 14;
            this.btnSiSinFin.Text = "Si";
            this.btnSiSinFin.UseVisualStyleBackColor = true;
            // 
            // lblConSinFin
            // 
            this.lblConSinFin.AutoSize = true;
            this.lblConSinFin.Location = new System.Drawing.Point(79, 8);
            this.lblConSinFin.Name = "lblConSinFin";
            this.lblConSinFin.Size = new System.Drawing.Size(100, 20);
            this.lblConSinFin.TabIndex = 13;
            this.lblConSinFin.Text = "¿Continuar?";
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 680);
            this.Controls.Add(this.pnlConSinFin);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.pnlTransaccionSin);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.lblUsuario);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmMenu";
            this.Text = "MENU";
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.pnlElegirDes.ResumeLayout(false);
            this.pnlElegirDes.PerformLayout();
            this.pnlTransaccionSin.ResumeLayout(false);
            this.pnlTransaccionSin.PerformLayout();
            this.pnlContinuarSin.ResumeLayout(false);
            this.pnlContinuarSin.PerformLayout();
            this.pnlConSinFin.ResumeLayout(false);
            this.pnlConSinFin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVenta;
        private System.Windows.Forms.Button btnCompra;
        private System.Windows.Forms.Button btnSumadora;
        private System.Windows.Forms.Button btnEntSal;
        private System.Windows.Forms.Button btnListOperaciones;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblCompra;
        private System.Windows.Forms.Label lblTCCompra;
        private System.Windows.Forms.Label lblVenta;
        private System.Windows.Forms.Label lblTCVenta;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlElegirDes;
        private System.Windows.Forms.Button btnConDes;
        private System.Windows.Forms.Button btnSinDes;
        private System.Windows.Forms.Label lblDes;
        private System.Windows.Forms.Panel pnlTransaccionSin;
        private System.Windows.Forms.Panel pnlContinuarSin;
        private System.Windows.Forms.Button btnCancContSin;
        private System.Windows.Forms.Button btnEspContiSin;
        private System.Windows.Forms.Button btnNoContiSin;
        private System.Windows.Forms.Button btnSiContiSin;
        private System.Windows.Forms.Label lblContinuarSin;
        private System.Windows.Forms.TextBox txtConversion;
        private System.Windows.Forms.TextBox txtTC;
        private System.Windows.Forms.Label lblConversion;
        private System.Windows.Forms.Label lblTC;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblTransSin;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Timer tmrHora;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtCambio;
        private System.Windows.Forms.TextBox txtPago;
        private System.Windows.Forms.Label lblCambio;
        private System.Windows.Forms.Label lblPago;
        private System.Windows.Forms.Panel pnlConSinFin;
        private System.Windows.Forms.Button btnCancSinFin;
        private System.Windows.Forms.Button btnNoSinFin;
        private System.Windows.Forms.Button btnSiSinFin;
        private System.Windows.Forms.Label lblConSinFin;
    }
}