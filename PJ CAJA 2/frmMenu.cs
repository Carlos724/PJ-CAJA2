using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using MySql.Data.MySqlClient;

namespace PJ_CAJA_2
{
    public partial class frmMenu : Form
    {
        //## VARIABLES ##
        ConexionInicial conexionSQL = new ConexionInicial();
        //Variable para definir venta u operacion
        string ClaseOp = "V";

        double dblCantidad;
        double dblConversion;
        double dblCambio;
        double dblPago;
        double dblTC;
        int[] BilletesP = { 1000, 500, 200, 100, 50, 20 };
        int[] BilletesD = { 100, 50, 20, 10, 5, 1 };
        StreamWriter Log_Error = new StreamWriter(@"C:\Users\ale\Documents\PJ Caja2\PJ CAJA 2\Resources\Log_Error.txt");
        char chrDivisa = '0';

        bool blnTE;

        public frmMenu()
        {
            InitializeComponent();

            conexionSQL.datosXML = conexionSQL.LeerXML();
            conexionSQL.cnnInicial = new MySqlConnection(conexionSQL.datosXML);

            lblUsuario.Text = Properties.Settings.Default.strUsuario_;
            lblTCCompra.Text = Properties.Settings.Default.dblTCCompra_.ToString();
            lblTCVenta.Text = Properties.Settings.Default.dblTCVenta_.ToString();
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yy");
            tmrHora.Interval = 1000;
            tmrHora.Start();
            btnVenta.Focus();

            //####### PRUEBAS
            //SE TIENE QUE ELIMINAR EL SONIDO DE LOS CONTROLES CAMBIANDO DE FOCO
            //            e.Handled = true;//elimina el sonido

            //ACCESOS REPIDOS PARA EL MENU, SE ADJUDICA A LOS BOTONES DEL MENU.
            foreach (Control mibtn in pnlMenu.Controls)
            {
                if (mibtn is Button)
                {
                    mibtn.KeyDown += new KeyEventHandler(HotKeysMenu);
                }
            }

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

            //EVENTOS PARA TEXBOXES DE TRANSACCION SIN DESGLOCE
            foreach (Control miControl in pnlTransaccionSin.Controls)
            {
                if (miControl is TextBox)
                {
                    //CADA QUE SE PRECIONE UNA TECLA DENTRO DE ALGUN TEXTBOX, SE ACTIVA ESTE EVENTO; EVITA CIERTAS TECLAS
                    miControl.KeyPress += new KeyPressEventHandler(FiltroTeclas);
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
            dblTC = Properties.Settings.Default.dblTCVenta_;
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            ClaseOp = "C";
            pnlElegirDes.Visible = true;
            dblTC = Properties.Settings.Default.dblTCCompra_;
        }

        //Botón SinDesglose para una venta/compra directa
        private void btnSinDes_Click(object sender, EventArgs e)
        {
            pnlElegirDes.Visible = false;
            pnlElegirDirecta.Visible = true;
            btnDirecta.Focus();
        }

        //Botón para corregir la cantidad escrita
        private void btnNoContiSin_Click(object sender, EventArgs e)
        {
            pnlContinuarSin.Visible = false;
            txtCantidad.Focus();
            txtCantidad.SelectAll();
        }

        //Te permite ingresar una cantidad distinta en tipo de cambio
        private void btnEspContiSin_Click(object sender, EventArgs e)
        {
            blnTE = true;
            pnlContinuarSin.Visible = false;
            txtTC.Focus();
        }

        //Continuar el proceso, permitiendo el ingreso del pago
        private void btnSiContiSin_Click(object sender, EventArgs e)
        {
            pnlContinuarSin.Visible = false;
            grpTranSinCambio.Visible = true;
            txtPago.Focus();
        }

        private void btnAceptarSum_Click(object sender, EventArgs e)
        {
            pnlSumadora.Visible = false;
            switch (chrDivisa)
            {
                case 'D':
                    txtUmD.Text = txtSumaTotal.Text;
                    txtCpD.Focus();
                    break;
                case 'P':
                    txtUmP.Text = txtSumaTotal.Text;
                    txtCpP.Focus();
                    break;
            }
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
            frmListadoOperacion miListado = new frmListadoOperacion();
        }

        private void btSumD_Click(object sender, EventArgs e)
        {
            pnlSumadora.Visible = true;
            chrDivisa = 'D';
            txtSuma1.Focus();
            txtSuma1.SelectAll();
        }

        private void btnSumP_Click(object sender, EventArgs e)
        {
            pnlSumadora.Visible = true;
            chrDivisa = 'P';
            txtSuma1.Focus();
            txtSuma1.SelectAll();
        }

        private void btnCancelarEntSal_Click(object sender, EventArgs e)
        {
            pnlEntSal.Visible = false;
        }

        //## METODOS ##
        double Conversion(double miCantidad, double miTC)
        {
            switch (ClaseOp)
            {
                case "V":
                case "CI":
                    return miCantidad / miTC;
                case "C":
                case "VI":
                    return miCantidad * miTC;
                default:
                    return 0;
            }
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
            try
            {
                dblCantidad = double.Parse(txtCantidad.Text);
                dblConversion = Conversion(dblCantidad, dblTC);
                txtConversion.Text = dblConversion.ToString("N2");
                pnlContinuarSin.Visible = true;
                btnSiContiSin.Focus();
            }
            catch (Exception ex)
            {
                VariablesGlobales.MessageBox_Show("ATENCION", "AH OCURRIDO UN ERROR INTENTANDO REALIZAR LA OPERACION, COMUNICATE CON EL DEP. DE SISTEMAS", false, "#a83252", Properties.Resources.advertencia);
                Log_Error.WriteLine(DateTime.Now.ToString("dd:MM:yyyy") + @" MENSAJE DE ERROR : " + ex.Message);

            }
        }

        private void txtTC_Leave_1(object sender, EventArgs e)
        {
            try
            {
                if (txtTC.Text != dblTC.ToString())
                {
                    if (((ClaseOp == "V" || ClaseOp == "VI") && double.Parse(txtTC.Text) < dblTC && double.Parse(txtTC.Text) >= dblTC - 0.4) ||
                        ((ClaseOp == "C" || ClaseOp == "CI") && double.Parse(txtTC.Text) > dblTC && double.Parse(txtTC.Text) <= dblTC + 0.4))
                    {
                        dblTC = double.Parse(txtTC.Text);
                    }
                    else
                    {
                        VariablesGlobales.MessageBox_Show("ATENCION", "INGRESA UN TIPO DE CAMBIO VALIDO; SI EL ERROR PERSISTE, COMUNICATE CON EL DEP. DE SISTEMAS", false, "#F9B600", Properties.Resources.advertencia);
                        if (ClaseOp == "V" || ClaseOp == "VI")
                        {
                            txtTC.Text = Properties.Settings.Default.dblTCVenta_.ToString();
                        }
                        else txtTC.Text = Properties.Settings.Default.dblTCCompra_.ToString();
                        txtTC.Focus();
                        txtTC.SelectAll();
                        return;
                    }
                }
                dblConversion = Conversion(dblCantidad, dblTC);
                txtConversion.Text = dblConversion.ToString();
                pnlContinuarSin.Visible = true;
                btnSiContiSin.Focus();
            }
            catch (Exception ex)
            {
                VariablesGlobales.MessageBox_Show("ATENCION", "AH OCURRIDO UN ERROR INTENTANDO REALIZAR LA OPERACION, COMUNICATE CON EL DEP. DE SISTEMAS", false, "#a83252", Properties.Resources.advertencia);
                Log_Error.WriteLine(DateTime.Now.ToString("dd:MM:yyyy HH:mm:ss") + @" MENSAJE DE ERROR : " + ex.Message);
            }
        }

        private void txtPago_Leave(object sender, EventArgs e)
        {
            try
            {
                //SE COMPRUEBA QUE TIPO DE OPERACION ES
                if(ClaseOp=="V" || ClaseOp == "C")
                {
                    dblPago = double.Parse(txtPago.Text);
                    dblCambio = dblPago - dblCantidad;
                }
                //EN CASO DE QUE SE TRATE DE UNA OPERACION INDIRECTA, SE OBTIENE LA CANTIDAD DE LA CONVERSION
                else
                {
                    dblCantidad = double.Parse(txtConversion.Text);
                    dblPago = double.Parse(txtPago.Text);
                    dblCambio = dblPago - dblCantidad;
                }

                if (dblPago >= dblCantidad)
                {
                    txtCambio.Text = dblCambio.ToString();
                    pnlConSinFin.Visible = true;
                    btnSiSinFin.Focus();
                }
                else
                {
                    VariablesGlobales.MessageBox_Show("ATENCION", "INGRESA UNA CANTIDAD MAYOR O IGUAL A LA QUE VAS A ENTREGAR, REVISA DE NUEVO EL PAGO", false, "#F9B600", Properties.Resources.advertencia);
                    txtPago.Focus();
                    txtPago.SelectAll();
                }
            }
            catch (Exception ex)
            {
                VariablesGlobales.MessageBox_Show("ATENCION", "AH OCURRIDO UN ERROR INTENTANDO REALIZAR LA OPERACION, COMUNICATE CON EL DEP. DE SISTEMAS", false, "#a83252", Properties.Resources.advertencia);
                Log_Error.WriteLine(DateTime.Now.ToString("dd:MM:yyyy HH:mm:ss") + @" MENSAJE DE ERROR : " + ex.Message);
            }
        }



        private void btnNoSinFin_Click(object sender, EventArgs e)
        {
            pnlConSinFin.Visible = false;
            txtPago.Focus();
            txtPago.SelectAll();
        }

        private void btnCancSinFin_Click(object sender, EventArgs e)
        {
            pnlConSinFin.Visible = false;
            pnlTransaccionSin.Visible = false;
        }

        private void btnCancContSin_Click(object sender, EventArgs e)
        {
            pnlContinuarSin.Visible = false;
            pnlTransaccionSin.Visible = false;
        }

        private void btnSiSinFin_Click(object sender, EventArgs e)
        {
            try
            {
                char chrTE = 'N';

                Ticket ticket = new Ticket();
                ticket.datosImpresora = conexionSQL.EjecutarSelectImpresora();
                printDocument1 = new PrintDocument();
                PrinterSettings ps = new PrinterSettings();
                //ticket.datosFolio.Add(conexionSQL.sucursal);

            pnlConSinFin.Visible = false;
            pnlTransaccionSin.Visible = false;
                //public void InsertarGenerico(int Num_Folio, string Clase_Ope, string Tipo_Ope, double Dolares, double Pesos, double Tipo_Cam, char Tipo_Especial, double Tipo_Sis, double Pago, double Cambio, char Activo, char Corte)
             
                if (blnTE)
                {
                    chrTE = 'S';
                }
             
                if (ClaseOp == "V")
                {
                    ticket.datosFolio = new List<string>() { DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "VENTA","Pesos:", dblCantidad.ToString("F2"), "T.V:", dblTC.ToString("F2"), "Dolares:", Math.Round(dblConversion, 2).ToString("F2"), Math.Round(dblPago, 2).ToString("F2"), Math.Round(dblCambio, 2).ToString("F2") };
                    VariablesGlobales.NumFolio++;
                    conexionSQL.InsertarGenerico((VariablesGlobales.NumFolio), "folio", "VENTA", Math.Round(dblConversion, 2), dblCantidad, dblTC, chrTE, Properties.Settings.Default.dblTCVenta_, dblPago, dblCambio, 'S', 'S');
                }
                else if (ClaseOp == "C")
                {
                    ticket.datosFolio = new List<string>() { DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "COMPRA", "Dolares:", dblCantidad.ToString(), "T.C:", dblTC.ToString(), "Pesos:", Math.Round(dblConversion, 2).ToString(), Math.Round(dblPago, 2).ToString(), Math.Round(dblCambio, 2).ToString() };
                    VariablesGlobales.NumFolio++;
                    conexionSQL.InsertarGenerico((VariablesGlobales.NumFolio), "folio", "COMPRA", dblCantidad, Math.Round(dblConversion, 2), dblTC, chrTE, Properties.Settings.Default.dblTCCompra_, dblPago, dblCambio, 'S', 'S');
                }

                printDocument1.PrinterSettings = ps;
                printDocument1.PrintPage += ticket.ImprimirFolio;
                printDocument1.Print();

            }
            catch (Exception y)
            {
                MessageBox.Show("" + y);
            }

        }

        private void btnImprimirSum_Click(object sender, EventArgs e)
        {
            try
            {
                Ticket ticket = new Ticket();
                ticket.datosImpresora = conexionSQL.EjecutarSelectImpresora();
                printDocument1 = new PrintDocument();
                PrinterSettings ps = new PrinterSettings();
                ticket.cantidades = new List<double>();
                double dblSuma = 0;

                foreach (Control miControl in pnlSumadora.Controls)
                {
                    if (miControl is TextBox && miControl.Name != "txtSumaTotal" && (double.Parse(miControl.Text) != 00.00))
                    {
                        dblSuma = double.Parse(miControl.Text) + dblSuma;
                        ticket.cantidades.Add(double.Parse(miControl.Text));
                    }
                }

                ticket.cantidades.Add(dblSuma);

                printDocument1.PrinterSettings = ps;
                printDocument1.PrintPage += ticket.ImprimirSumadora;
                printDocument1.Print();
            }
            catch (Exception ex)
            {
                VariablesGlobales.MessageBox_Show("ATENCION", "AH OCURRIDO UN ERROR INTENTANDO REALIZAR LA OPERACION, COMUNICATE CON EL DEP. DE SISTEMAS", false, "#a83252", Properties.Resources.advertencia);
                Log_Error.WriteLine(DateTime.Now.ToString("dd:MM:yyyy HH:mm:ss") + @" MENSAJE DE ERROR : " + ex.Message);
            }
            pnlSumadora.Visible = false;
        }

        //Evento que verifica si se quiere cambiar o salir del control
        private void txtSuma1_KeyDown(object sender, KeyEventArgs e)
        {
            HotKeysTxtBox(e.KeyCode, btnCancelarSum);
        }

        private void txtSuma2_KeyDown(object sender, KeyEventArgs e)
        {
            HotKeysTxtBox(e.KeyCode, btnCancelarSum);
        }

        private void txtSuma3_KeyDown(object sender, KeyEventArgs e)
        {
            HotKeysTxtBox(e.KeyCode, btnCancelarSum);
        }

        private void txtSuma4_KeyDown(object sender, KeyEventArgs e)
        {
            HotKeysTxtBox(e.KeyCode, btnCancelarSum);
        }

        private void txtSuma5_KeyDown(object sender, KeyEventArgs e)
        {
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
            if (pnlSumadora.Visible)
            {
                foreach (Control Micontrol in pnlSumadora.Controls)
                {
                    if (Micontrol is TextBox)
                    {
                        Micontrol.Text = "00.00";
                    }
                }
            }
            else
            {
                if (!pnlEntSal.Visible)
                {
                    if (ClaseOp == "V" || ClaseOp == "VI")
                    {
                        btnVenta.Focus();
                    }
                    else
                    {
                        btnCompra.Focus();
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
                    if (miControl is TextBox && miControl != txtSumaTotal)
                    {
                        if (miControl.Text == "" && miControl is TextBox mitxt)
                        {
                            miControl.Text = "00.00";
                            mitxt.SelectAll();
                        }
                        dblSuma = double.Parse(miControl.Text) + dblSuma;
                    }
                }
                txtSumaTotal.Text = dblSuma.ToString("N2");
            }
            catch (Exception ex)
            {
                VariablesGlobales.MessageBox_Show("ATENCION", "AH OCURRIDO UN ERROR INTENTANDO REALIZAR LA OPERACION, COMUNICATE CON EL DEP. DE SISTEMAS", false, "#a83252", Properties.Resources.advertencia);
                Log_Error.WriteLine(DateTime.Now.ToString("dd:MM:yyyy HH:mm:ss") + @" MENSAJE DE ERROR : " + ex.Message);
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
                txtTotalD.Text = dblSuma.ToString("N2");

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
                txtTotalP.Text = dblSuma.ToString("N2");
            }
            catch (Exception ex)
            {
                VariablesGlobales.MessageBox_Show("ATENCION", "AH OCURRIDO UN ERROR INTENTANDO REALIZAR LA OPERACION, COMUNICATE CON EL DEP. DE SISTEMAS", false, "#a83252", Properties.Resources.advertencia);
                Log_Error.WriteLine(DateTime.Now.ToString("dd:MM:yyyy HH:mm:ss") + @" MENSAJE DE ERROR : " + ex.Message);
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
            try
            {
                dblCantidad = double.Parse(txtRecibidosTotal.Text);

                pnlTranConContinuar1.Visible = false;
                grpTranConTC.Visible = true;
                txtTranConRecibidos.Text = txtRecibidosTotal.Text;
                if (ClaseOp == "V")
                {
                    txtTranConTC.Text = Properties.Settings.Default.dblTCVenta_.ToString();
                    txtTranConEntregar.Text = Conversion(dblCantidad, dblTC).ToString();
                }
                else if (ClaseOp == "C")
                {
                    txtTranConTC.Text = Properties.Settings.Default.dblTCCompra_.ToString();
                    txtTranConEntregar.Text = Conversion(dblCantidad, dblTC).ToString();
                }
                pnlTranConContinuar2.Visible = true;
                btnTranConSi2.Focus();
            }
            catch (Exception ex)
            {
                VariablesGlobales.MessageBox_Show("ATENCION", "AH OCURRIDO UN ERROR INTENTANDO REALIZAR LA OPERACION, COMUNICATE CON EL DEP. DE SISTEMAS", false, "#a83252", Properties.Resources.advertencia);
                Log_Error.WriteLine(DateTime.Now.ToString("dd:MM:yyyy HH:mm:ss") + @" MENSAJE DE ERROR : " + ex.Message);
            }
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
                txtRecibidosTotal.Text = dblSuma.ToString("N2");

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
                txtEntregarTotal.Text = dblSuma.ToString("N2");
            }
            catch (Exception ex)
            {
                VariablesGlobales.MessageBox_Show("ATENCION", "AH OCURRIDO UN ERROR INTENTANDO REALIZAR LA OPERACION, COMUNICATE CON EL DEP. DE SISTEMAS", false, "#a83252", Properties.Resources.advertencia);
                Log_Error.WriteLine(DateTime.Now.ToString("dd:MM:yyyy HH:mm:ss") + @" MENSAJE DE ERROR : " + ex.Message);
            }
        }

        private void CantidadDinero(object sender, EventArgs e)
        {
            int Cantidad = 0;
            try
            {
                //Pretendemos usar el control que activo mediante el evento "leave"
                if (sender is TextBox mitxt && pnlTransaccionCon.Visible)
                {
                    //Buscamos en que grupo esta mediante el nombre, existen dos grupos, Recibidos y Entregar
                    //Grupo recibidos
                    if (mitxt.Name.Substring(0, 12) == "txtRecibidos")
                    {
                        //Verificamos si se trata de una venta o compra
                        if (ClaseOp == "V")
                        {
                            //En este caso se trata de una venta, se usa el arreglo de BilletesPesos

                            //En esta variable se guarda el ultimo numero del nombre del txt, y se resta 1 para ajustar su uso como indice
                            int indicePesos = (int.Parse(mitxt.Name.Substring(12, 1))) - 1;

                            //Se verifica antes que sea posible la division sin dejar diferencia 
                            if (int.Parse(mitxt.Text) % BilletesP[indicePesos] == 0)
                            {
                                int Valor = BilletesP[indicePesos];
                                Cantidad = int.Parse(mitxt.Text) / Valor;
                            }
                            else
                            {//Se le recuerda al usuario que debe poner la informacion correcta
                                VariablesGlobales.MessageBox_Show("ATENCION", "INGRESA SOLO VALORES DIVISIBLES DE " + BilletesP[indicePesos].ToString(), false, "#F9B600", Properties.Resources.advertencia);

                                mitxt.Focus();
                                mitxt.SelectAll();
                                return;
                            }
                        }
                        else if (ClaseOp == "C")
                        {
                            //En este caso se trata de una compra, se usa el arreglo de BilletesDolares

                            //En esta variable se guarda el ultimo numero del nombre del txt, y se resta 1 para ajustar su uso como indice
                            int indiceDolares = (int.Parse(mitxt.Name.Substring(12, 1))) - 1;

                            if (int.Parse(mitxt.Text) % BilletesD[indiceDolares] == 0)
                            {
                                int Valor = BilletesD[indiceDolares];
                                Cantidad = int.Parse(mitxt.Text) / Valor;
                            }
                            else
                            {
                                //CAMBIANDO LOS MENSAJES POR ALERTA FORM
                                VariablesGlobales.MessageBox_Show("ATENCION", "INGRESA SOLO VALORES DIVISIBLES DE " + BilletesD[indiceDolares].ToString(), false, "#F9B600", Properties.Resources.advertencia);
                                mitxt.Focus();
                                mitxt.SelectAll();
                                return;
                            }
                        }

                        //Al final se busca en el grupo todos los texboxes de cantidad, y se identifica mediante la numeracion en su nombre
                        foreach (Control txtCantidad in grpTransConRecibidos.Controls)
                        {
                            if (txtCantidad is TextBox && txtCantidad.Name.Substring(0, 9) == "txtRecCan" && mitxt.Name.Substring(12, 1) == txtCantidad.Name.Substring(9, 1))
                            {
                                txtCantidad.Text = Cantidad.ToString();
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
                        //Al final se busca en el grupo todos los texboxes de cantidad, y se identifica mediante la numeracion en su nombre
                        foreach (Control txtCantidad in grpTransConEntregar.Controls)
                        {
                            if (txtCantidad.Name.Substring(0, 9) == "txtEntCan" && mitxt.Name.Substring(11, 1) == txtCantidad.Name.Substring(9, 1))
                            {
                                txtCantidad.Text = Cantidad.ToString();
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                VariablesGlobales.MessageBox_Show("ATENCION", "AH OCURRIDO UN ERROR INTENTANDO REALIZAR LA OPERACION, COMUNICATE CON EL DEP. DE SISTEMAS", false, "#a83252", Properties.Resources.advertencia);
                Log_Error.WriteLine(DateTime.Now.ToString("dd:MM:yyyy HH:mm:ss") + @" MENSAJE DE ERROR : " + ex.Message);
            }
        }

        private void HotKeysDesglose(object sender, KeyEventArgs e)
        {
            if (!pnlTranConContinuar1.Visible && e.KeyCode == Keys.Escape)
            {
                pnlTranConContinuar1.Visible = true;
            }
            HotKeysTxtBox(e.KeyCode, btnTranConRegresar1);
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
             * COSAS DE IMPRESION
             * int[] BilletesP = { 1000, 500, 200, 100, 50, 20 };
             * int[] BilletesD = { 100, 50, 20, 10, 5, 1 };
             */
            try
            {
                List<string> desglose = new List<string> { "txtRecibidos1", "txtRecibidos2", "txtRecibidos3", "txtRecibidos4", "txtRecibidos5", "txtRecibidos6", "txtRecibidos7" };
                Ticket ticket = new Ticket();
                ticket.datosImpresora = conexionSQL.EjecutarSelectImpresora();
                printDocument1 = new PrintDocument();
                PrinterSettings ps = new PrinterSettings();
                ticket.cantidades = new List<double>();
                ticket.denominacion = new List<string>();
                double dblSuma = 0;
                string[] denominacion = { };

                if (ClaseOp == "V")
                {
                    // Inicialización del array con los valores correspondientes
                    denominacion = new string[] { "1000", " 500", " 200", "100", "50", "20", "Morralla" };
                }
                else if (ClaseOp == "C")
                {
                    // Inicialización del array con los valores correspondientes
                    denominacion = new string[] { "100", "50", "20", "10", "5", "1", "Morralla" };
                }

                foreach (Control miControl in grpTransConRecibidos.Controls)
                {
                    int i = 0;
                    foreach (string nombre in desglose)
                    {
                        if (miControl is TextBox && miControl.Name == nombre && (double.Parse(miControl.Text) != 00.00))
                        {
                            dblSuma = double.Parse(miControl.Text) + dblSuma;
                            ticket.cantidades.Add(double.Parse(miControl.Text));
                            ticket.denominacion.Add(denominacion[i]);
                        }
                        i++;
                    }
                }

                ticket.cantidades.Add(dblSuma);

                printDocument1.PrinterSettings = ps;
                printDocument1.PrintPage += ticket.ImprimirDesgloce;
                printDocument1.Print();
            }
            catch (Exception ex)
            {
                VariablesGlobales.MessageBox_Show("ATENCION", "AH OCURRIDO UN ERROR INTENTANDO REALIZAR LA OPERACION, COMUNICATE CON EL DEP. DE SISTEMAS", false, "#a83252", Properties.Resources.advertencia);
                Log_Error.WriteLine(DateTime.Now.ToString("dd:MM:yyyy HH:mm:ss") + @" MENSAJE DE ERROR : " + ex.Message);
            }
        }

        private void btnTranConSi2_Click(object sender, EventArgs e)
        {
            try
            {
            pnlTranConContinuar2.Visible = false;
            grpTransConEntregar.Visible = true;
            txtEntregar1.Focus();
            txtEntregar1.SelectAll();

                char chrTE = 'N';

                Ticket ticket = new Ticket();
                ticket.datosImpresora = conexionSQL.EjecutarSelectImpresora();
                printDocument1 = new PrintDocument();
                PrinterSettings ps = new PrinterSettings();

                if (blnTE)
                {
                    chrTE = 'S';
                }

                if (ClaseOp == "V")
                {
                    ticket.datosFolio = new List<string>() { DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "VENTA", "Pesos:", dblCantidad.ToString("F2"), "T.V:", dblTC.ToString("F2"), "Dolares:", Math.Round(dblConversion, 2).ToString("F2"), Math.Round(dblPago, 2).ToString("F2"), Math.Round(dblCambio, 2).ToString("F2") };
                    VariablesGlobales.NumFolio++;
                    conexionSQL.InsertarGenerico((VariablesGlobales.NumFolio), "folio", "VENTA", Math.Round(dblConversion, 2), dblCantidad, dblTC, chrTE, Properties.Settings.Default.dblTCVenta_, dblPago, dblCambio, 'S', 'S');
                }
                else if (ClaseOp == "C")
                {
                    ticket.datosFolio = new List<string>() { DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "COMPRA", "Dolares:", dblCantidad.ToString(), "T.C:", dblTC.ToString(), "Pesos:", Math.Round(dblConversion, 2).ToString(), Math.Round(dblPago, 2).ToString(), Math.Round(dblCambio, 2).ToString() };
                    VariablesGlobales.NumFolio++;
                    conexionSQL.InsertarGenerico((VariablesGlobales.NumFolio), "folio", "COMPRA", dblCantidad, Math.Round(dblConversion, 2), dblTC, chrTE, Properties.Settings.Default.dblTCCompra_, dblPago, dblCambio, 'S', 'S');
                }

                printDocument1.PrinterSettings = ps;
                printDocument1.PrintPage += ticket.ImprimirFolio;
                printDocument1.Print();

            }
            catch (Exception y)
            {
                MessageBox.Show("" + y);
            }

            //Para guardar
            /*
            conexionSQL.InsertarGenerico((VariablesGlobales.NumFolio), "folio", "COMPRA", Properties.Settings.Default.dblEMorD_, Properties.Settings.Default.dblEMorP_, -1.0, 'X', -1.0, -1.0, -1.0, 'S', 'S');
            VariablesGlobales.NumFolio++;
            conexionSQL.InsertarGenerico((VariablesGlobales.NumFolio), "folio", "VENTA", Properties.Settings.Default.dblEMorD_, Properties.Settings.Default.dblEMorP_, -1.0, 'X', -1.0, -1.0, -1.0, 'S', 'S');
            VariablesGlobales.NumFolio++;
            conexionSQL.InsertarGenerico((VariablesGlobales.NumFolio), "folio", "COMPRA", Properties.Settings.Default.dblEMorD_, Properties.Settings.Default.dblEMorP_, -1.0, 'X', -1.0, -1.0, -1.0, 'S', 'S');
            */
        }

        private void btnTranConNo2_Click(object sender, EventArgs e)
        {
            grpTranConTC.Visible = false;
            pnlTranConContinuar2.Visible = false;
            txtRecibidos1.Focus();
            txtRecibidos1.SelectAll();
        }

        private void btnTranConEspecial_Click(object sender, EventArgs e)
        {
            pnlTranConContinuar2.Visible = false;
            txtTranConTC.Focus();
            txtTranConTC.SelectAll();
        }

        private void btnTranConRegresar2_Click(object sender, EventArgs e)
        {
            pnlTranConContinuar2.Visible = false;
            pnlTransaccionCon.Visible = false;
        }

        //Al cambiar su estado visible, se activa este evento que limpia y esconde controles.
        private void pnlTransaccionCon_VisibleChanged(object sender, EventArgs e)
        {
            //Se asegura que sea visible
            if (pnlTransaccionCon.Visible)
            {
                //Busca entre los controles
                foreach (Control miGrupo in pnlTransaccionCon.Controls)
                {
                    //Si alguno es un groupbox
                    if (miGrupo is GroupBox)
                    {
                        //Dentre de ellos se buscan los textboxes
                        foreach (Control mitxt in miGrupo.Controls)
                        {
                            if (mitxt is TextBox)
                            {//si alguno cumple con esta condicion, su valor será diferente
                                if (mitxt == txtRecibidos7 || mitxt == txtRecibidosTotal || mitxt == txtEntregarTotal || mitxt == txtEntregarTotal)
                                {
                                    mitxt.Text = "00.00";
                                }
                                else
                                {
                                    mitxt.Text = "00";
                                }
                            }
                        }
                        //Grupos diferentes al de esta condicion, se esconden
                        if (miGrupo != grpTransConRecibidos)
                        {
                            miGrupo.Visible = false;
                        }
                    }
                    //Y los paneles tambien se ensconden
                    if (miGrupo is Panel)
                    {
                        miGrupo.Visible = false;
                    }
                }
                txtRecibidos1.Focus();
                txtRecibidos1.SelectAll();
            }
            else
            {
                if (ClaseOp == "V")
                {
                    btnVenta.Focus();
                }
                else
                {
                    btnCompra.Focus();
                }
            }
        }

        private void txtEntregar7_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtTranConEntregar.Text == txtEntregarTotal.Text)
                {
                    VariablesGlobales.MessageBox_Show("TERMINAR OPERACION", "¿SEGURO QUE DESEAS TERMINAR LA OPERACION?", true, "#F9B600", Properties.Resources.pregunta);
                    if (VariablesGlobales.ResultDialog == "YES")
                    {
                        pnlTransaccionCon.Visible = false;
                    }
                    else
                    {
                        pnlTranConContinuar2.Visible = true;
                        btnTranConSi2.Focus();
                    }
                }
                else
                {
                    VariablesGlobales.MessageBox_Show("ATENCION", "LA CANTIDAD NO COINCIDE, ASEGURATE DE HABERLA ESCRITO CORRECTAMENTE; SI EL ERROR PERSISTE, COMUNICATE CON EL DEP. DE SISTEMAS", false, "#a83252", Properties.Resources.advertencia);
                    txtEntregar1.Focus();
                    txtEntregar1.SelectAll();
                }
            }
            catch (Exception ex)
            {
                VariablesGlobales.MessageBox_Show("ATENCION", "AH OCURRIDO UN ERROR INTENTANDO REALIZAR LA OPERACION, COMUNICATE CON EL DEP. DE SISTEMAS", false, "#a83252", Properties.Resources.advertencia);
                Log_Error.WriteLine(DateTime.Now.ToString("dd:MM:yyyy HH:mm:ss") + @" MENSAJE DE ERROR : " + ex.Message);
            }
        }

        private void txtTranConTC_Leave(object sender, EventArgs e)
        {
            double dblTranConTC = double.Parse(txtTranConTC.Text);
            try
            {
                if (dblTranConTC != dblTC)
                {
                    if ((ClaseOp == "V" && dblTranConTC < dblTC && dblTranConTC >= dblTC - 0.4) ||
                        (ClaseOp == "C" && dblTranConTC > dblTC && dblTranConTC <= dblTC + 0.4))
                    {
                        dblTC = dblTranConTC;
                    }
                    else
                    {
                        VariablesGlobales.MessageBox_Show("ATENCION", "LA CANTIDAD NO COINCIDE, ASEGURATE DE HABERLA ESCRITO CORRECTAMENTE; SI EL ERROR PERSISTE, COMUNICATE CON EL DEP. DE SISTEMAS", false, "#a83252", Properties.Resources.advertencia);

                        if (ClaseOp == "V")
                        {
                            txtTranConTC.Text = Properties.Settings.Default.dblTCVenta_.ToString();
                        }
                        else txtTranConTC.Text = Properties.Settings.Default.dblTCCompra_.ToString();
                        txtTranConTC.Focus();
                        txtTranConTC.SelectAll();
                        return;
                    }
                }
                dblConversion = Conversion(dblCantidad, dblTC);
                txtTranConEntregar.Text = dblConversion.ToString("N2");
                pnlTranConContinuar2.Visible = true;
                btnTranConSi2.Focus();
            }
            catch (Exception ex)
            {
                VariablesGlobales.MessageBox_Show("ATENCION", "AH OCURRIDO UN ERROR INTENTANDO REALIZAR LA OPERACION, COMUNICATE CON EL DEP. DE SISTEMAS", false, "#a83252", Properties.Resources.advertencia);
                Log_Error.WriteLine(DateTime.Now.ToString("dd:MM:yyyy HH:mm:ss") + @" MENSAJE DE ERROR : " + ex.Message);
            }
        }

        private void btnTranConAceptar_Click(object sender, EventArgs e)
        {


        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (!btnTranSinCancelar.Visible && e.KeyCode == Keys.Escape)
            {
                btnTranSinCancelar.Visible = true;
            }
            HotKeysTxtBox(e.KeyCode, btnTranSinCancelar);
        }

        private void txtTC_KeyDown(object sender, KeyEventArgs e)
        {
            if (!btnTranSinCancelar.Visible && e.KeyCode == Keys.Escape)
            {
                btnTranSinCancelar.Visible = true;
            }
            HotKeysTxtBox(e.KeyCode, btnTranSinCancelar);
        }

        private void HotKeysMenu(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad1:
                    btnVenta.PerformClick();
                    break;
                case Keys.NumPad2:
                    btnCompra.PerformClick();
                    break;
                case Keys.F5:
                    btnEntSal.PerformClick();
                    break;
                case Keys.F2:
                    btnListOperaciones.PerformClick();
                    break;
                case Keys.F11:
                    btnSumadora.PerformClick();
                    break;
                default:
                    break;
            }
        }

        private void btnSinDes_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad1:
                    btnConDes.PerformClick();
                    break;
                case Keys.NumPad2:
                    btnSinDes.PerformClick();
                    break;
                case Keys.Escape:
                    pnlElegirDes.Visible = false;
                    break;
            }

        }

        private void btnConDes_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad1:
                    btnConDes.PerformClick();
                    break;
                case Keys.NumPad2:
                    btnSinDes.PerformClick();
                    break;
                case Keys.Escape:
                    pnlElegirDes.Visible = false;
                    break;
            }
        }

        private void pnlElegirDes_VisibleChanged(object sender, EventArgs e)
        {
            if (!pnlElegirDes.Visible)
            {
                if (ClaseOp == "V")
                {
                    btnVenta.Focus();
                }
                else
                {
                    btnCompra.Focus();
                }
            }
            else
            {
                btnConDes.Focus();
            }
        }

        private void pnlTransaccionSin_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlTransaccionSin.Visible)
            {
                txtCantidad.Text = "00.00";
                txtTC.Text = dblTC.ToString();
                txtConversion.Text = "00.00";
                txtPago.Text = "00.00";
                txtCambio.Text = "00.00";
                pnlConSinFin.Visible = false;
                pnlContinuarSin.Visible = false;
                btnTranSinCancelar.Visible = false;
                grpTranSinCambio.Visible = false;
            }
            else
            {
                if (ClaseOp == "V")
                {
                    btnVenta.Focus();
                }
                else
                {
                    btnCompra.Focus();
                }
            }
        }

