
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
            this.lblHoras = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlInicios = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.grpDolares = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMorD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUmD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCpD = new System.Windows.Forms.TextBox();
            this.grpPesos = new System.Windows.Forms.GroupBox();
            this.lblMor = new System.Windows.Forms.Label();
            this.txtMorP = new System.Windows.Forms.TextBox();
            this.lblUm = new System.Windows.Forms.Label();
            this.txtUmP = new System.Windows.Forms.TextBox();
            this.lblCp = new System.Windows.Forms.Label();
            this.txtCpP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTiposCambio = new System.Windows.Forms.Panel();
            this.btnAceptarCambio = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVenta = new System.Windows.Forms.TextBox();
            this.lblCambios = new System.Windows.Forms.Label();
            this.lvlCompra = new System.Windows.Forms.Label();
            this.txtCompra = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnlInicios.SuspendLayout();
            this.grpDolares.SuspendLayout();
            this.grpPesos.SuspendLayout();
            this.pnlTiposCambio.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(403, 87);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(6);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(151, 29);
            this.txtUsuario.TabIndex = 0;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(337, 412);
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
            this.lblUsuario.Location = new System.Drawing.Point(293, 90);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(98, 24);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "USUARIO:";
            // 
            // clndFecha
            // 
            this.clndFecha.Location = new System.Drawing.Point(304, 190);
            this.clndFecha.Name = "clndFecha";
            this.clndFecha.TabIndex = 3;
            // 
            // lblAdTiempo
            // 
            this.lblAdTiempo.AutoSize = true;
            this.lblAdTiempo.Location = new System.Drawing.Point(293, 135);
            this.lblAdTiempo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAdTiempo.Name = "lblAdTiempo";
            this.lblAdTiempo.Size = new System.Drawing.Size(271, 48);
            this.lblAdTiempo.TabIndex = 4;
            this.lblAdTiempo.Text = "REVISA QUE FECHA Y HORA\r\nSEAN CORRECTOS";
            this.lblAdTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHoras
            // 
            this.lblHoras.AutoSize = true;
            this.lblHoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoras.Location = new System.Drawing.Point(372, 362);
            this.lblHoras.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHoras.Name = "lblHoras";
            this.lblHoras.Size = new System.Drawing.Size(127, 33);
            this.lblHoras.TabIndex = 5;
            this.lblHoras.Text = "00:00:00";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnlInicios
            // 
            this.pnlInicios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInicios.Controls.Add(this.btnCancelar);
            this.pnlInicios.Controls.Add(this.btnAceptar);
            this.pnlInicios.Controls.Add(this.grpDolares);
            this.pnlInicios.Controls.Add(this.grpPesos);
            this.pnlInicios.Controls.Add(this.label1);
            this.pnlInicios.Location = new System.Drawing.Point(142, 159);
            this.pnlInicios.Margin = new System.Windows.Forms.Padding(4);
            this.pnlInicios.Name = "pnlInicios";
            this.pnlInicios.Size = new System.Drawing.Size(631, 345);
            this.pnlInicios.TabIndex = 6;
            this.pnlInicios.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(334, 266);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(189, 54);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(106, 266);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(189, 54);
            this.btnAceptar.TabIndex = 17;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // grpDolares
            // 
            this.grpDolares.Controls.Add(this.label2);
            this.grpDolares.Controls.Add(this.txtMorD);
            this.grpDolares.Controls.Add(this.label3);
            this.grpDolares.Controls.Add(this.txtUmD);
            this.grpDolares.Controls.Add(this.label4);
            this.grpDolares.Controls.Add(this.txtCpD);
            this.grpDolares.Location = new System.Drawing.Point(321, 68);
            this.grpDolares.Margin = new System.Windows.Forms.Padding(4);
            this.grpDolares.Name = "grpDolares";
            this.grpDolares.Padding = new System.Windows.Forms.Padding(4);
            this.grpDolares.Size = new System.Drawing.Size(284, 175);
            this.grpDolares.TabIndex = 16;
            this.grpDolares.TabStop = false;
            this.grpDolares.Text = "DOLARES";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 122);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 24);
            this.label2.TabIndex = 14;
            this.label2.Text = "MORRALLA:";
            // 
            // txtMorD
            // 
            this.txtMorD.Location = new System.Drawing.Point(139, 118);
            this.txtMorD.Margin = new System.Windows.Forms.Padding(4);
            this.txtMorD.Name = "txtMorD";
            this.txtMorD.Size = new System.Drawing.Size(136, 29);
            this.txtMorD.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "UM:";
            // 
            // txtUmD
            // 
            this.txtUmD.Location = new System.Drawing.Point(139, 66);
            this.txtUmD.Margin = new System.Windows.Forms.Padding(4);
            this.txtUmD.Name = "txtUmD";
            this.txtUmD.Size = new System.Drawing.Size(136, 29);
            this.txtUmD.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "CP:";
            // 
            // txtCpD
            // 
            this.txtCpD.Location = new System.Drawing.Point(139, 20);
            this.txtCpD.Margin = new System.Windows.Forms.Padding(4);
            this.txtCpD.Name = "txtCpD";
            this.txtCpD.Size = new System.Drawing.Size(136, 29);
            this.txtCpD.TabIndex = 8;
            // 
            // grpPesos
            // 
            this.grpPesos.Controls.Add(this.lblMor);
            this.grpPesos.Controls.Add(this.txtMorP);
            this.grpPesos.Controls.Add(this.lblUm);
            this.grpPesos.Controls.Add(this.txtUmP);
            this.grpPesos.Controls.Add(this.lblCp);
            this.grpPesos.Controls.Add(this.txtCpP);
            this.grpPesos.Location = new System.Drawing.Point(15, 68);
            this.grpPesos.Margin = new System.Windows.Forms.Padding(4);
            this.grpPesos.Name = "grpPesos";
            this.grpPesos.Padding = new System.Windows.Forms.Padding(4);
            this.grpPesos.Size = new System.Drawing.Size(284, 175);
            this.grpPesos.TabIndex = 15;
            this.grpPesos.TabStop = false;
            this.grpPesos.Text = "PESOS";
            // 
            // lblMor
            // 
            this.lblMor.AutoSize = true;
            this.lblMor.Location = new System.Drawing.Point(9, 122);
            this.lblMor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMor.Name = "lblMor";
            this.lblMor.Size = new System.Drawing.Size(118, 24);
            this.lblMor.TabIndex = 14;
            this.lblMor.Text = "MORRALLA:";
            // 
            // txtMorP
            // 
            this.txtMorP.Location = new System.Drawing.Point(139, 118);
            this.txtMorP.Margin = new System.Windows.Forms.Padding(4);
            this.txtMorP.Name = "txtMorP";
            this.txtMorP.Size = new System.Drawing.Size(136, 29);
            this.txtMorP.TabIndex = 13;
            // 
            // lblUm
            // 
            this.lblUm.AutoSize = true;
            this.lblUm.Location = new System.Drawing.Point(83, 68);
            this.lblUm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUm.Name = "lblUm";
            this.lblUm.Size = new System.Drawing.Size(44, 24);
            this.lblUm.TabIndex = 12;
            this.lblUm.Text = "UM:";
            // 
            // txtUmP
            // 
            this.txtUmP.Location = new System.Drawing.Point(139, 66);
            this.txtUmP.Margin = new System.Windows.Forms.Padding(4);
            this.txtUmP.Name = "txtUmP";
            this.txtUmP.Size = new System.Drawing.Size(136, 29);
            this.txtUmP.TabIndex = 11;
            // 
            // lblCp
            // 
            this.lblCp.AutoSize = true;
            this.lblCp.Location = new System.Drawing.Point(83, 22);
            this.lblCp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCp.Name = "lblCp";
            this.lblCp.Size = new System.Drawing.Size(40, 24);
            this.lblCp.TabIndex = 9;
            this.lblCp.Text = "CP:";
            // 
            // txtCpP
            // 
            this.txtCpP.Location = new System.Drawing.Point(139, 20);
            this.txtCpP.Margin = new System.Windows.Forms.Padding(4);
            this.txtCpP.Name = "txtCpP";
            this.txtCpP.Size = new System.Drawing.Size(136, 29);
            this.txtCpP.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "INGRESA INICIOS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTiposCambio
            // 
            this.pnlTiposCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTiposCambio.Controls.Add(this.btnAceptarCambio);
            this.pnlTiposCambio.Controls.Add(this.label5);
            this.pnlTiposCambio.Controls.Add(this.txtVenta);
            this.pnlTiposCambio.Controls.Add(this.lblCambios);
            this.pnlTiposCambio.Controls.Add(this.lvlCompra);
            this.pnlTiposCambio.Controls.Add(this.txtCompra);
            this.pnlTiposCambio.Location = new System.Drawing.Point(265, 159);
            this.pnlTiposCambio.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTiposCambio.Name = "pnlTiposCambio";
            this.pnlTiposCambio.Size = new System.Drawing.Size(349, 236);
            this.pnlTiposCambio.TabIndex = 7;
            this.pnlTiposCambio.Visible = false;
            // 
            // btnAceptarCambio
            // 
            this.btnAceptarCambio.Location = new System.Drawing.Point(83, 157);
            this.btnAceptarCambio.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptarCambio.Name = "btnAceptarCambio";
            this.btnAceptarCambio.Size = new System.Drawing.Size(189, 54);
            this.btnAceptarCambio.TabIndex = 19;
            this.btnAceptarCambio.Text = "ACEPTAR";
            this.btnAceptarCambio.UseVisualStyleBackColor = true;
            this.btnAceptarCambio.Click += new System.EventHandler(this.btnAceptarCambio_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 109);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = "VENTA:";
            // 
            // txtVenta
            // 
            this.txtVenta.Location = new System.Drawing.Point(163, 103);
            this.txtVenta.Margin = new System.Windows.Forms.Padding(4);
            this.txtVenta.Name = "txtVenta";
            this.txtVenta.Size = new System.Drawing.Size(136, 29);
            this.txtVenta.TabIndex = 13;
            // 
            // lblCambios
            // 
            this.lblCambios.AutoSize = true;
            this.lblCambios.Location = new System.Drawing.Point(95, 11);
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
            this.lvlCompra.Location = new System.Drawing.Point(61, 55);
            this.lvlCompra.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lvlCompra.Name = "lvlCompra";
            this.lvlCompra.Size = new System.Drawing.Size(97, 24);
            this.lvlCompra.TabIndex = 11;
            this.lvlCompra.Text = "COMPRA:";
            // 
            // txtCompra
            // 
            this.txtCompra.Location = new System.Drawing.Point(163, 50);
            this.txtCompra.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompra.Name = "txtCompra";
            this.txtCompra.Size = new System.Drawing.Size(136, 29);
            this.txtCompra.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.lblUsuario);
            this.groupBox1.Controls.Add(this.pnlInicios);
            this.groupBox1.Controls.Add(this.pnlTiposCambio);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.btnIniciar);
            this.groupBox1.Controls.Add(this.lblHoras);
            this.groupBox1.Controls.Add(this.clndFecha);
            this.groupBox1.Controls.Add(this.lblAdTiempo);
            this.groupBox1.Location = new System.Drawing.Point(17, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(906, 574);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // frmInicioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 685);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInicioSesion";
            this.Text = "INICIO DE SESION";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInicioSesion_FormClosing);
            this.Load += new System.EventHandler(this.frmInicioSesion_Load);
            this.pnlInicios.ResumeLayout(false);
            this.pnlInicios.PerformLayout();
            this.grpDolares.ResumeLayout(false);
            this.grpDolares.PerformLayout();
            this.grpPesos.ResumeLayout(false);
            this.grpPesos.PerformLayout();
            this.pnlTiposCambio.ResumeLayout(false);
            this.pnlTiposCambio.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.MonthCalendar clndFecha;
        private System.Windows.Forms.Label lblAdTiempo;
        private System.Windows.Forms.Label lblHoras;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlInicios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCpP;
        private System.Windows.Forms.Label lblCp;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox grpDolares;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMorD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUmD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCpD;
        private System.Windows.Forms.GroupBox grpPesos;
        private System.Windows.Forms.Label lblMor;
        private System.Windows.Forms.TextBox txtMorP;
        private System.Windows.Forms.Label lblUm;
        private System.Windows.Forms.TextBox txtUmP;
        private System.Windows.Forms.Panel pnlTiposCambio;
        private System.Windows.Forms.Button btnAceptarCambio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtVenta;
        private System.Windows.Forms.Label lblCambios;
        private System.Windows.Forms.Label lvlCompra;
        private System.Windows.Forms.TextBox txtCompra;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

