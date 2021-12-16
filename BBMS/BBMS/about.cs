using System.Windows.Forms;

namespace BBMS
{
    public partial class about : Form
    {
        public about()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, System.EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, System.EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
