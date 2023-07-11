using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Quiz10_Secim_Yapma
{
    public partial class FormSifre : Form
    {
        public FormSifre()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string yol = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + Application.StartupPath + @"\\Data.accdb";
            OleDbConnection cnn = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataTable dt = new DataTable();

            cnn.ConnectionString = yol;
            cmd.Connection = cnn;
            cmd.CommandText = "select sifre from sifre";
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows[0][0].ToString() == textBox1.Text)
            {
                FormSonuclar snç = new FormSonuclar();
                snç.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Şifre Yanlış");
        }

        private void FormSifre_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormMain formMain= new FormMain();
            formMain.Show();
            this.Hide();
        }
    }
}
