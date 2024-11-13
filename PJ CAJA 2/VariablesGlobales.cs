using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace PJ_CAJA_2
{
    class VariablesGlobales
    {
        public static string ResultDialog;
        public static int NumFolio = 1;
        public static int NumEntrada = 3200;
        public static int NumSalida = 5000;

        public static void MessageBox_Show(string titulo, string mensaje, bool decision, string colorFondo, Bitmap imagen)
        {
            frmAlerta frm = new frmAlerta();
            frm.centraX();
            frm.BackColor = ColorTranslator.FromHtml(colorFondo);
            frm.lblTitulo.Text = titulo;
            frm.lblMensaje.Text = mensaje;
            frm.pnlAlerta.BackColor = ColorTranslator.FromHtml(colorFondo);
            frm.lblMensaje.BackColor = ColorTranslator.FromHtml(colorFondo);
            frm.tabPage1.BackColor = ColorTranslator.FromHtml(colorFondo);
            frm.tabPage2.BackColor = ColorTranslator.FromHtml(colorFondo);
            frm.picIcono.Image = imagen;
            frm.picIcono.BackColor = ColorTranslator.FromHtml(colorFondo);


            if (decision)
            {
                frm.tbBotones.SelectedIndex = 1;
            }
            else if (decision == false)
            {
                frm.tbBotones.SelectedIndex = 0;
            }
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                ResultDialog = "OK";
            }
            else if (frm.DialogResult == DialogResult.Yes)
            {
                ResultDialog = "YES";
            }
            else if (frm.DialogResult == DialogResult.No)
            {
                ResultDialog = "NO";
            }

            frm.Close();
        }
    }
}
