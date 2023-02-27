using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace forlks
{
    public partial class menuutama : Form
    {
        pegawai formpegawai;
        login formlogin;
        transaksi formtransaksi;

        void formlogin_FormClosed(Object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            formlogin = null;
        }

        void formpegawai_FormClosed(Object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            formpegawai = null;
        }

        void formtransaksi_FormClosed(Object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            formtransaksi = null;
        }

        public menuutama()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (formpegawai == null)
            {
                formpegawai = new pegawai();
                formpegawai.FormClosed += new FormClosedEventHandler(formpegawai_FormClosed);
                formpegawai.Show();
                this.Hide();
            }
            else
            {
                this.Hide();
                formpegawai.Activate();
            }
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void menuutama_Load(object sender, EventArgs e)
        {
            label1.Text = "Hi, " + login.recby;
        }
    }
}
