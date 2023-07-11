using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Quiz10_Secim_Yapma
{
    public partial class FormSonuclar : Form
    {
        public FormSonuclar()
        {
            InitializeComponent();
        }

        private void sonuclar_Load(object sender, EventArgs e)
        {
            string yol = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + Application.StartupPath + @"\\Data.accdb";
            OleDbConnection cnn = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataTable dt = new DataTable();

            cnn.ConnectionString = yol;
            cmd.Connection = cnn;
            cmd.CommandText = "select * from Oy";
            da.SelectCommand = cmd;
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void FormSonuclar_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
