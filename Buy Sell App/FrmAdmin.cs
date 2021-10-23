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
    public partial class FrmAdmin : Form
    {
        int ID;
        int varlikID;
        double eklenecekMiktar;
        double mevcutMiktar;

        public FrmAdmin()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-2BOGKJG;Initial Catalog=yazilimYapimi;Integrated Security=True");
        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOnay_Click(object sender, EventArgs e)
        {
            varlikGetir();
            varlikEkle();
            varlikGuncelle();
            onaySil();
            listele();
        }

        //datagridview nesnesinin güncellenmesi
        private void listele()
        {
            baglanti.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From KullaniciOnay", baglanti);
            da.Fill(dt);
            datagridview1.DataSource = dt;
            baglanti.Close();
        }

        // Kullanıcının Mevcut Varlığının Veritabanından çekilmesi
        private void varlikGetir()
        {
            baglanti.Open();
            SqlCommand komutVarlikGetir = new SqlCommand("select ogeMiktar from KullaniciOgeleri where kullaniciID=@p1 and ogeID=@p2", baglanti);
            komutVarlikGetir.Parameters.AddWithValue("@p1",ID);
            komutVarlikGetir.Parameters.AddWithValue("@p2",varlikID);
            mevcutMiktar = Convert.ToDouble(komutVarlikGetir.ExecuteScalar());
            baglanti.Close();
        }

        // Mevcut varlığın eklenecek miktar kadar arttırılması
        private void varlikEkle ()
        {
            mevcutMiktar += eklenecekMiktar;
        }

        // Varlığın Veri tabanına Eklenmesi
        private void varlikGuncelle()
        {
            baglanti.Open();
            SqlCommand komutGuncelle = new SqlCommand("Update KullaniciOgeleri set  ogeMiktar=@p1 Where kullaniciID=@p2 and ogeID=@p3", baglanti);
            komutGuncelle.Parameters.AddWithValue("@p1", mevcutMiktar.ToString());
            komutGuncelle.Parameters.AddWithValue("@p2", ID);
            komutGuncelle.Parameters.AddWithValue("@p3", varlikID);
            komutGuncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Varlık Eklendi");
        }

        //Onaylanan kullanıcının veri tabanından silinmesi
        private void onaySil()
        {
            baglanti.Open();
            SqlCommand komutSil = new SqlCommand("Delete From KullaniciOnay Where KullaniciID =@p1 and ogeID=@p2", baglanti);
            komutSil.Parameters.AddWithValue("@p1", ID);
            komutSil.Parameters.AddWithValue("@p2", varlikID);
            komutSil.ExecuteNonQuery();
            baglanti.Close();
        }

        //datagridview de seçilen kullanıcı bilgilernin değişkenlere atanması
        private void datagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int satir = datagridview1.SelectedCells[0].RowIndex;
            ID = Convert.ToInt16(datagridview1.Rows[satir].Cells[1].Value);
            varlikID = Convert.ToInt16(datagridview1.Rows[satir].Cells[2].Value);
            eklenecekMiktar = Convert.ToDouble(datagridview1.Rows[satir].Cells[3].Value);
        }
    }
}
