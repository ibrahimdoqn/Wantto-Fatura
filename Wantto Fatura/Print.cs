using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Wantto_Fatura
{
    public partial class Print : Form
    {
        public Print()
        {
            InitializeComponent();
        }
        OleDbConnection con;
        OleDbDataAdapter da;
        DataTable tablo = new DataTable();
        public string f_no = "";

        private void print() 
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database1.accdb");
            da = new OleDbDataAdapter("SElect *from Fatura where Fatura_No like '" + f_no + "%'", con);
            tablo.Clear();
            da.Fill(tablo);
            CrystalReport1 rapor = new CrystalReport1();
            rapor.SetDataSource(tablo);
            crystalReportViewer1.ReportSource = rapor;
        }

        private void Print_Load(object sender, EventArgs e)
        {
            if (f_no != "") print();
            else 
            {
                MessageBox.Show("Yazdırılacak Fatura Bulunamadı");
                this.Close();
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
