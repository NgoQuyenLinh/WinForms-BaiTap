using System;
using System.Data.SqlClient;
using System.Windows.Forms;

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
            cboStatus.SelectedIndex = 1;
            LoadTable();
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

        private void LoadTable()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "SELECT * FROM [Table]";
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            SqlDataReader da = sqlCommand.ExecuteReader();
            this.DisplayTable(da);
            sqlConnection.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên bàn!");
                return;
            }
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "INSERT INTO [Table] (Name, Status, Capacity)" + "VALUES " +
                "(@Name,@Status,@Capacity)";
            sqlCommand.CommandText = query;
            sqlCommand.Parameters.AddWithValue("@Name", txtName.Text);
            sqlCommand.Parameters.AddWithValue("@Status", cboStatus.SelectedIndex);
            sqlCommand.Parameters.AddWithValue("@Capacity", numberCapacity.Value);
            sqlConnection.Open();
            int numOfRowsAffected = sqlCommand.ExecuteNonQuery();
            if (numOfRowsAffected > 0)
            {
                MessageBox.Show("Thêm dữ liệu thành công!");
                LoadTable();
            }
            else
            {
                MessageBox.Show("Thêm dữ liệu thất bại!");
            }
            sqlConnection.Close();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa bàn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
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
            txtName.Text = dgvTable.SelectedRows[0].Cells["ColName"].Value.ToString();
            cboStatus.Text = dgvTable.SelectedRows[0].Cells["Status"].Value.ToString();
            numberCapacity.Text = dgvTable.SelectedRows[0].Cells["Capacity"].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "UPDATE [Table] SET Name = @Name, Status = @Status, Capacity = @Capacity WHERE ID = @ID";
            sqlCommand.CommandText = query;
            sqlCommand.Parameters.AddWithValue("@ID", txtID.Text);
            sqlCommand.Parameters.AddWithValue("@Name", txtName.Text);
            sqlCommand.Parameters.AddWithValue("@Status", cboStatus.SelectedIndex);
            sqlCommand.Parameters.AddWithValue("@Capacity", numberCapacity.Value);
            sqlConnection.Open();
            int numOfRowsAffected = sqlCommand.ExecuteNonQuery();
            if (numOfRowsAffected > 0)
            {
                MessageBox.Show("Cập nhật dữ liệu thành công!");
                LoadTable();
            }
            else
            {
                MessageBox.Show("Cập nhật dữ liệu thất bại!");
            }
        }

        private void xemDanhMucHoaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int billID = Convert.ToInt32(dgvTable.CurrentRow.Cells["ID"].Value);
            ListBills frm = new ListBills(billID);
            frm.ShowDialog();
        }

        private void xemNhâtKyHoaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BillLogForm frm = new BillLogForm();
            frm.ShowDialog();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
