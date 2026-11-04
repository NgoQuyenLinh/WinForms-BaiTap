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
    public partial class RoleForm : Form
    {
        private string accountName;
        public RoleForm(string accountName)
        {
            InitializeComponent();
            this.accountName= accountName;
        }
        private void LoadRole()
        {
            string connectString = @"Server=.\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "SELECT r.ID, r.RoleName, ra.Actived, ra.Notes " +
                "FROM Role r, Account a, RoleAccount ra " +
                "WHERE a.AccountName = ra.AccountName AND ra.RoleID = r.ID AND a.AccountName = '" + this.accountName + "'";
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable("RoleAccount");
            da.Fill(dt);
            dgvRole.DataSource = dt;
            sqlConnection.Close();
            sqlConnection.Dispose();
        }
        private void GetFullName()
        {
            string connectString = @"Server=.\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "SELECT FullName FROM Account WHERE AccountName = '" + this.accountName + "'";
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            string fullName = sqlCommand.ExecuteScalar().ToString();
            lblAccount.Text = accountName + " - " + fullName;
            sqlConnection.Close();
            sqlConnection.Dispose();
        }

        private void RoleForm_Load(object sender, EventArgs e)
        {
            LoadRole();
            GetFullName();
        }

        private void dgvRole_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
