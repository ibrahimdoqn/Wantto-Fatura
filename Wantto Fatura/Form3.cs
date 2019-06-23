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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

        }
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr;
        private void Form3_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database1.accdb");
            con.Open();
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT *FROM Form";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                textBox3.Text = dr[3].ToString();
                textBox4.Text = dr[4].ToString();
                textBox5.Text = dr[5].ToString();
                textBox6.Text = dr[6].ToString();
                textBox7.Text = dr[7].ToString();
                textBox8.Text = dr[8].ToString();
                textBox9.Text = dr[9].ToString();
                textBox10.Text = dr[10].ToString();
                textBox11.Text = dr[11].ToString();
                textBox12.Text = dr[12].ToString();
                textBox13.Text = dr[13].ToString();
                textBox14.Text = dr[14].ToString();
                textBox15.Text = dr[15].ToString();
                textBox16.Text = dr[16].ToString();
                textBox17.Text = dr[17].ToString();
                textBox18.Text = dr[18].ToString();
                textBox19.Text = dr[19].ToString();
                textBox20.Text = dr[20].ToString();
                textBox21.Text = dr[21].ToString();
                textBox22.Text = dr[22].ToString();
                textBox23.Text = dr[23].ToString();
                textBox24.Text = dr[24].ToString();
            }
            dr.Close();
        }
        



        private void button1_Click(object sender, EventArgs e)
        {
            String vStr1 = "Update Form set SatirAralik =@1," +
                " sayinBaslangic = @2," +
                " detayBaslangic = @3," +
                " vdBaslangic = @4," +
                " tarihBaslangic = @5," +
                " yekunBaslangıc = @6," +
                " kdvBaslangıc = @7," +
                " toplamBaslangic = @8," +
                " yazileBaslangic = @9," +
                " cBaslangic = @10," +
                " mBaslangic = @11," +
                " bBaslangic = @12," +
                " fBaslangic = @13," +
                " tBaslangic = @14," +
                " sayinYandan = @15," +
                " vd1Yandan = @16," +
                " vd2Yandan = @17," +
                " tarihYandan = @18," +
                " yekunYandan = @19," +
                " kdvYandan = @20," +
                " toplamYandan = @21," +
                " yazileYandan = @22," +
                " tb1 = @23," +
                " tb2 = @24" +
                " where ID = 1";
            cmd = new OleDbCommand(vStr1, con);
            cmd.Parameters.AddWithValue("@1",textBox1.Text);
            cmd.Parameters.AddWithValue("@2", textBox2.Text);
            cmd.Parameters.AddWithValue("@3", textBox3.Text);
            cmd.Parameters.AddWithValue("@4", textBox4.Text);
            cmd.Parameters.AddWithValue("@5", textBox5.Text);
            cmd.Parameters.AddWithValue("@6", textBox6.Text);
            cmd.Parameters.AddWithValue("@7", textBox7.Text);
            cmd.Parameters.AddWithValue("@8", textBox8.Text);
            cmd.Parameters.AddWithValue("@9", textBox9.Text);
            cmd.Parameters.AddWithValue("@10", textBox10.Text);
            cmd.Parameters.AddWithValue("@11", textBox11.Text);
            cmd.Parameters.AddWithValue("@12", textBox12.Text);
            cmd.Parameters.AddWithValue("@13", textBox13.Text);
            cmd.Parameters.AddWithValue("@14", textBox14.Text);
            cmd.Parameters.AddWithValue("@15", textBox15.Text);
            cmd.Parameters.AddWithValue("@16", textBox16.Text);
            cmd.Parameters.AddWithValue("@17", textBox17.Text);
            cmd.Parameters.AddWithValue("@18", textBox18.Text);
            cmd.Parameters.AddWithValue("@19", textBox19.Text);
            cmd.Parameters.AddWithValue("@20", textBox20.Text);
            cmd.Parameters.AddWithValue("@21", textBox21.Text);
            cmd.Parameters.AddWithValue("@22", textBox22.Text);
            cmd.Parameters.AddWithValue("@23", textBox23.Text);
            cmd.Parameters.AddWithValue("@24", textBox24.Text);
            cmd.ExecuteNonQuery();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
