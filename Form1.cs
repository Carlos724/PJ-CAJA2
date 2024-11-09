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

            timer1.Interval=1000;
            timer1.Start();

            conexionSQL.prueba = conexionSQL.LeerXML();
            conexionSQL.cnnPrueba = new MySqlConnection(conexionSQL.prueba);
        }

        //## BOTÓNES ##
        //Iniciar la caja, hace visible el panel de tipos de cambio
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.strUsuario_ = txtUsuario.Text;
            Properties.Settings.Default.Save();
            pnlTiposCambio.Visible = true;
            txtCompra.Focus();
        }

        //Aceptar tipos de cambio, guarda las variables y hace visible el panel de inicios
        private void btnAceptarCambio_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.dblTCCompra_ = double.Parse(txtCompra.Text);
            Properties.Settings.Default.dblTCVenta_ = double.Parse(txtVenta.Text);
            Properties.Settings.Default.Save();
            pnlInicios.Visible = true;
            pnlTiposCambio.Visible = false;
            txtCpP.Focus();
            pnlTiposCambio.Enabled = false;
        }

        //Aceptar los inicios, guarda las variables y abre el menu de operaciones
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            VariablesGlobales.MessageBox_Show("Verificacion","¿Estan correctos los inicios?",true, "#228b22");
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
                miMenu.Show();
                this.Close();
            }
            else
            {

            }

        }

        //Regresa al inicio introduccion del usuario
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlInicios.Visible = false;
        }

        //RELOJ EN PANTALLA
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHoras.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void frmInicioSesion_Load(object sender, EventArgs e)
        {
            this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            this.WindowState = FormWindowState.Maximized;
            Taskbar.Hide();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void frmInicioSesion_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;
        }
    }
}
