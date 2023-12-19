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
    public partial class Task : Form
    {
        public Task()
        {
            InitializeComponent();
            string constr = @"Data Source=DESKTOP-2EKNDJ5\SQLEXPRESS;Initial Catalog=SE LAB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT task_id FROM tasks", con))
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
                    comboBox2.DisplayMember = "task_id";
                    comboBox2.ValueMember = "task_id";
                }
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
                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "employee_id";
                    comboBox1.ValueMember = "employee_id";
                }
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO[tasks](description,due_date,status,assigned_to)VALUES(@description,@due_date,@status,@assigned_to)", con);
                cmd.Parameters.AddWithValue("@description", textBox1.Text);
                cmd.Parameters.AddWithValue("@status", textBox2.Text);
                cmd.Parameters.AddWithValue("@due_date", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@assigned_to", comboBox1.SelectedValue);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved");
                this.Refresh();
            }
            else
            {
                MessageBox.Show("PLEASE ENTER THE DETAILS!!!!!!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Con = Configuration.getInstance().getConnection();
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string query = "update [product] set description='" + textBox1.Text + "',status='" + textBox2.Text + "',due_date='" + dateTimePicker1.Text + "',assigned_to='" + comboBox1.SelectedValue + "' where task_id='" + comboBox2.SelectedValue + "'";
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


            string query = "delete [tasks] where task_id='" + comboBox2.SelectedValue + "'";
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
                using (SqlCommand cmd = new SqlCommand("Select * from tasks", con))
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
