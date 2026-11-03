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
    public partial class AddAccountForm : Form
    {
        public AddAccountForm()
        {
            InitializeComponent();
        }

        private void AddAccount_Load(object sender, EventArgs e)
        {
            LoadRole();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectString = @"Server=.\SQLEXPRESS; DATABASE = RestaurantManagement; Integrated Security = True";
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
            string connectString = @"Server=.\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "SELECT ID, RoleName FROM Role";
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable("Role");
            da.Fill(dt);
            dgvRole.DataSource = dt;
            sqlConnection.Close();
        }

       
    }
}
