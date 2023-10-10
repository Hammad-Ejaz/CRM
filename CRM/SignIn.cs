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
using System.Text.RegularExpressions;
using Azure;
using Microsoft.VisualBasic.ApplicationServices;
using System.Reflection;

namespace CRM
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("INSERT INTO[user](name, gender, password, age, role) VALUES(@name, @gender, @password, @age, @role)", con);

                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@gender", textBox3.Text);
                    cmd.Parameters.AddWithValue("@password", textBox4.Text);
                    cmd.Parameters.AddWithValue("@age", int.Parse(textBox5.Text));
                    cmd.Parameters.AddWithValue("@role", textBox2.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully saved");

                }
                else
                {
                    MessageBox.Show("PLEASE ENTER THE DETAILS!!!!!!");
                }
            }
            catch
            {
                MessageBox.Show("There was an error in adding the data. Please check the information again.");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }
    }
}
