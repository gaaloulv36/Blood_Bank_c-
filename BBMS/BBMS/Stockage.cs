using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BBMS
{
    public partial class Stockage : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gaalo\Documents\BSBD.mdf;Integrated Security=True;Connect Timeout=30");

        public Stockage()
        {
            InitializeComponent();
            SangSTOCk();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void dash_Click(object sender, EventArgs e)
        {
            dashboard log = new dashboard();
            log.Show();
            this.Hide();
        }

        private void stock_Click(object sender, EventArgs e)
        {

        }

        private void tra_sa_Click(object sender, EventArgs e)
        {
            Transfer log = new Transfer();
            log.Show();
            this.Hide();
        }

        private void list_pa_Click(object sender, EventArgs e)
        {
            List_patient log = new List_patient();
            log.Show();
            this.Hide();
        }

        private void patie_Click(object sender, EventArgs e)
        {
            Patient log = new Patient();
            log.Show();
            this.Hide();
        }

        private void list_op_Click(object sender, EventArgs e)
        {
            list_done log = new list_done();
            log.Show();
            this.Hide();
        }

        private void oper_Click(object sender, EventArgs e)
        {
            operation log = new operation();
            log.Show();
            this.Hide();
        }

        private void Done_Click(object sender, EventArgs e)
        {
            donateur log = new donateur();
            log.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        // affichage les donees de Stockage de sang 
        private void SangSTOCk()
        {
            conn.Open();
            String Tab = "select * from SangDB";
            SqlDataAdapter squp = new SqlDataAdapter(Tab, conn);
            SqlCommandBuilder buid = new SqlCommandBuilder(squp);
            var ds = new DataSet();
            squp.Fill(ds);
            SangTB.DataSource = ds.Tables[0];
            conn.Close();

        }
        private void SangTB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        // Event listener pour exit application
        private void label17_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

       
        // creé une function de recherch sur le text box
        private void Bnom_TextChanged(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed) // control de connexion
                conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from SangDB where Btype like '%" + BFILTER.Text + "%'", conn);
            SqlDataAdapter ds = new SqlDataAdapter();
            DataTable dt = new DataTable();
            ds.SelectCommand = cmd;
            dt.Clear();
            SangTB.DataSource = dt;
            ds.Fill(dt);
            conn.Close();
            if (BFILTER.Text == "")
            {
                SangSTOCk();
            }
        }
    }
    }

