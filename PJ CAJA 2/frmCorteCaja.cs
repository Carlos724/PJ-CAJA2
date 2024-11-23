using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Printing;
using MySql.Data.MySqlClient;

namespace PJ_CAJA_2
{
    public partial class frmCorteCaja : Form
    {
        ConexionInicial conexionSQL = new ConexionInicial();
        public List<string> datosCorte;
        public List<string> datosFoliosCan;

        public frmCorteCaja()
        {
            InitializeComponent();
        }

        private void frmCorteCaja_Load(object sender, EventArgs e)
        {
            Animation.Start();
            this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            this.WindowState = FormWindowState.Maximized;
            //Taskbar.Hide();
        }

        private void Animation_Tick(object sender, EventArgs e)
        {
            prgImprimiendo.Value += 1;

            if (prgImprimiendo.Value == 25)
            {
                picAnimacion.Image = Properties.Resources.verificar;
                EjecutarCorte();
            }

            if (prgImprimiendo.Value >= 25 && prgImprimiendo.Value <= 50)
            {
                lblTexto.Text = "Verificando inicios y salidas...";
            }

            if (prgImprimiendo.Value == 50)
            {
                picAnimacion.Image = Properties.Resources.calcular;
            }

            if (prgImprimiendo.Value > 50 && prgImprimiendo.Value <= 75)
            {
                lblTexto.Text = "Sumando folios...";
            }

            if (prgImprimiendo.Value == 75)
            {
                picAnimacion.Image = Properties.Resources.impresora;
                Imprimir();
            }

            if (prgImprimiendo.Value > 75 && prgImprimiendo.Value <= 99)
            {
                lblTexto.Text = "Imprimiendo ticket...";
            }

            if (prgImprimiendo.Value == 100)
            {
                Animation.Stop();
                VariablesGlobales.MessageBox_Show("Corte de caja", "CORTE REALIZADO CON EXITO", false, "#18c71e", Properties.Resources.dinero);
                if (VariablesGlobales.ResultDialog == "OK")
                {
                    //conexionSQL.CerrarSesion();
                    //Application.Restart();
                }
            }
        }

        private void EjecutarCorte()
        {
            try
            {
                conexionSQL.datosXML = conexionSQL.LeerXML();
                conexionSQL.cnnInicial = new MySqlConnection(conexionSQL.datosXML);
                datosCorte = conexionSQL.RealizarCorte();
                datosFoliosCan = conexionSQL.EjecutarConsultaListaCancelacions();
            }
            catch (Exception y)
            {
                MessageBox.Show("" + y);
            }
        }

        private void Imprimir()
        {
            Ticket ticket = new Ticket();
            ticket.datosImpresora = conexionSQL.EjecutarSelectImpresora();
            ticket.datosCorte = datosCorte;
            ticket.datosFoliosCan = datosFoliosCan;
            printDocument1 = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();

            printDocument1.PrinterSettings = ps;
            printDocument1.PrintPage += ticket.ImprimirCorte;
            printDocument1.Print();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
