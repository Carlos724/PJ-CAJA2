using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PJ_CAJA_2
{
    public partial class frmMenu : Form
    {
        //Variable para definir venta u operacion
        string ClaseOp = "O";

        double dblCantidad;
        double dblConversion;
        double dblCambio;
        double dblPago;
        double dblTC;
        public frmMenu()
        {
            InitializeComponent();
            lblUsuario.Text = Properties.Settings.Default.strUsuario_;
            lblTCCompra.Text = Properties.Settings.Default.dblTCCompra_.ToString();
            lblTCVenta.Text = Properties.Settings.Default.dblTCVenta_.ToString();
            lblFecha.Text= DateTime.Now.ToString("dd/MM/yy");
            tmrHora.Interval = 1000;
            tmrHora.Start();
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            ClaseOp = "V";
            pnlElegirDes.Visible = true;
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            ClaseOp = "C";
            pnlElegirDes.Visible = true;
        }

        private void btnSinDes_Click(object sender, EventArgs e)
        {
            if (ClaseOp == "V")
            {
                lblTransSin.Text = "VENTA DIRECTA";
                lblCantidad.Text = "PESOS:";
                lblConversion.Text = "DOLARES:";

                dblTC = Properties.Settings.Default.dblTCVenta_;
                txtTC.Text = dblTC.ToString();
            }
            else
            {
                lblTransSin.Text = "COMPRA DIRECTA";
                lblCantidad.Text = "DOLARES:";
                lblConversion.Text = "PESOS:";

                dblTC = Properties.Settings.Default.dblTCCompra_;
                txtTC.Text = dblTC.ToString();
            }
            pnlTransaccionSin.Visible = true;
            txtCantidad.Focus();
        }

        private void tmrHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            dblCantidad = double.Parse(txtCantidad.Text);
            dblConversion = Conversion(dblCantidad, dblTC);
            txtConversion.Text = dblConversion.ToString();
            pnlContinuarSin.Visible = true;
            btnSiContiSin.Focus();
        }

        private void txtTC_Leave(object sender, EventArgs e)
        {
            switch (ClaseOp)
            {
                case "V":
                    if (double.Parse(txtTC.Text) < dblTC && double.Parse(txtTC.Text) >= dblTC - 0.4)
                    {
                        dblTC = double.Parse(txtTC.Text);
                    }


            }
            dblConversion = Conversion(dblCantidad, dblTC);
            txtConversion.Text = dblConversion.ToString();
            pnlContinuarSin.Visible = true;
            btnSiContiSin.Focus();
        }


        double Conversion(double miCantidad, double miTC)
        {
            
            switch (ClaseOp)
            {
                case "V":
                    return miTC / miCantidad;
                case "C":
                    return miCantidad * miTC;
                default:
                    return 0;
            }
        }

        private void btnNoContiSin_Click(object sender, EventArgs e)
        {
            pnlContinuarSin.Visible = false;
            txtCantidad.Focus();
        }

        private void btnSiContiSin_Click(object sender, EventArgs e)
        {
            txtPago.Enabled = true;
            txtCambio.Enabled = true;
            txtPago.Focus();
        }

        private void txtPago_Leave(object sender, EventArgs e)
        {
            dblCambio = dblCantidad - dblPago;
            txtCambio.Text = dblCambio.ToString();
            pnlConSinFin.Visible=true;
        }

        private void btnEspContiSin_Click(object sender, EventArgs e)
        {
            txtTC.Focus();
        }
    }
}
