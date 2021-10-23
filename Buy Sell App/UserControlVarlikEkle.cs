using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using System.Data.SqlClient;

namespace Exchange_App
{
    
    public partial class UserControlVarlikEkle : UserControl
    {
        private string dolar, euro, sterlin;
        
        public UserControlVarlikEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-2BOGKJG;Initial Catalog=yazilimYapimi;Integrated Security=True");

        private void btnVarlikEkle_Click(object sender, EventArgs e)
        {
            dovizKuruGetir();
            if(cmbVarlik.Text == "ARPA")
            {
                adminOnayinaGonder("1");
            }
            else if(cmbVarlik.Text =="BUĞDAY")
            {
                adminOnayinaGonder("2");
            }
            else if (cmbVarlik.Text == "PAMUK")
            {
                adminOnayinaGonder("3");
            }
            else if (cmbVarlik.Text == "TL")
            {
                adminOnayinaGonder("4");
            }
            else if (cmbVarlik.Text == "USD")
            {
                kurHesapla(dolar);
                adminOnayinaGonder("4");
            }
            else if (cmbVarlik.Text == "EURO")
            {
                kurHesapla(euro);
                adminOnayinaGonder("4");
            }
            else if (cmbVarlik.Text == "POUND")
            {
                kurHesapla(sterlin);
                adminOnayinaGonder("4");
            }
        }

        private void adminOnayinaGonder(string ogeID)
        { 
            baglanti.Open();
            SqlCommand komutEkle = new SqlCommand("insert into KullaniciOnay (kullaniciID,ogeID,ogeMiktar)values(@p1,@p2,@p3)", baglanti);
            komutEkle.Parameters.AddWithValue("@p1", FrmLogin.id);
            komutEkle.Parameters.AddWithValue("@p2", ogeID);
            komutEkle.Parameters.AddWithValue("@p3", txtMiktar.Text);
            komutEkle.ExecuteNonQuery();
            baglanti.Close();
        }

        private void kurHesapla(string kur)
        {
            double sonTutar;
            sonTutar = Convert.ToDouble(txtMiktar.Text) * Convert.ToDouble(kur);
            txtMiktar.Text = sonTutar.ToString();
        }

        //Döviz kurunu webden çeker
        private void dovizKuruGetir()
        {
            WebProxy wb = new WebProxy(WebProxy.GetDefaultProxy().Address);


            WebClient wc = new WebClient();
            wc.Proxy = wb;
            string site = wc.DownloadString("https://www.tcmb.gov.tr/kurlar/today.xml");

            XmlDocument xd = new XmlDocument();
            xd.LoadXml(site);

            XmlNodeList liste = xd.SelectNodes("Tarih_Date/Currency");

            foreach (XmlNode item in liste)
            {
                string parabirimi = item["CurrencyName"].InnerText;
                string alis = item["ForexBuying"] == null ? " " : item["ForexBuying"].InnerText;
                string satis = item["ForexSelling"] == null ? " " : item["ForexSelling"].InnerText;

                if (parabirimi == "US DOLLAR")
                {
                    dolar = alis;
                    dolar = dolar.Replace(".", ",");
                }
                else if (parabirimi == "EURO")
                {
                    euro = alis;
                    euro = euro.Replace(".", ",");
                }
                else if (parabirimi == "POUND STERLING")
                {
                    sterlin = alis;
                    sterlin = sterlin.Replace(".", ",");
                }


            }
        }
    }
}
