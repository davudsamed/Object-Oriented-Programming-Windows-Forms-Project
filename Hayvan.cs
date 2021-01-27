/****************************************************************************
**					    SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					    2018-2019 BAHAR DÖNEMİ
**	
**				             PROJE ÖDEVİ
**				ÖĞRENCİ ADI............: Davud Samed Tombul
**				ÖĞRENCİ NUMARASI.......: B171210007
**              DERSİN ALINDIĞI GRUP...: 1D
****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1D_B171210007_NDP_Proje
{
    abstract class Hayvan : IArayuz
    {
        public int Can { get; set; }

        public int Urun { get; set; }

        public Hayvan()
        {
            Can = 100;
            Urun = 0;
        }

        public abstract int YemVer();


        public string KasaYazdır(int tutar)
        {
            string kasa = Convert.ToString(tutar) + " TL ";
            return kasa;
        }
    }
}
