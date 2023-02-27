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
    public partial class transaksipaket : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        menuutama formhome;
        login formlogin;
        transaksi formtransaksi;
        lihatransaksi formlihatransaksi;
        pelanggan formpelanggan;

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

        void formlihatransaksi_FormClosed(Object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            formlihatransaksi = null;
        }

        void formpelanggan_FormClosed(Object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            formpelanggan = null;
        }
        public transaksipaket()
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
            if (formtransaksi == null)
            {
                formtransaksi = new transaksi();
                formtransaksi.FormClosed += new FormClosedEventHandler(formhome_FormClosed);
                formtransaksi.Show();
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
    }
}
