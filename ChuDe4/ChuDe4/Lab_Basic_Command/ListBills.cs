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
    public partial class ListBills : Form
    {
        string connectString = @"Server=.\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";
        private int tableID;

        public ListBills(int tableID)
        {
            InitializeComponent();
            this.tableID = tableID;
        }

        private void ListBills_Load(object sender, EventArgs e)
        {
            LoadBillList();
        }

        private void LoadBillList()
        {
            SqlConnection conn = new SqlConnection(connectString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT ID, N'Hóa đơn ' + CAST(ID AS nvarchar(10)) + N' - ' + " +
                "CASE WHEN CheckoutDate IS NULL THEN N'chưa thanh toán' " +
                "ELSE CONVERT(nvarchar(20), CheckoutDate, 103) END AS DisplayText " +
                "FROM Bills WHERE TableID = @TableID ORDER BY ID";
            cmd.Parameters.AddWithValue("@TableID", tableID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            lbBills.DisplayMember = "DisplayText";
            lbBills.ValueMember = "ID";
            lbBills.DataSource = dt;  

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Bàn này chưa có hóa đơn nào");
            }
        }

       

        private void LoadBillDetail(int billID)
        {
            SqlConnection sqlConnection = new SqlConnection(connectString);
            SqlCommand sqlCommand1 = sqlConnection.CreateCommand();
            sqlCommand1.CommandText = "SELECT b.Name, t.Name AS TableName, a.FullName, b.CheckoutDate, b.Discount " +
                "FROM Bills b, [Table] t, Account a " +
                "WHERE b.TableID = t.ID AND b.Account = a.AccountName AND b.ID = @BillID";
            sqlCommand1.Parameters.AddWithValue("@BillID", billID);
            double discount = 0;
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand1.ExecuteReader();
            if (reader.Read())
            {
                lblBill.Text = reader["Name"].ToString();
                lblTable.Text = reader["TableName"].ToString();
                lblAccount.Text = reader["FullName"].ToString();
                if (reader["CheckoutDate"] == DBNull.Value)
                    lblDate.Text = "Chưa thanh toán";
                else
                    lblDate.Text = Convert.ToDateTime(reader["CheckoutDate"]).ToString("dd/MM/yyyy HH:mm");
                discount = Convert.ToDouble(reader["Discount"]);
            }
            reader.Close();
            sqlConnection.Close();
            SqlCommand sqlCommand2 = sqlConnection.CreateCommand();
            sqlCommand2.CommandText = "SELECT f.Name, f.Price, bd.Quantity, " + "f.Price * bd.Quantity AS Amount, " +
                "f.Price * bd.Quantity * @Discount AS DiscountAmount, " + "f.Price * bd.Quantity * (1 - @Discount) AS Total " +
                "FROM Food f, BillDetails bd " + "WHERE bd.FoodID = f.ID AND bd.InvoiceID = @BillID";
            sqlCommand2.Parameters.AddWithValue("@Discount", discount);
            sqlCommand2.Parameters.AddWithValue("@BillID", billID);
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand2);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvBills.DataSource = dt;
            lblAmount.Text = Convert.ToDecimal(dt.Compute("SUM(Amount)","")).ToString("N0")+ " VNĐ";
            lblDiscount.Text = Convert.ToDecimal(dt.Compute("SUM(DiscountAmount)", "")).ToString("N0") + " VNĐ";
            lblTotal.Text = Convert.ToDecimal(dt.Compute("SUM(Total)", "")).ToString("N0") + " VNĐ";
            sqlConnection.Close();
        }

        private void lbBills_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbBills.SelectedIndex < 0) return;
            DataRowView drv = (DataRowView)lbBills.SelectedItem;
            int billID = Convert.ToInt32(drv["ID"]);
            LoadBillDetail(billID);
        }

        private void dgvBills_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}