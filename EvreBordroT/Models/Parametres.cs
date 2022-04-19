using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvreBordroT
{
    public class Parametres
    {
        public double BrutMaas { get; set; }

        public double NettenMaas { get; set; }

        public double SgkIsciPayi { get; set; }

        public double IssizlikSigortIsciPayıi { get; set; }

        public double GelirVergisiMatrahıi { get; set; }

        public double GelirVergisiKesintisi { get; set; }

        public double GünSayısı { get; set; }

        public double AsgariUcretDamgaVergisi { get; set; }

        public double DamgaVergisi { get; set; }

        public double OdenecekDamgaVergisi { get; set; }

        public double AsgariUcretGelırVergısıKesintisi { get; set; }

        public double OdenecekGelırVergısı { get; set; }  

        public double KulatifVergiMatrahi { get; set; }

        public double ToplamKesilenVergi { get; set; }

        public double NetMaas { get; set; }

        public double AsgariGecimIndirimi { get; set; }

        public double SaatlikUcret { get; set; }

        public double GunlukUcret { get; set; }

        public double HaftalıkUcret { get; set; }

        public double NMesai { get; set; }

        public double HTMesai { get; set; }

        public double RBMesai { get; set; }

        public double DBMesai { get; set; }

        public double MesaiToplam { get; set; }

        public double ToplamBrüt { get; set; }
    }
    
    public class TextBoX
    {
        public string Statü { get; set; }

        public string EngellilikDurumu { get; set; }

        public double EngellilikDerece { get; set; }

        public string EmeklilikDurumu { get; set; }

        public bool SeciliTercih { get; set; } 

    }
    
}
