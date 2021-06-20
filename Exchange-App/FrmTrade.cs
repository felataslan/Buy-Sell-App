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
    public partial class FrmTrade : Form
    {
        
        public FrmTrade()
        {
            InitializeComponent();
            sidePanel.Height = btnVarlikEkle.Height;
            sidePanel.Top = btnVarlikEkle.Top;
            userControlVarlikEkle1.BringToFront();
            lblid.Text = FrmLogin.id;
            lblKullaniciAdi.Text = FrmLogin.kullaniciAdi;
            lblBakiye.Text = FrmLogin.Bakiye;
            lblPamuk.Text = FrmLogin.Pamuk;
            lblArpa.Text = FrmLogin.Arpa;
            lblBugday.Text = FrmLogin.Bugday;
            
        }

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

        // labellardaki kullanıcı bilgisinin güncellenmesi
        public void labelGuncelle()
        {
            //düzenlenecek
            lblKullaniciAdi.Text = "deneme";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmLogin frmlogin = new FrmLogin();
            frmlogin.Show();
            this.Close();
        }
    }
}
