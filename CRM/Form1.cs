namespace CRM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SIgnUp form = new SIgnUp();   
            this.Hide();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             SignIn form = new SignIn();
            this.Hide();
            form.Show();
        }
    }
}