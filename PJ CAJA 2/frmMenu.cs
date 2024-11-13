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
        string ClaseOp = "V";

        double dblCantidad;
        double dblConversion;
        double dblCambio;
        double dblPago;
        double dblTC;
        int[] BilletesP = { 1000, 500, 200, 100, 50, 20 };
        int[] BilletesD = { 100, 50, 20, 10, 5, 1 };

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

            //EVENTOS PARA TEXTBOXES DE SUMADORA
            foreach (Control miControl in pnlSumadora.Controls)
            {
                if (miControl is TextBox && miControl != txtSumaTotal)
                {
                    //CADA QUE EL TEXTO CAMBIE, SE ACTIVA ESTE EVENTO; SUMA TODOS LOS TXTBOX Y LOS MUESTRA EN UNO ESPECIFICO
                    miControl.TextChanged += new EventHandler(SumaSumadora);
                    //CADA QUE SE PRECIONE UNA TECLA DENTRO DE ALGUN TEXTBOX, SE ACTIVA ESTE EVENTO; EVITA CIERTAS TECLAS
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
                            //CADA QUE EL TEXTO CAMBIE, SE ACTIVA ESTE EVENTO; SUMA TODOS LOS TXTBOX Y LOS MUESTRA EN UNO ESPECIFICO
                            miControl2.TextChanged += new EventHandler(SumaEntSal);
                            //CADA QUE SE PRECIONE UNA TECLA DENTRO DE ALGUN TEXTBOX, SE ACTIVA ESTE EVENTO; EVITA CIERTAS TECLAS
                            miControl2.KeyPress += new KeyPressEventHandler(FiltroTeclas);
                        }
                    }
                }
            }

            //EVENTOS PARA TEXTBOXES DE TRANSACCION CON DESGLOCE
            foreach (Control miControl in pnlTransaccionCon.Controls)
            {
                if (miControl is GroupBox miGrupo)
                {
                    foreach (Control miControl2 in miGrupo.Controls)
                    {
                        if (miControl2 is TextBox && miControl2 != txtEntregarTotal && miControl2 != txtRecibidosTotal && miControl.Name.Substring(0, 9) != "txtEntCan" && miControl.Name.Substring(0, 9) != "txtRecCan")
                        {
                            //CADA QUE EL TEXTO CAMBIE, SE ACTIVA ESTE EVENTO; SUMA TODOS LOS TXTBOX Y LOS MUESTRA EN UNO ESPECIFICO
                            miControl2.TextChanged += new EventHandler(SumaConDesgloce);
                            //CADA QUE SE PRECIONE UNA TECLA DENTRO DE ALGUN TEXTBOX, SE ACTIVA ESTE EVENTO; EVITA CIERTAS TECLAS
                            miControl2.KeyPress += new KeyPressEventHandler(FiltroTeclas);
                            //CADA QUE EL FOCO SE QUITE DEL CONTROL, SE ACTIVA ESTE EVENTO; MUESTRA LA CANTIDAD DE BILLETES
                            miControl2.Leave += new EventHandler(CantidadDinero);
                            //CADA QUE SE PRECIONE UNA DE LAS TECLAS ESPECIFICAS, SE ACTIVA ESTE EVENTO; AYUDA A MOVERSE POR LOS CONTROLES, ADEMAS DA USO A LA TECLA SCAPE
                            miControl2.KeyDown += new KeyEventHandler(HotKeysDesglose);
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
         
            pnlTransaccionSin.Visible = true;
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

        //Operacion con desgloce
        private void btnConDes_Click(object sender, EventArgs e)
        {
            pnlElegirDes.Visible = false;

            pnlTransaccionCon.Visible = true;
            if (ClaseOp == "V")
            {
                lblTransCon.Text = "*#* VENTA *#*";
                //RECIBIDO
                grpTransConRecibidos.Text = "PESOS RECIBIDOS";
                lblTranConRecDivisa.Text = "PESOS";
                lblRecibido1.Text = "[1000]..........";
                lblRecibido2.Text = "[ 500 ]..........";
                lblRecibido3.Text = "[ 200 ]..........";
                lblRecibido4.Text = "[ 100 ]..........";
                lblRecibido5.Text = "[  50  ]..........";
                lblRecibido6.Text = "[  20  ]..........";
                //ENTREGADO
                grpTransConEntregar.Text = "DOLARES A ENTREGAR";
                lblTranConEntDivisa.Text = "DOLARES";
                lblEntregar1.Text = "[ 100 ]..........";
                lblEntregar2.Text = "[  50  ]..........";
                lblEntregar3.Text = "[  20  ]..........";
                lblEntregar4.Text = "[  10  ]..........";
                lblEntregar5.Text = "[   5   ]..........";
                lblEntregar6.Text = "[   1   ]..........";
                //grpTranConTC
                lblTranConRecibidos.Text = "Pesos recibidos:";
                lblTranConEntregar.Text = "Dolares a entregar:";
            }
            else if (ClaseOp == "C")
            {
                lblTransCon.Text = "*#* COMPRA *#*";
                //RECIBIDO
                grpTransConRecibidos.Text = "DOLARES RECIBIDOS";
                lblTranConRecDivisa.Text = "DOLARES";
                lblRecibido1.Text = "[ 100 ]..........";
                lblRecibido2.Text = "[  50  ]..........";
                lblRecibido3.Text = "[  20  ]..........";
                lblRecibido4.Text = "[  10  ]..........";
                lblRecibido5.Text = "[   5   ]..........";
                lblRecibido6.Text = "[   1   ]..........";
                //ENTREGADO
                grpTransConEntregar.Text = "PESOS A ENTREGAR";
                lblTranConEntDivisa.Text = "PESOS";
                lblEntregar1.Text = "[1000]..........";
                lblEntregar2.Text = "[ 500 ]..........";
                lblEntregar3.Text = "[ 200 ]..........";
                lblEntregar4.Text = "[ 100 ]..........";
                lblEntregar5.Text = "[  50  ]..........";
                lblEntregar6.Text = "[  20  ]..........";
                //grpTranConTC
                lblTranConRecibidos.Text = "Dolares recibidos:";
                lblTranConEntregar.Text = "Pesos a entregar:";
            }
        }

        //Se confirma la captura de datos y el siguiente paso es verificar que el tipo de dato sea correcto y la conversion sea aceptada por el cliente
        private void btnTranConSi1_Click(object sender, EventArgs e)
        {
            grpTranConTC.Visible = true;
            txtTranConRecibidos.Text = txtRecibidosTotal.Text;
            if (ClaseOp == "V")
            {
                txtTranConTC.Text = Properties.Settings.Default.dblTCVenta_.ToString();
                txtTranConEntregar.Text = (double.Parse(txtRecibidosTotal.Text) / double.Parse(txtTranConTC.Text)).ToString();
            }
            else if (ClaseOp == "C")
            {
                txtTranConTC.Text = Properties.Settings.Default.dblTCCompra_.ToString();
                txtTranConEntregar.Text = (double.Parse(txtRecibidosTotal.Text) * double.Parse(txtTranConTC.Text)).ToString();
            }
            pnlTranConContinuar2.Visible = true;
            btnTranConSi2.Focus();
        }

        //Metodo para el panel de transaccion con desgloce y sus texbox
        private void SumaConDesgloce(object sender, EventArgs e)
        {
            try
            {
                double dblSuma = 0;
                foreach (Control miControl in grpTransConRecibidos.Controls)
                {
                    if (miControl is TextBox && miControl != txtRecibidosTotal && miControl.Name.Substring(0, 9) != "txtRecCan")
                    {
                        if (miControl.Text == "" && miControl is TextBox mitxt)
                        {
                            miControl.Text = "00";
                            mitxt.SelectAll();
                        }
                        dblSuma = double.Parse(miControl.Text) + dblSuma;
                    }
                }
                txtRecibidosTotal.Text = dblSuma.ToString();

                dblSuma = 0;
                foreach (Control miControl in grpTransConEntregar.Controls)
                {
                    if (miControl is TextBox && miControl != txtEntregarTotal && miControl.Name.Substring(0, 9) != "txtEntCan")
                    {
                        if (miControl.Text == "" && miControl is TextBox mitxt)
                        {
                            miControl.Text = "00";
                            mitxt.SelectAll();
                        }
                        dblSuma = double.Parse(miControl.Text) + dblSuma;
                    }
                }
                txtEntregarTotal.Text = dblSuma.ToString();
            }
            catch
            {

            }
        }

        private void CantidadDinero(object sender, EventArgs e)
        {
            int Cantidad = 0;
            try
            {
                //Pretendemos usar el control que activo mediante el evento "leave"
                if (sender is TextBox mitxt)
                {
                    //Buscamos en que grupo esta mediante el nombre, existen dos grupos, Recibidos y Entregar
                    //Grupo recibidos
                    if (mitxt.Name.Substring(0, 12) == "txtRecibidos")
                    {
                        //Verificamos si se trata de una venta o compra
                        if (ClaseOp == "V")
                        {
                            //En este caso se trata de una venta, se usa el arreglo de BilletesPesos
                            //Se verifica antes que sea posible la division sin dejar diferencia 
                            if (int.Parse(mitxt.Text) % BilletesP[(int.Parse(mitxt.Name.Substring(12, 1)))-1] == 0)
                            {
                                int Valor = BilletesP[(int.Parse(mitxt.Name.Substring(12, 1)) - 1)];
                                Cantidad = int.Parse(mitxt.Text) / Valor;
                            }
                            else
                            {//Se le recuerda al usuario que debe poner la informacion correcta
                                MessageBox.Show("INGRESA CORRECTAMENTE LA SUMA DE LOS BILLETES CORRESPONDIENTES", "ERROR AL CAPTURAR VALOR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                mitxt.Focus();
                                mitxt.SelectAll();
                                return;
                            }
                        }
                        else if (ClaseOp == "C")
                        {
                            //En este caso se trata de una compra, se usa el arreglo de BilletesDolares
                            if (int.Parse(mitxt.Text) % BilletesD[(int.Parse(mitxt.Name.Substring(12, 1))) - 1] == 0)
                            {
                                int Valor = BilletesD[(int.Parse(mitxt.Name.Substring(12, 1)) - 1)];
                                Cantidad = int.Parse(mitxt.Text) / Valor;
                            }
                            else
                            {
                                MessageBox.Show("INGRESA CORRECTAMENTE LA SUMA DE LOS BILLETES CORRESPONDIENTES", "ERROR AL CAPTURAR VALOR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                mitxt.Focus();
                                mitxt.SelectAll();
                                return;
                            }
                        }
                    }
                    //Grupo entregar
                    else if (mitxt.Name.Substring(0, 11) == "txtEntregar")
                    {
                        //Verificamos si se trata de una venta o compra
                        if (ClaseOp == "V")
                        {//En este caso se trata de una compra, se usa el arreglo de BilletesDolares

                            if (int.Parse(mitxt.Text) % BilletesD[(int.Parse(mitxt.Name.Substring(11, 1))) - 1] == 0)
                            {
                                int Valor = BilletesD[(int.Parse(mitxt.Name.Substring(11, 1)) - 1)];
                                Cantidad = int.Parse(mitxt.Text) / Valor;
                            }
                            else
                            {
                                MessageBox.Show("INGRESA CORRECTAMENTE LA SUMA DE LOS BILLETES CORRESPONDIENTES", "ERROR AL CAPTURAR VALOR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                mitxt.Focus();
                                mitxt.SelectAll();
                                return;
                            }
                        }
                        else if (ClaseOp == "C")
                        {//En este caso se trata de una compra, se usa el arreglo de BilletesPesos
                            if (int.Parse(mitxt.Text) % BilletesP[(int.Parse(mitxt.Name.Substring(11, 1))) - 1] == 0)
                            {
                                int Valor = BilletesP[(int.Parse(mitxt.Name.Substring(11, 1)) - 1)];
                                Cantidad = int.Parse(mitxt.Text) / Valor;
                            }
                            else
                            {
                                MessageBox.Show("INGRESA CORRECTAMENTE LA SUMA DE LOS BILLETES CORRESPONDIENTES", "ERROR AL CAPTURAR VALOR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                mitxt.Focus();
                                mitxt.SelectAll();
                                return;
                            }
                        }
                    }
                    //Al final se busca en el grupo todos los texboxes de cantidad, y se identifica mediante la numeracion en su nombre
                    foreach (Control txtCantidad in grpTransConRecibidos.Controls)
                    {
                        if ((txtCantidad.Name.Substring(0, 9) == "txtRecCan" && mitxt.Name.Substring(12, 1) == txtCantidad.Name.Substring(9, 1)) 
                            || (txtCantidad.Name.Substring(0, 9) == "txtEntCan" && mitxt.Name.Substring(11, 1) == txtCantidad.Name.Substring(9, 1)))
                        {
                            txtCantidad.Text = Cantidad.ToString();
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void btnTranConCancelar_Click(object sender, EventArgs e)
        {
            pnlTransaccionCon.Visible = false;
        }

        private void HotKeysDesglose(object sender, KeyEventArgs e)
        {
            HotKeysTxtBox(e.KeyCode, btnTranConCancelar);
        }

        private void txtRecibidos6_KeyDown(object sender, KeyEventArgs e)
        {
            pnlTranConContinuar1.Visible = true;
            btnTranConSi1.Focus();
        }

        private void btnTranConNo1_Click(object sender, EventArgs e)
        {
            pnlTranConContinuar1.Visible = false;
            txtRecibidos1.SelectAll();
        }

        private void btnTranConRegresar1_Click(object sender, EventArgs e)
        {
            pnlTranConContinuar1.Visible = false;
            pnlTransaccionCon.Visible = false;
        }

        private void btnTranConImprimir1_Click(object sender, EventArgs e)
        {
            /*
             COSAS DE IMPRESION
             */
        }

        private void btnTranConSi2_Click(object sender, EventArgs e)
        {
            pnlTranConContinuar2.Visible = false;
            grpTransConEntregar.Visible = true;
            txtEntregar1.SelectAll();
        }

        private void btnTranConNo2_Click(object sender, EventArgs e)
        {
            grpTranConTC.Visible = false;
            pnlTranConContinuar2.Visible = false;
            txtRecibidos1.SelectAll();
        }

        private void btnTranConEspecial_Click(object sender, EventArgs e)
        {
            pnlTranConContinuar2.Visible = false;
            txtTranConTC.SelectAll();
        }

        private void btnTranConRegresar2_Click(object sender, EventArgs e)
        {
            pnlTranConContinuar2.Visible = false;
            pnlTransaccionCon.Visible = false;
        }

        private void txtEntregar7_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("¿QUIERES TERMINAR LA OPERACION?", "FINALIZAR", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            pnlTransaccionCon.Visible = false;
        }
    }
}
