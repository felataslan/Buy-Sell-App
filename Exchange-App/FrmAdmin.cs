using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exchange_App
{
    public partial class FrmAdmin : Form
    {
        /*string ID;
        string varlikAdi;
        string eklenecekMiktar;
        string mevcutMiktar;*/

        public FrmAdmin()
        {
            InitializeComponent();
        }
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
            listele();
        }

        //datagridview nesnesinin güncellenmesi
        private void listele()
        {
            //düzenlenecek
        }

        // Kullanıcının Mevcut Varlığının Veritabanından çekilmesi
        private void varlikGetir()
        {
            // düzenlenecek
        }

        // Mevcut varlığın eklenecek miktar kadar arttırılması
        private void varlikEkle ()
        {
            // düzenlenecek
        }

        // Varlığın Veri tabanına Eklenmesi
        private void varlikGuncelle()
        {
            // düzenlenecek
        }

        //datagridview de seçilen kullanıcı bilgilernin değişkenlere atanması
        private void datagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int satir = datagridview1.SelectedCells[0].RowIndex;
            //ID = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            //varlikAdi = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            //eklenecekMiktar = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            //düzenlenecek

        }
    }
}
