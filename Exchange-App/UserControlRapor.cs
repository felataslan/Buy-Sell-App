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
    public partial class UserControlRapor : UserControl
    {
        public UserControlRapor()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-2BOGKJG;Initial Catalog=yazilimYapimi;Integrated Security=True");

        private void btnGetir_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select R.kullaniciID,R.tarih,O.ogeAdi,R.miktar from Rapor R inner join Ogeler O on R.ogeID=O.ogeID where R.kullaniciID=@p1 and R.tarih Between @p2 and @p3", baglanti);
            da.SelectCommand.Parameters.AddWithValue("@p1",FrmLogin.id);
            da.SelectCommand.Parameters.AddWithValue("@p2",dtpBaslangic.Value);
            da.SelectCommand.Parameters.AddWithValue("@p3",dtpBitis.Value);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Excel_Disa_Aktar(dataGridView1);
        }
        private void Excel_Disa_Aktar(DataGridView dataGridView1)
        {

            SaveFileDialog save = new SaveFileDialog();
            save.OverwritePrompt = false;
            save.Title = "Excel Dosyaları";
            save.DefaultExt = "xlsx";
            save.Filter = "xlsx Dosyaları (*.xlsx)|*.xlsx|Tüm Dosyalar(*.*)|*.*";

            if (save.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = true;
                worksheet = workbook.Sheets["Sayfa1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Excel Dışa Aktarım";
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                workbook.SaveAs(save.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                app.Quit();
            }
        }
    }
}
