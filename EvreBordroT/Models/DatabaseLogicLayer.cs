using Devart.Data.Oracle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvreBordroT.Models
{
    public class DatabaseLogicLayer
    {
       public void DBKaydet(OracleConnection con)
        {
            string CommandText = "INSERT INTO HesapTablo(SICIL_NO," +
                "HESAPLAMA_TURU," +
                "UCRET," +
                "STATU," +
                "ENGELLILIK_DURUMU," +
                "ENGELLILIK_DERECE," +
                "EMEKLILIK_DURUMU," +
                "CALISTIGI_GUN," +
                "NORMAL_GUN_MESAI," +
                "HAFTA_TATILI_MESAI," +
                "RESMI_BAYRAM_MESAI," +
                "DINI_BAYRAM_MESAI," +
                "SAATLIK_UCRET," +
                "GUNLUK_UCRET," +
                "HAFTALIK_UCRET," +
                "MESAI_TOPLAM," +
                "TOPLAM_NET)" +
                "VALUES (:a,:b,:c,:d,:e,:f,:g,:h,:j,:k,:l,:m,:n,:s,:o,:u,:v)";
            con.Open();
            OracleCommand cmd = new OracleCommand(CommandText, con);
            cmd.Parameters.Add("a", Form1.t1.SicilNo.ToString());
            cmd.Parameters.Add("b",Form1.t1.HesapTuru.ToString());
            cmd.Parameters.Add("c",Form1.t1.BrutUcret.ToString());
            cmd.Parameters.Add("d",Form1.t1.Statu.ToString());
            cmd.Parameters.Add("e",Form1.t1.EngelliDurum.ToString());
            cmd.Parameters.Add("f",Form1.t1.EngelliDerece.ToString());
            cmd.Parameters.Add("g",Form1.t1.EmekliDurum.ToString());
            cmd.Parameters.Add("h",Form1.t1.GunSayisi.ToString());
            cmd.Parameters.Add("j",Form1.t1.NormalGunSayisi.ToString());
            cmd.Parameters.Add("k",Form1.t1.HaftalıkTatil.ToString());
            cmd.Parameters.Add("l",Form1.t1.ResmiBayramTatili.ToString());
            cmd.Parameters.Add("m",Form1.t1.DiniBayramTatili.ToString());
            cmd.Parameters.Add("n",Form1.t1.SaatlikUcret.ToString());
            cmd.Parameters.Add("s",Form1.t1.GunlukUcret.ToString());
            cmd.Parameters.Add("o",Form1.t1.HaftalikUcret.ToString());
            cmd.Parameters.Add("u",Form1.t1.MesaiToplam.ToString());
            cmd.Parameters.Add("v", Form1.t1.ToplamBrut.ToString()); 
            cmd.ExecuteNonQuery();
            con.Close();
        }


       public void DBGuncelle(OracleConnection con)
        {
            string CommandText = "UPDATE HesapTablo SET SICIL_NO='" + Form1.t1.SicilNo + "'," +
                "HESAPLAMA_TURU='" + Form1.t1.HesapTuru + "'," +
                "UCRET='" + Form1.t1.BrutUcret + "'," +
                "STATU='" + Form1.t1.Statu + "'," +
                "ENGELLILIK_DURUMU='" + Form1.t1.EngelliDurum + "'," +
                "ENGELLILIK_DERECE='" + Form1.t1.EngelliDerece + "'," +
                "EMEKLILIK_DURUMU='" + Form1.t1.EmekliDurum + "'," +
                "CALISTIGI_GUN='" + Form1.t1.GunSayisi + "'," +
                "NORMAL_GUN_MESAI='" + Form1.t1.NormalGunSayisi + "'," +
                "HAFTA_TATILI_MESAI='" + Form1.t1.HaftalıkTatil + "'," +
                "RESMI_BAYRAM_MESAI='" + Form1.t1.ResmiBayramTatili + "'," +
                "DINI_BAYRAM_MESAI='" + Form1.t1.DiniBayramTatili + "'," +
                "SAATLIK_UCRET='" + Form1.t1.SaatlikUcret + "'," +
                "GUNLUK_UCRET='" + Form1.t1.GunlukUcret + "'," +
                "HAFTALIK_UCRET='" + Form1.t1.HaftalikUcret + "'," +
                "MESAI_TOPLAM='" + Form1.t1.MesaiToplam + "'," +
                "TOPLAM_NET='" + Form1.t1.ToplamBrut + "' WHERE SICIL_NO='" + Form1.t1.SicilNo + "'";
            con.Open();
            OracleCommand command = new OracleCommand(CommandText, con);
            command.ExecuteNonQuery();
            con.Close();

        }

        public void DBDelete(OracleConnection con)
        {
            string CommandText = "DELETE FROM HesapTablo WHERE SICIL_NO='" + Form1.t1.SicilNo + "'";
            con.Open();
            OracleCommand cmd = new OracleCommand(CommandText, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
