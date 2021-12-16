using System;
using System.Windows.Forms;

namespace BBMS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }


        private void Done_Click_1(object sender, EventArgs e)
        {
            donateur log = new donateur();
            log.Show();
            this.Hide();
        }

        private void oper_Click(object sender, EventArgs e)
        {
            operation log = new operation();
            log.Show();
            this.Hide();
        }

        private void list_op_Click(object sender, EventArgs e)
        {
            list_done log = new list_done();
            log.Show();
            this.Hide();
        }

        private void patie_Click(object sender, EventArgs e)
        {
            Patient log = new Patient();
            log.Show();
            this.Hide();
        }

        private void list_pa_Click(object sender, EventArgs e)
        {
            List_patient log = new List_patient();
            log.Show();
            this.Hide();
        }

        private void tra_sa_Click(object sender, EventArgs e)
        {
            Transfer log = new Transfer();
            log.Show();
            this.Hide();
        }

        private void stock_Click(object sender, EventArgs e)
        {
            Stockage log = new Stockage();
            log.Show();
            this.Hide();
        }

        private void dash_Click(object sender, EventArgs e)
        {
            dashboard log = new dashboard();
            log.Show();
            this.Hide();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
