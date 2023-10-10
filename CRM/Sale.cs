using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
namespace CRM
{
    public partial class Sale : Form
    {
        public Sale()
        {
            InitializeComponent();
            string constr = @"Data Source=DESKTOP-2EKNDJ5\SQLEXPRESS;Initial Catalog=SE LAB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT sale_id FROM sales", con))
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
                    comboBox4.DataSource = dt;
                    comboBox4.DisplayMember = "sale_id";
                    comboBox4.ValueMember = "sale_id";
                }
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Con = Configuration.getInstance().getConnection();
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string query = "update [product] set commission_rate='" + textBox1.Text + "',sale_price='" + textBox2.Text + "',property_id='" + comboBox1.SelectedValue + "',client_id ='" + comboBox2.SelectedValue + "',employee_id='" + comboBox3.SelectedValue + "',sale_date='" + dateTimePicker1.Value + "' where id='" + comboBox1.SelectedValue + "'";
                SqlCommand q1 = new SqlCommand(query, Con);
                q1.ExecuteNonQuery();
                MessageBox.Show("Update Successfully");
                this.Refresh();
            }
            else { MessageBox.Show("Enter the proper field", "ERROR"); };
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String ConnectionStr = @"Data Source=DESKTOP-2EKNDJ5\SQLEXPRESS;Initial Catalog=SE LAB;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(ConnectionStr))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from sales", con))
                {

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    this.Refresh();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO[sales](property_id,client_id,employee_id,sale_price,sale_date,commission_rate)VALUES(@sale_id,@property_id,@client_id,@employee_id,@sale_price,@sale_date,@commission_rate)", con);
                cmd.Parameters.AddWithValue("@commission_rate", textBox1.Text);
                cmd.Parameters.AddWithValue("@sale_price", textBox2.Text);
                cmd.Parameters.AddWithValue("@property_id", comboBox1.SelectedValue);
                cmd.Parameters.AddWithValue("@client_id", comboBox2.SelectedValue);
                cmd.Parameters.AddWithValue("@employee_id", comboBox3.SelectedValue);
                cmd.Parameters.AddWithValue("@sale_date", dateTimePicker1.Value);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved");
                this.Refresh();
            }
            else
            {
                MessageBox.Show("PLEASE ENTER THE DETAILS!!!!!!");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var Con = Configuration.getInstance().getConnection();
            string query = "delete [sales] where sale_id='" + comboBox4.SelectedValue + "'";
            SqlCommand q1 = new SqlCommand(query, Con);
            q1.ExecuteNonQuery();
            MessageBox.Show("Deleted Successfully");
            this.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Mainform form = new Mainform();
            // this.Hide();
            //Mainform.show();
        }
    }
}
