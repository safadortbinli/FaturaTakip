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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;

        private void Form2_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\FaturaBilgileri.accdb;Persist Security Info=False;");
            da = new OleDbDataAdapter("SElect * from FaturaTakip", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "FaturaTakip");
            dataGridView1.DataSource = ds.Tables["FaturaTakip"];
            con.Close();
        }
    }
}
