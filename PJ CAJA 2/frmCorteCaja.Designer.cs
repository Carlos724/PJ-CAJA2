
namespace PJ_CAJA_2
{
    partial class frmCorteCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCorteCaja));
            this.Animation = new System.Windows.Forms.Timer(this.components);
            this.pnlAnimacion = new System.Windows.Forms.Panel();
            this.lblTexto = new System.Windows.Forms.Label();
            this.picAnimacion = new System.Windows.Forms.PictureBox();
            this.prgImprimiendo = new System.Windows.Forms.ProgressBar();
            this.txtTexto = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlAnimacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnimacion)).BeginInit();
            this.SuspendLayout();
            // 
            // Animation
            // 
            this.Animation.Tick += new System.EventHandler(this.Animation_Tick);
            // 
            // pnlAnimacion
            // 
            this.pnlAnimacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlAnimacion.BackColor = System.Drawing.Color.White;
            this.pnlAnimacion.Controls.Add(this.btnSalir);
            this.pnlAnimacion.Controls.Add(this.lblTexto);
            this.pnlAnimacion.Controls.Add(this.picAnimacion);
            this.pnlAnimacion.Controls.Add(this.prgImprimiendo);
            this.pnlAnimacion.Controls.Add(this.txtTexto);
            this.pnlAnimacion.Location = new System.Drawing.Point(12, 14);
            this.pnlAnimacion.Name = "pnlAnimacion";
            this.pnlAnimacion.Size = new System.Drawing.Size(791, 259);
            this.pnlAnimacion.TabIndex = 4;
            // 
            // lblTexto
            // 
            this.lblTexto.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTexto.Location = new System.Drawing.Point(288, 177);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(289, 23);
            this.lblTexto.TabIndex = 3;
            this.lblTexto.Text = "Realizando corte de caja...";
            this.lblTexto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picAnimacion
            // 
            this.picAnimacion.Image = ((System.Drawing.Image)(resources.GetObject("picAnimacion.Image")));
            this.picAnimacion.InitialImage = null;
            this.picAnimacion.Location = new System.Drawing.Point(335, 45);
            this.picAnimacion.Name = "picAnimacion";
            this.picAnimacion.Size = new System.Drawing.Size(150, 129);
            this.picAnimacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAnimacion.TabIndex = 2;
            this.picAnimacion.TabStop = false;
            // 
            // prgImprimiendo
            // 
            this.prgImprimiendo.Location = new System.Drawing.Point(182, 200);
            this.prgImprimiendo.Name = "prgImprimiendo";
            this.prgImprimiendo.Size = new System.Drawing.Size(450, 23);
            this.prgImprimiendo.TabIndex = 1;
            // 
            // txtTexto
            // 
            this.txtTexto.AutoSize = true;
            this.txtTexto.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTexto.Location = new System.Drawing.Point(288, 174);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(0, 20);
            this.txtTexto.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(639, 110);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmCorteCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 287);
            this.ControlBox = false;
            this.Controls.Add(this.pnlAnimacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCorteCaja";
            this.Text = "CorteCaja";
            this.Load += new System.EventHandler(this.frmCorteCaja_Load);
            this.pnlAnimacion.ResumeLayout(false);
            this.pnlAnimacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAnimacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer Animation;
        private System.Windows.Forms.Panel pnlAnimacion;
        private System.Windows.Forms.PictureBox picAnimacion;
        private System.Windows.Forms.ProgressBar prgImprimiendo;
        private System.Windows.Forms.Label txtTexto;
        private System.Windows.Forms.Label lblTexto;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button btnSalir;
    }
}