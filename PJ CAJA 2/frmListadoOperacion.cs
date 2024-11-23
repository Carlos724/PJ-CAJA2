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
    public partial class frmListadoOperacion : Form
    {
        string usuario = Properties.Settings.Default.strUsuario_;
        public frmListadoOperacion()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
