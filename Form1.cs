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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace _1D_B171210007_NDP_Proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Nesneler oluşturuluyor
        Keci keci = new Keci();
        Tavuk tavuk = new Tavuk();
        Ordek ordek = new Ordek();
        Inek inek = new Inek();

        private void Form1_Load(object sender, EventArgs e)//Form yüklendiğinde çalışacak fonksiyon ve ayarlamalar yapılıyor.
        {
            OrdekProgressBar.Value = ordek.Can;
            TavukProgressBar.Value = tavuk.Can;
            InekProgressBar.Value = keci.Can;
            KeciProgressBar.Value = inek.Can;

            timer1.Start();
        }

        int kasa = 0;
        int saniye = 0;


        /*  Zamanın ilerlemesi, hayvanların canlarının azalması ve ölmesi gibi olaylar zamana bağlı oldukları için 
          bunlarla ilgili fonksiyon ve ifadeler timer kontrolünün ilgili kısmına yazılıyor. */
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            timerlbl.Text = (Convert.ToString(saniye) + " SN");
            saniye++;

            if (inek.Can > 4)//İneğin canının 4 ten büyük olduğu durumlarda çalışır.
            {
                if (saniye % 8 == 0)//8 saniyede bir süt üretmeyi düzenlemek amacıyla if kullanılıyor.
                {
                    inek.Urun++;
                    InekSutLbl.Text = Convert.ToString(inek.Urun) + " Adet";
                }
                inek.Can -= 8;
                InekProgressBar.Value = inek.Can;
            }
            else if (inek.Can == 4)//İneğin canının 4 olduğu durum bizim için özel bir durumdur çünkü bir sonraki aşamada öleceği için farklı kontroller gerekir.
            {
                inek.Can = 0;
                InekProgressBar.Value = inek.Can;
                InekHayatLbl.Text = "ÖLÜ";
                SoundPlayer ses = new SoundPlayer();//İnek sesi yükleniyor.
                string dizin = Application.StartupPath + "\\inek.wav";
                ses.SoundLocation = dizin;
                ses.Play();
            }

            if (tavuk.Can > 2)
            {
                if (saniye % 3 == 0)
                {
                    tavuk.Urun++;
                    TavukYumurtaLbl.Text = Convert.ToString(tavuk.Urun) + " Adet";
                }
                tavuk.Can -= 2;
                TavukProgressBar.Value = tavuk.Can;
            }
            else if (tavuk.Can == 2)
            {
                tavuk.Can = 0;
                TavukProgressBar.Value = tavuk.Can;
                TavukHayatLbl.Text = "ÖLÜ";
                SoundPlayer ses = new SoundPlayer();
                string dizin = Application.StartupPath + "\\tavuk.wav";
                ses.SoundLocation = dizin;
                ses.Play();
            }

            if (keci.Can > 4)
            {
                if (saniye % 7 == 0)
                {
                    keci.Urun++;
                    KeciSutLbl.Text = Convert.ToString(keci.Urun) + " Adet";
                }
                keci.Can -= 6;
                KeciProgressBar.Value = keci.Can;
            }
            else if (KeciProgressBar.Value == 4)
            {
                keci.Can = 0;
                KeciProgressBar.Value = keci.Can;
                KeciHayatLbl.Text = "ÖLÜ";
                SoundPlayer ses = new SoundPlayer();
                string dizin = Application.StartupPath + "\\keci.wav";
                ses.SoundLocation = dizin;
                ses.Play();
            }

            if (ordek.Can > 1)
            {
                if (saniye % 5 == 0)
                {
                    ordek.Urun++;
                    OrdekYumurtaLbl.Text = Convert.ToString(ordek.Urun) + " Adet";
                }
                ordek.Can -= 3;
                OrdekProgressBar.Value = ordek.Can;
            }
            else if (ordek.Can == 1)
            {
                ordek.Can = 0;
                OrdekProgressBar.Value = ordek.Can;
                OrdekHayatLbl.Text = "ÖLÜ";
                SoundPlayer ses = new SoundPlayer();
                string dizin = Application.StartupPath + "\\ordek.wav";
                ses.SoundLocation = dizin;
                ses.Play();
            }
        }

        private void TavukYSatButon_Click_1(object sender, EventArgs e)//Tavuk yumurtasını satmak için ilgili butona basıldığında çalışan kodlar.
        {
            kasa += tavuk.Urun * 1; //Kasaya tavuk yumurtasının birim fiyatı ile yumurta sayısı çarpımı kadar para ekleniyor.
            tavuk.Urun = 0;         //Ürünler satıldığı için sıfırlanıyor.
            TavukYumurtaLbl.Text = "0 Adet";
            KasaLbl.Text = tavuk.KasaYazdır(kasa); //Kasa label'ine mevcut para yazılıyor.
        }

        private void OrdekYSatButon_Click_1(object sender, EventArgs e)
        {
            kasa += ordek.Urun * 3;
            ordek.Urun = 0;
            OrdekYumurtaLbl.Text = "0 Adet";
            KasaLbl.Text = ordek.KasaYazdır(kasa);

        }

        private void InekSSatButon_Click_1(object sender, EventArgs e)
        {
            kasa += inek.Urun * 5;
            inek.Urun = 0;
            InekSutLbl.Text = "0 Adet";
            KasaLbl.Text = inek.KasaYazdır(kasa);
        }

        private void KeciSSatButon_Click_1(object sender, EventArgs e)
        {
            kasa += keci.Urun * 8;
            keci.Urun = 0;
            KeciSutLbl.Text = "0 Adet";
            KasaLbl.Text = keci.KasaYazdır(kasa);
        }

        private void TavukYemButon_Click_1(object sender, EventArgs e)//Tavuğun yem verme butonuna basıldığında çalışan kodlarımız burada yer alıyor.
        {
            if (tavuk.Can > 0)//Tavuğun can değerinin 0 dan fazla olduğu yani tavuğun canlı olduğu esnada butona basılması durumunda if içerisindeki kodlar çalışıyor.
            {
                tavuk.YemVer();//Oluşturduğumuz nesnedeki YemVer fonksiyonu çalıştırılarak yem verme olayı gerçekleştiriliyor.
                TavukProgressBar.Value = tavuk.Can; //Tavuğun can değeri ilgili progress bara değer olarak atanıyor.
            }
            else//Tavuk ölüyken aşağıdaki kodlar çalışıyor.
            {
                tavuk.Can = 0;
                TavukProgressBar.Value = tavuk.Can;
            }
        }

        private void OrdekYemButon_Click_1(object sender, EventArgs e)
        {
            if (ordek.Can > 0)
            {
                ordek.YemVer();
                OrdekProgressBar.Value = ordek.Can;
            }
            else
            {
                ordek.Can = 0;
                OrdekProgressBar.Value = ordek.Can;
            }
        }

        private void InekYemButon_Click_1(object sender, EventArgs e)
        {
            if (inek.Can > 0)
            {
                inek.YemVer();
                InekProgressBar.Value = inek.Can;
            }
            else
            {
                inek.Can = 0;
                InekProgressBar.Value = inek.Can;
            }
        }

        private void KeciYemButon_Click_1(object sender, EventArgs e)
        {
            if (keci.Can > 0)
            {
                keci.YemVer();
                KeciProgressBar.Value = keci.Can;
            }
            else
            {
                keci.Can = 0;
                KeciProgressBar.Value = keci.Can;
            }
        }
    }
}
