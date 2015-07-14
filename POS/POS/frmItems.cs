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
    public partial class frmItems : Form
    {
        public frmItems()
        {
            InitializeComponent();
        }
        SqlConnection connection;
        SqlCommand command;

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(DBHelper.ConnectionString());
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "insert into stock_db (code,name) values ('"+this.txtItemCode.Text+"','"+this.txtItemName.Text+"')";
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                MessageBox.Show("Item Saved Successfully");
                txtItemCode.Clear();
                txtItemName.Clear();
                displayAllCatagories();
                txtItemCode.Clear();
                txtItemName.Clear();
               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            } 
        }
        DataSet ds = new DataSet();
       
        private void displayAllCatagories()
        {

            connection = new SqlConnection(DBHelper.ConnectionString());
            connection.Open();
            command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select * from stock_db";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            ds = new DataSet();
            da.Fill(ds);
            this.lbxItemSaved.DataSource = null;
            this.lbxItemSaved.DisplayMember = "name";
            this.lbxItemSaved.ValueMember = "code";
            this.lbxItemSaved.DataSource = ds.Tables[0];
            connection.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            displayAllCatagories();
        }

        private void lbxItemSaved_SelectedIndexChanged(object sender, EventArgs e)
        {

            int currentIndex = this.lbxItemSaved.SelectedIndex;
            if (currentIndex == -1)
                return;
            DataRow row = ds.Tables[0].Rows[currentIndex];
           this.txtItemCode.Text=row[0].ToString();
            this.txtItemName.Text = row[1].ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtItemCode.Clear();
            txtItemName.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(DBHelper.ConnectionString());
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "delete from stock_db where code='" + this.txtItemCode.Text + "';";
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
                MessageBox.Show("Item Deleted Successfully");
                displayAllCatagories();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            } 
        }

        private void frmItems_Load(object sender, EventArgs e)
        {
            displayAllCatagories();
            txtItemCode.Clear();
            txtItemName.Clear();
        }
    }
}
