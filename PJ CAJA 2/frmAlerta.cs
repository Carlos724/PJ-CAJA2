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
    public partial class frmAlerta : Form
    {
        public frmAlerta()
        {
            InitializeComponent();
        }

        public void centraX()
        {
            //un poco de matematicas, restando los anchos y dividiendo entre 2
            int x = (tabPage1.Width / 2) - (btnAceptar.Width / 2);

            //asignamos la nueva ubicación
            btnAceptar.Location = new Point(x, btnAceptar.Location.Y);

            //un poco de matematicas, restando los anchos y dividiendo entre 2
            double y = (tabPage2.Width / 3.75) - (btnConfirmar.Width / 3.75) ;

            //asignamos la nueva ubicación
            btnConfirmar.Location = new Point((int)y, btnConfirmar.Location.Y);

            //un poco de matematicas, restando los anchos y dividiendo entre 2
            double z = (tabPage2.Width / 1.50) - (btnCancelar.Width / 1.50);

            //asignamos la nueva ubicación
            btnCancelar.Location = new Point((int)z, btnCancelar.Location.Y);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
