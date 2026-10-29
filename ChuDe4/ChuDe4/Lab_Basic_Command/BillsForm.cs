using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_Basic_Command
{
    public partial class BillsForm : Form
    {
        string connectionString = @"Server=.\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";
        public BillsForm()
        {
            InitializeComponent();
        }

        private void BillsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string fromDate = dtpFrom.Value.ToString("yyyy-MM-dd 00:00:00");
            string toDate = dtpTo.Value.ToString("yyyy-MM-dd 23:59:59");
            string query = "SELECT BillID, BillName, CheckoutDate, Amount, Discount, (Amount - Discount) AS FinalTotal " +
                   "FROM Bill " +
                   "WHERE CheckoutDate >= '" + fromDate + "' AND CheckoutDate <= '" + toDate + "'";
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable("Bills");
            da.Fill(dt);
            dgvBills.DataSource = dt;
            int totalAmount = 0;
            int totalDiscount = 0;
            int finalTotal = 0;
            foreach(DataRow dr in dt.Rows)
            {
                totalAmount += Convert.ToInt32(dr["Amount"]);
                totalDiscount += Convert.ToInt32(dr["Discount"]);
                finalTotal += Convert.ToInt32(dr["FinalTotal"]);
            }
            lblFinalTotal.Text = finalTotal.ToString() + " VNĐ";
            lblDiscount.Text = totalDiscount.ToString() + " VNĐ";
            lblTotalAmount.Text = totalAmount.ToString() + " VNĐ";
            sqlConnection.Close();
        }
    }
}
