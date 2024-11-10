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
        Conexion conexionSQL = new Conexion();

        public frmInicioSesion()
        {
            InitializeComponent();

            conexionSQL.prueba = conexionSQL.LeerXML();
            conexionSQL.cnnPrueba = new MySqlConnection(conexionSQL.prueba);
            timer1.Interval = 500;
            timer1.Start();

            /*
            //######PRUEBAS
            frmMenu miMenu = new frmMenu();
            miMenu.Show();
            */
        }

        //Mantiene la forma en pantalla completa y no permite que se minimice
        private void frmInicioSesion_Load(object sender, EventArgs e)
        {/*
            this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            this.WindowState = FormWindowState.Maximized;
            //Taskbar.Hide();
            */
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
                Properties.Settings.Default.dblTCCompra_ = double.Parse(txtCompra.Text);
                Properties.Settings.Default.dblTCVenta_ = double.Parse(txtVenta.Text);
                Properties.Settings.Default.Save();
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

        private void btSumD_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSumP_Click(object sender, EventArgs e)
        {

        }

        //Aceptar los inicios, guarda las variables y abre el menu de operaciones
        private void btnAceptarInSa_Click(object sender, EventArgs e)
        {
            VariablesGlobales.MessageBox_Show("Verificacion", "¿Estan correctos los inicios?", true, "#228b22");
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
                conexionSQL.InsertarGenerico(0, "", "INI BILL", sumaD, sumaP, -1.0, 'X', -1.0, -1.0, -1.0, 'S', 'S');
                conexionSQL.InsertarGenerico(0, "", "INI MOR", Properties.Settings.Default.dblEMorD_, Properties.Settings.Default.dblEMorP_, -1.0, 'X', -1.0, -1.0, -1.0, 'S', 'S');
                frmMenu miMenu = new frmMenu();
                miMenu.Show();
                this.Close();
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
                    if(this.ActiveControl is TextBox mitxt)
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

        private void txtCompra_KeyDown(object sender, KeyEventArgs e)
        {
            HotKeysTxtBox(e.KeyCode, btnCancelarEntSal);
        }

        private void txtVenta_KeyDown(object sender, KeyEventArgs e)
        {
            HotKeysTxtBox(e.KeyCode, btnCancelarEntSal);
        }

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

        private void rdbEntrada_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbEntrada.Checked)
            {
                grpMotivo.Text = "¿De donde viene?";
            }
            else { grpMotivo.Text = "¿A donde va?"; }
        }

       
    }
}
