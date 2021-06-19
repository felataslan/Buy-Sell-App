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
        }

        private void btnRapor_Click(object sender, EventArgs e)
        {
            sidePanel.Height = btnRapor.Height;
            sidePanel.Top = btnRapor.Top;

        }
    }
}
