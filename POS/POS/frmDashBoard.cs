using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class frmDashBoard : Form
    {
        public frmDashBoard()
        {
            InitializeComponent();
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            frmItems fi = new frmItems();
            fi.Show();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            frmPurchaseInvoice pi = new frmPurchaseInvoice();
            pi.Show();
        }
    }
}
