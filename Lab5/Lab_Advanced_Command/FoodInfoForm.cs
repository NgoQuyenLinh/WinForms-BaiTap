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

namespace Lab_Advanced_Command
{
    public partial class FoodInfoForm : Form
    {
        public bool AddCategory { get; set; } = false;
        string connectString = @"server=.\SQLEXPRESS; database= RestaurantManagement; Integrated Security=true;";
        public FoodInfoForm()
        {
            InitializeComponent();
        }

        private void FoodInfoForm_Load(object sender, EventArgs e)
        {
            this.InitValues();
        }
        private void InitValues()
        {
            SqlConnection conn = new SqlConnection(connectString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT ID,Name FROM Category";

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            conn.Open();

            adapter.Fill(ds, "Category");
            cbbCatName.DataSource = ds.Tables["Category"];
            cbbCatName.DisplayMember = "Name";
            cbbCatName.ValueMember = "ID";

            conn.Close();
            conn.Dispose();
        }
        private void ResetTexts()
        {
            txtFoodID.ResetText();
            txtName.ResetText();
            txtUnit.ResetText();
            numPrice.ResetText();
            txtNotes.ResetText();
            cbbCatName.ResetText();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXECUTE InsertFood @id OUTPUT, @name,@unit,@foodCategoryID,@price,@notes";

                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@unit", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@foodCategoryID", SqlDbType.Int);
                cmd.Parameters.Add("@price", SqlDbType.Int);
                cmd.Parameters.Add("@notes", SqlDbType.NVarChar, 3000);

                cmd.Parameters["@id"].Direction = ParameterDirection.Output;

                cmd.Parameters["@name"].Value = txtName.Text;
                cmd.Parameters["@unit"].Value = txtUnit.Text;
                cmd.Parameters["@foodCategoryID"].Value = cbbCatName.SelectedValue;
                cmd.Parameters["@price"].Value = numPrice.Value;
                cmd.Parameters["@notes"].Value = txtNotes.Text;

                conn.Open();
                int numOfRowsAffected = cmd.ExecuteNonQuery();

                if (numOfRowsAffected > 0)
                {
                    string foodID = cmd.Parameters["@id"].Value.ToString();
                    MessageBox.Show("Successfully adding new food, Food ID = " + foodID, "Message");
                    this.ResetTexts();
                }
                else
                {
                    MessageBox.Show("Adding food failed", "Message");
                }
                conn.Close();
                conn.Dispose();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
        }
        public void DisplayFoodInfo(DataRowView rowView)
        {
            try
            {
                txtFoodID.Text = rowView["ID"].ToString();
                txtName.Text = rowView["Name"].ToString();
                txtUnit.Text = rowView["Unit"].ToString();
                txtNotes.Text = rowView["Notes"].ToString();
                numPrice.Text = rowView["Price"].ToString();

                cbbCatName.SelectedIndex = -1;

                for (int i = 0; i < cbbCatName.Items.Count; i++)
                {
                    DataRowView cat = cbbCatName.Items[i] as DataRowView;
                    if (cat["ID"].ToString() == rowView["FoodCategoryID"].ToString())
                    {
                        cbbCatName.SelectedIndex = i;
                        break;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
                this.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connectString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EXECUTE UpdateFood @id, @name,@unit,@foodCategoryID,@price,@notes";

                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@unit", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@foodCategoryID", SqlDbType.Int);
                cmd.Parameters.Add("@price", SqlDbType.Int);
                cmd.Parameters.Add("@notes", SqlDbType.NVarChar, 3000);

                cmd.Parameters["@id"].Value = txtFoodID.Text;
                cmd.Parameters["@name"].Value = txtName.Text;
                cmd.Parameters["@unit"].Value = txtUnit.Text;
                cmd.Parameters["@foodCategoryID"].Value = cbbCatName.SelectedValue;
                cmd.Parameters["@price"].Value = numPrice.Value;
                cmd.Parameters["@notes"].Value = txtNotes.Text;

                conn.Open();
                int numOfRowsAffected = cmd.ExecuteNonQuery();

                if (numOfRowsAffected > 0)
                {
                    MessageBox.Show("Succesfully update food", "Message");
                    this.ResetTexts();
                }
                else
                {
                    MessageBox.Show("Updating food faild");
                }
                conn.Close();
                conn.Dispose();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            using (AddNewCatFoodForm catFoodForm = new AddNewCatFoodForm())
            {
                if (catFoodForm.ShowDialog(this) == DialogResult.OK)
                {
                    this.InitValues();
                    AddCategory = true;
                }
            }
        }
    }
}
