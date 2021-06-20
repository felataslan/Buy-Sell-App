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
    public partial class FrmLogin : Form
    {
        bool admin;
        bool kontrol;
        public static string id, kullaniciAdi,Bakiye,Arpa,Bugday,Pamuk;

        public FrmLogin()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-2BOGKJG;Initial Catalog=yazilimYapimi;Integrated Security=True");

        // Exit butonu
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Kayıt olma formunun açılması
        private void lblSignUp_Click(object sender, EventArgs e)
        {
            FrmSignUp signUp = new FrmSignUp();
            signUp.Show();
            this.Close();
        }

        // Giriş Yapma butonu
        private void btnLogin_Click(object sender, EventArgs e)
        {
            girisKontrol();
            
            if (kontrol == true)
            {
                //Admin formu
                if (admin)
                {
                    FrmAdmin frmAdmin = new FrmAdmin();
                    frmAdmin.Show();
                    this.Hide();
                }
                //Trade formu
                else
                {
                    FrmTrade trade = new FrmTrade();
                    trade.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız!");
            }
        }

        // Kullanıcı giriş bilgilerinin kontrolü
        private void girisKontrol()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select k.kullaniciAdi, k.kullaniciParola, Kt.kullanicitipAdi from Kullanicilar k inner join KullaniciTipleri Kt on k.kullaniciID = kt.kullaniciID Where k.kullaniciAdi=@p1 and k.kullaniciParola=@p2 and Kt.kullanicitipAdi=@p3", baglanti);
            komut.Parameters.AddWithValue("@p1",txtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2",textPassword.Text);
            SqlDataReader dr;

            if (ckbAdmin.Checked)
            {
                komut.Parameters.AddWithValue("@p3", "admin");
                dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    admin = true;
                    kontrol = true;
                }
                else
                {
                    kontrol = false;
                }
            }
            else
            {
                komut.Parameters.AddWithValue("@p3", "user");
                dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    admin = false;
                    kontrol = true;
                    baglanti.Close();
                    kullaniciBilgiBul();
                }
                else
                {
                    kontrol = false;
                }
            }

            baglanti.Close();
        }

        public void kullaniciBilgiBul()
        {
            idBul();
            arpaBul();
            bugdayBul();
            pamukBul();
            bakiyeBul();
        }
        private void idBul()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select kullaniciID from Kullanicilar where kullaniciAdi=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
            id = komut.ExecuteScalar().ToString();
            baglanti.Close();
            kullaniciAdi = txtKullaniciAdi.Text;
        }

        private void arpaBul()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select KO.ogeMiktar from Kullanicilar K inner join  KullaniciOgeleri Ko on K.kullaniciID=Ko.kullaniciID where K.kullaniciAdi=@p1 and Ko.ogeID=1", baglanti);
            komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
            if(komut.ExecuteScalar()== null)
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
            komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
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
            komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
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
            komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
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


        /*private void datatableOlustur()
        {
            idBul();
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select k.kullaniciID, k.kullaniciAdi,O.ogeAdi,KO.ogeMiktar from Kullanicilar K inner join KullaniciOgeleri KO on K.kullaniciID=KO.kullaniciID inner join Ogeler O on O.ogeID = KO.ogeID where K.kullaniciID=@p1", baglanti);
            da.SelectCommand.Parameters.AddWithValue("@p1", id);
            da.Fill(kullaniciBilgileri);
            dataGridView1.DataSource = kullaniciBilgileri;
            baglanti.Close();
        }*/
    }
}
