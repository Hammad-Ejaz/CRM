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

namespace CRM
{
    public partial class lead : Form
    {
        public lead()
        {
            InitializeComponent();
            string constr = @"Data Source=DESKTOP-2EKNDJ5\SQLEXPRESS;Initial Catalog=SE LAB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT employee_id FROM employees", con))
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
                    comboBox2.DataSource = dt;
                    comboBox2.DisplayMember = "employee_id";
                    comboBox2.ValueMember = "employee_id";
                }
            }

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT lead_id FROM lead", con))
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
                    comboBox1.DisplayMember = "lead_id";
                    comboBox1.ValueMember = "lead_id";
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO[lead](email,name,phone_number,assigned_to,status)VALUES(@email,@name,@phone_number,@status,@assigned_to)", con);
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@email", textBox2.Text);
                cmd.Parameters.AddWithValue("@phone_number", textBox3.Text);
                cmd.Parameters.AddWithValue("@status", textBox4.Text);
                cmd.Parameters.AddWithValue("assigned_to", comboBox2.SelectedValue);

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
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                string query = "update [lead] set name='" + textBox1.Text + "',phone_number='" + textBox3.Text + "',email='" + textBox2.Text + "',status ='" + textBox4.Text + "',assigned_to='" + comboBox2.SelectedValue + "' where lead_id='" + comboBox1.SelectedValue + "'";
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
            string query = "delete [lead] where lead_id='" + comboBox1.SelectedValue + "'";
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
                using (SqlCommand cmd = new SqlCommand("Select * from lead", con))
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
            MainFormcs form = new MainFormcs();
            this.Hide();
            form.Show();
        }
    }
}
