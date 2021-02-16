using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaturaTakip
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        int say;
        private void Form5_Load(object sender, EventArgs e)
        {
            AcceptButton = button1;
            CancelButton = button2;

            timer1.Enabled = true;

            label3.AutoSize = false;
            label3.Width = 560;
            label3.Height = 3;
            label3.BorderStyle = BorderStyle.Fixed3D;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "123456")
                DialogResult = DialogResult.OK;
            else
            {
                say++;
                textBox1.ResetText();
                textBox1.Focus();
                MessageBox.Show("Yanlış Şifre!!!");
                if (say == 3)
                {
                    Close();//DialogResult = DialogResult.Cancel;
                    MessageBox.Show("Programı Yetkisiz Kişiler Kullanamaz", "Bilgi");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //checkBox işaretli ise
            if (checkBox1.Checked)
            {
                //karakteri göster.
                textBox1.PasswordChar = '\0';
            }
            //değilse karakterlerin yerine * koy.
            else
            {
                textBox1.PasswordChar = '*';
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.CharacterCasing = CharacterCasing.Upper;
        }












    }
}
