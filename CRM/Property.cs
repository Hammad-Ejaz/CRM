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
namespace CRM
{
    public partial class Property : Form
    {
        public Property()
        {
            InitializeComponent();
            string constr = @"Data Source=DESKTOP-2EKNDJ5\SQLEXPRESS;Initial Catalog=SE LAB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT property_id FROM properties", con))
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
                    comboBox1.DisplayMember = "peoperty_id";
                    comboBox1.ValueMember = "property_id";
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO[properties](address,city,state,zip_code,property_type,bedrooms,bathrooms,square_feet,price,status,description)VALUES(@address,@city,@state,@zip_code,@property_type,@bedrooms,@bathrooms,@square_feet,@price,@status,@description)", con);
                cmd.Parameters.AddWithValue("@address", textBox1.Text);
                cmd.Parameters.AddWithValue("@city", textBox2.Text);
                cmd.Parameters.AddWithValue("@state", textBox3.Text);
                cmd.Parameters.AddWithValue("@zip_Code", textBox4.Text);
                cmd.Parameters.AddWithValue("@property_type", textBox5.Text);
                cmd.Parameters.AddWithValue("@bedrooms", int.Parse(textBox6.Text));
                cmd.Parameters.AddWithValue("@bathrooms", int.Parse(textBox10.Text));
                cmd.Parameters.AddWithValue("@square_feet", int.Parse(textBox9.Text));
                cmd.Parameters.AddWithValue("@price", textBox8.Text);
                cmd.Parameters.AddWithValue("@status", textBox7.Text);
                cmd.Parameters.AddWithValue("@description", textBox11.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved");
                this.Refresh();
            }
            else
            {
                MessageBox.Show("PLEASE ENTER THE DETAILS!!!!!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Con = Configuration.getInstance().getConnection();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "")
            {
                string query = "update [properties] set property_type='" + textBox2.Text + "',state ='" + textBox3.Text + "',zip_code='" + textBox4.Text + "',bedrooms='" + textBox6.Text + "',bathrooms='" + textBox10.Text + "',square_feet='" + textBox9.Text + "',price='" + textBox8.Text + "',status='" + textBox7.Text + "',description='" + textBox11.Text + "',address='" + textBox1.Text + "',city='" + textBox2.Text + "' where property_id='" + comboBox1.SelectedValue + "'";
                SqlCommand q1 = new SqlCommand(query, Con);
                q1.ExecuteNonQuery();
                MessageBox.Show("Update Successfully");
                this.Refresh();
            }
            else { MessageBox.Show("Enter the proper field", "ERROR"); };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var Con = Configuration.getInstance().getConnection();


            string query = "delete [properties] where property_id='" + comboBox1.SelectedValue + "'";
            SqlCommand q1 = new SqlCommand(query, Con);
            q1.ExecuteNonQuery();
            MessageBox.Show("Deleted Successfully");
            this.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String ConnectionStr = @"Data Source=DESKTOP-2EKNDJ5\SQLEXPRESS;Initial Catalog=SE LAB;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(ConnectionStr))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from properties", con))
                {

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    this.Refresh();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Mainform form = new Mainform();
            // this.Hide();
            //Mainform.show();
        }
    }

}
