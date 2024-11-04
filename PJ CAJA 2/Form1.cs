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
    public partial class frmInicioSesion : Form
    {
        
        public frmInicioSesion()
        {
            InitializeComponent();

            timer1.Interval=1000;
            timer1.Start();            
        }

        //BOTÓNES
        //Iniciar la caja, hace visible el panel de tipos de cambio
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.strUsuario_ = txtUsuario.Text;
            Properties.Settings.Default.Save();
            pnlTiposCambio.Visible = true;
           
        }

        //Aceptar tipos de cambio, guarda las variables y hace visible el panel de inicios
        private void btnAceptarCambio_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.dblTCCompra_ = double.Parse(txtCompra.Text);
            Properties.Settings.Default.dblTCVenta_ = double.Parse(txtVenta.Text);
            Properties.Settings.Default.Save();
            pnlInicios.Visible = true;
            pnlTiposCambio.Visible = false;
        }

        //Aceptar los inicios, guarda las variables y abre el menu de operaciones
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.dblECpP_ =double.Parse(txtCpP.Text);
            Properties.Settings.Default.dblEUmP_ =double.Parse(txtUmP.Text);
            Properties.Settings.Default.dblEMorP_ = double.Parse(txtMorP.Text);
            Properties.Settings.Default.dblECpD_ = double.Parse(txtCpD.Text);
            Properties.Settings.Default.dblEUmD_ = double.Parse(txtUmD.Text);
            Properties.Settings.Default.dblEMorD_ = double.Parse(txtMorD.Text);
            Properties.Settings.Default.Save();
            frmMenu miMenu = new frmMenu();
            miMenu.Show();
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
    }
}
