using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace forlks
{
    public partial class transaksi : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        menuutama formhome;
        login formlogin;
        pelanggan formpelanggan;
        transaksipaket formtransaksipaket;
        lihatransaksi formlihatransaksi;

        koneksi Konn = new koneksi();

        void formhome_FormClosed(Object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            formhome = null;
        }

        void formpelanggan_FormClosed(Object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            formpelanggan = null;
        }

        void formlogin_FormClosed(Object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            formlogin = null;
        }

        void formtransaksipaket_FormClosed(Object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            formtransaksipaket = null;
        }

        void formlihatransaksi_FormClosed(Object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            formlihatransaksi = null;
        }

        public transaksi()
        {
            InitializeComponent();
        }

        void datalayanan()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select * from Layanan", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Layanan");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Layanan";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (formhome == null)
            {
                formhome = new menuutama();
                formhome.FormClosed += new FormClosedEventHandler(formhome_FormClosed);
                formhome.Show();
                this.Hide();
            }
            else
            {
                this.Hide();
                formhome.Activate();
            }
        }

        private void transaksi_Load(object sender, EventArgs e)
        {
            datalayanan();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (formlogin == null)
            {
                formlogin = new login();
                formlogin.FormClosed += new FormClosedEventHandler(formlogin_FormClosed);
                formlogin.Show();
                this.Hide();
            }
            else
            {
                this.Hide();
                formlogin.Activate();
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                textBox8.Text = row.Cells["id"].Value.ToString();
                textBox1.Text = row.Cells["nama_layanan"].Value.ToString();
                numericUpDown1.Text = row.Cells["qty"].Value.ToString();
                textBox2.Text = row.Cells["harga"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (formpelanggan == null)
            {
                formpelanggan = new pelanggan();
                formpelanggan.FormClosed += new FormClosedEventHandler(formpelanggan_FormClosed);
                formpelanggan.Show();
            }
            else
            {
                formpelanggan = new pelanggan();
                formpelanggan.FormClosed += new FormClosedEventHandler(formpelanggan_FormClosed);
                formpelanggan.Activate();
                formpelanggan.Show();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (formtransaksipaket == null)
            {
                formtransaksipaket = new transaksipaket();
                formtransaksipaket.FormClosed += new FormClosedEventHandler(formtransaksipaket_FormClosed);
                formtransaksipaket.Show();
                this.Hide();
            }
            else
            {
                this.Hide();
                formtransaksipaket.Activate();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (formlihatransaksi == null)
            {
                formlihatransaksi = new lihatransaksi();
                formlihatransaksi.FormClosed += new FormClosedEventHandler(formlihatransaksi_FormClosed);
                formlihatransaksi.Show();
                this.Hide();
            }
            else
            {
                this.Hide();
                formlihatransaksi.Activate();
            }
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
