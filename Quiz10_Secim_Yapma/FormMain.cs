using System;
using System.Data.OleDb;
using System.Windows.Forms;
//f4t1hsalih

namespace Quiz10_Secim_Yapma
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cboy.Text != "")
            {
                OleDbConnection cnn = new OleDbConnection();
                OleDbCommand cmd = new OleDbCommand();
                cnn.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + Application.StartupPath + @"\\Data.accdb";
                cmd.Connection = cnn;

                cmd.CommandText = "update Oy set AldıgıOy=AldıgıOy+1 where Isim=@Isim";
                cmd.Parameters.Add("@Isim", OleDbType.VarChar).Value = cboy.Text;

                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();

                MessageBox.Show("Oy Verme İşleminiz Başarıyla Gerçekleşti");
            }
            else
            {
                MessageBox.Show("Oy Kullanabilmek İçin Lütfen Bir Kişi Seçiniz!!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormSifre sfr = new FormSifre();
            sfr.Show();
            this.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OleDbConnection cnn = new OleDbConnection();
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataReader dr;
            cmd.Connection = cnn;
            cnn.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + Application.StartupPath + @"\\Data.accdb";
            cmd.CommandText = "select * from Oy";
            cnn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cboy.Items.Add(dr["Isim"].ToString());
            }
            cnn.Close();
        }
    }
}
