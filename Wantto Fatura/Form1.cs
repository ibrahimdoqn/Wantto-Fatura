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
    public partial class Form1 : Form
    {
        //Access Veri Bağalantıları
        OleDbConnection con;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataTable dt;
        OleDbDataReader dr;
        //Hesap toplamı için
        private double a1 = 0; private double a2 = 0; private double a3 = 0; private double a4 = 0; private double a5 = 0; private double a6 = 0; private double a7 = 0; private double a8 = 0; private double a9 = 0; private double a10 = 0; private double a11 = 0; private double a12 = 0; private double a13 = 0;
        
        public Form1()
        {
            InitializeComponent();
            tarih.Text = DateTime.Now.ToShortDateString();
        }
        public void dataReader() 
        {
            dataReader2();
            dataReader1();
        }
        public void dataReader1() 
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database1.accdb");
            cmd = new OleDbCommand("Select *From Fatura", con);
            da = new OleDbDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void dataReader2()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database1.accdb");
            cmd = new OleDbCommand("Select *From person", con);
            da = new OleDbDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }
        private void textDelete()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            tarih.Clear();
            vd1.Clear();
            vd2.Clear();
            f_no.Clear();
            //
            M1.Clear();
            B1.Clear();
            C1.Clear();
            F1.Clear();
            T1.Clear();
            //
            M2.Clear();
            B2.Clear();
            C2.Clear();
            F2.Clear();
            T2.Clear();
            //
            M3.Clear();
            B3.Clear();
            C3.Clear();
            F3.Clear();
            T3.Clear();
            //
            M4.Clear();
            B4.Clear();
            C4.Clear();
            F4.Clear();
            T4.Clear();
            //
            M5.Clear();
            B5.Clear();
            C5.Clear();
            F5.Clear();
            T5.Clear();
            //
            M6.Clear();
            B6.Clear();
            C6.Clear();
            F6.Clear();
            T6.Clear();
            //
            M7.Clear();
            B7.Clear();
            C7.Clear();
            F7.Clear();
            T7.Clear();
            //
            M8.Clear();
            B8.Clear();
            C8.Clear();
            F8.Clear();
            T8.Clear();
            //
            M9.Clear();
            B9.Clear();
            C9.Clear();
            F9.Clear();
            T9.Clear();
            //
            M10.Clear();
            B10.Clear();
            C10.Clear();
            F10.Clear();
            T10.Clear();
            //
            M11.Clear();
            B11.Clear();
            C11.Clear();
            F11.Clear();
            T11.Clear();
            //
            M12.Clear();
            B12.Clear();
            C12.Clear();
            F12.Clear();
            T12.Clear();
            //
            M13.Clear();
            B13.Clear();
            C13.Clear();
            F13.Clear();
            T13.Clear();
            //
        }
        private void updateTablo()
        {
            OleDbCommandBuilder oldbcom = new OleDbCommandBuilder(da);
            oldbcom.GetUpdateCommand();
            da.Update(dt); 
        }
        private string yaziyaCevir(decimal tutar)
        {
            string sTutar = tutar.ToString("F2").Replace('.', ','); // Replace('.',',') ondalık ayracının . olma durumu için            
            string lira = sTutar.Substring(0, sTutar.IndexOf(',')); //tutarın tam kısmı
            string kurus = sTutar.Substring(sTutar.IndexOf(',') + 1, 2);
            string yazi = "";

            string[] birler = { "", "BİR", "İKİ", "Üç", "DÖRT", "BEŞ", "ALTI", "YEDİ", "SEKİZ", "DOKUZ" };
            string[] onlar = { "", "ON", "YİRMİ", "OTUZ", "KIRK", "ELLİ", "ALTMIŞ", "YETMİŞ", "SEKSEN", "DOKSAN" };
            string[] binler = { "KATRİLYON", "TRİLYON", "MİLYAR", "MİLYON", "BİN", "" }; //KATRİLYON'un önüne ekleme yapılarak artırabilir.

            int grupSayisi = 6; //sayıdaki 3'lü grup sayısı. katrilyon içi 6. (1.234,00 daki grup sayısı 2'dir.)
            //KATRİLYON'un başına ekleyeceğiniz her değer için grup sayısını artırınız.

            lira = lira.PadLeft(grupSayisi * 3, '0'); //sayının soluna '0' eklenerek sayı 'grup sayısı x 3' basakmaklı yapılıyor.            

            string grupDegeri;

            for (int i = 0; i < grupSayisi * 3; i += 3) //sayı 3'erli gruplar halinde ele alınıyor.
            {
                grupDegeri = "";

                if (lira.Substring(i, 1) != "0")
                    grupDegeri += birler[Convert.ToInt32(lira.Substring(i, 1))] + "YÜZ"; //yüzler                

                if (grupDegeri == "BİRYÜZ") //biryüz düzeltiliyor.
                    grupDegeri = "YÜZ";

                grupDegeri += onlar[Convert.ToInt32(lira.Substring(i + 1, 1))]; //onlar

                grupDegeri += birler[Convert.ToInt32(lira.Substring(i + 2, 1))]; //birler                

                if (grupDegeri != "") //binler
                    grupDegeri += binler[i / 3];

                if (grupDegeri == "BİRBİN") //birbin düzeltiliyor.
                    grupDegeri = "BİN";

                yazi += grupDegeri;
            }

            if (yazi != "")
                yazi += " TL ";

            int yaziUzunlugu = yazi.Length;

            if (kurus.Substring(0, 1) != "0") //kuruş onlar
                yazi += onlar[Convert.ToInt32(kurus.Substring(0, 1))];

            if (kurus.Substring(1, 1) != "0") //kuruş birler
                yazi += birler[Convert.ToInt32(kurus.Substring(1, 1))];

            if (yazi.Length > yaziUzunlugu)
                yazi += " Kr.";
            else
                yazi += "SIFIR Kr.";

            return yazi;
        }
        
        private void topla()
        {

            double ktoplam = a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9 + a10 + a11 + a12 + a13;//Kutucukların Toplamı
            double kdv1 = Convert.ToDouble(comboKDV1.Text);//KDV Oranı
            double kdv2 = ktoplam * kdv1;//Hesaplanmış KDV
            String Yekun = ktoplam.ToString("F2").Replace('.', ',');//Virgülle ayırmak
            String kdvHesap = kdv2.ToString("F2").Replace('.', ',');//için hesaplanmış
            String Toplam = (ktoplam + kdv2).ToString("F2").Replace('.', ',');//String Hesap
            yazile.Text = yaziyaCevir(Convert.ToDecimal(ktoplam + kdv2));//Yazı ile yazılmış tutar
            yekun.Text = Yekun + " TL";//YEKUN
            kdv.Text = kdvHesap + " TL";//KDV
            toplam.Text = Toplam + " TL";//TOPLAM
        }
        private void saveButton()
        {
            if (f_no.Text != "")
            {
                string ad = f_no.Text;
                string sifre = tarih.Text;
                con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database1.accdb");
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Fatura where Fatura_No='" + ad + "' AND Tarih='" + sifre + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Bu Fatura Seri NO Zaten sistemde kayıtlı, Lütfen kontrol ediniz.");
                }
                else
                {
                    string ekle = "insert into Fatura(Fatura_No,Tarih,Musteri,Musteri2,Musteri3,Vergi_Dairesi,Vergi_No,m1,b1,c1,f1,t1,m2,b2,c2,f2,t2,m3,b3,c3,f3,t3,m4,b4,c4,f4,t4,m5,b5,c5,f5,t5,m6,b6,c6,f6,t6,m7,b7,c7,f7,t7,m8,b8,c8,f8,t8,m9,b9,c9,f9,t9,m10,b10,c10,f10,t10,m11,b11,c11,f11,t11,m12,b12,c12,f12,t12,m13,b13,c13,f13,t13,Yekun,KDV,Toplam,kdvoran,yalniz) values (@Fatura_No,@Tarih,@Musteri,@Musteri2,@Musteri3,@Vergi_Dairesi,@Vergi_No,@m1,@b1,@c1,@f1,@t1,@m2,@b2,@c2,@f2,@t2,@m3,@b3,@c3,@f3,@t3,@m4,@b4,@c4,@f4,@t4,@m5,@b5,@c5,@f5,@t5,@m6,@b6,@c6,@f6,@t6,@m7,@b7,@c7,@f7,@t7,@m8,@b8,@c8,@f8,@t8,@m9,@b9,@c9,@f9,@t9,@m10,@b10,@c10,@f10,@t10,@m11,@b11,@c11,@f11,@t11,@m12,@b12,@c12,@f12,@t12,@m13,@b13,@c13,@f13,@t13,@Yekun,@KDV,@Toplam,@kdvoran,@yalniz)";
                    cmd = new OleDbCommand(ekle, con);
                    cmd.Parameters.AddWithValue("@Fatura_No", f_no.Text);//Fatura No
                    cmd.Parameters.AddWithValue("@Tarih", tarih.Text);//Tarih
                    cmd.Parameters.AddWithValue("@Musteri", textBox1.Text);//Müşteri
                    cmd.Parameters.AddWithValue("@Musteri2", textBox2.Text);//Müşteri2
                    cmd.Parameters.AddWithValue("@Musteri3", textBox3.Text);//Müşteri3
                    cmd.Parameters.AddWithValue("@Vergi_Dairesi", vd1.Text);//Vergi Dairesi
                    cmd.Parameters.AddWithValue("@Vergi_No", vd2.Text);//Vergi Dairesi Hesap No

                    //Aşağıdaki alan Miktar Birim Cins Fiyat Tutar tablolarının kaydını yapar
                    cmd.Parameters.AddWithValue("@m1", M1.Text); cmd.Parameters.AddWithValue("@b1", B1.Text); cmd.Parameters.AddWithValue("@c1", C1.Text); cmd.Parameters.AddWithValue("@f1", F1.Text); cmd.Parameters.AddWithValue("@t1", T1.Text);
                    cmd.Parameters.AddWithValue("@m2", M2.Text); cmd.Parameters.AddWithValue("@b2", B2.Text); cmd.Parameters.AddWithValue("@c2", C2.Text); cmd.Parameters.AddWithValue("@f2", F2.Text); cmd.Parameters.AddWithValue("@t2", T2.Text);
                    cmd.Parameters.AddWithValue("@m3", M3.Text); cmd.Parameters.AddWithValue("@b3", B3.Text); cmd.Parameters.AddWithValue("@c3", C3.Text); cmd.Parameters.AddWithValue("@f3", F3.Text); cmd.Parameters.AddWithValue("@t3", T3.Text);
                    cmd.Parameters.AddWithValue("@m4", M4.Text); cmd.Parameters.AddWithValue("@b4", B4.Text); cmd.Parameters.AddWithValue("@c4", C4.Text); cmd.Parameters.AddWithValue("@f4", F4.Text); cmd.Parameters.AddWithValue("@t4", T4.Text);
                    cmd.Parameters.AddWithValue("@m5", M5.Text); cmd.Parameters.AddWithValue("@b5", B5.Text); cmd.Parameters.AddWithValue("@c5", C5.Text); cmd.Parameters.AddWithValue("@f5", F5.Text); cmd.Parameters.AddWithValue("@t5", T5.Text);
                    cmd.Parameters.AddWithValue("@m6", M6.Text); cmd.Parameters.AddWithValue("@b6", B6.Text); cmd.Parameters.AddWithValue("@c6", C6.Text); cmd.Parameters.AddWithValue("@f6", F6.Text); cmd.Parameters.AddWithValue("@t6", T6.Text);
                    cmd.Parameters.AddWithValue("@m7", M7.Text); cmd.Parameters.AddWithValue("@b7", B7.Text); cmd.Parameters.AddWithValue("@c7", C7.Text); cmd.Parameters.AddWithValue("@f7", F7.Text); cmd.Parameters.AddWithValue("@t7", T7.Text);
                    cmd.Parameters.AddWithValue("@m8", M8.Text); cmd.Parameters.AddWithValue("@b8", B8.Text); cmd.Parameters.AddWithValue("@c8", C8.Text); cmd.Parameters.AddWithValue("@f8", F8.Text); cmd.Parameters.AddWithValue("@t8", T8.Text);
                    cmd.Parameters.AddWithValue("@m9", M9.Text); cmd.Parameters.AddWithValue("@b9", B9.Text); cmd.Parameters.AddWithValue("@c9", C9.Text); cmd.Parameters.AddWithValue("@f9", F9.Text); cmd.Parameters.AddWithValue("@t9", T9.Text);
                    cmd.Parameters.AddWithValue("@m10", M10.Text); cmd.Parameters.AddWithValue("@b10", B10.Text); cmd.Parameters.AddWithValue("@c10", C10.Text); cmd.Parameters.AddWithValue("@f10", F10.Text); cmd.Parameters.AddWithValue("@t10", T10.Text);
                    cmd.Parameters.AddWithValue("@m11", M11.Text); cmd.Parameters.AddWithValue("@b11", B11.Text); cmd.Parameters.AddWithValue("@c11", C11.Text); cmd.Parameters.AddWithValue("@f11", F11.Text); cmd.Parameters.AddWithValue("@t11", T11.Text);
                    cmd.Parameters.AddWithValue("@m12", M12.Text); cmd.Parameters.AddWithValue("@b12", B12.Text); cmd.Parameters.AddWithValue("@c12", C12.Text); cmd.Parameters.AddWithValue("@f12", F12.Text); cmd.Parameters.AddWithValue("@t12", T12.Text);
                    cmd.Parameters.AddWithValue("@m13", M13.Text); cmd.Parameters.AddWithValue("@b13", B13.Text); cmd.Parameters.AddWithValue("@c13", C13.Text); cmd.Parameters.AddWithValue("@f13", F13.Text); cmd.Parameters.AddWithValue("@t13", T13.Text);
                    //Fatura tablosu bitiş
                    cmd.Parameters.AddWithValue("@Yekun", yekun.Text);
                    cmd.Parameters.AddWithValue("@KDV", kdv.Text);
                    cmd.Parameters.AddWithValue("@Toplam", toplam.Text);
                    cmd.Parameters.AddWithValue("@kdvoran", comboKDV1.Text);
                    cmd.Parameters.AddWithValue("@yalniz", yazile.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt başarılı");
                    dataReader();
                }
            }
            else
            {
                MessageBox.Show("Fatura Seri No Boş Bırakılamaz");
            }
        }

        private void saveButton2()
        {
            if(textBox1.Text != "")
            {
            string vtyolu = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database1.accdb;Persist Security Info=True";
            OleDbConnection con = new OleDbConnection(vtyolu);
            con.Open();
            string ekle = "insert into person(MUSTERI,MUSTERI_2,MUSTERI_3,VERGI_DAIRESI,VERGI_NO) values (@MUSTERI,@MUSTERI_2,@MUSTERI_3,@VERGI_DAIRESI,@VERGI_NO)";
            OleDbCommand cmd = new OleDbCommand(ekle, con);
            cmd.Parameters.AddWithValue("@MUSTERI", textBox1.Text);//Müşteri
            cmd.Parameters.AddWithValue("@MUSTERI_2", textBox2.Text);//Müşteri2
            cmd.Parameters.AddWithValue("@MUSTERI_3", textBox3.Text);//Müşteri3
            cmd.Parameters.AddWithValue("@VERGI_DAIRESI", vd1.Text);
            cmd.Parameters.AddWithValue("@VERGI_NO", vd2.Text);
            cmd.ExecuteNonQuery();
            dataReader();
            MessageBox.Show("Firma Başarıyla kaydedildi");
            }
            else MessageBox.Show("İlk kutucuk boş bırakılamaz");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            f_no.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tarih.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            vd1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            vd2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            M1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            B1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            C1.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            F1.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            T1.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            //
            M2.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            B2.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            C2.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            F2.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
            T2.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
            //
            //
            M3.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();
            B3.Text = dataGridView1.CurrentRow.Cells[18].Value.ToString();
            C3.Text = dataGridView1.CurrentRow.Cells[19].Value.ToString();
            F3.Text = dataGridView1.CurrentRow.Cells[20].Value.ToString();
            T3.Text = dataGridView1.CurrentRow.Cells[21].Value.ToString();
            //
            M4.Text = dataGridView1.CurrentRow.Cells[22].Value.ToString();
            B4.Text = dataGridView1.CurrentRow.Cells[23].Value.ToString();
            C4.Text = dataGridView1.CurrentRow.Cells[24].Value.ToString();
            F4.Text = dataGridView1.CurrentRow.Cells[25].Value.ToString();
            T4.Text = dataGridView1.CurrentRow.Cells[26].Value.ToString();
            //
            M5.Text = dataGridView1.CurrentRow.Cells[27].Value.ToString();
            B5.Text = dataGridView1.CurrentRow.Cells[28].Value.ToString();
            C5.Text = dataGridView1.CurrentRow.Cells[29].Value.ToString();
            F5.Text = dataGridView1.CurrentRow.Cells[30].Value.ToString();
            T5.Text = dataGridView1.CurrentRow.Cells[31].Value.ToString();
            //
            M6.Text = dataGridView1.CurrentRow.Cells[32].Value.ToString();
            B6.Text = dataGridView1.CurrentRow.Cells[33].Value.ToString();
            C6.Text = dataGridView1.CurrentRow.Cells[34].Value.ToString();
            F6.Text = dataGridView1.CurrentRow.Cells[35].Value.ToString();
            T6.Text = dataGridView1.CurrentRow.Cells[36].Value.ToString();
            //
            M7.Text = dataGridView1.CurrentRow.Cells[37].Value.ToString();
            B7.Text = dataGridView1.CurrentRow.Cells[38].Value.ToString();
            C7.Text = dataGridView1.CurrentRow.Cells[39].Value.ToString();
            F7.Text = dataGridView1.CurrentRow.Cells[40].Value.ToString();
            T7.Text = dataGridView1.CurrentRow.Cells[41].Value.ToString();
            //
            M8.Text = dataGridView1.CurrentRow.Cells[42].Value.ToString();
            B8.Text = dataGridView1.CurrentRow.Cells[43].Value.ToString();
            C8.Text = dataGridView1.CurrentRow.Cells[44].Value.ToString();
            F8.Text = dataGridView1.CurrentRow.Cells[45].Value.ToString();
            T8.Text = dataGridView1.CurrentRow.Cells[46].Value.ToString();
            //
            M9.Text = dataGridView1.CurrentRow.Cells[47].Value.ToString();
            B9.Text = dataGridView1.CurrentRow.Cells[48].Value.ToString();
            C9.Text = dataGridView1.CurrentRow.Cells[49].Value.ToString();
            F9.Text = dataGridView1.CurrentRow.Cells[50].Value.ToString();
            T9.Text = dataGridView1.CurrentRow.Cells[51].Value.ToString();
            //
            M10.Text = dataGridView1.CurrentRow.Cells[52].Value.ToString();
            B10.Text = dataGridView1.CurrentRow.Cells[53].Value.ToString();
            C10.Text = dataGridView1.CurrentRow.Cells[54].Value.ToString();
            F10.Text = dataGridView1.CurrentRow.Cells[55].Value.ToString();
            T10.Text = dataGridView1.CurrentRow.Cells[56].Value.ToString();
            //
            M11.Text = dataGridView1.CurrentRow.Cells[57].Value.ToString();
            B11.Text = dataGridView1.CurrentRow.Cells[58].Value.ToString();
            C11.Text = dataGridView1.CurrentRow.Cells[59].Value.ToString();
            F11.Text = dataGridView1.CurrentRow.Cells[60].Value.ToString();
            T11.Text = dataGridView1.CurrentRow.Cells[61].Value.ToString();
            //
            M12.Text = dataGridView1.CurrentRow.Cells[62].Value.ToString();
            B12.Text = dataGridView1.CurrentRow.Cells[63].Value.ToString();
            C12.Text = dataGridView1.CurrentRow.Cells[64].Value.ToString();
            F12.Text = dataGridView1.CurrentRow.Cells[65].Value.ToString();
            T12.Text = dataGridView1.CurrentRow.Cells[66].Value.ToString();
            //
            M13.Text = dataGridView1.CurrentRow.Cells[67].Value.ToString();
            B13.Text = dataGridView1.CurrentRow.Cells[68].Value.ToString();
            C13.Text = dataGridView1.CurrentRow.Cells[69].Value.ToString();
            F13.Text = dataGridView1.CurrentRow.Cells[70].Value.ToString();
            T13.Text = dataGridView1.CurrentRow.Cells[71].Value.ToString();
            //
            yekun.Text = dataGridView1.CurrentRow.Cells[72].Value.ToString();
            kdv.Text = dataGridView1.CurrentRow.Cells[73].Value.ToString();
            toplam.Text = dataGridView1.CurrentRow.Cells[74].Value.ToString();
            comboKDV1.Text = dataGridView1.CurrentRow.Cells[75].Value.ToString();
            yazile.Text = dataGridView1.CurrentRow.Cells[76].Value.ToString();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                saveButton();
            }
            catch
            {
                MessageBox.Show("Veritabanı kayıt hatası");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textDelete();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            vd1.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            vd2.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
        }

        private void M1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void M2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ad = f_no.Text;
            string sifre = tarih.Text;
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database1.accdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Fatura where Fatura_No='" + ad + "' AND Tarih='" + sifre + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Print yazdir = new Print();
                yazdir.f_no = f_no.Text;
                yazdir.Show();
            }
            else
            {
                try
                {
                    if(f_no.Text != "")saveButton();
                    Print yazdir = new Print();
                    yazdir.f_no = f_no.Text;
                    yazdir.Show();
                }
                catch 
                {
                    MessageBox.Show("Yazdırma Hatası");
                }
            }

            con.Close();
        }

        private void M3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void M4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void M5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void M6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void M7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void M8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void M9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void M10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void M11_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void M12_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void M13_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void F1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void F2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void F3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void F4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void F5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void F6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void F7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void F8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void F9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void F10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void F11_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void F12_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void F13_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ','; 
        }

        private void M1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double a = Convert.ToDouble(M1.Text);
                Double b = Convert.ToDouble(F1.Text);
                a1 = a * b;
                String HesapTutari = (a1).ToString("F2").Replace('.', ',');
                T1.Text = HesapTutari + " TL";
            }
            catch 
            {
                a1 = 0;
                T1.Text = "";
                
            }
        }

        private void F1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double a = Convert.ToDouble(M1.Text);
                Double b = Convert.ToDouble(F1.Text);
                a1 = a * b;
                String HesapTutari = (a1).ToString("F2").Replace('.', ',');
                T1.Text = HesapTutari + " TL";
            }
            catch
            {
                a1 = 0;
                T1.Text = "";
                
            }
        }

        private void M2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double a = Convert.ToDouble(M2.Text);
                Double b = Convert.ToDouble(F2.Text);
                a2 = a * b;
                String HesapTutari = (a2).ToString("F2").Replace('.', ',');
                T2.Text = HesapTutari + " TL";
            }
            catch
            {
                a2 = 0;
                T2.Text = "";
                
            }
        }

        private void F2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double a = Convert.ToDouble(M2.Text);
                Double b = Convert.ToDouble(F2.Text);
                a2 = a * b;
                String HesapTutari = (a2).ToString("F2").Replace('.', ',');
                T2.Text = HesapTutari + " TL";
            }
            catch
            {
                a2 = 0;
                T2.Text = "";
                
            }
        }

        private void M3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double a = Convert.ToDouble(M3.Text);
                Double b = Convert.ToDouble(F3.Text);
                a3 = a * b;
                String HesapTutari = (a3).ToString("F2").Replace('.', ',');
                T3.Text = HesapTutari + " TL";
            }
            catch
            {
                a3 = 0;
                T3.Text = "";
                
            }
        }

        private void F3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double a = Convert.ToDouble(M3.Text);
                Double b = Convert.ToDouble(F3.Text);
                a3 = a * b;
                String HesapTutari = (a3).ToString("F2").Replace('.', ',');
                T3.Text = HesapTutari + " TL";
            }
            catch
            {
                a3 = 0;
                T3.Text = "";
                
            }
        }

        private void M4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double a = Convert.ToDouble(M4.Text);
                Double b = Convert.ToDouble(F4.Text);
                a4 = a * b;
                String HesapTutari = (a4).ToString("F2").Replace('.', ',');
                T4.Text = HesapTutari + " TL";
            }
            catch
            {
                a4 = 0;
                T3.Text = "";
                
            }
        }

        private void F4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double a = Convert.ToDouble(M4.Text);
                Double b = Convert.ToDouble(F4.Text);
                a4 = a * b;
                String HesapTutari = (a4).ToString("F2").Replace('.', ',');
                T4.Text = HesapTutari + " TL";
            }
            catch
            {
                a4 = 0;
                T4.Text = "";
                
            }
        }

        private void M5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double a = Convert.ToDouble(M5.Text);
                Double b = Convert.ToDouble(F5.Text);
                a5 = a * b;
                String HesapTutari = (a5).ToString("F2").Replace('.', ',');
                T5.Text = HesapTutari + " TL";
            }
            catch
            {
                a5 = 0;
                T5.Text = "";
                
            }
        }

        private void F5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double a = Convert.ToDouble(M5.Text);
                Double b = Convert.ToDouble(F5.Text);
                a5 = a * b;
                String HesapTutari = (a5).ToString("F2").Replace('.', ',');
                T5.Text = HesapTutari + " TL";
            }
            catch
            {
                a5 = 0;
                T5.Text = "";
                
            }
        }

        private void M6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double a = Convert.ToDouble(M6.Text);
                Double b = Convert.ToDouble(F6.Text);
                a6 = a * b;
                String HesapTutari = (a6).ToString("F2").Replace('.', ',');
                T6.Text = HesapTutari + " TL";
            }
            catch
            {
                a6 = 0;
                T6.Text = "";
                
            }
        }

        private void F6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double a = Convert.ToDouble(M6.Text);
                Double b = Convert.ToDouble(F6.Text);
                a6 = a * b;
                String HesapTutari = (a6).ToString("F2").Replace('.', ',');
                T6.Text = HesapTutari + " TL";
            }
            catch
            {
                a6 = 0;
                T6.Text = "";
                
            }
        }

        private void M7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double a = Convert.ToDouble(M7.Text);
                Double b = Convert.ToDouble(F7.Text);
                a7 = a * b;
                String HesapTutari = (a7).ToString("F2").Replace('.', ',');
                T7.Text = HesapTutari + " TL";
            }
            catch
            {
                a7 = 0;
                T7.Text = "";
                
            }
        }

        private void F7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double a = Convert.ToDouble(M7.Text);
                Double b = Convert.ToDouble(F7.Text);
                a7 = a * b;
                String HesapTutari = (a7).ToString("F2").Replace('.', ',');
                T7.Text = HesapTutari + " TL";
            }
            catch
            {
                a7 = 0;
                T7.Text = "";
                
            }
        }

        private void M8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double a = Convert.ToDouble(M8.Text);
                Double b = Convert.ToDouble(F8.Text);
                a8 = a * b;
                String HesapTutari = (a8).ToString("F2").Replace('.', ',');
                T8.Text = HesapTutari + " TL";
            }
            catch
            {
                a8 = 0;
                T8.Text = "";
                
            }
        }

        private void F8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double a = Convert.ToDouble(M8.Text);
                Double b = Convert.ToDouble(F8.Text);
                a8 = a * b;
                String HesapTutari = (a8).ToString("F2").Replace('.', ',');
                T8.Text = HesapTutari + " TL";
            }
            catch
            {
                a8 = 0;
                T8.Text = "";
                
            }
        }

        private void M9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double a = Convert.ToDouble(M9.Text);
                Double b = Convert.ToDouble(F9.Text);
                a9 = a * b;
                String HesapTutari = (a9).ToString("F2").Replace('.', ',');
                T9.Text = HesapTutari + " TL";
            }
            catch
            {
                a9 = 0;
                T9.Text = "";
                
            }
        }

        private void F9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double a = Convert.ToDouble(M9.Text);
                Double b = Convert.ToDouble(F9.Text);
                a9 = a * b;
                String HesapTutari = (a9).ToString("F2").Replace('.', ',');
                T9.Text = HesapTutari + " TL";
            }
            catch
            {
                a9 = 0;
                T9.Text = "";
                
            }
        }

        private void M10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double a = Convert.ToDouble(M10.Text);
                Double b = Convert.ToDouble(F10.Text);
                a10 = a * b;
                String HesapTutari = (a10).ToString("F2").Replace('.', ',');
                T10.Text = HesapTutari + " TL";
            }
            catch
            {
                a10 = 0;
                T10.Text = "";
                
            }
        }

        private void F10_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double a = Convert.ToDouble(M10.Text);
                Double b = Convert.ToDouble(F10.Text);
                a10 = a * b;
                String HesapTutari = (a10).ToString("F2").Replace('.', ',');
                T10.Text = HesapTutari + " TL";
            }
            catch
            {
                a10 = 0;
                T10.Text = "";
                
            }
        }

        private void M11_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double a = Convert.ToDouble(M11.Text);
                Double b = Convert.ToDouble(F11.Text);
                a11 = a * b;
                String HesapTutari = (a11).ToString("F2").Replace('.', ',');
                T11.Text = HesapTutari + " TL";
            }
            catch
            {
                a11 = 0;
                T11.Text = "";
                
            }
        }

        private void F11_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double a = Convert.ToDouble(M11.Text);
                Double b = Convert.ToDouble(F11.Text);
                a11 = a * b;
                String HesapTutari = (a11).ToString("F2").Replace('.', ',');
                T11.Text = HesapTutari + " TL";
            }
            catch
            {
                a11 = 0;
                T11.Text = "";
                
            }
        }

        private void M12_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double a = Convert.ToDouble(M12.Text);
                Double b = Convert.ToDouble(F12.Text);
                a12 = a * b;
                String HesapTutari = (a12).ToString("F2").Replace('.', ',');
                T12.Text = HesapTutari + " TL";
            }
            catch
            {
                a12 = 0;
                T12.Text = "";
                
            }
        }

        private void F12_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double a = Convert.ToDouble(M12.Text);
                Double b = Convert.ToDouble(F12.Text);
                a12 = a * b;
                String HesapTutari = (a12).ToString("F2").Replace('.', ',');
                T12.Text = HesapTutari + " TL";
            }
            catch
            {
                a12 = 0;
                T12.Text = "";
                
            }
        }

        private void M13_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double a = Convert.ToDouble(M13.Text);
                Double b = Convert.ToDouble(F13.Text);
                a13 = a * b;
                String HesapTutari = (a13).ToString("F2").Replace('.', ',');
                T13.Text = HesapTutari + " TL";
            }
            catch
            {
                a13 = 0;
                T13.Text = "";
                
            }
        }

        private void F13_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double a = Convert.ToDouble(M13.Text);
                Double b = Convert.ToDouble(F13.Text);
                a13 = a * b;
                String HesapTutari = (a13).ToString("F2").Replace('.', ',');
                T13.Text = HesapTutari + " TL";
            }
            catch
            {
                a13 = 0;
                T13.Text = "";
                
            }
        }

        private void T1_TextChanged(object sender, EventArgs e)
        {
            topla();
        }

        private void T2_TextChanged(object sender, EventArgs e)
        {
            topla();
        }

        private void T3_TextChanged(object sender, EventArgs e)
        {
            topla();
        }

        private void T4_TextChanged(object sender, EventArgs e)
        {
            topla();
        }

        private void T5_TextChanged(object sender, EventArgs e)
        {
            topla();
        }

        private void T6_TextChanged(object sender, EventArgs e)
        {
            topla();
        }

        private void T7_TextChanged(object sender, EventArgs e)
        {
            topla();
        }

        private void T8_TextChanged(object sender, EventArgs e)
        {
            topla();
        }

        private void T9_TextChanged(object sender, EventArgs e)
        {
            topla();
        }

        private void T10_TextChanged(object sender, EventArgs e)
        {
            topla();
        }

        private void T11_TextChanged(object sender, EventArgs e)
        {
            topla();
        }

        private void T12_TextChanged(object sender, EventArgs e)
        {
            topla();
        }

        private void T13_TextChanged(object sender, EventArgs e)
        {
            topla();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void yenileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label15.Text = label15.Text.Substring(1) + label15.Text.Substring(0, 1);
            label16.Text = DateTime.Now.ToString();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            try
            {
                con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database1.accdb");
                con.Open();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Veritabanı dosyası bulunamadı");
                Application.Exit();
            }
            dataReader();
        }

        private void comboKDV1_SelectedIndexChanged(object sender, EventArgs e)
        {
            topla();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult exit;
            exit = MessageBox.Show("Çıkmak istediğinize emin misiniz.", "Çıkış", MessageBoxButtons.YesNo);
            if(exit == DialogResult.Yes)Application.Exit();
        }

        private void yenileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dataReader();
        }


        private void faturaHakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void tabloyuGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateTablo();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateTablo();
            if (f_no.Text != "") 
            {
                string ad = f_no.Text;
                string sifre = tarih.Text;
                con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database1.accdb");
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Fatura where Fatura_No='" + ad + "' AND Tarih='" + sifre + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    con.Close();
                }
                else
                {
                    saveButton();
                    con.Close();
                }
            }
        }
        private void advancedSearch() 
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database1.accdb");
            //Arama Bölümü
            if (radioButton1.Checked) { cmd = new OleDbCommand("SElect *from Fatura where Fatura_No like '" + textBox4.Text + "%'", con); }
            else if (radioButton2.Checked) { cmd = new OleDbCommand("SElect *from Fatura where Tarih like '" + textBox4.Text + "%'", con); }
            else if (radioButton3.Checked) { cmd = new OleDbCommand("SElect *from Fatura where Musteri like '" + textBox4.Text + "%'", con); }
            else
            {
                cmd = new OleDbCommand("Select *From Fatura", con);
                MessageBox.Show("Lütfen aramak istediğiniz kriteri seçiniz");
            }
            //Arama Bölümü bitiş
            da = new OleDbDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void advancedSearch2()
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=Database1.accdb");
            //Arama Bölümü
            cmd = new OleDbCommand("SElect *from person where MUSTERI like '" + textBox5.Text + "%'", con);
            //Arama Bölümü bitiş
            da = new OleDbDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            advancedSearch();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            advancedSearch();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            advancedSearch();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            advancedSearch();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            advancedSearch2();
        }

        private void kutucuklarıTemizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveButton2();
            }
            catch
            {
                MessageBox.Show("Veritabanı kayıt hatası");
            }
        }



    }
}