        private void pnlEntSal_VisibleChanged(object sender, EventArgs e)
        {
            if (pnlEntSal.Visible)
            {
                foreach (Control micontrol in grpDolares.Controls)
                {
                    if (micontrol is TextBox)
                    {
                        micontrol.Text = "00.00";
                    }
                }
                foreach (Control micontrol in grpPesos.Controls)
                {
                    if (micontrol is TextBox)
                    {
                        micontrol.Text = "00.00";
                    }
                }
                rdbEntrada.Checked = false;
                rdbEntrada.Checked = false;
            }
            else
            {
                if (ClaseOp == "V")
                {
                    btnVenta.Focus();
                }
                else
                {
                    btnCompra.Focus();
                }
            }
        }

        private void txtUmP_Click(object sender, EventArgs e)
        {
            btnSumP.PerformClick();
        }

        private void txtUmD_Click(object sender, EventArgs e)
        {
            btSumD.PerformClick();
        }

        private void txtMorP_KeyDown(object sender, KeyEventArgs e)
        {
            HotKeysTxtBox(e.KeyCode, btnCancelarEntSal);

        }

        private void btnAceptarEntSal_Click(object sender, EventArgs e)
        {
            if (rdbEntrada.Checked)
            {
                if (double.Parse(txtTotalD.Text) != 00.00)
                {
                    conexionSQL.InsertarGenerico(3200, "EntD", txtMotivo.Text, double.Parse(txtTotalD.Text), -1.0, -1.0, 'X', -1.0, -1.0, -1.0, 'S', 'S');
                }

                if (double.Parse(txtTotalP.Text) != 00.00)
                {
                    conexionSQL.InsertarGenerico(3300, "EntP", txtMotivo.Text, -1.0, double.Parse(txtTotalP.Text), -1.0, 'X', -1.0, -1.0, -1.0, 'S', 'S');
                }
            }
            else if (rdbSalida.Checked)
            {
                if (double.Parse(txtTotalD.Text) != 00.00)
                {
                    conexionSQL.InsertarGenerico(5200, "SalD", txtMotivo.Text, double.Parse(txtTotalD.Text), -1.0, -1.0, 'X', -1.0, -1.0, -1.0, 'S', 'S');
                }

                if (double.Parse(txtTotalP.Text) != 00.00)
                {
                    conexionSQL.InsertarGenerico(5300, "SalP", txtMotivo.Text, -1.0, double.Parse(txtTotalP.Text), -1.0, 'X', -1.0, -1.0, -1.0, 'S', 'S');
                }
            }
            pnlEntSal.Visible = false;
        }

