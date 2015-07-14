using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace POS
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        SqlConnection cn;
        SqlDataAdapter da;
        DataTable dt;
        bool showpass;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "123" && txtPassword.Text == "123")
            {
                frmDashBoard db = new frmDashBoard();
                db.Show();

            }
            else
            {
                MessageBox.Show("Incorrect Password");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (showpass == false)
            {
                showpass = true;
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                showpass = false;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}