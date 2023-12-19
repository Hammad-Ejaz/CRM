using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM
{
    public partial class MainFormcs : Form
    {
        public MainFormcs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lead form = new lead();
            this.Hide();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sale form = new Sale();
            this.Hide();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            employee form = new employee();
            this.Hide();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clientscs form = new Clientscs();
            form.Show();
            this.Hide():
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            this.Hide();
            product.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Property property = new Property();
            this.Hide();
            property.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            meeting meeting = new meeting();
            this.Hide(); meeting.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Task task = new Task(); 
            task.Show();
            this.Hide();
        }
    }
}
