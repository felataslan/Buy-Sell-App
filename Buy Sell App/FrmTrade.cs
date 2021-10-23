using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Exchange_App
{
    public partial class FrmTrade : Form
    {
        public static string Bakiye, Arpa, Bugday, Pamuk;

        public FrmTrade()
        {
            InitializeComponent();
            sidePanel.Height = btnVarlikEkle.Height;
            sidePanel.Top = btnVarlikEkle.Top;
            userControlVarlikEkle1.BringToFront();
            labelGuncelle();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-2BOGKJG;Initial Catalog=yazilimYapimi;Integrated Security=True");

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVarlikEkle_Click(object sender, EventArgs e)
        {
            sidePanel.Height = btnVarlikEkle.Height;
            sidePanel.Top = btnVarlikEkle.Top;
            userControlVarlikEkle1.BringToFront();
        }

        private void btnTrade_Click(object sender, EventArgs e)
        {
            sidePanel.Height = btnTrade.Height;
            sidePanel.Top = btnTrade.Top;
            userControlAlimSatim1.BringToFront();
        }

        private void btnRapor_Click(object sender, EventArgs e)
        {
            sidePanel.Height = btnRapor.Height;
            sidePanel.Top = btnRapor.Top;
            userControlRapor1.BringToFront();
        }


        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            labelGuncelle();
        }

        // labellardaki kullanıcı bilgisinin güncellenmesi
        public void labelGuncelle()
        {
            kullaniciBilgiBul();
            lblid.Text = FrmLogin.id;
            lblKullaniciAdi.Text = FrmLogin.kullaniciAdi;
            lblBakiye.Text = Bakiye;
            lblPamuk.Text = Pamuk;
            lblArpa.Text = Arpa;
            lblBugday.Text = Bugday;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmLogin frmlogin = new FrmLogin();
            frmlogin.Show();
            this.Close();
        }


        public void kullaniciBilgiBul()
        {
            arpaBul();
            bugdayBul();
            pamukBul();
            bakiyeBul();
        }
 
        private void arpaBul()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select KO.ogeMiktar from Kullanicilar K inner join  KullaniciOgeleri Ko on K.kullaniciID=Ko.kullaniciID where K.kullaniciAdi=@p1 and Ko.ogeID=1", baglanti);
            komut.Parameters.AddWithValue("@p1", FrmLogin.kullaniciAdi);
            if (komut.ExecuteScalar() == null)
            {
                Arpa = "0";
            }
            else
            {
                Arpa = komut.ExecuteScalar().ToString();
            }
            baglanti.Close();

        }


        private void bugdayBul()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select KO.ogeMiktar from Kullanicilar K inner join  KullaniciOgeleri Ko on K.kullaniciID=Ko.kullaniciID where K.kullaniciAdi=@p1 and Ko.ogeID=2", baglanti);
            komut.Parameters.AddWithValue("@p1", FrmLogin.kullaniciAdi);
            if (komut.ExecuteScalar() == null)
            {
                Bugday = "0";
            }
            else
            {
                Bugday = komut.ExecuteScalar().ToString();
            }
            baglanti.Close();
        }
        private void pamukBul()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select KO.ogeMiktar from Kullanicilar K inner join  KullaniciOgeleri Ko on K.kullaniciID=Ko.kullaniciID where K.kullaniciAdi=@p1 and Ko.ogeID=3", baglanti);
            komut.Parameters.AddWithValue("@p1", FrmLogin.kullaniciAdi);
            if (komut.ExecuteScalar() == null)
            {
                Pamuk = "0";
            }
            else
            {
                Pamuk = komut.ExecuteScalar().ToString();
            }
            baglanti.Close();
        }
        private void bakiyeBul()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select KO.ogeMiktar from Kullanicilar K inner join  KullaniciOgeleri Ko on K.kullaniciID=Ko.kullaniciID where K.kullaniciAdi=@p1 and Ko.ogeID=4", baglanti);
            komut.Parameters.AddWithValue("@p1", FrmLogin.kullaniciAdi);
            if (komut.ExecuteScalar() == null)
            {
                Bakiye = "0";
            }
            else
            {
                Bakiye = komut.ExecuteScalar().ToString();
            }
            baglanti.Close();
        }
    }
}
