using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab_Basic_Command
{
    public partial class AccountManagerForm : Form
    {
        string connectString = @"Server=.\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";
        public AccountManagerForm()
        {
            InitializeComponent();
        }

        private void AccountManagerForm_Load(object sender, EventArgs e)
        {
            SqlConnection sqlconnection = new SqlConnection(connectString);
            SqlCommand sqlcommand = sqlconnection.CreateCommand();
            string query = "SELECT AccountName, FullName, Email, Tell, DateCreated FROM Account ";
            sqlcommand.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(sqlcommand);
            DataTable dt = new DataTable("Account");
            da.Fill(dt);
            dgvAccount.DataSource = dt;
            sqlconnection.Close();
            cboRole.Text = "Tất cả";
            cboActived.Text = "Tất cả";
        }

        private void dgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAccount();
        }
        private void LoadAccount()
        {
            SqlConnection sqlConnection = new SqlConnection(connectString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "SELECT AccountName, FullName, Email, Tell, DateCreated FROM Account ";
            if (cboRole.SelectedIndex > 0 || cboActived.SelectedIndex > 0)
            {
                query += "WHERE AccountName IN (" +
                         "SELECT ra.AccountName FROM RoleAccount ra, Role r " +
                         "WHERE ra.RoleID = r.ID ";

                if (cboRole.SelectedIndex > 0)
                {
                    query += "AND r.RoleName = @RoleName ";
                    sqlCommand.Parameters.AddWithValue("@RoleName", cboRole.Text);
                }
                if (cboActived.SelectedIndex > 0)
                {
                    query += "AND ra.Actived = @Actived ";
                    sqlCommand.Parameters.AddWithValue("@Actived", cboActived.SelectedIndex == 1);
                }
                query += ")";
            }
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable("Account");
            da.Fill(dt);
            dgvAccount.DataSource = dt;
            sqlConnection.Dispose();    
            da.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AccountForm frm = new AccountForm();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                LoadAccount();
            }
        }

        private void xemDanhSachVaiTroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string accountName = dgvAccount.CurrentRow.Cells["AccountName"].Value.ToString();
            RoleForm frm = new RoleForm(accountName);
            frm.ShowDialog();
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string accountName = dgvAccount.CurrentRow.Cells["AccountName"].Value.ToString();
            AccountForm frm = new AccountForm(accountName);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadAccount();
            }
        }

        private void xoaTaiKhoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return;
            }
            SqlConnection sqlConnection = new SqlConnection(connectString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "UPDATE RoleAccount SET Actived = 0 WHERE AccountName =@AccountName ";
            sqlCommand.Parameters.AddWithValue("@AccountName", dgvAccount.CurrentRow.Cells["AccountName"].Value.ToString());
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            int numOfRowsAffected = sqlCommand.ExecuteNonQuery();
            if (numOfRowsAffected > 0) {
                MessageBox.Show("Xóa tài khoản thành công");
                LoadAccount();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại");
            }
            sqlConnection.Close();
        }
    }
}