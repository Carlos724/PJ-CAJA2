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

            bool sesion = conexionSQL.VerificarSesion();
            if (sesion)
            {
                frmMenu miMenu = new frmMenu();
                miMenu.FormClosed += MainForm_Closed;
                miMenu.Show();
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
            ticket.Show();*/
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
