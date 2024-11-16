using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Printing;
using System.Windows;

namespace PJ_CAJA_2
{
    public partial class Probando_ticket : Form
    {
        public Probando_ticket()
        {
            InitializeComponent();
        }

        Ticket ticket = new Ticket();

        private void button1_Click(object sender, EventArgs e)
        {
            printDocument1 = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printDocument1.PrinterSettings = ps;
            printDocument1.PrintPage += ticket.ImprimirCorte;
            printDocument1.Print();
        }

    }
}
