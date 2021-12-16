using System;
using System.Windows.Forms;

namespace BBMS
{
    public partial class spalsh : Form
    {
        public spalsh()
        {
            InitializeComponent();
        }
        int startpos = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpos += 1;
            myprog.Value = startpos;
            if (myprog.Value == 100)
            {
                myprog.Value = 0;
                timer1.Stop();
                Login log = new Login();
                log.Show();
                this.Hide();
            }

        }

        private void spalsh_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
