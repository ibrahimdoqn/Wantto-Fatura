using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing.Printing;
using System.IO;

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
        string serial = "";
        //Hesap toplamı için
        private double a1 = 0; private double a2 = 0; private double a3 = 0; private double a4 = 0; private double a5 = 0; private double a6 = 0; private double a7 = 0; private double a8 = 0; private double a9 = 0; private double a10 = 0; private double a11 = 0; private double a12 = 0; private double a13 = 0;
        //Print
        PrintDocument pDoc;

        public Form1()
        {
            InitializeComponent();
        }

        //Kağıt Boyutu ayarlama
        public static System.Drawing.Printing.PaperSize CalculatePaperSize(double WidthInCentimeters, double HeightInCentimetres)
        {
            int Width = int.Parse((Math.Round((WidthInCentimeters * 0.393701) * 100, 0, MidpointRounding.AwayFromZero)).ToString());
            int Height = int.Parse((Math.Round((HeightInCentimetres * 0.393701) * 100, 0, MidpointRounding.AwayFromZero)).ToString());
            PaperSize NewSize = new PaperSize();
            NewSize.RawKind = (int)PaperKind.Custom;
            NewSize.Width = Width;
            NewSize.Height = Height;
            NewSize.PaperName = "Letter";
            return NewSize;
        }

        public void printingCode()
        {
            saveButton();
            int formBoy = 28, formEn = 20;
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT formBoy, formEn FROM Form";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                formBoy = Convert.ToInt32(dr[0]);
                formEn = Convert.ToInt32(dr[1]);

            }
            dr.Close();
            pDoc = new PrintDocument();
            pDoc.PrintPage += new PrintPageEventHandler(pDoc_PrintPage);
            pDoc.DefaultPageSettings.PaperSize = CalculatePaperSize(formEn, formBoy);
        }

        // Print Fonksionu
        void pDoc_PrintPage(object sender, PrintPageEventArgs e)
        {

            //Fatura ayarları
            float SatirAralik = 10f;
            //Üstten
            float sayinBaslangic = 10f;
            float detayBaslangic = 80f;
            float vdBaslangic = 40f;
            float tarihBaslangic = 30f;
            float yekunBaslangıc = 200f;
            float kdvBaslangıc = 210f;
            float toplamBaslangic = 220f;
            float yazileBaslangic = 220f;
            //Yandan
            float cBaslangic = 10f;
            float mBaslangic = 50f;
            float fBaslangic = 90f;
            float tBaslangic = 110f;
            float sayinYandan = 10f;
            float vd1Yandan = 10f;
            float vd2Yandan = 40f;
            float tarihYandan = 90f;
            float yekunYandan = 150;
            float kdvYandan = 150;
            float toplamYandan = 150f;
            float yazileYandan = 50f;

            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT *FROM Form";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                SatirAralik = float.Parse(dr[1].ToString());
                sayinBaslangic = float.Parse(dr[2].ToString());
                detayBaslangic = float.Parse(dr[3].ToString());
                vdBaslangic = float.Parse(dr[4].ToString());
                tarihBaslangic = float.Parse(dr[5].ToString());
                yekunBaslangıc = float.Parse(dr[6].ToString());
                kdvBaslangıc = float.Parse(dr[7].ToString());
                toplamBaslangic = float.Parse(dr[8].ToString());
                yazileBaslangic = float.Parse(dr[9].ToString());
                cBaslangic = float.Parse(dr[10].ToString());
                mBaslangic = float.Parse(dr[11].ToString());
                fBaslangic = float.Parse(dr[12].ToString());
                tBaslangic = float.Parse(dr[13].ToString());
                sayinYandan = float.Parse(dr[14].ToString());
                vd1Yandan = float.Parse(dr[15].ToString());
                vd2Yandan = float.Parse(dr[16].ToString());
                tarihYandan = float.Parse(dr[17].ToString());
                yekunYandan = float.Parse(dr[18].ToString());
                kdvYandan = float.Parse(dr[19].ToString());
                toplamYandan = float.Parse(dr[20].ToString());
                yazileYandan = float.Parse(dr[21].ToString());

            }
                dr.Close();
            float aralik(float baslangic, float Satir)
            {
                return baslangic + (Satir * SatirAralik);
            }

            // Bundan sonra X, Y, Genislik, Yukseklik gibi olculerde
            // Pixel degil Milimetre kullanicahiz
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;

            // Bu sekilde sabit bir printer'a yonlendire biliriz
            // e.PageSettings.PrinterSettings.PrinterName = "Bir Printer Adi";

            // yazdirmada kullanilacak bir font olusturalim.
            Font aFont = new System.Drawing.Font("Arial", 10);

            // stringi pDoc nesnemize yazdiralim.
            // string olarak "Deneme" verdik.
            // renk olarak brushes.black verdik ve X,Y olarak noktalarimizi belirttik.
            // ben genelde point kullanmaktan yana degilimdir gerci
            // bu yuzden tanimlamayi pointsiz yapalim.

            if (File.Exists(@"IMG.jpg") == true)
            {
                Image aImg = Image.FromFile(@"IMG.jpg");
                e.Graphics.DrawImage(aImg, 0, 0, 200, 280);
            }
                

            // Resim ekleme sol'dan 10 mm, yukardan 25 mm atliyarak
            // resmi resize etmek isterseniz bunuda bunuda
            // genislik 30 mm yukseklik 42 mm olarak atadik.
            
            
            //Sayın Kısmı
            e.Graphics.DrawString(textBox1.Text, aFont, Brushes.Black, sayinYandan, aralik(sayinBaslangic, 0f));
            e.Graphics.DrawString(textBox2.Text, aFont, Brushes.Black, sayinYandan, aralik(sayinBaslangic, 1f));
            e.Graphics.DrawString(textBox3.Text, aFont, Brushes.Black, sayinYandan, aralik(sayinBaslangic, 2f));
            //Vergi Dairesi Vergi No
            e.Graphics.DrawString(vd1.Text, aFont, Brushes.Black, vd1Yandan, vdBaslangic);
            e.Graphics.DrawString(vd2.Text, aFont, Brushes.Black, vd2Yandan, vdBaslangic);
            //Tarih
            e.Graphics.DrawString(dateTimePicker3.Value.ToShortDateString(), aFont, Brushes.Black, tarihYandan, tarihBaslangic);
            //Fatura Detayları

            if (C1.Text != "")
            {
                e.Graphics.DrawString(C1.Text, aFont, Brushes.Black, cBaslangic, aralik(detayBaslangic,0f));
                e.Graphics.DrawString(M1.Text + " " + B1.Text, aFont, Brushes.Black, mBaslangic, aralik(detayBaslangic, 0f));
                //e.Graphics.DrawString(B1.Text, aFont, Brushes.Black, bBaslangic, aralik(detayBaslangic, 0f));
                e.Graphics.DrawString(F1.Text + " TL", aFont, Brushes.Black, fBaslangic, aralik(detayBaslangic, 0f));
                e.Graphics.DrawString(T1.Text + " TL", aFont, Brushes.Black, tBaslangic, aralik(detayBaslangic, 0f));
            }
            if (C2.Text != "")
            {
                e.Graphics.DrawString(C2.Text, aFont, Brushes.Black, cBaslangic, aralik(detayBaslangic, 1f));
                e.Graphics.DrawString(M2.Text + " " + B2.Text, aFont, Brushes.Black, mBaslangic, aralik(detayBaslangic, 1f));
                //e.Graphics.DrawString(B2.Text, aFont, Brushes.Black, bBaslangic, aralik(detayBaslangic, 1f));
                e.Graphics.DrawString(F2.Text + " TL", aFont, Brushes.Black, fBaslangic, aralik(detayBaslangic, 1f));
                e.Graphics.DrawString(T2.Text + " TL", aFont, Brushes.Black, tBaslangic, aralik(detayBaslangic, 1f));
            }
            if (C3.Text != "")
            {
                e.Graphics.DrawString(C3.Text, aFont, Brushes.Black, cBaslangic, aralik(detayBaslangic, 2f));
                e.Graphics.DrawString(M3.Text + " " + B3.Text, aFont, Brushes.Black, mBaslangic, aralik(detayBaslangic, 2f));
                //e.Graphics.DrawString(B3.Text, aFont, Brushes.Black, bBaslangic, aralik(detayBaslangic, 2f));
                e.Graphics.DrawString(F3.Text + " TL", aFont, Brushes.Black, fBaslangic, aralik(detayBaslangic, 2f));
                e.Graphics.DrawString(T3.Text + " TL", aFont, Brushes.Black, tBaslangic, aralik(detayBaslangic, 2f));
            }
            if (C4.Text != "")
            {
                e.Graphics.DrawString(C4.Text, aFont, Brushes.Black, cBaslangic, aralik(detayBaslangic, 3f));
                e.Graphics.DrawString(M4.Text + " " + B4.Text, aFont, Brushes.Black, mBaslangic, aralik(detayBaslangic, 3f));
                //e.Graphics.DrawString(B4.Text, aFont, Brushes.Black, bBaslangic, aralik(detayBaslangic, 3f));
                e.Graphics.DrawString(F4.Text + " TL", aFont, Brushes.Black, fBaslangic, aralik(detayBaslangic, 3f));
                e.Graphics.DrawString(T4.Text + " TL", aFont, Brushes.Black, tBaslangic, aralik(detayBaslangic, 3f));
            }
            if (C5.Text != "")
            {
                e.Graphics.DrawString(C5.Text, aFont, Brushes.Black, cBaslangic, aralik(detayBaslangic, 4f));
                e.Graphics.DrawString(M5.Text + " " + B5.Text, aFont, Brushes.Black, mBaslangic, aralik(detayBaslangic, 4f));
                //e.Graphics.DrawString(B5.Text, aFont, Brushes.Black, bBaslangic, aralik(detayBaslangic, 4f));
                e.Graphics.DrawString(F5.Text + " TL", aFont, Brushes.Black, fBaslangic, aralik(detayBaslangic, 4f));
                e.Graphics.DrawString(T5.Text + " TL", aFont, Brushes.Black, tBaslangic, aralik(detayBaslangic, 4f));
            }
            if (C6.Text != "")
            {
                e.Graphics.DrawString(C6.Text, aFont, Brushes.Black, cBaslangic, aralik(detayBaslangic, 5f));
                e.Graphics.DrawString(M6.Text + " " + B6.Text, aFont, Brushes.Black, mBaslangic, aralik(detayBaslangic, 5f));
                //e.Graphics.DrawString(B6.Text, aFont, Brushes.Black, bBaslangic, aralik(detayBaslangic, 5f));
                e.Graphics.DrawString(F6.Text + " TL", aFont, Brushes.Black, fBaslangic, aralik(detayBaslangic, 5f));
                e.Graphics.DrawString(T6.Text + " TL", aFont, Brushes.Black, tBaslangic, aralik(detayBaslangic, 5f));
            }
            if (C7.Text != "")
            {
                e.Graphics.DrawString(C7.Text, aFont, Brushes.Black, cBaslangic, aralik(detayBaslangic, 6f));
                e.Graphics.DrawString(M7.Text + " " + B7.Text, aFont, Brushes.Black, mBaslangic, aralik(detayBaslangic, 6f));
                //e.Graphics.DrawString(B7.Text, aFont, Brushes.Black, bBaslangic, aralik(detayBaslangic, 6f));
                e.Graphics.DrawString(F7.Text + " TL", aFont, Brushes.Black, fBaslangic, aralik(detayBaslangic, 6f));
                e.Graphics.DrawString(T7.Text + " TL", aFont, Brushes.Black, tBaslangic, aralik(detayBaslangic, 6f));
            }
            if (C8.Text != "")
            {
                e.Graphics.DrawString(C8.Text, aFont, Brushes.Black, cBaslangic, aralik(detayBaslangic, 7f));
                e.Graphics.DrawString(M8.Text + " " + B8.Text, aFont, Brushes.Black, mBaslangic, aralik(detayBaslangic, 7f));
                //e.Graphics.DrawString(B8.Text, aFont, Brushes.Black, bBaslangic, aralik(detayBaslangic, 7f));
                e.Graphics.DrawString(F8.Text + " TL", aFont, Brushes.Black, fBaslangic, aralik(detayBaslangic, 7f));
                e.Graphics.DrawString(T8.Text + " TL", aFont, Brushes.Black, tBaslangic, aralik(detayBaslangic, 7f));
            }
            if (C9.Text != "")
            {
                e.Graphics.DrawString(C9.Text, aFont, Brushes.Black, cBaslangic, aralik(detayBaslangic, 8f));
                e.Graphics.DrawString(M9.Text + " " + B9.Text, aFont, Brushes.Black, mBaslangic, aralik(detayBaslangic, 8f));
                //e.Graphics.DrawString(B9.Text, aFont, Brushes.Black, bBaslangic, aralik(detayBaslangic, 8f));
                e.Graphics.DrawString(F9.Text + " TL", aFont, Brushes.Black, fBaslangic, aralik(detayBaslangic, 8f));
                e.Graphics.DrawString(T9.Text + " TL", aFont, Brushes.Black, tBaslangic, aralik(detayBaslangic, 8f));
            }
            if (C10.Text != "")
            {
                e.Graphics.DrawString(C10.Text, aFont, Brushes.Black, cBaslangic, aralik(detayBaslangic, 9f));
                e.Graphics.DrawString(M10.Text + " " + B10.Text, aFont, Brushes.Black, mBaslangic, aralik(detayBaslangic, 9f));
                //e.Graphics.DrawString(B10.Text, aFont, Brushes.Black, bBaslangic, aralik(detayBaslangic, 9f));
                e.Graphics.DrawString(F10.Text + " TL", aFont, Brushes.Black, fBaslangic, aralik(detayBaslangic, 9f));
                e.Graphics.DrawString(T10.Text + " TL", aFont, Brushes.Black, tBaslangic, aralik(detayBaslangic, 9f));
            }
            if (C11.Text != "")
            {
                e.Graphics.DrawString(C11.Text, aFont, Brushes.Black, cBaslangic, aralik(detayBaslangic, 10f));
                e.Graphics.DrawString(M11.Text + " " + B11.Text, aFont, Brushes.Black, mBaslangic, aralik(detayBaslangic, 10f));
                //e.Graphics.DrawString(B11.Text, aFont, Brushes.Black, bBaslangic, aralik(detayBaslangic, 10f));
                e.Graphics.DrawString(F11.Text + " TL", aFont, Brushes.Black, fBaslangic, aralik(detayBaslangic, 10f));
                e.Graphics.DrawString(T11.Text + " TL", aFont, Brushes.Black, tBaslangic, aralik(detayBaslangic, 10f));
            }
            if (C12.Text != "")
            {
                e.Graphics.DrawString(C12.Text, aFont, Brushes.Black, cBaslangic, aralik(detayBaslangic, 11f));
                e.Graphics.DrawString(M12.Text + " " + B12.Text, aFont, Brushes.Black, mBaslangic, aralik(detayBaslangic, 11f));
                //e.Graphics.DrawString(B12.Text, aFont, Brushes.Black, bBaslangic, aralik(detayBaslangic, 11f));
                e.Graphics.DrawString(F12.Text + " TL", aFont, Brushes.Black, fBaslangic, aralik(detayBaslangic, 11f));
                e.Graphics.DrawString(T12.Text + " TL", aFont, Brushes.Black, tBaslangic, aralik(detayBaslangic, 11f));
            }
            if (C13.Text != "")
            {
                e.Graphics.DrawString(C13.Text, aFont, Brushes.Black, cBaslangic, aralik(detayBaslangic, 12f));
                e.Graphics.DrawString(M13.Text + " " + B13.Text, aFont, Brushes.Black, mBaslangic, aralik(detayBaslangic, 12f));
                //e.Graphics.DrawString(B13.Text, aFont, Brushes.Black, bBaslangic, aralik(detayBaslangic, 12f));
                e.Graphics.DrawString(F13.Text + " TL", aFont, Brushes.Black, fBaslangic, aralik(detayBaslangic, 12f));
                e.Graphics.DrawString(T13.Text + " TL", aFont, Brushes.Black, tBaslangic, aralik(detayBaslangic, 12f));
            }
            //Yekun KDV Toplam
            e.Graphics.DrawString(yekun.Text + " TL", aFont, Brushes.Black, yekunYandan, yekunBaslangıc);
            e.Graphics.DrawString(kdv.Text + " TL", aFont, Brushes.Black, kdvYandan, kdvBaslangıc);
            e.Graphics.DrawString(toplam.Text + " TL", aFont, Brushes.Black, toplamYandan, toplamBaslangic);
            //Yalnız
            e.Graphics.DrawString(yazile.Text, aFont, Brushes.Black, yazileYandan, yazileBaslangic);
        }

        public void fyazdir()
        {
            printPreviewDialog1.Document = pDoc;
            DialogResult sayfaOnizleme;
            sayfaOnizleme = printPreviewDialog1.ShowDialog();
            if (sayfaOnizleme == DialogResult.OK)
            {
                pDoc.Print();
            }
        }

        public void dataReader() 
        {
            dataReader2();
            dataReader1();
        }

        public void dataReader1() 
        {
            string vFDate, vTDate, vStr, vStr1, vStr2, vStr3;
            vFDate = dateTimePicker1.Value.ToShortDateString();
            vTDate = dateTimePicker2.Value.ToShortDateString();
            if (checkBox1.Checked == true && checkBox2.Checked)
            {
                vStr = "Select Fatura_No, Tarih, Musteri, Toplam, Odendi From Fatura where Date1 between tr1 and tr2";
                vStr1 = "SELECT sum(kdv) FROM Fatura WHERE Date1 BETWEEN @FD AND @TD";
                vStr2 = "SELECT sum(Yekun) FROM Fatura WHERE Date1 BETWEEN @FD AND @TD";
                vStr3 = "SELECT sum(Toplam) FROM Fatura WHERE Date1 BETWEEN @FD AND @TD";
            }
            else if (checkBox1.Checked == true)
            {
                vStr = "Select Fatura_No, Tarih, Musteri, Toplam, Odendi From Fatura where Date1 between tr1 and tr2 AND odendi ='Evet'";
                vStr1 = "SELECT sum(kdv) FROM Fatura WHERE Date1 BETWEEN @FD AND @TD AND odendi ='Evet'";
                vStr2 = "SELECT sum(Yekun) FROM Fatura WHERE Date1 BETWEEN @FD AND @TD AND odendi ='Evet'";
                vStr3 = "SELECT sum(Toplam) FROM Fatura WHERE Date1 BETWEEN @FD AND @TD AND odendi ='Evet'";
            }
            else if (checkBox2.Checked == true)
            {
                vStr = "Select Fatura_No, Tarih, Musteri, Toplam, Odendi From Fatura where Date1 between tr1 and tr2 AND odendi ='Hayır'";
                vStr1 = "SELECT sum(kdv) FROM Fatura WHERE Date1 BETWEEN @FD AND @TD AND odendi ='Hayır'";
                vStr2 = "SELECT sum(Yekun) FROM Fatura WHERE Date1 BETWEEN @FD AND @TD AND odendi ='Hayır'";
                vStr3 = "SELECT sum(Toplam) FROM Fatura WHERE Date1 BETWEEN @FD AND @TD AND odendi ='Hayır'";
            }
            else
            {
                vStr = "Select Fatura_No, Tarih, Musteri, Toplam, Odendi From Fatura where Date1 between tr1 and tr2 AND odendi =''";
                vStr1 = "SELECT sum(kdv) FROM Fatura WHERE Date1 BETWEEN @FD AND @TD AND odendi =''";
                vStr2 = "SELECT sum(Yekun) FROM Fatura WHERE Date1 BETWEEN @FD AND @TD AND odendi =''";
                vStr3 = "SELECT sum(Toplam) FROM Fatura WHERE Date1 BETWEEN @FD AND @TD AND odendi =''";
            }

            if(comboBox1.Text != "")
            {
                vStr = vStr + " AND Musteri='" + comboBox1.Text + "'";
                vStr1 = vStr1 + " AND Musteri='" + comboBox1.Text + "'";
                vStr2 = vStr2 + " AND Musteri='" + comboBox1.Text + "'";
                vStr3 = vStr3 + " AND Musteri='" + comboBox1.Text + "'";
            }

            if (textBox4.Text != "")
            {
                vStr = vStr + " AND Fatura_No like '" + textBox4.Text + "%'";
                vStr1 = vStr1 + " AND Fatura_No like '" + textBox4.Text + "%'";
                vStr2 = vStr2 + " AND Fatura_No like '" + textBox4.Text + "%'";
                vStr3 = vStr3 + " AND Fatura_No like '" + textBox4.Text + "%'";
            }

            //Datagrid'i doldurur
            da = new OleDbDataAdapter(vStr, con);
            da.SelectCommand.Parameters.AddWithValue("tr1", vFDate);
            da.SelectCommand.Parameters.AddWithValue("tr2", vTDate);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Toplam KDV'yi hesaplar
            cmd = new OleDbCommand(vStr1, con);
            cmd.Parameters.AddWithValue("@FD", vFDate);
            cmd.Parameters.AddWithValue("@TD", vTDate);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label17.Text = "Toplam KDV: " + dr[0].ToString() + " TL";
            }
            dr.Close();

            //Aratoplamı Verir
            cmd = new OleDbCommand(vStr2, con);
            cmd.Parameters.AddWithValue("@FD", vFDate);
            cmd.Parameters.AddWithValue("@TD", vTDate);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label19.Text = "Aratoplam: " + dr[0].ToString() + " TL";
            }
            dr.Close();

            //Toplam Raporunu verir
            cmd = new OleDbCommand(vStr3, con);
            cmd.Parameters.AddWithValue("@FD", vFDate);
            cmd.Parameters.AddWithValue("@TD", vTDate);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                label20.Text = "Toplam: " + dr[0].ToString() + " TL";
            }
            dr.Close();

        }

        private void musteri()
        {
            //Musteri Combobox Kısmı
            comboBox1.Items.Clear();
            comboBox1.Items.Add("");
            cmd = new OleDbCommand("select distinct Musteri from Fatura", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Musteri"]);
            }
            dr.Close();
        }

        public void dataReader2()
        {
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
            yekun.Text = Yekun;//YEKUN
            kdv.Text = kdvHesap;//KDV
            toplam.Text = Toplam;//TOPLAM
        }
        private void saveButton()
        {
            if (f_no.Text != "")
            {
                string ad = f_no.Text;
                string sifre = dateTimePicker3.Value.ToShortDateString();
                cmd = new OleDbCommand();
                cmd.Connection = con;
                
                cmd.CommandText = "SELECT * FROM Fatura where Fatura_No='" + ad + "' AND Tarih='" + sifre + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Bu Fatura Seri No Zaten sistemde kayıtlı.");
                }
                else
                {
                    string ekle = "insert into Fatura(Fatura_No,Tarih,Musteri,Musteri2,Musteri3,Vergi_Dairesi,Vergi_No,m1,b1,c1,f1,t1,m2,b2,c2,f2,t2,m3,b3,c3,f3,t3,m4,b4,c4,f4,t4,m5,b5,c5,f5,t5,m6,b6,c6,f6,t6,m7,b7,c7,f7,t7,m8,b8,c8,f8,t8,m9,b9,c9,f9,t9,m10,b10,c10,f10,t10,m11,b11,c11,f11,t11,m12,b12,c12,f12,t12,m13,b13,c13,f13,t13,Yekun,KDV,Toplam,kdvoran,yalniz,Odendi,Date1) values (@Fatura_No,@Tarih,@Musteri,@Musteri2,@Musteri3,@Vergi_Dairesi,@Vergi_No,@m1,@b1,@c1,@f1,@t1,@m2,@b2,@c2,@f2,@t2,@m3,@b3,@c3,@f3,@t3,@m4,@b4,@c4,@f4,@t4,@m5,@b5,@c5,@f5,@t5,@m6,@b6,@c6,@f6,@t6,@m7,@b7,@c7,@f7,@t7,@m8,@b8,@c8,@f8,@t8,@m9,@b9,@c9,@f9,@t9,@m10,@b10,@c10,@f10,@t10,@m11,@b11,@c11,@f11,@t11,@m12,@b12,@c12,@f12,@t12,@m13,@b13,@c13,@f13,@t13,@Yekun,@KDV,@Toplam,@kdvoran,@yalniz,@Odendi,@Date1)";
                    cmd = new OleDbCommand(ekle, con);
                    cmd.Parameters.AddWithValue("@Fatura_No", f_no.Text);//Fatura No
                    cmd.Parameters.AddWithValue("@Tarih", dateTimePicker3.Value.ToShortDateString());//Tarih
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
                    cmd.Parameters.AddWithValue("@Odendi", "Hayır");
                    cmd.Parameters.AddWithValue("@Date1", dateTimePicker3.Value.ToShortDateString());//Tarih
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt başarılı");
                    dataReader();
                    dr.Close();
                }
                musteri();
            }
            else
            {
                MessageBox.Show("Fatura Seri No Boş Bırakılamaz");
            }
        }

        private void saveButton2()
        {
            if(textBox6.Text != "")
            {
            string ekle = "insert into person(MUSTERI,MUSTERI_2,MUSTERI_3,VERGI_DAIRESI,VERGI_NO) values (@MUSTERI,@MUSTERI_2,@MUSTERI_3,@VERGI_DAIRESI,@VERGI_NO)";
            OleDbCommand cmd = new OleDbCommand(ekle, con);
            cmd.Parameters.AddWithValue("@MUSTERI", textBox6.Text);//Müşteri
            cmd.Parameters.AddWithValue("@MUSTERI_2", textBox7.Text);//Müşteri2
            cmd.Parameters.AddWithValue("@MUSTERI_3", textBox8.Text);//Müşteri3
            cmd.Parameters.AddWithValue("@VERGI_DAIRESI", textBox9.Text);
            cmd.Parameters.AddWithValue("@VERGI_NO", textBox10.Text);
            cmd.ExecuteNonQuery();
            dataReader();
            MessageBox.Show("Firma Başarıyla kaydedildi");
            }
            else MessageBox.Show("İlk kutucuk boş bırakılamaz");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textDelete();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox7.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox8.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBox9.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            textBox10.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
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
                T1.Text = HesapTutari;
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
                T1.Text = HesapTutari;
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
                T2.Text = HesapTutari;
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
                T2.Text = HesapTutari;
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
                T3.Text = HesapTutari;
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
                T3.Text = HesapTutari;
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
                T4.Text = HesapTutari;
            }
            catch
            {
                a4 = 0;
                T4.Text = "";
                
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
                T4.Text = HesapTutari;
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
                T5.Text = HesapTutari;
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
                T5.Text = HesapTutari;
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
                T6.Text = HesapTutari;
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
                T6.Text = HesapTutari;
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
                T7.Text = HesapTutari;
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
                T7.Text = HesapTutari;
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
                T8.Text = HesapTutari;
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
                T8.Text = HesapTutari;
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
                T9.Text = HesapTutari;
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
                T9.Text = HesapTutari;
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
                T10.Text = HesapTutari;
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
                T10.Text = HesapTutari;
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
                T11.Text = HesapTutari;
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
                T11.Text = HesapTutari;
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
                T12.Text = HesapTutari;
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
                T12.Text = HesapTutari;
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
                T13.Text = HesapTutari;
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
                T13.Text = HesapTutari;
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
            }
            catch
            {
                MessageBox.Show("Veritabanı dosyası bulunamadı");
                Application.Exit();
            }
            dataReader();
            musteri();
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

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void tabloyuGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void advancedSearch2()
        {
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
            dataReader();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            advancedSearch2();
        }

        private void kutucuklarıTemizleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveButton();
        }

        private void firmayıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveButton2();
        }

        private void yazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void temizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textDelete();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serial = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete from Fatura where Fatura_No='" + serial + "'";
            cmd.ExecuteNonQuery();
            dataReader1();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            serial = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "update Fatura set odendi='Evet' where Fatura_No='" + serial + "'";
            cmd.ExecuteNonQuery();
            dataReader1();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            serial = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "update Fatura set odendi='Hayır' where Fatura_No='" + serial + "'";
            cmd.ExecuteNonQuery();
            dataReader1();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dataReader();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            dataReader();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataReader1();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dataReader1();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            serial = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete from Person where MUSTERI='" + serial + "'";
            cmd.ExecuteNonQuery();
            dataReader2();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            serial = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            serial = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            vd1.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            vd2.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            tabControl1.SelectedIndex = 0;
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            serial = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Fatura where Fatura_No='" + serial + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                
                f_no.Text = dr["Fatura_No"].ToString();
                string tarih = dr["Tarih"].ToString();
                DateTime oDate = DateTime.Parse(tarih);
                dateTimePicker3.Value = oDate;
                textBox1.Text = dr["Musteri"].ToString();
                textBox2.Text = dr["Musteri2"].ToString();
                textBox3.Text = dr["Musteri3"].ToString();
                vd1.Text = dr["Vergi_Dairesi"].ToString();
                vd2.Text = dr["Vergi_No"].ToString();
                M1.Text = dr["m1"].ToString();
                B1.Text = dr["b1"].ToString();
                C1.Text = dr["c1"].ToString();
                F1.Text = dr["f1"].ToString();
                T1.Text = dr["t1"].ToString();
                //
                M2.Text = dr["m2"].ToString();
                B2.Text = dr["b2"].ToString();
                C2.Text = dr["c2"].ToString();
                F2.Text = dr["f2"].ToString();
                T2.Text = dr["t2"].ToString();
                //
                //
                M3.Text = dr["m3"].ToString();
                B3.Text = dr["b3"].ToString();
                C3.Text = dr["c3"].ToString();
                F3.Text = dr["f3"].ToString();
                T3.Text = dr["t3"].ToString();
                //
                M4.Text = dr["m4"].ToString();
                B4.Text = dr["b4"].ToString();
                C4.Text = dr["c4"].ToString();
                F4.Text = dr["f4"].ToString();
                T4.Text = dr["t4"].ToString();
                //
                M5.Text = dr["m5"].ToString();
                B5.Text = dr["b5"].ToString();
                C5.Text = dr["c5"].ToString();
                F5.Text = dr["f5"].ToString();
                T5.Text = dr["t5"].ToString();
                //
                M6.Text = dr["m6"].ToString();
                B6.Text = dr["b6"].ToString();
                C6.Text = dr["c6"].ToString();
                F6.Text = dr["f6"].ToString();
                T6.Text = dr["t6"].ToString();
                //
                M7.Text = dr["m7"].ToString();
                B7.Text = dr["b7"].ToString();
                C7.Text = dr["c7"].ToString();
                F7.Text = dr["f7"].ToString();
                T7.Text = dr["t7"].ToString();
                //
                M8.Text = dr["m8"].ToString();
                B8.Text = dr["b8"].ToString();
                C8.Text = dr["c8"].ToString();
                F8.Text = dr["f8"].ToString();
                T8.Text = dr["t8"].ToString();
                //
                M9.Text = dr["m9"].ToString();
                B9.Text = dr["b9"].ToString();
                C9.Text = dr["c9"].ToString();
                F9.Text = dr["f9"].ToString();
                T9.Text = dr["t9"].ToString();
                //
                M10.Text = dr["m10"].ToString();
                B10.Text = dr["b10"].ToString();
                C10.Text = dr["c10"].ToString();
                F10.Text = dr["f10"].ToString();
                T10.Text = dr["t10"].ToString();
                //
                M11.Text = dr["m11"].ToString();
                B11.Text = dr["b11"].ToString();
                C11.Text = dr["c11"].ToString();
                F11.Text = dr["f11"].ToString();
                T11.Text = dr["t11"].ToString();
                //
                M12.Text = dr["m12"].ToString();
                B12.Text = dr["b12"].ToString();
                C12.Text = dr["c12"].ToString();
                F12.Text = dr["f12"].ToString();
                T12.Text = dr["t12"].ToString();
                //
                M13.Text = dr["m13"].ToString();
                B13.Text = dr["b13"].ToString();
                C13.Text = dr["c13"].ToString();
                F13.Text = dr["f13"].ToString();
                T13.Text = dr["t13"].ToString();
                //
                yekun.Text = dr["Yekun"].ToString();
                kdv.Text = dr["KDV"].ToString();
                toplam.Text = dr["Toplam"].ToString();
                comboKDV1.Text = dr["kdvoran"].ToString();
                yazile.Text = dr["yalniz"].ToString();
            }
            dr.Close();
            tabControl1.SelectedIndex = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            saveButton2();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            serial = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = "update person set MUSTERI='"+ textBox6.Text + "', MUSTERI_2='" + textBox7.Text + "', MUSTERI_3='" + textBox8.Text + "', VERGI_DAIRESI='" + textBox9.Text + "', VERGI_NO='" + textBox10.Text + "' where MUSTERI='" + serial + "'";
            cmd.ExecuteNonQuery();
            dataReader2();
        }

        private void formAyarlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataReader();
        }

        private void menüToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void yazdırToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            printingCode();
            printDialog1.Document = pDoc;
            DialogResult yazdirmaIslemi;
            yazdirmaIslemi = printDialog1.ShowDialog();
            if (yazdirmaIslemi == DialogResult.OK)
            {
                pDoc.Print();
            }
        }

        private void sayfaÖnizlemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printingCode();
            fyazdir();
        }
    }
}
