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
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yy");
            tmrHora.Interval = 1000;
            tmrHora.Start();
        }
        //## BOTÓNES ##
        //Botónes de venta y compra, solo deciden que clase de operacion se lleva a cabo
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

        //Botón SinDesglose para una venta/compra directa
        private void btnSinDes_Click(object sender, EventArgs e)
        {
            pnlElegirDes.Visible = false;
            if (ClaseOp == "V")
            {
                //Se ajusta para una venta directa
                lblTransSin.Text = "VENTA DIRECTA";
                lblCantidad.Text = "PESOS RECIBIDOS:";
                lblConversion.Text = "DOLARES A ENTREGAR:";

                //Acomodo de las etiquetas
                lblCantidad.Location = new Point(83, 67);
                lblConversion.Location = new Point(32, 166);
                dblTC = Properties.Settings.Default.dblTCVenta_;
            }
            else
            {
                //Se ajusta para una compra directa
                lblTransSin.Text = "COMPRA DIRECTA";
                lblCantidad.Text = "DOLARES RECIBIDOS:";
                lblConversion.Text = "PESOS A ENTREGAR:";

                //Acomodo de las etiquetas
                lblCantidad.Location = new Point(60, 67);
                lblConversion.Location = new Point(60, 166);
                dblTC = Properties.Settings.Default.dblTCCompra_;
            }
            txtTC.Text = dblTC.ToString();
            pnlTransaccionSin.Visible = true;
            txtCantidad.Focus();
        }

        //Botón para corregir la cantidad escrita
        private void btnNoContiSin_Click(object sender, EventArgs e)
        {
            pnlContinuarSin.Visible = false;
            txtCantidad.Focus();
        }

        //Te permite ingresar una cantidad distinta en tipo de cambio
        private void btnEspContiSin_Click(object sender, EventArgs e)
        {
            pnlContinuarSin.Visible = false;
            txtTC.Focus();
        }

        //Continuar el proceso, permitiendo el ingreso del pago
        private void btnSiContiSin_Click(object sender, EventArgs e)
        {
            pnlContinuarSin.Visible = false;
            txtPago.Enabled = true;
            txtCambio.Enabled = true;
            txtPago.Focus();
        }

        //Sumadora
        private void btnSumadora_Click(object sender, EventArgs e)
        {
            foreach (Control miControl in pnlMenu.Controls)
            {
                miControl.Enabled = false;
            }
            pnlSumadora.Visible = true;
            txtSuma1.Focus();
        }


        //## EVENTOS ## 

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

        private void txtTC_Leave_1(object sender, EventArgs e)
        {/*
            switch (ClaseOp)
            {
                case "V":
                    if (double.Parse(txtTC.Text) < dblTC && double.Parse(txtTC.Text) >= dblTC - 0.4)
                    {
                        dblTC = double.Parse(txtTC.Text);
                    }
                    else
                    {
                        MessageBox.Show("LIMITE TIPO ESPECIAL", "El tipo especial supero el limite de rango, asegurate de escribirlo correctamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTC.Focus();
                    }
                    break;

                case "C":
                    if (double.Parse(txtTC.Text) > dblTC && double.Parse(txtTC.Text) <= dblTC + 0.4)
                    {
                        dblTC = double.Parse(txtTC.Text);
                    }
                    else
                    {
                        MessageBox.Show("LIMITE TIPO ESPECIAL", "El tipo especial supero el limite de rango, asegurate de escribirlo correctamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTC.Focus();
                    }
                    break;
            }*/

            if ((ClaseOp == "V" && double.Parse(txtTC.Text) < dblTC && double.Parse(txtTC.Text) >= dblTC - 0.4) ||
                (ClaseOp == "C" && double.Parse(txtTC.Text) > dblTC && double.Parse(txtTC.Text) <= dblTC + 0.4))
            {
                dblTC = double.Parse(txtTC.Text);
                MessageBox.Show("SALIO BIEN");
            }
            else
            {
                MessageBox.Show("El tipo especial supero el limite de rango, asegurate de escribirlo correctamente", "LIMITE TIPO ESPECIAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTC.Focus();
                return;
            }
            dblConversion = Conversion(dblCantidad, dblTC);
            txtConversion.Text = dblConversion.ToString();
            pnlContinuarSin.Visible = true;
            btnSiContiSin.Focus();
        }

        private void txtPago_Leave(object sender, EventArgs e)
        {
            dblCambio = dblCantidad - dblPago;
            txtCambio.Text = dblCambio.ToString();
            pnlConSinFin.Visible = true;
        }


        //## METODOS ##

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

        private void btnNoSinFin_Click(object sender, EventArgs e)
        {
            pnlConSinFin.Visible = false;
            txtPago.Focus();
        }

        private void btnCancSinFin_Click(object sender, EventArgs e)
        {
            pnlConSinFin.Visible = false;
            pnlTransaccionSin.Visible = false;
        }

        private void btnCancContSin_Click(object sender, EventArgs e)
        {
            pnlTransaccionSin.Visible = false;
        }

        private void btnSiSinFin_Click(object sender, EventArgs e)
        {
            pnlConSinFin.Visible = false;
            pnlTransaccionSin.Visible = false;
            /*
             AQUI IMPRIME Y GUARDA LA OPERACION
             
             
             */
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            this.WindowState = FormWindowState.Maximized;
            Taskbar.Hide();
        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
        }

        private void txtSuma1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtSuma2.Focus();
            }

        }

        private void txtSuma2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtSuma1.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtSuma3.Focus();
            }
        }

        private void txtSuma3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtSuma2.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtSuma4.Focus();
            }
        }

        private void txtSuma4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtSuma3.Focus();
            }
            if (e.KeyCode == Keys.Down)
            {
                txtSuma5.Focus();
            }
        }

        private void txtSuma5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtSuma4.Focus();
            }
        }
    }
}
