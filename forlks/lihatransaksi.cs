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

namespace forlks
{
    public partial class lihatransaksi : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        login formlogin;
        menuutama formhome;
        transaksi formtransaksi;
        transaksipaket formtransaksipaket;
        koneksi Konn = new koneksi();


        void formlogin_FormClosed(Object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            formlogin = null;
        }

        void formhome_FormClosed(Object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            formhome = null;
        }

        void formtransaksi_FormClosed(Object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            formtransaksi = null;
        }

        void formtransaksipaket_FormClosed(Object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            formtransaksipaket = null;
        }
        
        void tampil()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select * from Transaksi", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Transaksi");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Transaksi";
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

        void Detailtransaksi()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select * from DetailTransaksi", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "DetailTransaksi");
                dataGridView2.DataSource = ds;
                dataGridView2.DataMember = "DetailTransaksi";
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
    public lihatransaksi()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (formtransaksi == null)
            {
                formtransaksi = new transaksi();
                formtransaksi.FormClosed += new FormClosedEventHandler(formtransaksi_FormClosed);
                formtransaksi.Show();
                this.Hide();
            }
            else
            {
                this.Hide();
                formtransaksi.Activate();
            }
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

        private void lihatransaksi_Load(object sender, EventArgs e)
        {
            tampil();
            Detailtransaksi();

        }
    }
}
