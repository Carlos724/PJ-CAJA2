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
        //## VARIABLES ##
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

            //####### PRUEBAS
            pnlEntSal.Visible = true;

            //EVENTOS PARA TEXTBOXES DE SUMADORA
            foreach (Control miControl in pnlSumadora.Controls)
            {
                if (miControl is TextBox && miControl != txtSumaTotal)
                {
                    //CADA QUE EL TEXTO CAMBIE, SE ACTIVA ESTE EVENTO
                    miControl.TextChanged += new EventHandler(SumaSumadora);
                    //CADA QUE SE PRECIONE UNA TECLA DENTRO DE ALGUN TEXTBOX, SE ACTIVA ESTE EVENTO
                    miControl.KeyPress += new KeyPressEventHandler(FiltroTeclas);
                }
            }

            //EVENTOS PARA TEXTBOXES DE ENTRADAS/SALIDAS
            foreach (Control miControl in pnlEntSal.Controls)
            {
                if (miControl is GroupBox miGrupo)
                {
                    foreach (Control miControl2 in miGrupo.Controls)
                    {
                        if (miControl2 is TextBox && miControl2 != txtTotalP && miControl2 != txtTotalD && miControl2 != txtMotivo)
                        {
                            //CADA QUE EL TEXTO CAMBIE, SE ACTIVA ESTE EVENTO
                            miControl2.TextChanged += new EventHandler(SumaEntSal);
                            //CADA QUE SE PRECIONE UNA TECLA DENTRO DE ALGUN TEXTBOX, SE ACTIVA ESTE EVENTO
                            miControl2.KeyPress += new KeyPressEventHandler(FiltroTeclas);
                        }
                    }
                }

            }


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

        private void btnAceptarSum_Click(object sender, EventArgs e)
        {

            pnlSumadora.Visible = false;
            /*
             SE GUARDARAN LAS SUMAS?
             */
        }

        private void btnCancelarSum_Click(object sender, EventArgs e)
        {
            pnlSumadora.Visible = false;
        }

        //##SUMADORA
        private void btnSumadora_Click(object sender, EventArgs e)
        {
            pnlSumadora.Visible = true;
            txtSuma1.Focus();
        }

        //BOTÓN PARA CERRAR APP (USO DE PRUEBAS)
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        //BOTÓN PARA CAPTURAR ENTRADAS O SALIDAS
        private void btnEntSal_Click(object sender, EventArgs e)
        {
            pnlEntSal.Visible = true;
            txtMorD.Focus();
        }
        //BOTÓN PARA MOSTRAR EL HISTORIAL DE OPERACIONES
        //#######(ANALIZAR SÍ MOSTRAR ENTRADAS, SALIDAS Y SUMAS)
        private void btnListOperaciones_Click(object sender, EventArgs e)
        {

        }

        private void btSumD_Click(object sender, EventArgs e)
        {
            pnlSumadora.Visible = true;
        }

        private void btnSumP_Click(object sender, EventArgs e)
        {
            pnlSumadora.Visible = true;
        }

        private void btnCancelarEntSal_Click(object sender, EventArgs e)
        {
            pnlEntSal.Visible = false;
            foreach (Control miControl in pnlEntSal.Controls)
            {
                if (miControl is TextBox)
                {
                    miControl.Text = "00.00";
                }
            }
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

        double Suma(double E)
        {
            double dblSuma = double.Parse(txtSumaTotal.Text);
            dblSuma = E + dblSuma;
            txtSumaTotal.Text = dblSuma.ToString();
            return dblSuma;
        }

        //Metodo para moverse entre los TextBox, o regresar al menu anterior
        private void HotKeysTxtBox(Keys miTecla, Button miCancelar)
        {
            switch (miTecla)
            {
                case Keys.Enter:
                case Keys.Down:
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    //Selecciona todo el texto para ser modificado completo
                    if (this.ActiveControl is TextBox mitxt)
                    {
                        mitxt.SelectAll();
                    }
                    break;
                case Keys.Up:
                    this.SelectNextControl(this.ActiveControl, false, true, true, true);
                    if (this.ActiveControl is TextBox mitxt2)
                    {
                        mitxt2.SelectAll();
                    }
                    break;
                case Keys.Escape:
                    miCancelar.PerformClick();
                    break;
                default:
                    break;
            }
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
        {
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

        private void btnImprimirSum_Click(object sender, EventArgs e)
        {
            /*
         codigo de imprimision
         */
            pnlSumadora.Visible = false;
        }

        //Evento que verifica si se quiere cambiar o salir del control
        private void txtSuma1_KeyDown(object sender, KeyEventArgs e)
        {
            Suma(double.Parse(txtSuma1.Text));
            HotKeysTxtBox(e.KeyCode, btnCancelarSum);
        }

        private void txtSuma2_KeyDown(object sender, KeyEventArgs e)
        {
            Suma(double.Parse(txtSuma2.Text));
            HotKeysTxtBox(e.KeyCode, btnCancelarSum);
        }

        private void txtSuma3_KeyDown(object sender, KeyEventArgs e)
        {
            Suma(double.Parse(txtSuma3.Text));
            HotKeysTxtBox(e.KeyCode, btnCancelarSum);
        }

        private void txtSuma4_KeyDown(object sender, KeyEventArgs e)
        {
            Suma(double.Parse(txtSuma4.Text));
            HotKeysTxtBox(e.KeyCode, btnCancelarSum);
        }

        private void txtSuma5_KeyDown(object sender, KeyEventArgs e)
        {
            Suma(double.Parse(txtSuma5.Text));
            HotKeysTxtBox(e.KeyCode, btnCancelarSum);
        }

        private void rdbEntrada_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbEntrada.Checked)
            {
                grpMotivo.Text = "¿De donde viene?";
            }
            else { grpMotivo.Text = "¿A donde va?"; }
        }

        private void pnlSumadora_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                foreach (Control Micontrol in pnlSumadora.Controls)
                {
                    if (Micontrol is TextBox)
                    {
                        Micontrol.Text = "00.00";
                    }
                }
            }
        }

        private void btSumD_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    txtCpD.Focus();
                    break;

                case Keys.Up:
                    txtMorD.Focus();
                    break;

                case Keys.Escape:
                    btnCancelarEntSal_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        private void txtMorD_KeyDown(object sender, KeyEventArgs e)
        {
            HotKeysTxtBox(e.KeyCode, btnCancelarEntSal);
        }


        private void txtCpD_KeyDown(object sender, KeyEventArgs e)
        {
            HotKeysTxtBox(e.KeyCode, btnCancelarEntSal);
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            this.WindowState = FormWindowState.Maximized;
            //Taskbar.Hide();
        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
        }

        //METODO PARA EVENTO DE SUMA DE TODOS LOS TXTBOXES DEL PANEL SUMADORA, EL RESULTADO SE GUARDA EN UN TEXTBOX
        private void SumaSumadora(object sender, EventArgs e)
        {
            try
            {
                double dblSuma = 0;
                foreach (Control miControl in pnlSumadora.Controls)
                {
                    if (miControl is TextBox && miControl.Name != "txtSumaTotal")
                    {
                        if (miControl.Text == "" && miControl is TextBox mitxt)
                        {
                            miControl.Text = "00.00";
                            mitxt.SelectAll();
                        }
                        dblSuma = double.Parse(miControl.Text) + dblSuma;
                    }
                }
                txtSumaTotal.Text = dblSuma.ToString();
            }
            catch
            {

            }
        }

        //Metodo que suma todos los texboxes del panel Entradas/Salidas y pone el resultado en txtTotalD y txtTotalP 
        private void SumaEntSal(object sender, EventArgs e)
        {
            try
            {
                double dblSuma = 0;
                foreach (Control miControl in grpDolares.Controls)
                {
                    if (miControl is TextBox && miControl.Name != "txtTotalD")
                    {
                        if (miControl.Text == "" && miControl is TextBox mitxt)
                        {
                            miControl.Text = "00.00";
                            mitxt.SelectAll();
                        }
                        dblSuma = double.Parse(miControl.Text) + dblSuma;
                    }
                }
                txtTotalD.Text = dblSuma.ToString();

                dblSuma = 0;
                foreach (Control miControl in grpPesos.Controls)
                {
                    if (miControl is TextBox && miControl.Name != "txtTotalP")
                    {
                        if (miControl.Text == "" && miControl is TextBox mitxt)
                        {
                            miControl.Text = "00.00";
                            mitxt.SelectAll();
                        }
                        dblSuma = double.Parse(miControl.Text) + dblSuma;
                    }
                }
                txtTotalP.Text = dblSuma.ToString();
            }
            catch
            {

            }
        }

        //Filtro que solo permite el ingreso de numeros y punto decimal
        private void FiltroTeclas(object sender, KeyPressEventArgs e)
        {
            if (e != null)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
            }
        }

    }
}
