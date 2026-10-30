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
    public partial class FoodForm : Form
    {
        public FoodForm()
        {
            InitializeComponent();
        }
        public void LoadFood(int CategoryID)
        {
            string connectionString = @"Server=.\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "SELECT NAME FROM CATEGORY WHERE ID = " + CategoryID;
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            string catName = sqlCommand.ExecuteScalar().ToString();
            this.Text= "Danh sách các món ăn thuộc nhóm: " + catName;
            sqlCommand.CommandText = "SELECT * FROM Food WHERE FoodCategoryID = " + CategoryID;
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable("Food");
            da.Fill(dt);
            dgvFood.DataSource = dt;
            sqlConnection.Close();
            sqlConnection.Dispose();
            da.Dispose();
        }

        private void dgvFood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgvFood.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng dữ liệu để xóa!");
                return;
            }
            string connectionString = @"Server=.\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "DELETE FROM Food WHERE ID = " + dgvFood.SelectedRows[0].Cells["ID"].Value.ToString();
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            int numOfRowsAffected = sqlCommand.ExecuteNonQuery();
            if (numOfRowsAffected ==1)
            {
                MessageBox.Show("Xóa dữ liệu thành công!");
                dgvFood.Rows.RemoveAt(dgvFood.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Xóa dữ liệu thất bại!");
            }
            sqlConnection.Close();
            sqlConnection.Dispose();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("Cập nhật dữ liệu thành công!");

        }

       
    }
}
