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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti;
        OleDbCommand komut;
        OleDbDataAdapter da;

        // Kişileri listelemek için metot oluşturuyoruz.
        public void UrunListele()
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\FaturaBilgileri.accdb;Persist Security Info=False;");
            baglanti.Open();
            da = new OleDbDataAdapter("Select * from FaturaTakip", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        public void temizle() {

            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox tbox = (TextBox)item;
                    tbox.Clear();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UrunListele();
            // label çizgiler
            label9.AutoSize = false;
            label9.Width = 3;
            label9.Height = 430;
            label9.BorderStyle = BorderStyle.Fixed3D;

            label10.AutoSize = false;
            label10.Width = 420;
            label10.Height = 3;
            label10.BorderStyle = BorderStyle.Fixed3D;

            timer1.Enabled = true;   // saat tarih

            var frm = new Form5(); // şifre 
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.Cancel) Close();
            frm.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sorgu = "insert into FaturaTakip (FATURA_NO,TARİH,SUBE_ADI,CİGKOFTE,LAVAS,TOPLAM_ÜCRET,ALINAN_ÜCRET,KALAN_ÜCRET) values ('" + textBox8.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
                komut = new OleDbCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("TARİH", textBox1.Text);
                komut.Parameters.AddWithValue("FATURA_NO", textBox8.Text);
                komut.Parameters.AddWithValue("SUBE_ADI", textBox2.Text);
                komut.Parameters.AddWithValue("CİGKOFTE", textBox3.Text);
                komut.Parameters.AddWithValue("LAVAS", textBox4.Text);
                komut.Parameters.AddWithValue("TOPLAM_ÜCRET", textBox5.Text);
                komut.Parameters.AddWithValue("ALINAN_ÜCRET", textBox6.Text);
                komut.Parameters.AddWithValue("KALAN_ÜCRET", textBox7.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                UrunListele();
                MessageBox.Show("Kayıt Eklendi!");
                temizle();
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 ff = new Form3();
            ff.ShowDialog();   // form3 ten cıktıktan sonra form1 deki data yı günceller...
            UrunListele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string sorgu = "Update FaturaTakip Set FATURA_NO= '" + textBox8.Text + "' ,TARİH = '" + textBox1.Text + "',SUBE_ADI='" + textBox2.Text + "',CİGKOFTE='" + textBox3.Text + "',LAVAS='" + textBox4.Text + "',TOPLAM_ÜCRET='" + textBox5.Text + "',ALINAN_ÜCRET='" + textBox6.Text + "',KALAN_ÜCRET='" + textBox7.Text + "' Where  FATURA_NO = '" + textBox8.Text + "' ";
                komut = new OleDbCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("TARİH", textBox1.Text);
                komut.Parameters.AddWithValue("FATURA_NO", textBox8.Text);
                komut.Parameters.AddWithValue("SUBE_ADI", textBox2.Text);
                komut.Parameters.AddWithValue("CİGKOFTE", textBox3.Text);
                komut.Parameters.AddWithValue("LAVAS", textBox4.Text);
                komut.Parameters.AddWithValue("TOPLAM_ÜCRET", textBox5.Text);
                komut.Parameters.AddWithValue("ALINAN_ÜCRET", textBox6.Text);
                komut.Parameters.AddWithValue("KALAN_ÜCRET", textBox7.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                UrunListele();
                MessageBox.Show("Kayıt Güncellendi!");
                temizle();
            }
            catch (Exception hata)
            {
                MessageBox.Show("İşlem Sırasında Hata Oluştu." + hata.Message);
            }
        }
        private void button6_Click(object sender, EventArgs e) // FORM2 KAYITLAR
        {
            Form2 ff = new Form2();
            ff.Show();  
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form4 ff = new Form4();
            ff.Show();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox8.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.CharacterCasing = CharacterCasing.Upper;
        }
        private void textBox1_TextChanged(object sender, EventArgs e){}

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox8.CharacterCasing = CharacterCasing.Upper;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label11.Text = DateTime.Now.ToString();
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Height += 10;
            pictureBox1.Width += 10;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Height -= 10;
            pictureBox1.Width -= 10;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
