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
using System.Runtime.CompilerServices;

namespace Lab_Basic_Command
{
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=.\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            string query = "SELECT ID, Name, Type FROM CATEGORY";
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            SqlDataReader sqlData = sqlCommand.ExecuteReader();
            this.DisplayCategory(sqlData);
            sqlConnection.Close();
        }

        private void DisplayCategory(SqlDataReader reader)
        {
            lvCategory.Items.Clear();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["ID"].ToString());
                lvCategory.Items.Add(item);
                item.SubItems.Add(reader["Name"].ToString());
                item.SubItems.Add(reader["Type"].ToString());
            }
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=.\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO CATEGORY (Name, [Type])" + "VALUES (N'" + txtName.Text + "'," + txtType.Text + ")";
            sqlConnection.Open();
            int numOfRowsAffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            if (numOfRowsAffected == 1)
            {
                MessageBox.Show("Thêm món ăn thành công");
                btnLoad.PerformClick();
                txtName.Text="";
                txtType.Text="";

            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại");
            }
        }

        private void lvCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvCategory_Click(object sender, EventArgs e)
        {
            ListViewItem item  = lvCategory.SelectedItems[0];

            txtID.Text= item.Text;
            txtName.Text = item.SubItems[1].Text;
            txtType.Text = item.SubItems[2].Text;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
        string connectString = @"Server=.\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";
        SqlConnection sqlConnection = new SqlConnection(connectString);
        SqlCommand sqlCommand = sqlConnection.CreateCommand();
         sqlCommand.CommandText = "UPDATE CATEGORY SET Name = N'" + txtName.Text + "', [Type] = " + txtType.Text + " WHERE ID = " + txtID.Text;
            sqlConnection.Open();
            int numOfRowsAffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            if(numOfRowsAffected == 1)
            {
                ListViewItem item = lvCategory.SelectedItems[0];
                txtID.Text= item.Text;
                txtName.Text = item.SubItems[1].Text;
                txtType.Text = item.SubItems[2].Text;
                btnLoad.PerformClick();
                txtID.Text = "";
                txtName.Text = "";
                txtType.Text = "";
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                MessageBox.Show("Cập nhật món ăn thành công");
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string connectString = @"Server=.\SQLEXPRESS; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectString);
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "DELETE FROM CATEGORY WHERE ID = " + txtID.Text;
            sqlConnection.Open();
            int numOfRowsAffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            if (numOfRowsAffected == 1)
            {
                ListViewItem item = lvCategory.SelectedItems[0];
                txtID.Text = item.Text;
                txtName.Text = item.SubItems[1].Text;
                txtType.Text = item.SubItems[2].Text;
                btnLoad.PerformClick();
                txtID.Text = "";
                txtName.Text = "";
                txtType.Text = "";
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                MessageBox.Show("Xóa món ăn thành công");
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại");
            }
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if(lvCategory.SelectedItems.Count > 0)
            {
                btnDelete.PerformClick();
            }
        }

        private void tsmViewFood_Click(object sender, EventArgs e)
        {
            if(txtID.Text != "")
            {
                FoodForm foodForm = new FoodForm();
                foodForm.Show(this);
                foodForm.LoadFood(Convert.ToInt32(txtID.Text));

            }
        }
    }
}
