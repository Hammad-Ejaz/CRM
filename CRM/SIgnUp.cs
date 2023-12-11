using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace CRM
{
    public partial class SIgnUp : Form
    {
        public SIgnUp()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" && textBox4.Text == "")
            {
                MessageBox.Show("Enter teh details!!!!");
            }
            else
            {
                int count = 0;
                string name = textBox1.Text;
                string password = textBox4.Text;
                var con = Configuration.getInstance().getConnection();
                bool credentialsMatch = false;
                SqlCommand cmd = new SqlCommand("SELECT * FROM [user] WHERE name = @name AND password = @password", con);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@password", password);

                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    if (int.TryParse(result.ToString(), out int rowCount))
                    {
                        count = rowCount;
                    }
                }

                con.Close();

                // If count is greater than 0, it means there is a match
                credentialsMatch = count > 0;

                if (credentialsMatch == true)
                {
                    MessageBox.Show("LOGIN SUCCESFUL");
                }
                else
                {
                    MessageBox.Show("WRONG CREDENTIALS");
                }

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
