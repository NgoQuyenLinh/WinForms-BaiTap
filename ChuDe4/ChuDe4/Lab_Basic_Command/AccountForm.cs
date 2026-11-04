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
    public partial class AccountForm : Form
    {
        string connectString = @"Server=.\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";
        private string accountName;
        public AccountForm()
        {
            InitializeComponent();
        }
        public AccountForm(string accountName)
        {
            InitializeComponent();
            this.accountName = accountName;
        }

        private void AddAccount_Load(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(accountName))
            {
                LoadAccount();
            }
            LoadRole();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query1 = "INSERT INTO Account ([AccountName], [Password], [FullName], [Email], [Tell], [DateCreated])VALUES " +
                "(N'"+txtAccountName.Text+"', N'"+txtPassword.Text+"', " +
                "N'"+txtFullName.Text+"', N'"+txtEmail.Text+"', N'"+mtxtTell.Text+ "', GETDATE())";
            sqlCommand.CommandText = query1;
            sqlConnection.Open();
            int numOfRowsAffected = sqlCommand.ExecuteNonQuery();
            if(numOfRowsAffected == 1)
            {
                foreach(DataGridViewRow row in dgvRole.Rows)
                {
                    if (row.IsNewRow) continue;
                    string status = row.Cells["Actived"].Value?.ToString();
                    if (!string.IsNullOrEmpty(status))
                    {
                        int roleID = Convert.ToInt32(row.Cells["ID"].Value);
                        int actived = (status == "Đã kích hoạt") ? 1 : 0;
                        string notes = row.Cells["Notes"].Value?.ToString() ?? "";
                        string query2 = "INSERT INTO RoleAccount ([AccountName], [RoleID], [Actived], [Notes]) VALUES " +
                            "(N'" + txtAccountName.Text + "', " + roleID + ", " + actived + ", N'" + notes + "')";
                        sqlCommand.CommandText = query2;
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Thêm tài khoản thành công");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại");
            }
            sqlConnection.Close();
        }
        private void LoadRole()
        {
            SqlConnection sqlConnection = new SqlConnection(connectString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query1 = "SELECT ID, RoleName FROM Role";
            sqlCommand.CommandText = query1;
            sqlConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable("Role");
            da.Fill(dt);
            dgvRole.DataSource = dt;
            if(!string.IsNullOrEmpty(this.accountName))
            {
                string query2 = "SELECT RoleID, Actived, Notes FROM RoleAccount WHERE AccountName = N'" + this.accountName + "'";
                sqlCommand.CommandText = query2;
                SqlDataAdapter da2 = new SqlDataAdapter(sqlCommand);
                DataTable dt2 = new DataTable("RoleAccount");
                da2.Fill(dt2);
                foreach (DataGridViewRow row in dgvRole.Rows)
                {
                    if (row.IsNewRow) continue;
                    int roleID = Convert.ToInt32(row.Cells["ID"].Value);
                    foreach (DataRow raRow in dt2.Rows)
                    {
                        if (Convert.ToInt32(raRow["RoleID"]) == roleID)
                        {
                            row.Cells["Actived"].Value = (Convert.ToInt32(raRow["Actived"]) == 1) ?"Kích hoạt" : "Chưa kích hoạt";
                            row.Cells["Notes"].Value = raRow["Notes"].ToString();
                            break;
                        }
                    }
                }
                da2.Dispose();
            }
            sqlConnection.Close();
            sqlConnection.Dispose();

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn làm mới không? Dữ liệu chưa lưu sẽ bị mất.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                txtAccountName.Text = "";
                txtPassword.Text = "";
                txtFullName.Text = "";
                txtEmail.Text = "";
                mtxtTell.Text = "";
                foreach (DataGridViewRow row in dgvRole.Rows)
                {
                    if (row.IsNewRow) continue;
                    row.Cells["Actived"].Value = null;
                    row.Cells["Notes"].Value = null;
                }
            }
        }
        private void LoadAccount()
        {
            if(string.IsNullOrEmpty(accountName)) return;
            SqlConnection sqlConnection = new SqlConnection(connectString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "SELECT * FROM Account WHERE AccountName = N'" + this.accountName + "'";
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand); 
            DataTable dt = new DataTable("Account");
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtAccountName.Text = row["AccountName"].ToString();
                txtAccountName.ReadOnly = true;
                txtPassword.Text = row["Password"].ToString();
                txtFullName.Text = row["FullName"].ToString();
                txtEmail.Text = row["Email"].ToString();
                mtxtTell.Text = row["Tell"].ToString();
                btnAdd.Enabled = false;
            }

            sqlConnection.Close();
            sqlConnection.Dispose();
            da.Dispose();

        }
    }
}
