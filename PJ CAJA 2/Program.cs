using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PJ_CAJA_2
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
            ConexionInicial conexionSQL = new ConexionInicial();

            conexionSQL.datosXML = conexionSQL.LeerXML();
            conexionSQL.cnnInicial = new MySqlConnection(conexionSQL.datosXML);
            var (sesion, inicios) = conexionSQL.VerificarSesion();

            if (sesion && inicios)
            {
                frmMenu miMenu = new frmMenu();
                miMenu.FormClosed += MainForm_Closed;
                miMenu.Show();

            }
            else if (sesion && (inicios == false))
            {
                VariablesGlobales.MessageBox_Show("ATENCION", "NO INICIOS REGISTRADOS", false, "#a83252", Properties.Resources.advertencia);
                
                frmInicioSesion newsesion = new frmInicioSesion();
                newsesion.pnlEntSal.Visible = true;
                newsesion.pnlTiposCambio.Visible = false;
                newsesion.txtCpP.Focus();
                newsesion.pnlTiposCambio.Enabled = false;
                newsesion.txtMorD.Focus();
                newsesion.FormClosed += MainForm_Closed;
                newsesion.Show();
            }
            else
            {
            frmInicioSesion newsesion = new frmInicioSesion();
            newsesion.FormClosed += MainForm_Closed;
            newsesion.Show();
            }
            
            /*
            Probando_ticket ticket = new Probando_ticket();
            ticket.FormClosed += MainForm_Closed;
            ticket.Show();
            frmCorteCaja corte = new frmCorteCaja();
            corte.FormClosed += MainForm_Closed;
            corte.Show();
            */
            Application.Run();
        }

        private static void MainForm_Closed(object sender, FormClosedEventArgs e)
        {
            ((Form)sender).FormClosed -= MainForm_Closed;

            if (Application.OpenForms.Count == 0)
            {
                Application.ExitThread();
            }
            else
            {
                Application.OpenForms[0].FormClosed += MainForm_Closed;
            }
        }
    }
}
