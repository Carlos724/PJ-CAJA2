using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using MySql.Data.MySqlClient;

namespace PJ_CAJA_2
{
    public partial class frmInicioSesion : Form
    {
        ConexionInicial conexionSQL = new ConexionInicial();
        char chrDivisa = '0';
        public frmInicioSesion()
        {
            InitializeComponent();

            conexionSQL.datosXML = conexionSQL.LeerXML();
            conexionSQL.cnnInicial = new MySqlConnection(conexionSQL.datosXML);
            timer1.Interval = 500;
            timer1.Start();
            //######PRUEBAS
            /*
            pnlSumadora.Visible = true;
            pnlEntSal.Visible = true;*/
            frmMenu miMenu = new frmMenu();
            miMenu.Show();
            this.Visible = false;
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
                if(miControl is GroupBox miGrupo)
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

        //Mantiene la forma en pantalla completa y no permite que se minimice
        private void frmInicioSesion_Load(object sender, EventArgs e)
        {
            this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            this.WindowState = FormWindowState.Maximized;
            //Taskbar.Hide();

        }

        //## BOTÓNES ##
        //Iniciar la caja, hace visible el panel de tipos de cambio
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.strUsuario_ = txtUsuario.Text;
            Properties.Settings.Default.Save();
            pnlTiposCambio.Visible = true;
            grpInicio.Enabled = false;
            txtCompra.Focus();
        }

        //Aceptar tipos de cambio, guarda las variables y hace visible el panel de inicios
        private void btnAceptarCambio_Click(object sender, EventArgs e)
        {
            if (double.Parse(txtCompra.Text) < double.Parse(txtVenta.Text))
            {
                foreach(Control micontrol in pnlTiposCambio.Controls)
                {
                    if(micontrol is TextBox mitxt)
                    {
                        if (!(mitxt.Text.Length == 4))
                        {
                            if (mitxt.Text.Contains("."))
                            {
                                mitxt.Text = mitxt.Text + "";
                            }
                        }
                    }
                }
                if (!txtCompra.Text.Contains("."))
                {
                    txtCompra.Text = txtCompra.Text + ".";
                }
                if (!txtVenta.Text.Contains("."))
                {
                    txtVenta.Text = txtVenta.Text + ".";
                }
                switch (txtCompra.Text.Length)
                {
                    case 3:
                        txtCompra.Text = txtCompra.Text + "0";
                        break;
                    default:
                        break;
                }
                Properties.Settings.Default.dblTCCompra_ = double.Parse(txtCompra.Text);
                Properties.Settings.Default.dblTCVenta_ = double.Parse(txtVenta.Text);
                Properties.Settings.Default.Save();
                conexionSQL.InsertarSesion();
                pnlEntSal.Visible = true;
                pnlTiposCambio.Visible = false;
                txtCpP.Focus();
                pnlTiposCambio.Enabled = false;
                txtMorD.Focus();
            }
            else
            {
                MessageBox.Show("LA COMPRA NO PUEDE SER MAYOR QUE LA VENTA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCompra.Focus();
                txtCompra.SelectAll();
            }
        }

        //Regresa al inicio introduccion del usuario
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlEntSal.Visible = false;
            grpInicio.Enabled = true;
        }

        //Cancela el ingreso del tipo de cambio y se regresa a la captura de usuario
        private void btnCancelarCambio_Click(object sender, EventArgs e)
        {
            pnlTiposCambio.Visible = false;
            grpInicio.Enabled = true;
            txtUsuario.Focus();
        }

        //Sumadora de dolares
        private void btnSumD_Click(object sender, EventArgs e)
        {
            chrDivisa = 'D';
            pnlSumadora.Visible = true;
            txtSuma1.Focus();
        }

        //Sumadora de pesos
        private void btnSumP_Click(object sender, EventArgs e)
        {
            chrDivisa = 'P';
            pnlSumadora.Visible = true;
            txtSuma1.Focus();
        }

