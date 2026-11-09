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
using System.Xml.XPath;

namespace Lab_Advanced_Command
{
   
    public partial class FoodForm : Form
    {
        private DataTable foodTable;
        string connectString = @"server=.\SQLEXPRESS; database= RestaurantManagement; Integrated Security=true;";

        public FoodForm()
        {
            InitializeComponent();
        }

        private void dgvFoodList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FoodForm_Load(object sender, EventArgs e)
        {
            LoadCategory();
        }

        private void LoadCategory()
        {
            SqlConnection conn = new SqlConnection(connectString);
            SqlCommand cmd = conn.CreateCommand();
            string query = "SELECT ID,NAME FROM Category";
            cmd.CommandText = query;
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();
            conn.Dispose();
            cbbCategory.DataSource = dt;
            cbbCategory.DisplayMember = "NAME";
            cbbCategory.ValueMember = "ID";


        }

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCategory.SelectedIndex == -1) return;
            SqlConnection conn = new SqlConnection(connectString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Food WHERE FoodCategoryID = @categoryId";
            cmd.Parameters.Add("@categoryID", SqlDbType.Int);
            if(cbbCategory.SelectedValue is DataRowView)
            {
                DataRowView rowView =cbbCategory.SelectedValue as DataRowView;
                cmd.Parameters["@categoryID"].Value = rowView["ID"];
            }
            else
            {
                cmd.Parameters["@categoryID"].Value = cbbCategory.SelectedValue;
            }
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            foodTable = new DataTable();
            adapter.Fill(foodTable);
            conn.Close();
            conn.Dispose();

            dgvFoodList.DataSource = foodTable;
            lblQuantity.Text = foodTable.Rows.Count.ToString();
            lblCatName.Text = cbbCategory.Text;
        }

        private void tsmCalculateQuantity_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT @numSaleFood = sum(quantity) FROM BillDetails WHERE FoodID = @foodID";
            if(dgvFoodList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvFoodList.SelectedRows[0];  
                DataRowView rowView = selectedRow.DataBoundItem as DataRowView;
                cmd.Parameters.Add("@foodID", SqlDbType.Int);
                cmd.Parameters["@foodID"].Value = rowView["ID"];

                cmd.Parameters.Add("@numSaleFood", SqlDbType.Int);
                cmd.Parameters["@numSaleFood"].Direction = ParameterDirection.Output;

                conn.Open();
                cmd.ExecuteNonQuery();

                string result = cmd.Parameters["@numSaleFood"].Value.ToString();
                MessageBox.Show("Tổng số lượng món " + rowView["Name"] + " đã bán là: " + result + " " + rowView["Unit"]);
                
                conn.Close();
            }
            cmd.Dispose();
            conn.Dispose();
        }

        private void tsmAddFood_Click(object sender, EventArgs e)
        {
            FoodInfoForm foodForm = new FoodInfoForm();
            foodForm.FormClosed += new FormClosedEventHandler(foodForm_FormClosed);
            foodForm.Show(this);
        }
        
        void foodForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            int index = cbbCategory.SelectedIndex;
            cbbCategory.SelectedIndex = -1;
            cbbCategory.SelectedIndex = index;
        }
        private void tsmUpdateFood_Click(object sender, EventArgs e)
        {
            if (dgvFoodList.SelectedRows.Count >0)
            {
                DataGridViewRow selectRow = dgvFoodList.SelectedRows[0];
                DataRowView rowView = selectRow.DataBoundItem as DataRowView;

                FoodInfoForm foodForm = new FoodInfoForm();
                foodForm.FormClosed += new FormClosedEventHandler(foodForm_FormClosed);
                foodForm.Show(this);
                foodForm.DisplayFoodInfo(rowView);
            }
        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            if (foodTable == null) return;

            string filterExpression = "Name LIKE '%" + txtSearchByName.Text + "%'";
            string sortExpression = "Price DESC";
            DataViewRowState rowStateFilter = DataViewRowState.OriginalRows;

            DataView foodView = new DataView(foodTable, filterExpression, sortExpression, rowStateFilter);

            dgvFoodList.DataSource = foodView;
        }
    }
}
