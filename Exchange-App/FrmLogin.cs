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
                }
                else
                {
                    kontrol = false;
                }
            }

            baglanti.Close();
        }
    }
}
