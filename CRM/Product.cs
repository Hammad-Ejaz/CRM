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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace CRM
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
            string constr = @"Data Source=DESKTOP-2EKNDJ5\SQLEXPRESS;Initial Catalog=SE LAB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT id FROM product", con))
                {
                    //Fill the DataTable with records from Table.
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    //Insert the Default Item to DataTable.
                    DataRow row = dt.NewRow();
                    //row[0] = 0;
                    //row[0] = "Please select";
                    dt.Rows.InsertAt(row, 0);

                    //Assign DataTable as DataSource.
                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "id";
                    comboBox1.ValueMember = "id";
                }
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {

        }




        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO[product](operation,name,description,price,createdAt)VALUES(@name , @operation, @description , @price , @createdAt)", con);
                cmd.Parameters.AddWithValue("@name", textBox5.Text);
                cmd.Parameters.AddWithValue("@operation", textBox1.Text);
                cmd.Parameters.AddWithValue("@description", textBox2.Text);
                cmd.Parameters.AddWithValue("@price", int.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@createdAt", textBox4.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved");
                this.Refresh();
            }
            else
            {
                MessageBox.Show("PLEASE ENTER THE DETAILS!!!!!!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String ConnectionStr = @"Data Source=DESKTOP-2EKNDJ5\SQLEXPRESS;Initial Catalog=SE LAB;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(ConnectionStr))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from product", con))
                {

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    this.Refresh();
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var Con = Configuration.getInstance().getConnection();


            string query = "delete [product] where id='" + comboBox1.SelectedValue + "'";
            SqlCommand q1 = new SqlCommand(query, Con);
            q1.ExecuteNonQuery();
            MessageBox.Show("Deleted Successfully");
            this.Refresh();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var Con = Configuration.getInstance().getConnection();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                string query = "update [product] set name='" + textBox5.Text + "',operation='" + textBox1.Text + "',description='" + textBox2.Text + "',price ='" + textBox3.Text + "',createdAt='" + textBox4.Text + "' where id='" + comboBox1.SelectedValue + "'";
                SqlCommand q1 = new SqlCommand(query, Con);
                q1.ExecuteNonQuery();
                MessageBox.Show("Update Successfully");
                this.Refresh();
            }
            else { MessageBox.Show("Enter the proper field", "ERROR"); };
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainFormcs form = new MainFormcs();
            this.Hide();
            form.Show();
        }
    }
}