        //Aceptar los inicios, guarda las variables y abre el menu de operaciones
        private void btnAceptarInSa_Click(object sender, EventArgs e)
        {
            VariablesGlobales.MessageBox_Show("Verificacion","¿Estan correctos los inicios?",true, "#18c71e", Properties.Resources.dinero);
            if (VariablesGlobales.ResultDialog == "YES")
            {
                //SUMA UM Y CP
                double sumaP = Properties.Settings.Default.dblECpP_ + Properties.Settings.Default.dblEUmP_;
                double sumaD = Properties.Settings.Default.dblECpD_ + Properties.Settings.Default.dblEUmD_;

                Properties.Settings.Default.dblECpP_ = double.Parse(txtCpP.Text);
                Properties.Settings.Default.dblEUmP_ = double.Parse(txtUmP.Text);
                Properties.Settings.Default.dblEMorP_ = double.Parse(txtMorP.Text);
                Properties.Settings.Default.dblECpD_ = double.Parse(txtCpD.Text);
                Properties.Settings.Default.dblEUmD_ = double.Parse(txtUmD.Text);
                Properties.Settings.Default.dblEMorD_ = double.Parse(txtMorD.Text);
                Properties.Settings.Default.Save();
                conexionSQL.InsertarGenerico(3110, "", "INI BILL", sumaD, sumaP, -1.0, 'X', -1.0, -1.0, -1.0, 'S', 'S');
                conexionSQL.InsertarGenerico(3120, "", "INI MOR", Properties.Settings.Default.dblEMorD_, Properties.Settings.Default.dblEMorP_, -1.0, 'X', -1.0, -1.0, -1.0, 'S', 'S');
                frmMenu miMenu = new frmMenu();
                miMenu.Show();
                this.Close();

                //Para guardar
                /*
                conexionSQL.InsertarGenerico((VariablesGlobales.NumFolio), "", "folio", Properties.Settings.Default.dblEMorD_, Properties.Settings.Default.dblEMorP_, -1.0, 'X', -1.0, -1.0, -1.0, 'S', 'S');
                VariablesGlobales.NumFolio++;
                conexionSQL.InsertarGenerico((VariablesGlobales.NumFolio), "", "folio", Properties.Settings.Default.dblEMorD_, Properties.Settings.Default.dblEMorP_, -1.0, 'X', -1.0, -1.0, -1.0, 'S', 'S');
                VariablesGlobales.NumFolio++;
                conexionSQL.InsertarGenerico((VariablesGlobales.NumFolio), "", "folio", Properties.Settings.Default.dblEMorD_, Properties.Settings.Default.dblEMorP_, -1.0, 'X', -1.0, -1.0, -1.0, 'S', 'S');
                */

            }
            else
            {

            }
        }

        private void btnCancelarEntSal_Click(object sender, EventArgs e)
        {
            pnlEntSal.Visible = false;
            grpInicio.Enabled = true;
        }

        //##    PRUEBA  ################
        private void btnSalida_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //## METODOS ## 
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
        //RELOJ EN PANTALLA
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHoras.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        //#EVENTOS: permiten moverse por los textboxes mas comodamente con el metodo HotKeysTxtBox(keycode, botón para cancelar)
        private void txtCompra_KeyDown(object sender, KeyEventArgs e)
        {
            HotKeysTxtBox(e.KeyCode, btnCancelarEntSal);
        }

        private void txtVenta_KeyDown(object sender, KeyEventArgs e)
        {
            HotKeysTxtBox(e.KeyCode, btnCancelarEntSal);
        }

        //no se que hace este
        private void frmInicioSesion_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
        }

        private void txtMorD_KeyDown(object sender, KeyEventArgs e)
        {
            HotKeysTxtBox(e.KeyCode, btnCancelarEntSal);
        }

        private void txtCpD_KeyDown(object sender, KeyEventArgs e)
        {
            HotKeysTxtBox(e.KeyCode, btnCancelarEntSal);
        }

        private void txtMorP_KeyDown(object sender, KeyEventArgs e)
        {
            HotKeysTxtBox(e.KeyCode, btnCancelarEntSal);
        }

        private void txtCpP_KeyDown(object sender, KeyEventArgs e)
        {
            HotKeysTxtBox(e.KeyCode, btnCancelarEntSal);
        }

        //Evento para el txt del usuario, dando enter, se continua por la aplicacion
        private void txtUsuario_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnIniciar.PerformClick();
            }
            else if (e.KeyCode == Keys.Down)
            {
                GetNextControl(txtVenta, true).Focus();
            }
        }

        //Radiobutton que cambia la leyenda del groupbox grpMotivo
        private void rdbEntrada_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbEntrada.Checked)
            {
                grpMotivo.Text = "¿De donde viene?";
            }
            else { grpMotivo.Text = "¿A donde va?"; }
        }

        //#EVENTOS: permiten moverse por los textboxes mas comodamente con el metodo HotKeysTxtBox(keycode, botón para cancelar)
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

        //Botón aceptar de sumadora
        private void btnAceptarSum_Click(object sender, EventArgs e)
        {
            pnlSumadora.Visible = false;
            //Dependiendo de la variable, el resultado se envia al txt de dolares o pesos
            switch (chrDivisa)
            {
                case 'P':
                    txtUmP.Text = txtSumaTotal.Text;
                    txtCpP.Focus();
                    break;
                case 'D':
                    txtUmD.Text = txtSumaTotal.Text;
                    txtCpD.Focus();
                    break;
                default:
                    break;
            }            
        }

        private void btnImprimirSum_Click(object sender, EventArgs e)
        {

            /*
             cosas de impresora
             */
        }

        //Botón de cancelado en sumadora, cambia su estado visible a falso
        private void btnCancelarSum_Click(object sender, EventArgs e)
        {
            pnlSumadora.Visible = false;
        }

        //Cuando cambie su estado visible, los controles se reinician en sumadora
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
        //Textbox de UM(dolares), al dar click, se abre sumadora
        private void txtUmD_Click(object sender, EventArgs e)
        {
            btnSumD.PerformClick();
        }

        //Textbox de UM(pesos), al dar click, se abre sumadora
        private void txtUmP_Click(object sender, EventArgs e)
        {
            btnSumP.PerformClick();
        }

    }
}
