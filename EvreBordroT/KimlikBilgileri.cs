using Devart.Data.Oracle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvreBordroT
{
    public partial class KimlikBilgileri : DevExpress.XtraEditors.XtraForm
    {
        public KimlikBilgileri()
        {
            InitializeComponent();
        }
        OracleConnection conn = new OracleConnection("User Id =berkay; Password=1;Server=DBServer; Direct=True;Sid=EVREDB;");
        


        void ınsert()
        {
            conn.Open();
            OracleCommand command = new OracleCommand("INSERT INTO EVREMESSENGER (AD,SOYAD,DEPARTMAN,TELEFON,EPOSTA,BAGLAN) VALUES (:ad,:soyad,:departman,:telefon,:eposta,:baglan)",conn);
            command.Parameters.Add("ad", t.Text);
            command.Parameters.Add("soyad", txtAd.Text);
            command.Parameters.Add("departman", txtAnaAdı.Text);
            command.Parameters.Add("telefon", txtBabaAdı.Text);
            command.Parameters.Add("eposta", txtDoğumYeri.Text);
            command.Parameters.Add("baglan", txtDoğumTarihi.Text);
            Console.WriteLine(command.CommandText);
            command.ExecuteNonQuery();
            conn.Close();
        }

        void update ()
        {
            conn.Open();
            OracleCommand cmd = new OracleCommand("Update EvreMessenger SET AD='"+t.Text+"',SOYAD='"+txtAd.Text+"',DEPARTMAN='"+txtAnaAdı.Text+"'," +
                "TELEFON='"+txtBabaAdı.Text+"',EPOSTA='"+txtDoğumYeri.Text+"',BAGLAN='"+txtDoğumTarihi.Text+"' WHERE TELEFON='"+txtBabaAdı.Text+"' ",conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        void delete()
        {
            conn.Open();
            OracleCommand cmd = new OracleCommand("DELETE FROM EvreMessenger WHERE TELEFON='"+txtBabaAdı.Text+"'",conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void KimlikBilgileri_Load(object sender, EventArgs e)
        {
            
        }

   
        private void smplbtnKaydet_Click(object sender, EventArgs e)
        {
            ınsert();
        }

        private void smplbtnGüncelle_Click(object sender, EventArgs e)
        {
            update();

        }

        private void smplbtnSil_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void textEdit1_Enter(object sender, EventArgs e)
        {
            txtTC.ForeColor = Color.White;
            txtTC.Text = "";
        }

        private void t_Enter(object sender, EventArgs e)
        {
            t.ForeColor = Color.White;
            t.Text = "";
        }

        private void txtAd_Enter(object sender, EventArgs e)
        {
            txtAd.ForeColor = Color.White;
            txtAd.Text = "";
        }

        private void txtAnaAdı_Enter(object sender, EventArgs e)
        {
            txtAnaAdı.ForeColor = Color.White;
            txtAnaAdı.Text = "";
        }

        private void txtBabaAdı_Enter(object sender, EventArgs e)
        {
            txtBabaAdı.ForeColor = Color.White;
            txtBabaAdı.Text = "";
        }

        private void txtDoğumYeri_Enter(object sender, EventArgs e)
        {
            txtDoğumYeri.ForeColor = Color.White;
            txtDoğumYeri.Text = "";
        }

        private void txtDoğumTarihi_Enter(object sender, EventArgs e)
        {
            txtDoğumTarihi.ForeColor = Color.White;
            txtDoğumTarihi.Text = "";
        }

        private void txtMedeniHali_Enter(object sender, EventArgs e)
        {
            txtMedeniHali.ForeColor = Color.White;
            txtMedeniHali.Text = "";
        }

        private void txtDini_Enter(object sender, EventArgs e)
        {
            txtDini.ForeColor = Color.White;
            txtDini.Text = "";
        }

        private void txtKanGrubu_Enter(object sender, EventArgs e)
        {
            txtKanGrubu.ForeColor = Color.White;
            txtKanGrubu.Text = "";
        }

        private void txtİl_Enter(object sender, EventArgs e)
        {
            txtİl.ForeColor = Color.White;
            txtİl.Text = "";
        }

        private void txtİlce_Enter(object sender, EventArgs e)
        {
            txtİlce.ForeColor = Color.White;
            txtİlce.Text = "";
        }

        private void txtMahalle_Enter(object sender, EventArgs e)
        {
            txtMahalle.ForeColor = Color.White;
            txtMahalle.Text = "";
        }

        private void txtCiltNO_Enter(object sender, EventArgs e)
        {
            txtCiltNO.ForeColor = Color.White;
            txtCiltNO.Text = "";
        }

        private void txtAileNo_Enter(object sender, EventArgs e)
        {
            txtAileNo.ForeColor = Color.White;
            txtAileNo.Text = "";
        }

        private void txtSıraNo_Enter(object sender, EventArgs e)
        {
            txtSıraNo.ForeColor = Color.White;
            txtSıraNo.Text = "";
        }

        private void txtVerildiğiYer_Enter(object sender, EventArgs e)
        {
            txtVerildiğiYer.ForeColor = Color.White;
            txtVerildiğiYer.Text = "";
        }

        private void txtVerilişNedeni_Enter(object sender, EventArgs e)
        {
            txtVerilişNedeni.ForeColor = Color.White;
            txtVerilişNedeni.Text = "";
        }

        private void txtKayıtNo_Enter(object sender, EventArgs e)
        {
            txtKayıtNo.ForeColor = Color.White;
            txtKayıtNo.Text = "";
        }

        private void txtVerilişTarihi_Enter(object sender, EventArgs e)
        {
            txtVerilişTarihi.ForeColor = Color.White;
            txtVerilişTarihi.Text = "";
        }
    }
}
