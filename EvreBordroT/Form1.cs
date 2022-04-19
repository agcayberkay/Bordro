using Devart.Data.Oracle;
using EvreBordroT.Models;
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
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {

        public Form1()
        {
            InitializeComponent();
            
        }

        public static Parametres pr = new Parametres(); 
        public static NettenBruteParamateres nb = new NettenBruteParamateres();
        public static TextBoX texp = new TextBoX();
        public static TextboxParamatres t1 = new TextboxParamatres();
        public static List<string> Aylar = new List<string>();
        public static double asgariBrüt = 5004.0;
        public static double asgariNet = 4253.40;
        public static OracleConnection con = new OracleConnection("User Id =berkay; Password=1;Server=DBServer; Direct=True;Sid=EVREDB;");
        public static DatabaseLogicLayer databaseLogic = new DatabaseLogicLayer();
        


        void temzile()
        {
            //txtPAd.Text = "";
            //txtPSoyad.Text = "";
            //txtDepartman.Text = "";
            txtBrütÜcret.Text = "";
            txtToplamBrüt.Text = "";
            cmbxStatu.Text = "";
            txtOGV.Text = "";
            txtSgk1.Text = "";
            txtIssızlık.Text = "";
            txtGVM.Text = "";
            txtGVKe.Text = "";
            txtDV.Text = "";
            txtToplamV.Text = "";
            txtNet.Text = "";
            cmbxDerece.Text = "";
            cmbxEmekli.Text = "";
            cmbxEngelli.Text = "";
            txtGünSayısı.Text = "";
            txtMT.Text = "0";
            txtRBM.Text = "0";
            txtDBM.Text = "0";
            txtHTM.Text = "0";
            txtNGM.Text = "0";
            txtAUDVK.Text = "";
            txtAGVK.Text = "";
            txtODV.Text = "";
            txtGünlük.Text = "";
            txtHaftalık.Text = "";
            txtSaatlik.Text = "";
        }

        public void brüttenNeteHesaplama()
        {


            pr.BrutMaas = double.Parse(txtBrütÜcret.Text);

            pr.SaatlikUcret = pr.BrutMaas / 225;
            txtSaatlik.Text = Convert.ToString(pr.SaatlikUcret);

            pr.GunlukUcret = pr.BrutMaas / 30;
            txtGünlük.Text = Convert.ToString(pr.GunlukUcret);

            pr.HaftalıkUcret = pr.BrutMaas / 4;
            txtHaftalık.Text = Convert.ToString(pr.HaftalıkUcret);

            pr.NMesai = double.Parse(txtNGM.Text);
            pr.NMesai = (1.5 * pr.NMesai) * pr.SaatlikUcret;

            pr.HTMesai = double.Parse(txtHTM.Text);
            pr.HTMesai = (1.5 * pr.HTMesai) * pr.SaatlikUcret;

            pr.RBMesai = double.Parse(txtRBM.Text);
            pr.RBMesai = (1 * pr.RBMesai) * pr.SaatlikUcret;

            pr.DBMesai = double.Parse(txtDBM.Text);
            pr.DBMesai = (1 * pr.DBMesai) * pr.SaatlikUcret;

            pr.MesaiToplam = pr.NMesai + pr.DBMesai + pr.RBMesai + pr.HTMesai;
            txtMT.Text = Convert.ToString(pr.MesaiToplam);

            pr.ToplamBrüt = pr.MesaiToplam + pr.BrutMaas;
            txtToplamBrüt.Text = Convert.ToString(pr.ToplamBrüt);

            pr.GünSayısı = double.Parse(txtGünSayısı.Text);

            if (pr.ToplamBrüt > 37530)
            {
                pr.SgkIsciPayi = ((37530 * 0.14) / 30) * pr.GünSayısı;
                txtSgk1.Text = Convert.ToString(pr.SgkIsciPayi);

                pr.IssizlikSigortIsciPayıi = 37530 * 0.01 / 30 * pr.GünSayısı;
                txtIssızlık.Text = Convert.ToString(pr.IssizlikSigortIsciPayıi);
            }
            else
            {
                pr.SgkIsciPayi = ((pr.ToplamBrüt * 0.14) / 30) * pr.GünSayısı;
                txtSgk1.Text = Convert.ToString(pr.SgkIsciPayi);

                pr.IssizlikSigortIsciPayıi = pr.ToplamBrüt * 0.01 / 30 * pr.GünSayısı;
                txtIssızlık.Text = Convert.ToString(pr.IssizlikSigortIsciPayıi);
            }


            if (pr.ToplamBrüt > asgariBrüt)
            {


                pr.GelirVergisiMatrahıi = pr.ToplamBrüt - pr.SgkIsciPayi - pr.IssizlikSigortIsciPayıi;
                txtGVM.Text = Convert.ToString(pr.GelirVergisiMatrahıi);

                pr.GelirVergisiKesintisi = pr.GelirVergisiMatrahıi * 0.15;
                txtGVKe.Text = Convert.ToString(pr.GelirVergisiKesintisi);


                pr.AsgariUcretGelırVergısıKesintisi = asgariNet * 0.15;
                txtAGVK.Text = Convert.ToString(pr.AsgariUcretGelırVergısıKesintisi);

                pr.OdenecekGelırVergısı = pr.GelirVergisiKesintisi - pr.AsgariUcretGelırVergısıKesintisi;
                txtOGV.Text = Convert.ToString(pr.OdenecekGelırVergısı);


                pr.AsgariUcretDamgaVergisi = ((asgariBrüt * 0.00759) / 30) * pr.GünSayısı;
                txtAUDVK.Text = Convert.ToString(pr.AsgariUcretDamgaVergisi);

                if (pr.ToplamBrüt > 37530)
                {
                    pr.DamgaVergisi = 37530 * 0.00759;
                    txtDV.Text = Convert.ToString(pr.DamgaVergisi);
                }

                pr.DamgaVergisi = (pr.ToplamBrüt * 0.00759);
                txtDV.Text = Convert.ToString(pr.DamgaVergisi);

                pr.OdenecekDamgaVergisi = pr.DamgaVergisi - pr.AsgariUcretDamgaVergisi;
                txtODV.Text = Convert.ToString(pr.OdenecekDamgaVergisi);

                pr.ToplamKesilenVergi = pr.SgkIsciPayi + pr.IssizlikSigortIsciPayıi + pr.OdenecekGelırVergısı + pr.OdenecekDamgaVergisi;
                txtToplamV.Text = Convert.ToString(pr.ToplamKesilenVergi);

                pr.NetMaas = ((pr.ToplamBrüt - pr.ToplamKesilenVergi) / 30) * pr.GünSayısı;
                txtNet.Text = Convert.ToString(pr.NetMaas);

                engellik();

                emeklilik();


            }
            else
            {
                pr.SgkIsciPayi = pr.ToplamBrüt * 0.14 / 30 * pr.GünSayısı;
                txtSgk1.Text = Convert.ToString(pr.SgkIsciPayi);

                pr.IssizlikSigortIsciPayıi = pr.ToplamBrüt * 0.01 / 30 * pr.GünSayısı;
                txtIssızlık.Text = Convert.ToString(pr.IssizlikSigortIsciPayıi);

                pr.GelirVergisiMatrahıi = pr.ToplamBrüt - pr.SgkIsciPayi - pr.IssizlikSigortIsciPayıi;
                txtGVM.Text = Convert.ToString(pr.GelirVergisiMatrahıi);

                pr.GelirVergisiKesintisi = 0;
                txtGVKe.Text = Convert.ToString(pr.GelirVergisiKesintisi);

                pr.AsgariUcretGelırVergısıKesintisi = asgariNet * 0.15;
                txtAGVK.Text = Convert.ToString(pr.AsgariUcretGelırVergısıKesintisi);

                pr.OdenecekGelırVergısı = 0;
                txtOGV.Text = Convert.ToString(pr.OdenecekGelırVergısı);

                pr.AsgariUcretDamgaVergisi = asgariBrüt * 0.00759 / 30 * pr.GünSayısı;
                txtAUDVK.Text = Convert.ToString(pr.AsgariUcretDamgaVergisi);

                pr.DamgaVergisi = 0;
                txtDV.Text = Convert.ToString(pr.DamgaVergisi);

                pr.OdenecekDamgaVergisi = 0;
                txtODV.Text = Convert.ToString(pr.OdenecekDamgaVergisi);

                pr.ToplamKesilenVergi = pr.SgkIsciPayi + pr.IssizlikSigortIsciPayıi;
                txtToplamV.Text = Convert.ToString(pr.ToplamKesilenVergi);

                pr.NetMaas = (pr.ToplamBrüt - pr.ToplamKesilenVergi) / 30 * pr.GünSayısı;
                txtNet.Text = Convert.ToString(pr.NetMaas);

                emeklilik();
            }
            if (cmbxEngelli.SelectedText == "Hayır")
            {
                cmbxDerece.Text = "0";
            }


            texp.Statü = cmbxStatu.Text;
            texp.EngellilikDurumu = cmbxEngelli.Text;
            texp.EngellilikDerece = Convert.ToDouble(cmbxDerece.Text);
            texp.EmeklilikDurumu = cmbxEmekli.Text;

        }

        public void engellik()
        {
            if (cmbxDerece.SelectedText == "1")
            {
                pr.GelirVergisiMatrahıi = pr.GelirVergisiMatrahıi - 2000;
                txtGVM.Text = Convert.ToString(pr.GelirVergisiMatrahıi);

                pr.GelirVergisiKesintisi = pr.GelirVergisiMatrahıi * 0.15;
                txtGVKe.Text = Convert.ToString(pr.GelirVergisiKesintisi);

                pr.OdenecekGelırVergısı = pr.GelirVergisiKesintisi - pr.AsgariUcretGelırVergısıKesintisi;
                txtOGV.Text = Convert.ToString(pr.OdenecekGelırVergısı);

                pr.ToplamKesilenVergi = pr.SgkIsciPayi + pr.IssizlikSigortIsciPayıi + pr.OdenecekGelırVergısı + pr.OdenecekDamgaVergisi;
                txtToplamV.Text = Convert.ToString(pr.ToplamKesilenVergi);

                pr.NetMaas = ((pr.ToplamBrüt - pr.ToplamKesilenVergi) / 30) * pr.GünSayısı;
                txtNet.Text = Convert.ToString(pr.NetMaas);

            }

            if (cmbxDerece.SelectedText == "2")
            {
                pr.GelirVergisiMatrahıi = pr.GelirVergisiMatrahıi - 1170;
                txtGVM.Text = Convert.ToString(pr.GelirVergisiMatrahıi);

                pr.GelirVergisiKesintisi = pr.GelirVergisiMatrahıi * 0.15;
                txtGVKe.Text = Convert.ToString(pr.GelirVergisiKesintisi);

                pr.OdenecekGelırVergısı = pr.GelirVergisiKesintisi - pr.AsgariUcretGelırVergısıKesintisi;
                txtOGV.Text = Convert.ToString(pr.OdenecekGelırVergısı);

                pr.ToplamKesilenVergi = pr.SgkIsciPayi + pr.IssizlikSigortIsciPayıi + pr.OdenecekGelırVergısı + pr.OdenecekDamgaVergisi;
                txtToplamV.Text = Convert.ToString(pr.ToplamKesilenVergi);

                pr.NetMaas = ((pr.ToplamBrüt - pr.ToplamKesilenVergi) / 30) * pr.GünSayısı;
                txtNet.Text = Convert.ToString(pr.NetMaas);


            }

            if (cmbxDerece.SelectedText == "3")
            {
                pr.GelirVergisiMatrahıi = pr.GelirVergisiMatrahıi - 500;
                txtGVM.Text = Convert.ToString(pr.GelirVergisiMatrahıi);

                pr.GelirVergisiKesintisi = pr.GelirVergisiMatrahıi * 0.15;
                txtGVKe.Text = Convert.ToString(pr.GelirVergisiKesintisi);

                pr.OdenecekGelırVergısı = pr.GelirVergisiKesintisi - pr.AsgariUcretGelırVergısıKesintisi;
                txtOGV.Text = Convert.ToString(pr.OdenecekGelırVergısı);

                pr.ToplamKesilenVergi = pr.SgkIsciPayi + pr.IssizlikSigortIsciPayıi + pr.OdenecekGelırVergısı + pr.OdenecekDamgaVergisi;
                txtToplamV.Text = Convert.ToString(pr.ToplamKesilenVergi);

                pr.NetMaas = ((pr.ToplamBrüt - pr.ToplamKesilenVergi) / 30) * pr.GünSayısı;
                txtNet.Text = Convert.ToString(pr.NetMaas);

            }
        }

        public void emeklilik()
        {
            if (cmbxEmekli.SelectedText == "Evet")
            {
                pr.SgkIsciPayi = pr.ToplamBrüt * 0.075;
                txtSgk1.Text = Convert.ToString(pr.SgkIsciPayi);

                pr.IssizlikSigortIsciPayıi = 0;
                txtIssızlık.Text = Convert.ToString(pr.IssizlikSigortIsciPayıi);

                pr.GelirVergisiMatrahıi = pr.ToplamBrüt - pr.SgkIsciPayi;
                txtGVM.Text = Convert.ToString(pr.GelirVergisiMatrahıi);


                pr.GelirVergisiKesintisi = 0;
                txtGVKe.Text = Convert.ToString(pr.GelirVergisiKesintisi);

                pr.AsgariUcretGelırVergısıKesintisi = asgariBrüt * 0.075;
                txtAGVK.Text = Convert.ToString(pr.AsgariUcretGelırVergısıKesintisi);

                pr.OdenecekGelırVergısı = pr.SgkIsciPayi;
                txtOGV.Text = Convert.ToString(pr.OdenecekGelırVergısı);

                pr.DamgaVergisi = 0;
                txtDV.Text = Convert.ToString(pr.DamgaVergisi);

                pr.ToplamKesilenVergi = pr.SgkIsciPayi + pr.IssizlikSigortIsciPayıi + pr.GelirVergisiKesintisi + pr.DamgaVergisi;
                txtToplamV.Text = Convert.ToString(pr.ToplamKesilenVergi);

                pr.NetMaas = ((pr.ToplamBrüt - pr.ToplamKesilenVergi) / 30) * pr.GünSayısı;
                txtNet.Text = Convert.ToString(pr.NetMaas);


            }
        }

        public static double sonucBrut = pr.NettenMaas;

        public void netttenBrüteHesaplama()

        {
            

            nb.NetMaas = double.Parse(txtBrütÜcret.Text);

            nb.NetMaas = Math.Round(nb.NetMaas, 2);
            txtNet.Text = Convert.ToString(nb.NetMaas);

            nb.BrutMaas = nb.NetMaas - 675.99;
            nb.BrutMaas = nb.BrutMaas * 1.398777468492538;



            nb.SaatlikUcret = Math.Round((nb.NetMaas / 225), 2);
            txtSaatlik.Text = Convert.ToString(pr.SaatlikUcret);

            nb.GunlukUcret = Math.Round((nb.NetMaas / 30), 2);
            txtGünlük.Text = Convert.ToString(pr.GunlukUcret);

            nb.HaftalıkUcret = Math.Round((nb.NetMaas / 4), 2);
            txtHaftalık.Text = Convert.ToString(pr.HaftalıkUcret);

            nb.NMesai = double.Parse(txtNGM.Text);
            nb.NMesai = (1.5 * nb.NMesai) * nb.SaatlikUcret;

            nb.HTMesai = double.Parse(txtHTM.Text);
            nb.HTMesai = (1.5 * nb.HTMesai) * nb.SaatlikUcret;

            nb.RBMesai = double.Parse(txtRBM.Text);
            nb.RBMesai = (1 * nb.RBMesai) * nb.SaatlikUcret;

            nb.DBMesai = double.Parse(txtDBM.Text);
            nb.DBMesai = (1 * nb.DBMesai) * nb.SaatlikUcret;

            nb.MesaiToplam = nb.NMesai + nb.RBMesai + nb.HTMesai + nb.DBMesai;
            txtMT.Text = Convert.ToString(nb.MesaiToplam);

            nb.GünSayısı = double.Parse(txtGünSayısı.Text);


        

            nb.ToplamBrüt = Math.Round((nb.MesaiToplam + nb.BrutMaas), 2);
            txtToplamBrüt.Text = Convert.ToString(nb.ToplamBrüt);

            nb.SgkIsciPayi = Math.Round((((nb.ToplamBrüt * 0.14) / 30) * nb.GünSayısı), 2);
            txtSgk1.Text = Convert.ToString(nb.SgkIsciPayi);

            nb.IssizlikSigortIsciPayıi = Math.Round((nb.ToplamBrüt * 0.01 / 30 * nb.GünSayısı), 2);
            txtIssızlık.Text = Convert.ToString(nb.IssizlikSigortIsciPayıi);

            if (nb.ToplamBrüt > asgariBrüt)
            {
                nb.GelirVergisiMatrahıi = Math.Round((nb.ToplamBrüt - (nb.SgkIsciPayi + nb.IssizlikSigortIsciPayıi)), 2);
                txtGVM.Text = Convert.ToString(nb.GelirVergisiMatrahıi);

                nb.GelirVergisiKesintisi = Math.Round((nb.GelirVergisiMatrahıi * 0.15), 2);
                txtGVKe.Text = Convert.ToString(nb.GelirVergisiKesintisi);

                nb.AsgariUcretGelırVergısıKesintisi = Math.Round((asgariNet * 0.15), 2);
                txtAGVK.Text = Convert.ToString(nb.AsgariUcretGelırVergısıKesintisi);

                nb.OdenecekGelırVergısı = Math.Round((nb.GelirVergisiKesintisi - nb.AsgariUcretGelırVergısıKesintisi), 2);
                txtOGV.Text = Convert.ToString(nb.OdenecekGelırVergısı);


                nb.AsgariUcretDamgaVergisi = Math.Round((((asgariBrüt * 0.00759) / 30) * nb.GünSayısı), 2);
                txtAUDVK.Text = Convert.ToString(nb.AsgariUcretDamgaVergisi);

                nb.DamgaVergisi = Math.Round((nb.ToplamBrüt * 0.00759), 2);
                txtDV.Text = Convert.ToString(nb.DamgaVergisi);

                nb.OdenecekDamgaVergisi = Math.Round((nb.DamgaVergisi - nb.AsgariUcretDamgaVergisi), 2);
                txtODV.Text = Convert.ToString(nb.OdenecekDamgaVergisi);

                nb.ToplamKesilenVergi = Math.Round((nb.SgkIsciPayi + nb.IssizlikSigortIsciPayıi + nb.OdenecekGelırVergısı + nb.OdenecekDamgaVergisi), 2);
                txtToplamV.Text = Convert.ToString(nb.ToplamKesilenVergi);



                if (cmbxDerece.SelectedText == "1")
                {
                    nb.GelirVergisiMatrahıi = nb.GelirVergisiMatrahıi - 2000;
                    txtGVM.Text = Convert.ToString(nb.GelirVergisiMatrahıi);

                    nb.GelirVergisiKesintisi = nb.GelirVergisiKesintisi * 0.15;
                    txtGVKe.Text = Convert.ToString(nb.GelirVergisiKesintisi);

                    nb.OdenecekGelırVergısı = nb.GelirVergisiKesintisi - nb.AsgariUcretGelırVergısıKesintisi;
                    txtOGV.Text = Convert.ToString(nb.OdenecekGelırVergısı);

                    nb.ToplamKesilenVergi = nb.SgkIsciPayi + nb.IssizlikSigortIsciPayıi + nb.OdenecekGelırVergısı + nb.OdenecekDamgaVergisi;
                    txtToplamV.Text = Convert.ToString(nb.ToplamKesilenVergi);

                }

                if (cmbxDerece.SelectedText == "2")
                {
                    nb.GelirVergisiMatrahıi = nb.GelirVergisiMatrahıi - 1170;
                    txtGVM.Text = Convert.ToString(nb.GelirVergisiMatrahıi);

                    nb.GelirVergisiKesintisi = nb.GelirVergisiKesintisi * 0.15;
                    txtGVKe.Text = Convert.ToString(nb.GelirVergisiKesintisi);

                    nb.OdenecekGelırVergısı = nb.GelirVergisiKesintisi - nb.AsgariUcretGelırVergısıKesintisi;
                    txtOGV.Text = Convert.ToString(nb.OdenecekGelırVergısı);

                    nb.ToplamKesilenVergi = nb.SgkIsciPayi + nb.IssizlikSigortIsciPayıi + nb.OdenecekGelırVergısı + nb.OdenecekDamgaVergisi;
                    txtToplamV.Text = Convert.ToString(nb.ToplamKesilenVergi);


                }

                if (cmbxDerece.SelectedText == "3")
                {
                    nb.GelirVergisiMatrahıi = nb.GelirVergisiMatrahıi - 500;
                    txtGVM.Text = Convert.ToString(nb.GelirVergisiMatrahıi);

                    nb.GelirVergisiKesintisi = nb.GelirVergisiKesintisi * 0.15;
                    txtGVKe.Text = Convert.ToString(nb.GelirVergisiKesintisi);

                    nb.OdenecekGelırVergısı = nb.GelirVergisiKesintisi - nb.AsgariUcretGelırVergısıKesintisi;
                    txtOGV.Text = Convert.ToString(nb.OdenecekGelırVergısı);

                    nb.ToplamKesilenVergi = nb.SgkIsciPayi + nb.IssizlikSigortIsciPayıi + nb.OdenecekGelırVergısı + nb.OdenecekDamgaVergisi;
                    txtToplamV.Text = Convert.ToString(nb.ToplamKesilenVergi);

                }

                if (cmbxEmekli.SelectedText == "Evet")
                {
                    nb.SgkIsciPayi = nb.ToplamBrüt * 0.075;
                    txtSgk1.Text = Convert.ToString(nb.SgkIsciPayi);

                    nb.IssizlikSigortIsciPayıi = 0;
                    txtIssızlık.Text = Convert.ToString(nb.IssizlikSigortIsciPayıi);

                    nb.GelirVergisiMatrahıi = nb.ToplamBrüt - nb.SgkIsciPayi;
                    txtGVM.Text = Convert.ToString(nb.GelirVergisiMatrahıi);


                    nb.GelirVergisiKesintisi = 0;
                    txtGVKe.Text = Convert.ToString(nb.GelirVergisiKesintisi);

                    nb.AsgariUcretGelırVergısıKesintisi = asgariBrüt * 0.075;
                    txtAGVK.Text = Convert.ToString(nb.AsgariUcretGelırVergısıKesintisi);

                    nb.OdenecekGelırVergısı = nb.SgkIsciPayi;
                    txtOGV.Text = Convert.ToString(nb.OdenecekGelırVergısı);

                    nb.DamgaVergisi = 0;
                    txtDV.Text = Convert.ToString(nb.DamgaVergisi);

                    nb.ToplamKesilenVergi = Math.Round((nb.SgkIsciPayi + nb.IssizlikSigortIsciPayıi + nb.OdenecekGelırVergısı + nb.OdenecekDamgaVergisi), 2);
                    txtToplamV.Text = Convert.ToString(nb.ToplamKesilenVergi);
                }

            }
            else
            {
                nb.SgkIsciPayi = Math.Round((((nb.ToplamBrüt * 0.14) / 30) * nb.GünSayısı), 2);
                txtSgk1.Text = Convert.ToString(nb.SgkIsciPayi);

                nb.IssizlikSigortIsciPayıi = Math.Round((nb.ToplamBrüt * 0.01 / 30 * nb.GünSayısı), 2);
                txtIssızlık.Text = Convert.ToString(nb.IssizlikSigortIsciPayıi);

                nb.GelirVergisiMatrahıi = Math.Round((nb.ToplamBrüt - nb.SgkIsciPayi - nb.IssizlikSigortIsciPayıi), 2);
                txtGVM.Text = Convert.ToString(nb.GelirVergisiMatrahıi);

                nb.GelirVergisiKesintisi = 0;
                txtGVKe.Text = Convert.ToString(nb.GelirVergisiKesintisi);

                nb.AsgariUcretGelırVergısıKesintisi = Math.Round((asgariNet * 0.15), 2);
                txtAGVK.Text = Convert.ToString(nb.AsgariUcretGelırVergısıKesintisi);

                nb.OdenecekGelırVergısı = 0;
                txtOGV.Text = Convert.ToString(pr.OdenecekGelırVergısı);

                nb.AsgariUcretDamgaVergisi = Math.Round((((nb.ToplamBrüt * 0.00759) / 30) * nb.GünSayısı), 2);
                txtAUDVK.Text = Convert.ToString(nb.AsgariUcretDamgaVergisi);

                nb.DamgaVergisi = Math.Round((nb.ToplamBrüt * 0.00759), 2);
                txtDV.Text = Convert.ToString(nb.DamgaVergisi);

                nb.OdenecekDamgaVergisi = 0;
                txtODV.Text = Convert.ToString(nb.OdenecekDamgaVergisi);

                nb.ToplamKesilenVergi = Math.Round((nb.SgkIsciPayi + nb.IssizlikSigortIsciPayıi));
                txtToplamV.Text = Convert.ToString(nb.ToplamKesilenVergi);


            }        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbxDerece.Text = "0";

        }

        private void btnBordo_Click_1(object sender, EventArgs e)
        {
            sidePanel.Height = btnBordo.Height;
            sidePanel.Top = btnBordo.Top;
            pnlOrta.Controls.Clear();
            pnlOrta.Controls.Add(pnlHesaplamaB);

        }

        private void btnPuantaj_Click_1(object sender, EventArgs e)
        {
            pnlOrta.Controls.Clear();
            sidePanel.Height = btnPuantaj.Height;
            sidePanel.Top = btnPuantaj.Top;
            PuantajB puantajB = new PuantajB();
            puantajB.MdiParent = this;
            puantajB.FormBorderStyle = FormBorderStyle.None;
            pnlOrta.Controls.Add(puantajB);
            puantajB.Show();

        }

        private void btnKimlik_Click_1(object sender, EventArgs e)
        {
            pnlOrta.Controls.Clear();
            sidePanel.Height = btnKimlik.Height;
            sidePanel.Top = btnKimlik.Top;
            KimlikBilgileri kimlikBilgileri = new KimlikBilgileri();
            kimlikBilgileri.MdiParent = this;
            kimlikBilgileri.FormBorderStyle = FormBorderStyle.None;
            pnlOrta.Controls.Add(kimlikBilgileri);
            kimlikBilgileri.Show();
        }

        private void btnTablo_Click(object sender, EventArgs e)
        {

            pnlOrta.Controls.Clear();
            sidePanel.Height = btnTablo.Height;
            sidePanel.Top = btnTablo.Top;
            HesaplamaSonuc hesaplama = new HesaplamaSonuc();
            hesaplama.MdiParent = this;
            hesaplama.FormBorderStyle = FormBorderStyle.None;
            pnlOrta.Controls.Add(hesaplama);
            hesaplama.Show();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        { 
            sidePanel.Height = btnBordo.Height;
            sidePanel.Top = btnBordo.Top;

            cmbxHesapT.SelectedIndex = 0;
            cmbxStatu.Text = "Özel";
            cmbxEngelli.Text = "Hayır";
            cmbxDerece.Text = "0";
            cmbxEmekli.Text = "Hayır";
            txtGünSayısı.Text = "30";
            txtMT.Text = "0";
            txtRBM.Text = "0";
            txtDBM.Text = "0";
            txtHTM.Text = "0";
            txtNGM.Text = "0";

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {


            if (cmbxHesapT.SelectedIndex == 0)
            {
                brüttenNeteHesaplama();
                texp.SeciliTercih = false;

            }
            else if (cmbxHesapT.SelectedIndex == 1)
            {
                netttenBrüteHesaplama();
                texp.SeciliTercih = true;
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {

            temzile();
            HesaplamaSonuc hsp = new HesaplamaSonuc();
            hsp.bNet.DataSource = null;
        }

        private void cmbxHesapT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbxHesapT.SelectedIndex == 0)
            {
                lblHesapTür.Text = "Brüt Ücret Giriniz:";

            }
            else if (cmbxHesapT.SelectedIndex == 1)
            {
                lblHesapTür.Text = "Net Ücret Giriniz:";
            }
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlOrta.Controls.Clear();
            sidePanel.Height = button1.Height;
            sidePanel.Top = button1.Top;
            Employees emp = new Employees();
            emp.MdiParent = this;
            emp.FormBorderStyle = FormBorderStyle.None;
            pnlOrta.Controls.Add(emp);
            emp.Show();
        }

        void texboxParamtres()
        {
            t1.SicilNo = double.Parse(txtSciliNo.Text);
            t1.HesapTuru = cmbxHesapT.Text;
            t1.BrutUcret = double.Parse(txtBrütÜcret.Text);
            t1.Statu = cmbxStatu.Text;
            t1.EngelliDurum = cmbxEngelli.Text;
            t1.EngelliDerece = cmbxDerece.Text;
            t1.EmekliDurum = cmbxEmekli.Text;
            t1.GunSayisi = double.Parse(txtGünSayısı.Text);
            t1.NormalGunSayisi = double.Parse(txtNGM.Text);
            t1.HaftalıkTatil = double.Parse(txtHTM.Text);
            t1.ResmiBayramTatili = double.Parse(txtRBM.Text);
            t1.DiniBayramTatili = double.Parse(txtDBM.Text);
            t1.SaatlikUcret = double.Parse(txtSaatlik.Text);
            t1.GunlukUcret = double.Parse(txtGünlük.Text);
            t1.HaftalikUcret = double.Parse(txtHaftalık.Text);
            t1.MesaiToplam = double.Parse(txtMT.Text);
            t1.ToplamBrut = double.Parse(txtToplamBrüt.Text);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            texboxParamtres();
            databaseLogic.DBKaydet(con);
            MessageBox.Show("Kaydetme İşlemi gerçekleştirildi !");
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            databaseLogic.DBGuncelle(con);
            MessageBox.Show("Güncelleme işlemi gerçekleştirildi!");
        }

        private void smplbtnSil_Click(object sender, EventArgs e)
        {
            databaseLogic.DBDelete(con);
            MessageBox.Show("Silme işlemi gerçekleştirildi!");
        }
    }
}
