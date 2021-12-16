using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BBMS
{
    public partial class dashboard : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gaalo\Documents\BSBD.mdf;Integrated Security=True;Connect Timeout=30");

        public dashboard()
        {
            InitializeComponent();
            GetData();
        }

        private void Done_Click(object sender, EventArgs e)
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
        // dans cette partie nous avons recuperee les information 
        private void GetData()
        {
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from DonateurDBD", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            donC.Text = dt.Rows[0][0].ToString();   // recupere les nombres des donateur dans le BD
            SqlDataAdapter sda1 = new SqlDataAdapter("Select count(*) from AEMP", conn);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            userC.Text = dt1.Rows[0][0].ToString(); // recupere les nombres des employee dans le BD


            SqlDataAdapter sda2 = new SqlDataAdapter("Select count(*) from DBtrans", conn);
               DataTable dt2 = new DataTable();
               sda2.Fill(dt2);
             tranC.Text = dt2.Rows[0][0].ToString(); // recupere les nombres des operation de transfer des sang



            SqlDataAdapter sda3 = new SqlDataAdapter("Select Sum(Bquant) from SangDB", conn);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            int Bstoock = Convert.ToInt32(dt3.Rows[0][0].ToString());
            totC.Text = "" + Bstoock;
            /* dans cette parie nous avons afficher les donne des dans dans une partie dynamique */

            // affichage de quantite de Sang de tye A+
            SqlDataAdapter sda4 = new SqlDataAdapter("Select Bquant from SangDB where Btype='" + "A+" + "'", conn);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            PosA.Text = dt4.Rows[0][0].ToString();

            double AplusPer = (Convert.ToDouble(PosA.Text) / Bstoock) * 100;
            Aplusprog.Value = Convert.ToInt32(AplusPer);


            // affichage de quantite de Sang de tye A-
            SqlDataAdapter sda5 = new SqlDataAdapter("Select Bquant from SangDB where Btype='" + "A-" + "'", conn);
            DataTable dt5 = new DataTable();
            sda5.Fill(dt5);
            NegA.Text = dt5.Rows[0][0].ToString();

            double AmoinPer = (Convert.ToDouble(NegA.Text) / Bstoock) * 100;
            amoinprog.Value = Convert.ToInt32(AmoinPer);


            // affichage de quantite de Sang de tye AB+
            SqlDataAdapter sda6 = new SqlDataAdapter("Select Bquant from SangDB where Btype='" + "AB+" + "'", conn);
            DataTable dt6 = new DataTable();
            sda6.Fill(dt6);
            PosAB.Text = dt6.Rows[0][0].ToString();

            double ABplusPer = (Convert.ToDouble(PosAB.Text) / Bstoock) * 100;
            ABplus.Value = Convert.ToInt32(ABplusPer);

            // affichage de quantite de Sang de tye AB-
            SqlDataAdapter sda7 = new SqlDataAdapter("Select Bquant from SangDB where Btype='" + "AB-" + "'", conn);
            DataTable dt7 = new DataTable();
            sda7.Fill(dt7);
            NegAB.Text = dt7.Rows[0][0].ToString();

            double abmoinper = (Convert.ToDouble(NegAB.Text) / Bstoock) * 100;
            ABmoinPROG.Value = Convert.ToInt32(abmoinper);


            // affichage de quantite de Sang de tye B+
            SqlDataAdapter sda8 = new SqlDataAdapter("Select Bquant from SangDB where Btype='" + "B+" + "'", conn);
            DataTable dt8 = new DataTable();
            sda8.Fill(dt8);
            PosB.Text = dt8.Rows[0][0].ToString();

            double bplusper = (Convert.ToDouble(PosB.Text) / Bstoock) * 100;
            bplusprog.Value = Convert.ToInt32(bplusper);

            // affichage de quantite de Sang de tye B-
            SqlDataAdapter sda9 = new SqlDataAdapter("Select Bquant from SangDB where Btype='" + "B-" + "'", conn);
            DataTable dt9 = new DataTable();
            sda9.Fill(dt9);
            NegB.Text = dt9.Rows[0][0].ToString();

            double bmoinper = (Convert.ToDouble(NegB.Text) / Bstoock) * 100;
            BmoinProg.Value = Convert.ToInt32(bmoinper);


            // affichage de quantite de Sang de tye O+
            SqlDataAdapter sda10 = new SqlDataAdapter("Select Bquant from SangDB where Btype='" + "O+" + "'", conn);
            DataTable dt10 = new DataTable();
            sda10.Fill(dt10);
            POSO.Text = dt10.Rows[0][0].ToString();

            double Oplusper = (Convert.ToDouble(POSO.Text) / Bstoock) * 100;
            Oplusprog.Value = Convert.ToInt32(Oplusper);


            // affichage de quantite de Sang de tye O-
            SqlDataAdapter sda11 = new SqlDataAdapter("Select Bquant from SangDB where Btype='" + "O-" + "'", conn);
            DataTable dt11 = new DataTable();
            sda11.Fill(dt11);
            NEGO.Text = dt11.Rows[0][0].ToString();

            double Omoinper = (Convert.ToDouble(NEGO.Text) / Bstoock) * 100;
            OmoinProg.Value = Convert.ToInt32(Omoinper);

            conn.Close();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void PosAB_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void donC_Click(object sender, EventArgs e)
        {

        }
    }
}
