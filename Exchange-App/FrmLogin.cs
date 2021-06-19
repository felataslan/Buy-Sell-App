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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

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
            bool admin = true;//Düzenlenecek
            if (girisKontrol())
            {
                //Admin formu
                if (admin)
                {
                    FrmAdmin frmAdmin = new FrmAdmin();
                    frmAdmin.Show();
                    this.Hide();
                    /*FrmTrade trade = new FrmTrade();
                    trade.Show();
                    this.Hide();*/

                }
                //Trade formu
                else
                {
                    
                }
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız!");
            }
        }
        //Düzenlenecek
        // Kullanıcı giriş bilgilerinin kontrolü
        private bool girisKontrol()
        {
            return true;
        }
    }
}
