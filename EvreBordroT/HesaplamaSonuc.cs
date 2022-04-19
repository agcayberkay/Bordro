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
    public partial class HesaplamaSonuc : DevExpress.XtraEditors.XtraForm
    {
        public HesaplamaSonuc()
        {
            InitializeComponent();

        }



        public static Models.Mounts mt = new Models.Mounts();
        Form1 frm = new Form1();

        private void HesaplamaSonuc_Load(object sender, EventArgs e)
        {
            var sonucH = Form1.texp.SeciliTercih;
            if (sonucH == true)
            {
                nettenBruteYazdırma();
                asdad.SelectedTabPageIndex = 1;
            }
            else if (sonucH == false)
            {
                bruttenNeteYazdırma();
                asdad.SelectedTabPageIndex = 0;

            }
        }

        public void nettenBruteYazdırma()
        {


            DataTable tb = new DataTable();

            tb.Columns.Add("Net Ücret", typeof(double));
            tb.Columns.Add("SGK İşçi Primi", typeof(double));
            tb.Columns.Add("İşsizlik Primi", typeof(double));
            tb.Columns.Add("Gelir Vergisi Matrahı", typeof(double));
            tb.Columns.Add("Kumülatif Gelir Vergisi Matrahı", typeof(double));
            tb.Columns.Add("Gelir Vergisi Kesintisi", typeof(double));
            tb.Columns.Add("Asgari Ücret Gelir Vergisi Matrahı", typeof(double));
            tb.Columns.Add("Ödenecek Gelir Vergisi", typeof(double));
            tb.Columns.Add("Damga Vergisi", typeof(double));
            tb.Columns.Add("Asgari Ücret Damga Vergisi", typeof(double));
            tb.Columns.Add("Ödenecek Damga Vergisi", typeof(double));
            tb.Columns.Add("Toplam Vergi", typeof(double));
            tb.Columns.Add("Brüt Ücret", typeof(double));

            double k = 0;
            double asg = 0;
            double asgariVergi = 4253.4;
            var kvergi = Form1.nb.GelirVergisiMatrahıi;
            for (int y = 0; y < 12; y++)
            {

                k += kvergi;
                asg += asgariVergi;
                if (asg <= 32000)
                {

                    Form1.nb.AsgariUcretGelırVergısıKesintisi = Form1.asgariNet * 0.15;

                }
                else if (asg > 32000)
                {
                    double toplamAsgariGecis = 0;
                    var kesilenAsgari = asg - 32000;
                    if (asgariVergi > kesilenAsgari)
                    {
                        var cıkanAsgariVergi = asgariVergi - kesilenAsgari;
                        kesilenAsgari = kesilenAsgari * 0.20;

                        cıkanAsgariVergi = cıkanAsgariVergi * 0.15;



                        toplamAsgariGecis = kesilenAsgari + cıkanAsgariVergi;
                        Form1.nb.AsgariUcretGelırVergısıKesintisi = toplamAsgariGecis;
                    }
                    else
                    {
                        Form1.nb.AsgariUcretGelırVergısıKesintisi = Form1.asgariNet * 0.20;

                    }
                    Form1.nb.OdenecekGelırVergısı = 0;
                    Form1.nb.ToplamKesilenVergi = Form1.nb.SgkIsciPayi + Form1.nb.IssizlikSigortIsciPayıi + Form1.nb.OdenecekGelırVergısı + Form1.nb.OdenecekDamgaVergisi;

                }

                if (k < 32000)
                {
                    Form1.nb.GelirVergisiKesintisi = Form1.nb.GelirVergisiMatrahıi * 0.15;
                    Form1.nb.OdenecekGelırVergısı = Form1.nb.GelirVergisiKesintisi - Form1.nb.AsgariUcretGelırVergısıKesintisi;
                    Form1.nb.ToplamKesilenVergi = Form1.nb.SgkIsciPayi + Form1.nb.IssizlikSigortIsciPayıi + Form1.nb.OdenecekGelırVergısı + Form1.nb.OdenecekDamgaVergisi;

                }
                else if (k >= 32000 && k < 70000)
                {
                    var kesilenVergi = k - 32000;
                    double toplamGecis = 0;
                    if (kvergi > kesilenVergi)
                    {
                        var kalanVergi = kvergi - kesilenVergi;
                        kalanVergi = kalanVergi * 0.15;

                        kesilenVergi = kesilenVergi * 0.20;

                        toplamGecis = kesilenVergi + kalanVergi;
                        Form1.nb.GelirVergisiKesintisi = toplamGecis;
                    }
                    else
                    {
                        Form1.nb.GelirVergisiKesintisi = Form1.nb.GelirVergisiMatrahıi * 0.20;
                    }

                    Form1.nb.OdenecekGelırVergısı = Form1.nb.GelirVergisiKesintisi - Form1.nb.AsgariUcretGelırVergısıKesintisi;
                    Form1.nb.ToplamKesilenVergi = Form1.nb.SgkIsciPayi + Form1.nb.IssizlikSigortIsciPayıi + Form1.nb.OdenecekGelırVergısı + Form1.nb.OdenecekDamgaVergisi;


                }
                else if (k >= 70000 && k < 250000)
                {
                    Form1.nb.GelirVergisiKesintisi = Form1.nb.GelirVergisiMatrahıi * 0.27;
                    Form1.nb.OdenecekGelırVergısı = Form1.nb.GelirVergisiKesintisi - Form1.nb.AsgariUcretGelırVergısıKesintisi;
                    Form1.nb.ToplamKesilenVergi = Form1.nb.SgkIsciPayi + Form1.nb.IssizlikSigortIsciPayıi + Form1.nb.OdenecekGelırVergısı + Form1.nb.OdenecekDamgaVergisi;
                }
                else if (k >= 250000 && k < 880000)
                {
                    Form1.nb.GelirVergisiKesintisi = Form1.nb.GelirVergisiMatrahıi * 0.35;
                    Form1.nb.OdenecekGelırVergısı = Form1.nb.GelirVergisiKesintisi - Form1.nb.AsgariUcretGelırVergısıKesintisi;
                    Form1.nb.ToplamKesilenVergi = Form1.nb.SgkIsciPayi + Form1.nb.IssizlikSigortIsciPayıi + Form1.nb.OdenecekGelırVergısı + Form1.nb.OdenecekDamgaVergisi;

                }
                else if (k >= 880000)
                {
                    Form1.nb.GelirVergisiKesintisi = Form1.nb.GelirVergisiMatrahıi * 0.40;
                    Form1.nb.OdenecekGelırVergısı = Form1.nb.GelirVergisiKesintisi - Form1.nb.AsgariUcretGelırVergısıKesintisi;
                    Form1.nb.ToplamKesilenVergi = Form1.nb.SgkIsciPayi + Form1.nb.IssizlikSigortIsciPayıi + Form1.nb.OdenecekGelırVergısı + Form1.nb.OdenecekDamgaVergisi;


                }


                tb.Rows.Add(
                    Form1.nb.NetMaas, Form1.nb.SgkIsciPayi, Form1.nb.IssizlikSigortIsciPayıi, Form1.nb.GelirVergisiMatrahıi, k,
                   Form1.nb.GelirVergisiKesintisi, Form1.nb.AsgariUcretGelırVergısıKesintisi
                    , Form1.nb.OdenecekGelırVergısı, Form1.nb.DamgaVergisi, Form1.nb.AsgariUcretDamgaVergisi,
                    Form1.nb.OdenecekDamgaVergisi, Form1.nb.ToplamKesilenVergi, Form1.nb.ToplamBrüt);

            }
            grdNettenB.DataSource = tb;
        }

        public void bruttenNeteYazdırma()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Brüt Ücret", typeof(double));
            dt.Columns.Add("SGK İşçi Primi", typeof(double));
            dt.Columns.Add("İşsizlik Primi", typeof(double));
            dt.Columns.Add("Gelir Vergisi Matrahı", typeof(double));
            dt.Columns.Add("Kumülatif Gelir Vergisi Matrahı", typeof(double));
            dt.Columns.Add("Gelir Vergisi Kesintisi", typeof(double));
            dt.Columns.Add("Asgari Ücret Gelir Vergisi Matrahı", typeof(double));
            dt.Columns.Add("Ödenecek Gelir Vergisi", typeof(double));
            dt.Columns.Add("Damga Vergisi", typeof(double));
            dt.Columns.Add("Asgari Ücret Damga Vergisi", typeof(double));
            dt.Columns.Add("Ödenecek Damga Vergisi", typeof(double));
            dt.Columns.Add("Toplam Vergi", typeof(double));
            dt.Columns.Add("Net Ücret", typeof(double));

            double k = 0;
            double asg = 0;
            double asgariVergi = 4253.4;
            var kvergi = Form1.pr.GelirVergisiMatrahıi;
            for (int y = 0; y < 12; y++)
            {

                k += kvergi;
                //x += Form1.pr.GelirVergisiKesintisi;
                asg += asgariVergi;
                if (asg <= 32000)
                {

                    Form1.pr.AsgariUcretGelırVergısıKesintisi = Form1.asgariNet * 0.15;

                }
                else if (asg > 32000)
                {
                    double toplamAsgariGecis = 0;
                    var kesilenAsgari = asg - 32000;
                    if (asgariVergi > kesilenAsgari)
                    {
                        var cıkanAsgariVergi = asgariVergi - kesilenAsgari;
                        kesilenAsgari = kesilenAsgari * 0.20;

                        cıkanAsgariVergi = cıkanAsgariVergi * 0.15;



                        toplamAsgariGecis = kesilenAsgari + cıkanAsgariVergi;
                        Form1.pr.AsgariUcretGelırVergısıKesintisi = toplamAsgariGecis;
                    }
                    else
                    {
                        Form1.pr.AsgariUcretGelırVergısıKesintisi = Form1.asgariNet * 0.20;

                    }
                    Form1.pr.OdenecekGelırVergısı = 0;
                    Form1.pr.ToplamKesilenVergi = Form1.pr.SgkIsciPayi + Form1.pr.IssizlikSigortIsciPayıi + Form1.pr.OdenecekGelırVergısı + Form1.pr.OdenecekDamgaVergisi;
                    Form1.pr.NetMaas = ((Form1.pr.ToplamBrüt - Form1.pr.ToplamKesilenVergi) / 30) * Form1.pr.GünSayısı;
                }

                if (k < 32000)
                {
                    Form1.pr.GelirVergisiKesintisi = Form1.pr.GelirVergisiMatrahıi * 0.15;
                    Form1.pr.OdenecekGelırVergısı = Form1.pr.GelirVergisiKesintisi - Form1.pr.AsgariUcretGelırVergısıKesintisi;
                    Form1.pr.ToplamKesilenVergi = Form1.pr.SgkIsciPayi + Form1.pr.IssizlikSigortIsciPayıi + Form1.pr.OdenecekGelırVergısı + Form1.pr.OdenecekDamgaVergisi;
                    Form1.pr.NetMaas = ((Form1.pr.ToplamBrüt - Form1.pr.ToplamKesilenVergi) / 30) * Form1.pr.GünSayısı;
                }
                else if (k >= 32000 && k < 70000)
                {
                  
                    var kesilenVergi = k - 32000;
                    double toplamGecis = 0;
                    if (kvergi > kesilenVergi)
                    {
                        var kalanVergi = kvergi - kesilenVergi;
                        kalanVergi = kalanVergi * 0.15;

                        kesilenVergi = kesilenVergi * 0.20;

                        toplamGecis = kesilenVergi + kalanVergi;
                        Form1.pr.GelirVergisiKesintisi = toplamGecis;
                    }
                    else
                    {
                        Form1.pr.GelirVergisiKesintisi = Form1.pr.GelirVergisiMatrahıi * 0.20;
                    }

                    Form1.pr.OdenecekGelırVergısı = Form1.pr.GelirVergisiKesintisi - Form1.pr.AsgariUcretGelırVergısıKesintisi;
                    Form1.pr.ToplamKesilenVergi = Form1.pr.SgkIsciPayi + Form1.pr.IssizlikSigortIsciPayıi + Form1.pr.OdenecekGelırVergısı + Form1.pr.OdenecekDamgaVergisi;
                    Form1.pr.NetMaas = ((Form1.pr.ToplamBrüt - Form1.pr.ToplamKesilenVergi) / 30) * Form1.pr.GünSayısı;

                }
                else if (k >= 70000 && k < 250000)
                {
                    var kesilenVergi = k - 70000;
                    double toplamGecis = 0;
                    if (kvergi > kesilenVergi)
                    {
                        var kalanVergi = kvergi - kesilenVergi;
                        kalanVergi = kalanVergi * 0.20;

                        kesilenVergi = kesilenVergi * 0.27;

                        toplamGecis = kesilenVergi + kalanVergi;
                        Form1.pr.GelirVergisiKesintisi = toplamGecis;
                    }
                    else
                    {
                        Form1.pr.GelirVergisiKesintisi = Form1.pr.GelirVergisiMatrahıi * 0.27;
                    }


                    Form1.pr.OdenecekGelırVergısı = Form1.pr.GelirVergisiKesintisi - Form1.pr.AsgariUcretGelırVergısıKesintisi;
                    Form1.pr.ToplamKesilenVergi = Form1.pr.SgkIsciPayi + Form1.pr.IssizlikSigortIsciPayıi + Form1.pr.OdenecekGelırVergısı + Form1.pr.OdenecekDamgaVergisi;
                    Form1.pr.NetMaas = ((Form1.pr.ToplamBrüt - Form1.pr.ToplamKesilenVergi) / 30) * Form1.pr.GünSayısı;

                }
                else if (k >= 250000 && k < 880000)
                {
                    var kesilenVergi = k - 250000;
                    double toplamGecis = 0;
                    if (kvergi > kesilenVergi)
                    {
                        var kalanVergi = kvergi - kesilenVergi;
                        kalanVergi = kalanVergi * 0.27;

                        kesilenVergi = kesilenVergi * 0.35;

                        toplamGecis = kesilenVergi + kalanVergi;
                        Form1.pr.GelirVergisiKesintisi = toplamGecis;
                    }
                    else
                    {
                        Form1.pr.GelirVergisiKesintisi = Form1.pr.GelirVergisiMatrahıi * 0.35;
                    }
                   
                    Form1.pr.OdenecekGelırVergısı = Form1.pr.GelirVergisiKesintisi - Form1.pr.AsgariUcretGelırVergısıKesintisi;
                    Form1.pr.ToplamKesilenVergi = Form1.pr.SgkIsciPayi + Form1.pr.IssizlikSigortIsciPayıi + Form1.pr.OdenecekGelırVergısı + Form1.pr.OdenecekDamgaVergisi;
                    Form1.pr.NetMaas = ((Form1.pr.ToplamBrüt - Form1.pr.ToplamKesilenVergi) / 30) * Form1.pr.GünSayısı;

                }
                else if (k >= 880000)
                {
                    var kesilenVergi = k - 880000;
                    double toplamGecis = 0;
                    if (kvergi > kesilenVergi)
                    {
                        var kalanVergi = kvergi - kesilenVergi;
                        kalanVergi = kalanVergi * 0.35;

                        kesilenVergi = kesilenVergi * 0.40;

                        toplamGecis = kesilenVergi + kalanVergi;
                        Form1.pr.GelirVergisiKesintisi = toplamGecis;
                    }
                    else
                    {
                        Form1.pr.GelirVergisiKesintisi = Form1.pr.GelirVergisiMatrahıi * 0.40;
                    }

                    Form1.pr.GelirVergisiKesintisi = Form1.pr.GelirVergisiMatrahıi * 0.40;
                    Form1.pr.OdenecekGelırVergısı = Form1.pr.GelirVergisiKesintisi - Form1.pr.AsgariUcretGelırVergısıKesintisi;
                    Form1.pr.ToplamKesilenVergi = Form1.pr.SgkIsciPayi + Form1.pr.IssizlikSigortIsciPayıi + Form1.pr.OdenecekGelırVergısı + Form1.pr.OdenecekDamgaVergisi;
                    Form1.pr.NetMaas = ((Form1.pr.ToplamBrüt - Form1.pr.ToplamKesilenVergi) / 30) * Form1.pr.GünSayısı;

                }

                dt.Rows.Add(
                  Form1.pr.ToplamBrüt, Form1.pr.SgkIsciPayi, Form1.pr.IssizlikSigortIsciPayıi, Form1.pr.GelirVergisiMatrahıi, k,
                 Form1.pr.GelirVergisiKesintisi, Form1.pr.AsgariUcretGelırVergısıKesintisi
                  , Form1.pr.OdenecekGelırVergısı, Form1.pr.DamgaVergisi, Form1.pr.AsgariUcretDamgaVergisi,
                  Form1.pr.OdenecekDamgaVergisi, Form1.pr.ToplamKesilenVergi, Form1.pr.NetMaas);


            }
            bNet.DataSource = dt;
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr != null)
            {
                textEdit13.Text = dr[0].ToString();
                textEdit14.Text = dr[1].ToString();
                textEdit15.Text = dr[2].ToString();
                textEdit16.Text = dr[3].ToString();
                textEdit17.Text = dr[5].ToString();
                textEdit18.Text = dr[6].ToString();
                textEdit19.Text = dr[7].ToString();
                textEdit20.Text = dr[8].ToString();
                textEdit21.Text = dr[9].ToString();
                textEdit22.Text = dr[10].ToString();
                textEdit23.Text = dr[11].ToString();
                textEdit24.Text = dr[12].ToString();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                textEdit1.Text = dr[0].ToString();
                textEdit2.Text = dr[1].ToString();
                textEdit3.Text = dr[2].ToString();
                textEdit4.Text = dr[3].ToString();
                textEdit5.Text = dr[5].ToString();
                textEdit6.Text = dr[6].ToString();
                textEdit7.Text = dr[7].ToString();
                textEdit8.Text = dr[8].ToString();
                textEdit9.Text = dr[9].ToString();
                textEdit10.Text = dr[10].ToString();
                textEdit11.Text = dr[11].ToString();
                textEdit12.Text = dr[12].ToString();
            }
        }

        private void xtraTabPage2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void asdad_Click(object sender, EventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
