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
    public partial class MainForm : Form
    {
        string connectionString = @"Server=.\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";
        public MainForm()
        {
            InitializeComponent();
        }

        private void dgvTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "SELECT ID, Name, Status, Capacity FROM [Table]";
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            SqlDataReader sqlData = sqlCommand.ExecuteReader();
            this.DisplayTable(sqlData);
        }
        private void DisplayTable(SqlDataReader reader)
        {
            dgvTable.Rows.Clear();
            while (reader.Read())
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvTable);
                row.Cells[0].Value = reader["ID"].ToString();
                row.Cells[1].Value = reader["Name"].ToString();
                row.Cells[2].Value = reader["Status"].ToString();
                if (reader["Status"].ToString() == "1")
                    row.Cells[2].Value = "Đang sử dụng";
                else 
                    row.Cells[2].Value = "Còn Trống";
                row.Cells[3].Value = reader["Capacity"].ToString();
                dgvTable.Rows.Add(row);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO [Table] (Name, Status, Capacity)" + "VALUES " +
                "(N'" + "" + "'," + 0 + "," + 4 + ")";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "DELETE FROM [Table] WHERE ID = " + dgvTable.SelectedRows[0].Cells["ID"].Value.ToString();
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            int numOfRowsAffected = sqlCommand.ExecuteNonQuery();
            if (numOfRowsAffected > 0)
            {
                MessageBox.Show("Xóa dữ liệu thành công!");
                dgvTable.Rows.RemoveAt(dgvTable.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Xóa dữ liệu thất bại!");
            }
            sqlConnection.Close();
        }

        private void xoaBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDelete.PerformClick();
        }

        private void gbTable_Enter(object sender, EventArgs e)
        {

        }
        private void dgvTable_Click(object sender, EventArgs e)
        {
            txtID.Text = dgvTable.SelectedRows[0].Cells["ID"].Value.ToString();
            txtName.Text = dgvTable.SelectedRows[0].Cells["Name"].Value.ToString();
            cboStatus.Text = dgvTable.SelectedRows[0].Cells["Status"].Value.ToString();
            numberCapacity.Text = dgvTable.SelectedRows[0].Cells["Capacity"].Value.ToString();
        }
    }
}
