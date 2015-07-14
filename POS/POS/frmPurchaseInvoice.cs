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

namespace POS
{
    public partial class frmPurchaseInvoice : Form
    {
        public frmPurchaseInvoice()
        {
            InitializeComponent();
        }
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter da;
        DataSet ds;
        SqlDataReader reader;
        DataTable dt;
        
        private void myamount()
        {
            double a, b;

            bool isAValid = double.TryParse(txtQty.Text, out a);
            bool isBValid = double.TryParse(txtRate.Text, out b);

            if (isAValid && isBValid)
                txtTotal.Text = (a * b).ToString();

            else
                txtTotal.Text = "Invalid input";
        }

        public void Remaining1()
        {
            double c, d, e, f;


            bool isCValid = double.TryParse(txtTotal.Text, out c);
            bool isDValid = double.TryParse(txtDiscountAmount.Text, out d);

            f = c - d;
            if (isCValid && isDValid)
                txtNetAmount.Text = f.ToString();


            else
                txtRemaining.Text = "Invalid OutPut";
        }

        public void Remaining2()
        {
            double c, d, e, f;


            bool isCValid = double.TryParse(txtNetAmount.Text, out c);
            bool isDValid = double.TryParse(txtPaid.Text, out d);

            f = c - d;
            if (isCValid && isDValid)
                txtRemaining.Text = f.ToString();


            else
                txtRemaining.Text = "Invalid OutPut";
        }


        private void frmPurchaseInvoice_Load(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(DBHelper.ConnectionString());
            connection.Open();
            command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select * from stock_db where code='" + this.txtProductID.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            ds = new DataSet();
            da.Fill(ds);

            try
            {
                

                reader = command.ExecuteReader();
                {
                    while (reader.Read())
                    {
                       txtProductName.Text = (reader["name"].ToString());
                        
                    }
                }
            }
            finally
            {
                connection.Close();
            }
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            myamount();
        }

        private void txtNetAmount_TextChanged(object sender, EventArgs e)
        {
            Remaining1();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemaining_TextChanged(object sender, EventArgs e)
        {
            Remaining2();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(DBHelper.ConnectionString());
            connection.Open();
            command = new SqlCommand();
            command.Connection = connection;
            string query = "select * from stock_db where code='" + txtProductID.Text + "'";
             da = new SqlDataAdapter(query,connection);
             dt = new DataTable();
             da.Fill(dt);
             if (dt.Rows.Count == 0)
             {
                 MessageBox.Show("Please Enter Product Id");
                 txtProductID.Select();
                 txtProductID.SelectAll();
                 toolStripProgressBar1.Value = 30;
                 return;
             }
             if (dataGridView1.Rows.Count > 0)
             {
                 for (int i = 0; i < dataGridView1.Rows.Count; i++)
                 {
                     if (txtProductID.Text == dataGridView1.Rows[i].Cells["p_id"].Value.ToString() )
                     {
                         MessageBox.Show("This product already exist in this invoice");
                         return;
                     }

                 }
             }
             toolStripProgressBar1.Value = 40;
             int rows = dataGridView1.Rows.Count;
             dataGridView1.Rows.Add();

             dataGridView1.Rows[rows].Cells["p_id"].Value = txtProductID.Text;
             dataGridView1.Rows[rows].Cells["p_name"].Value = txtProductName.Text;
             dataGridView1.Rows[rows].Cells["qty"].Value = txtQty.Text;
             dataGridView1.Rows[rows].Cells["rate"].Value = txtRate.Text;
             dataGridView1.Rows[rows].Cells["netTotal"].Value = txtNetAmount.Text;
             dataGridView1.Rows[rows].Cells["sale_price"].Value = txtSalePrice.Text;
             dataGridView1.Rows[rows].Cells["total"].Value = txtTotal.Text;
             dataGridView1.Rows[rows].Cells["date"].Value = dateTimePicker1.Value;
             dataGridView1.Rows[rows].Cells["paid_payment"].Value = txtPaid.Text;
             dataGridView1.Rows[rows].Cells["remaining_payment"].Value = txtRemaining.Text;
             dataGridView1.Rows[rows].Cells["inovice_num"].Value = txtInoviceNo.Text;
             toolStripProgressBar1.Value = 100;
             

           

        }
        private void clear()
        {

            txtDiscountAmount.Clear();
            txtProductID.Clear();
            txtPaid.Clear();
            txtQty.Clear();
            txtProductName.Clear();
            txtRemaining.Clear();
            txtPaid.Clear();
            txtTotal.Clear();
            txtNetAmount.Clear();
            txtRate.Clear();
            txtSalePrice.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            connection = new SqlConnection(DBHelper.ConnectionString());
            connection.Open();
            command = new SqlCommand();
            command.Connection = connection;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                command.CommandText = "insert into purchase_db (p_date,pi_no,p_id,rate,sale_price,qty,total,net_total,paid,remaining_payment) values ('" +dataGridView1.Rows[i].Cells["date"].Value+ "','" + dataGridView1.Rows[i].Cells["inovice_num"].Value + "','" + dataGridView1.Rows[i].Cells["p_id"].Value + "','" + dataGridView1.Rows[i].Cells["rate"].Value + "','" + dataGridView1.Rows[i].Cells["sale_price"].Value + "','" + dataGridView1.Rows[i].Cells["qty"].Value + "','" + dataGridView1.Rows[i].Cells["total"].Value + "','" + dataGridView1.Rows[i].Cells["netTotal"].Value + "','" + dataGridView1.Rows[i].Cells["paid_payment"].Value + "','" + dataGridView1.Rows[i].Cells["remaining_payment"].Value + "')";
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
           
           
            MessageBox.Show("Item Saved Successfully");
        }

        private void txtInoviceNo_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
