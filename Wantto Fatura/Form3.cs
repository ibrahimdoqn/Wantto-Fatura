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
                textBox13.Text = dr[12].ToString();
                textBox14.Text = dr[13].ToString();
                textBox15.Text = dr[14].ToString();
                textBox16.Text = dr[15].ToString();
                textBox17.Text = dr[16].ToString();
                textBox18.Text = dr[17].ToString();
                textBox19.Text = dr[18].ToString();
                textBox20.Text = dr[19].ToString();
                textBox21.Text = dr[20].ToString();
                textBox22.Text = dr[21].ToString();
                textBox12.Text = dr[22].ToString();
                textBox23.Text = dr[23].ToString();
                if (dr[24].ToString() == "1") checkBox1.Checked = true;

            }
            dr.Close();
        }
        

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            string customForm = "0";
            if (checkBox1.Checked)
            {
                customForm = "1";
            }
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
            " formBoy = @23," +
            " formEn = @24," +
            "customForm = @25 where ID = 1";
            cmd = new OleDbCommand(vStr1, con);
            cmd.Parameters.AddWithValue("@1", textBox1.Text);
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
            cmd.Parameters.AddWithValue("@23", textBox12.Text);
            cmd.Parameters.AddWithValue("@24", textBox23.Text);
            cmd.Parameters.AddWithValue("@24", customForm);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button30_Click(object sender, EventArgs e)
        {
            textBox2.Text = (Convert.ToInt32(textBox2.Text) - 1).ToString();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            textBox2.Text = (Convert.ToInt32(textBox2.Text) + 1).ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox15.Text = (Convert.ToInt32(textBox15.Text) - 1).ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox15.Text = (Convert.ToInt32(textBox15.Text) + 1).ToString();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            textBox5.Text = (Convert.ToInt32(textBox5.Text) - 1).ToString();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            textBox5.Text = (Convert.ToInt32(textBox5.Text) + 1).ToString();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox18.Text = (Convert.ToInt32(textBox18.Text) - 1).ToString();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox18.Text = (Convert.ToInt32(textBox18.Text) + 1).ToString();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            textBox1.Text = (Convert.ToInt32(textBox1.Text) + 1).ToString();
        }

        private void button44_Click(object sender, EventArgs e)
        {
            textBox1.Text = (Convert.ToInt32(textBox1.Text) - 1).ToString();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            textBox4.Text = (Convert.ToInt32(textBox4.Text) - 1).ToString();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            textBox4.Text = (Convert.ToInt32(textBox4.Text) + 1).ToString();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox16.Text = (Convert.ToInt32(textBox16.Text) - 1).ToString();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox16.Text = (Convert.ToInt32(textBox16.Text) + 1).ToString();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox17.Text = (Convert.ToInt32(textBox17.Text) - 1).ToString();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox17.Text = (Convert.ToInt32(textBox17.Text) + 1).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = (Convert.ToInt32(textBox3.Text) - 1).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = (Convert.ToInt32(textBox3.Text) + 1).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox10.Text = (Convert.ToInt32(textBox10.Text) - 1).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox10.Text = (Convert.ToInt32(textBox10.Text) + 1).ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox11.Text = (Convert.ToInt32(textBox11.Text) - 1).ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox11.Text = (Convert.ToInt32(textBox11.Text) + 1).ToString();
        }


        private void button11_Click(object sender, EventArgs e)
        {
            textBox13.Text = (Convert.ToInt32(textBox13.Text) - 1).ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox13.Text = (Convert.ToInt32(textBox13.Text) + 1).ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox14.Text = (Convert.ToInt32(textBox14.Text) - 1).ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox14.Text = (Convert.ToInt32(textBox14.Text) + 1).ToString();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            textBox6.Text = (Convert.ToInt32(textBox6.Text) - 1).ToString();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            textBox6.Text = (Convert.ToInt32(textBox6.Text) + 1).ToString();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            textBox7.Text = (Convert.ToInt32(textBox7.Text) - 1).ToString();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            textBox7.Text = (Convert.ToInt32(textBox7.Text) + 1).ToString();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            textBox8.Text = (Convert.ToInt32(textBox8.Text) - 1).ToString();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            textBox8.Text = (Convert.ToInt32(textBox8.Text) + 1).ToString();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            textBox9.Text = (Convert.ToInt32(textBox9.Text) - 1).ToString();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            textBox9.Text = (Convert.ToInt32(textBox9.Text) + 1).ToString();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox19.Text = (Convert.ToInt32(textBox19.Text) - 1).ToString();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            textBox19.Text = (Convert.ToInt32(textBox19.Text) + 1).ToString();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            textBox20.Text = (Convert.ToInt32(textBox20.Text) - 1).ToString();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox20.Text = (Convert.ToInt32(textBox20.Text) + 1).ToString();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            textBox21.Text = (Convert.ToInt32(textBox21.Text) - 1).ToString();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            textBox21.Text = (Convert.ToInt32(textBox21.Text) + 1).ToString();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            textBox22.Text = (Convert.ToInt32(textBox22.Text) - 1).ToString();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            textBox22.Text = (Convert.ToInt32(textBox22.Text) + 1).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button46_Click(object sender, EventArgs e)
        {

            textBox9.Text = (Convert.ToInt32(textBox9.Text) - 1).ToString();
            textBox8.Text = (Convert.ToInt32(textBox8.Text) - 1).ToString();
            textBox7.Text = (Convert.ToInt32(textBox7.Text) - 1).ToString();
            textBox6.Text = (Convert.ToInt32(textBox6.Text) - 1).ToString();
            textBox3.Text = (Convert.ToInt32(textBox3.Text) - 1).ToString();
            textBox4.Text = (Convert.ToInt32(textBox4.Text) - 1).ToString();
            textBox5.Text = (Convert.ToInt32(textBox5.Text) - 1).ToString();
            textBox2.Text = (Convert.ToInt32(textBox2.Text) - 1).ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox9.Text = (Convert.ToInt32(textBox9.Text) + 1).ToString();
            textBox8.Text = (Convert.ToInt32(textBox8.Text) + 1).ToString();
            textBox7.Text = (Convert.ToInt32(textBox7.Text) + 1).ToString();
            textBox6.Text = (Convert.ToInt32(textBox6.Text) + 1).ToString();
            textBox3.Text = (Convert.ToInt32(textBox3.Text) + 1).ToString();
            textBox4.Text = (Convert.ToInt32(textBox4.Text) + 1).ToString();
            textBox5.Text = (Convert.ToInt32(textBox5.Text) + 1).ToString();
            textBox2.Text = (Convert.ToInt32(textBox2.Text) + 1).ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox15.Text = (Convert.ToInt32(textBox15.Text) - 1).ToString();
            textBox18.Text = (Convert.ToInt32(textBox18.Text) - 1).ToString();
            textBox16.Text = (Convert.ToInt32(textBox16.Text) - 1).ToString();
            textBox17.Text = (Convert.ToInt32(textBox17.Text) - 1).ToString();
            textBox10.Text = (Convert.ToInt32(textBox10.Text) - 1).ToString();
            textBox11.Text = (Convert.ToInt32(textBox11.Text) - 1).ToString();
            textBox13.Text = (Convert.ToInt32(textBox13.Text) - 1).ToString();
            textBox14.Text = (Convert.ToInt32(textBox14.Text) - 1).ToString();
            textBox19.Text = (Convert.ToInt32(textBox19.Text) - 1).ToString();
            textBox20.Text = (Convert.ToInt32(textBox20.Text) - 1).ToString();
            textBox21.Text = (Convert.ToInt32(textBox21.Text) - 1).ToString();
            textBox22.Text = (Convert.ToInt32(textBox22.Text) - 1).ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox15.Text = (Convert.ToInt32(textBox15.Text) + 1).ToString();
            textBox18.Text = (Convert.ToInt32(textBox18.Text) + 1).ToString();
            textBox16.Text = (Convert.ToInt32(textBox16.Text) + 1).ToString();
            textBox17.Text = (Convert.ToInt32(textBox17.Text) + 1).ToString();
            textBox15.Text = (Convert.ToInt32(textBox15.Text) + 1).ToString();
            textBox10.Text = (Convert.ToInt32(textBox10.Text) + 1).ToString();
            textBox11.Text = (Convert.ToInt32(textBox11.Text) + 1).ToString();
            textBox13.Text = (Convert.ToInt32(textBox13.Text) + 1).ToString();
            textBox14.Text = (Convert.ToInt32(textBox14.Text) + 1).ToString();
            textBox19.Text = (Convert.ToInt32(textBox19.Text) + 1).ToString();
            textBox20.Text = (Convert.ToInt32(textBox20.Text) + 1).ToString();
            textBox21.Text = (Convert.ToInt32(textBox21.Text) + 1).ToString();
            textBox22.Text = (Convert.ToInt32(textBox22.Text) + 1).ToString();
        }
    }

}
