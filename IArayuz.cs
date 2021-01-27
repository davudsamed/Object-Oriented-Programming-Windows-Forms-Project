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
    interface IArayuz
    {
        int Can { get; set; }

        int Urun { get; set; }

        int YemVer();

    }
}