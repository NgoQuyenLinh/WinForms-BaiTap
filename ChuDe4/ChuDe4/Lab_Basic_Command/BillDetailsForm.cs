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

namespace Lab_Basic_Command
{
    public partial class BillDetailsForm : Form
    {
        string connectionString = @"Server=localhost\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";
        private int billID;

        public BillDetailsForm(int billID)
        {
            InitializeComponent();
            this.billID = billID;
        }
        private void LoadBillDetails()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "SELECT bd.ID, f.Name, f.Unit, bd.Quantity, f.Price, (bd.Quantity * f.Price) AS Amount " +
                           "FROM BillDetails bd, Food f, Bills b " +
                           "WHERE bd.FoodID = f.ID AND bd.InvoiceID = b.ID AND bd.InvoiceID = " + this.billID;
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable("BillDetails");
            da.Fill(dt);
            dgvBillDetails.DataSource = dt;
            sqlConnection.Close();
        }
    }
}