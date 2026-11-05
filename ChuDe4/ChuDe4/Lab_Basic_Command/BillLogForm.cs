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
    public partial class BillLogForm : Form
    {
       string connectString = @"Server=.\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";

        public BillLogForm()
        {
            InitializeComponent();
        }

        private void BillLogForm_Load(object sender, EventArgs e)
        {
            LoadBillLog();
        }

        private void LoadBillLog()
        {
            SqlConnection sqlConnection = new SqlConnection(connectString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText =
                "SELECT b.ID, b.Name AS BillName, t.Name AS TableName, a.FullName AS StaffName, " +
                "b.CheckoutDate, b.Amount, " +
                "b.Amount * ISNULL(b.Discount, 0) AS DiscountAmount, " +
                "b.Amount * ISNULL(b.Tax, 0) AS TaxAmount, " +
                "b.Amount - b.Amount * ISNULL(b.Discount, 0) + b.Amount * ISNULL(b.Tax, 0) AS TotalPay " +
                "FROM Bills b, [Table] t, Account a " +
                "WHERE b.TableID = t.ID AND b.Account = a.AccountName " +
                "ORDER BY b.ID DESC";

            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvBills.DataSource = dt;

            lblTotalBill.Text = dt.Rows.Count.ToString("N0");
            if (dt.Rows.Count > 0)
            {
                lblRevenue.Text = Convert.ToDecimal(dt.Compute("SUM(Amount)", "")).ToString("N0") + " VNĐ";
                lblTotalDiscount.Text = Convert.ToDecimal(dt.Compute("SUM(DiscountAmount)", "")).ToString("N0") + " VNĐ";
                lbltotalTax.Text = Convert.ToDecimal(dt.Compute("SUM(TaxAmount)", "")).ToString("N0") + " VNĐ";
            }
            else
            {
                lblRevenue.Text = "0 VNĐ";
                lblTotalDiscount.Text = "0 VNĐ";
                lbltotalTax.Text = "0 VNĐ";
            }
            sqlConnection.Dispose();
            da.Dispose();
        }

        private void dgvBills_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