        private void btnTranSinCancelar_Click(object sender, EventArgs e)
        {
            pnlContinuarSin.Visible = false;
            pnlTransaccionSin.Visible = false;
            pnlConSinFin.Visible = false;
        }

        private void txtPago_KeyDown(object sender, KeyEventArgs e)
        {
            if (!btnTranSinCancelar.Visible && e.KeyCode == Keys.Escape)
            {
                btnTranSinCancelar.Visible = true;
            }
            HotKeysTxtBox(e.KeyCode, btnTranSinCancelar);
        }

        private void txtRecibidos7_Leave(object sender, EventArgs e)
        {
            pnlTranConContinuar1.Visible = true;
            btnTranConSi1.Focus();
        }

         private void btnCorte_Click(object sender, EventArgs e)
        {
            frmCorteCaja miCorteCaja = new frmCorteCaja();
            miCorteCaja.Show();
            this.Visible = false;
        }

        private void btnDirecta_Click(object sender, EventArgs e)
        {
            pnlElegirDirecta.Visible = false;
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
            }
            txtTC.Text = dblTC.ToString();
            txtCantidad.Focus();
            txtCantidad.SelectAll();
        }

        private void btnIndirecta_Click(object sender, EventArgs e)
        {
            pnlElegirDirecta.Visible = false;
            pnlTransaccionSin.Visible = true;
            if (ClaseOp == "V")
            {
                //Se ajusta para una venta indirecta
                lblTransSin.Text = "VENTA INDIRECTA";
                lblCantidad.Text = "DOLARES DECEADOS:";
                lblConversion.Text = "PESOS NECESARIOS:";

                //Acomodo de las etiquetas
                lblTransSin.Location = new Point(165, 18);
                lblCantidad.Location = new Point(51, 67);
                lblConversion.Location = new Point(60, 166);
                ClaseOp = "VI";
            }
            else
            {
                //Se ajusta para una compra indirecta
                lblTransSin.Text = "COMPRA INDIRECTA";
                lblCantidad.Text = "PESOS DECEADOS:";
                lblConversion.Text = "DOLARES NECESARIOS: ";

                //Acomodo de las etiquetas
                lblTransSin.Location = new Point(164, 18);
                lblCantidad.Location = new Point(80, 67);
                lblConversion.Location = new Point(32, 166);
                ClaseOp = "CI";
            }
            txtTC.Text = dblTC.ToString();
            txtCantidad.Focus();
            txtCantidad.SelectAll();
        }

        private void btnDirecta_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad1:
                    btnDirecta.PerformClick();
                    break;
                case Keys.NumPad2:
                    btnIndirecta.PerformClick();
                    break;
                case Keys.Escape:
                    pnlElegirDirecta.Visible = false;
                    break;
            }
        }

        private void btnIndirecta_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad1:
                    btnDirecta.PerformClick();
                    break;
                case Keys.NumPad2:
                    btnIndirecta.PerformClick();
                    break;
                case Keys.Escape:
                    pnlElegirDirecta.Visible = false;
                    break;
            }
        }

   
    }
}