using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace FaturaTakip
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti;
        
        OleDbDataAdapter da;

        void KisiListele()
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\FaturaBilgileri.accdb;Persist Security Info=False;");
            baglanti.Open();
            da = new OleDbDataAdapter("Select * from FaturaTakip", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            KisiListele();

            label2.AutoSize = false;
            label2.Width = 730;
            label2.Height = 3;
            label2.BorderStyle = BorderStyle.Fixed3D;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\FaturaBilgileri.accdb;Persist Security Info=False;");
            baglanti.Open();
            da = new OleDbDataAdapter("SElect * from FaturaTakip where SUBE_ADI like '" + textBox1.Text + "%' or FATURA_NO like '" + textBox1.Text + "%'  ", baglanti);
            DataTable tablo2 = new DataTable();
            da.Fill(tablo2);
            dataGridView1.DataSource = tablo2;
            baglanti.Close();
            
        }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.CharacterCasing = CharacterCasing.Upper;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double toplam = 0.00;
            for (int a = 0; a < dataGridView1.Rows.Count; a++)
            {
                toplam += Convert.ToInt32(dataGridView1.Rows[a].Cells[5].Value);
            }
            textBox2.Text = toplam.ToString();

            double toplam1 = 0.00;
            for (int b = 0; b < dataGridView1.Rows.Count; b++)
            {

                toplam1 += Convert.ToInt32(dataGridView1.Rows[b].Cells[6].Value);
            }
            textBox3.Text = toplam1.ToString();


            double toplam2 = 0.00;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                toplam2 += Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);
            }
            textBox4.Text = toplam2.ToString();
        }
    }
}
