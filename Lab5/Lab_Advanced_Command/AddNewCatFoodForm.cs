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
namespace Lab_Advanced_Command
{
    public partial class AddNewCatFoodForm : Form
    {
        public AddNewCatFoodForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectString = @"Server=.\SQLEXPRESS; database=RestaurantManagement; Integrated Security = True;";
            SqlConnection conn = new SqlConnection(connectString);
            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "EXEC InsertCategory @Name, @Type";
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar,1000);
            cmd.Parameters.Add("@Type", SqlDbType.Int);

            cmd.Parameters["@Name"].Value = txtCatName.Text;
            cmd.Parameters["@Type"].Value = txtType.Text;

            conn.Open();
            int intOfRowsAffected = cmd.ExecuteNonQuery();
            if(intOfRowsAffected == 1)
            {
                MessageBox.Show("Successfully adding new category food", "Message");
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Adding category food failed","Message");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
