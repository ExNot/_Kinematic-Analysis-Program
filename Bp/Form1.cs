using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;

namespace Bp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics grafik;
        int Sayac;
        string CizimModu = null;
        int X11 = 0; //1. çubuğun X1'i
        int Y11 = 0; //1. çubuğun Y1'i
        int X12 = 0; //1. çubuğun X2'si
        int Y12 = 0; //1. çubuğun Y2'si
        int X21 = 0; //2. çubuğun X1'i
        int Y21 = 0; //2. çubuğun Y1'i
        int X22 = 0; //2. çubuğun X2'si
        int Y22 = 0; //2. çubuğun Y2'si
        int X31 = 0; //3. çubuğun X1'i
        int Y31 = 0; //3. çubuğun Y1'i
        int X32 = 0; //3. çubuğun X2'si
        int Y32 = 0; //3. çubuğun Y2'si
        Pen Kalem = new Pen(System.Drawing.Color.White, 1);
        int say = 0;
        int say1 = 0; 


        double r11, r22, r33, r44;
        double tet2, tet3, tet4;
        double ahizz;

        private void Form1_MouseClick_1(object sender, MouseEventArgs e)
        {
            grafik.DrawLine(Pens.Yellow, 20, 300, 50, 300);
            grafik.DrawLine(Pens.Yellow, 50, 300, 35, 274);
            grafik.DrawLine(Pens.Yellow, 35, 274, 20, 300);

            grafik.DrawLine(Pens.Yellow, 410, 300, 440, 300);
            grafik.DrawLine(Pens.Yellow, 440, 300, 425, 274);
            grafik.DrawLine(Pens.Yellow, 425, 274, 410, 300);
        }

        private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            if (say == 0)
            {
                X11 = 35;
                Y11 = 274;
                X12 = e.X;
                Y12 = e.Y;
                grafik.DrawLine(Pens.Yellow, X11, Y11, X12, Y12);

                say++;

                //if (say1 == 0 && X1 < 38 && X1 > 32 && Y1 < 277 && Y1 > 271)
                //{
                //    say1++;
                //    int X1 = e.X;
                //    int Y1 = e.Y;
                //}
                //else if (say1 == 1)
                //{
                //    X2 = e.X;
                //    Y2 = e.Y;
                //    grafik.DrawLine(Pens.Yellow, X1, Y1, X2, Y2);
                //    say++;
                //    say1 = 0;
                //}
                //else
                //    MessageBox.Show("Lütfen ilk Mesnetten Başlayınız");
            }
            else if (say == 1)
            {
                X22 = e.X;
                Y22 = e.Y;
                grafik.DrawLine(Pens.Yellow, X12, Y12, X22, Y22);
                say++;

            }
            else if (say == 2)
            {

                grafik.DrawLine(Pens.Yellow, X22, Y22, 425, 274);
                say++;
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            grafik = pictureBox1.CreateGraphics();
        }

        double hiztet3, ivmetet3, hiztet4, ivmetet4;

        double z1t3, z2t3, z1t4, z2t4, gustet3, gustet4;

        private void listBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                string s = listBox4.SelectedItem.ToString();
                Clipboard.SetText(string.Join(Environment.NewLine, listBox4.SelectedItems.OfType<string>()));
            }
        }

        private void listBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                string s = listBox5.SelectedItem.ToString();
                Clipboard.SetText(string.Join(Environment.NewLine, listBox5.SelectedItems.OfType<string>()));
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        private void listBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                string s = listBox3.SelectedItem.ToString();
                Clipboard.SetText(string.Join(Environment.NewLine, listBox3.SelectedItems.OfType<string>()));
            }
        }

        private void listBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                string s = listBox2.SelectedItem.ToString();
                Clipboard.SetText(string.Join(Environment.NewLine, listBox2.SelectedItems.OfType<string>()));
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                string s = listBox1.SelectedItem.ToString();
                Clipboard.SetText(string.Join(Environment.NewLine, listBox1.SelectedItems.OfType<string>()));
            }
        }



        double ek = 0;
        double lk = 0;
        double rk = 0;

        ArrayList Dizihiztetk = new ArrayList();
        ArrayList Dizihizxk = new ArrayList();
        ArrayList Diziivmetetk = new ArrayList();
        ArrayList Diziivmexk = new ArrayList();
        ArrayList __Dizitet2 = new ArrayList();
        ArrayList __Dizisaniye = new ArrayList();


        //krankbiyel*************************************************
        private void button4_Click(object sender, EventArgs e)
        {

            





            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();

            ek = double.Parse(textBox3.Text);
            lk = double.Parse(textBox2.Text);
            rk = double.Parse(textBox1.Text);

            double acisalhiz = double.Parse(textBox4.Text);

            double tet2 = 56.19;
            double tet21 = 56.19;

            int k = 0;

            double tetk, xk;

            while(k<360)
            {
                //************************************ X VE TETA KONUM****************************
                tet2 = tet2 * Math.PI /180;
                double kkk = Math.Sin(tet2);
                tetk = Math.Asin((ek - rk * kkk) / lk);

                
                double a = rk * Math.Cos(tet2);
                double b = rk * rk + ek * ek - lk * lk - 2 * ek * rk * Math.Sin(tet2);
                xk = a + Math.Sqrt(a * a - b);



                //************************************ X VE TETA HIZ****************************
                double z1t = -rk * Math.Cos(tet2);
                double z2t = lk * Math.Cos(tetk);
                double z1x = rk * (ek * Math.Cos(tet2) - xk * Math.Sin(tet2));
                double z2x = xk - rk * Math.Cos(tet2);

                double gust = z1t / z2t;
                double gusx = z1x / z2x;

                double tetkhiz = gust * acisalhiz;
                double xhiz = gusx * acisalhiz;



                //************************************ X VE TETA İVME****************************

                double z1tus, z2tus, z1xus, z2xus;

                z1tus = rk * Math.Sin(tet2);
                z2tus = -lk * gust * Math.Sin(tetk);
                z1xus = -rk * ((ek+gusx)*Math.Sin(tet2)+xk*Math.Cos(tet2));
                z2xus = gusx + rk * Math.Sin(tet2);
                
                double gusustetk = (z1tus * z2t - z1t * z2tus) / (z2t * z2t);
                double gususxk = (z1xus * z2x - z1x * z2xus) / (z2x * z2x);

                double ivmetetk = gusustetk * acisalhiz * acisalhiz;
                double ivmexk = gususxk * acisalhiz * acisalhiz;

                tet2 = tet2 * 180 / Math.PI;
                if (tet2 > 360)
                    tet2 = tet2 % 360;


                double ff = tet2 - tet21;
                double _ahizderece = acisalhiz * 180 / Math.PI;
                double _saniye = ff / _ahizderece;


                __Dizitet2.Add(tet2);
                Dizihiztetk.Add(tetkhiz);
                Dizihizxk.Add(xhiz);
                Diziivmetetk.Add(ivmetetk);
                Diziivmexk.Add(ivmexk);
                __Dizisaniye.Add(_saniye);

                listBox1.Items.Add("Hizteta" + "" + "=" + Dizihiztetk[k]);
                listBox2.Items.Add("HizX:" + "" + "=" + Dizihizxk[k]);
                listBox3.Items.Add("İvmeteta:" + "" + "=" + Diziivmetetk[k]);
                listBox4.Items.Add("İvmeX:" + "" + "=" + Diziivmexk[k]);
                listBox5.Items.Add("Saniye:" + "" + __Dizisaniye[k]);
                k++;
                tet2++;




            }






        }



        double teta21, f, ahizderece, saniye;
        double z1t3us, z2t3us, z1t4us, z2t4us, gusus;


        private void label13_Click(object sender, EventArgs e)
        {

        }



        ArrayList Dizihizssk = new ArrayList();
        ArrayList Dizihiztetsk = new ArrayList();
        ArrayList Diziivmessk = new ArrayList();
        ArrayList Diziivmetetsk = new ArrayList();
        ArrayList Dizitet2sk = new ArrayList();
        ArrayList Dizisaniyesk = new ArrayList();


        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();

            double xhiz = double.Parse(textBox11.Text);
            double xsk = double.Parse(textBox10.Text);
            double esk = double.Parse(textBox9.Text);
            double tet2 = 56.19;
            double f = 0;
            double teta21 = tet2;

            int m = 0;

            while(m<360)
            {
                tet2 = tet2 * (Math.PI / 180);


                //********************S VE TETA KONUM*********************************
                double ssk = Math.Sqrt(xsk * xsk + esk * esk);
                double tetask = Math.Atan(esk / xsk);

                //**********************S VE TETA HIZ*************************

                double z1s = xsk;
                double z2s = ssk;



                double z1tet = -esk * Math.Cos(tetask)*Math.Cos(tetask);
                double z2tet = xsk * xsk;
                double guss = z1s / z2s;
                double gustet = z1tet / z2tet;

                double shiz = guss * xhiz;
                double tethiz = gustet * xhiz;

                //*********************S VE TETA İVME***************************
                double z1sus = 1;
                double z2sus = guss;
                double z1tetus = 2 * esk * gustet * Math.Sin(tetask) * Math.Cos(tetask);
                double z2tetus = 2 * xsk;

                double gususs = (z1sus * z2s - z1s * z2sus) / (z2s * z2s);
                double gusustet = (z1tetus * z2tet - z1tet * z2tetus) / (z2tet * z2tet);

                double sivme = gususs * xhiz * xhiz;
                double tetivme = gusustet * xhiz * xhiz;
                tet2 = tet2 * 180 / Math.PI;
                if (tet2 > 360)
                {
                    tet2 = tet2 % 360;
                }


                f = tet2 - teta21;
                double __ahizderece = xhiz * 180 / Math.PI;
                double __saniye = f / ahizderece;

                Dizitet2sk.Add(tet2);
                Dizihiztetsk.Add(tethiz);
                Dizihizssk.Add(shiz);
                Diziivmessk.Add(sivme);
                Diziivmetetsk.Add(tetivme);
                Dizisaniyesk.Add(__saniye);

                listBox1.Items.Add("TetaHiz" + "" + "=" + Dizihiztetsk[0]);
                listBox2.Items.Add("SHiz:" + "" + "=" + Dizihizssk[0]);
                listBox3.Items.Add("İvmes:" + "" + "=" + Diziivmessk[0]);
                listBox4.Items.Add("İvmeTeta:" + "" + "=" + Diziivmetetsk[0]);
                listBox5.Items.Add("Saniye:" + "" + Dizisaniyesk[0]);
                m++;
                tet2++;


            }


        }



        ArrayList Dizihizs3 = new ArrayList();
        ArrayList Dizihizs4 = new ArrayList();
        ArrayList Diziivmes3 = new ArrayList();
        ArrayList Diziivmes4 = new ArrayList();

        private void button6_Click(object sender, EventArgs e)
        {
           

        }

        private void krankBiyelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            pictureBox1.Image = Image.FromFile(@"C:\Users\karta\OneDrive\Masaüstü\odev7\krankbiyel.jpg");
            textBox5.Visible = false;
            label1.Visible = false;
            label8.Visible = false;
            label7.Visible = false;
            label6.Visible = false;
            label5.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label19.Visible = false;
            label18.Visible = false;
            label17.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;

            ahiz.Visible = false;
            r1.Visible = false;
            r2.Visible = false;
            r3.Visible = false;
            r4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            _acisalhiz.Visible = false;
            x1.Visible = false;
            x2.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            textBox11.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;

            label12.Visible = true;
            label11.Visible = true;
            label10.Visible = true;
            label9.Visible = true;
            textBox4.Visible = true;
            textBox3.Visible = true;
            textBox2.Visible = true;
            textBox1.Visible = true;
            button4.Visible = true;
        }

        private void üçÇubukToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            pictureBox1.Image = Image.FromFile(@"C:\Users\karta\OneDrive\Masaüstü\odev7\uccubuk.jpg");
            label1.Visible = false;
            label8.Visible = false;
            label7.Visible = false;
            label6.Visible = false;
            label5.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label19.Visible = false;
            label18.Visible = false;
            label17.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;

            ahiz.Visible = false;
            r1.Visible = false;
            r2.Visible = false;
            r3.Visible = false;
            r4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            _acisalhiz.Visible = false;
            x1.Visible = false;
            x2.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            textBox11.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;

            label1.Visible = true;
            label8.Visible = true;
            label7.Visible = true;
            label6.Visible = true;
            label5.Visible = true;
            ahiz.Visible = true;
            r1.Visible = true;
            r2.Visible = true;
            r3.Visible = true;
            r4.Visible = true;
            button1.Visible = true;
        }

        private void kolKızakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            pictureBox1.Image = Image.FromFile(@"C:\Users\karta\OneDrive\Masaüstü\odev7\kolkizak.jpg");
            textBox5.Visible = false;
            label1.Visible = false;
            label8.Visible = false;
            label7.Visible = false;
            label6.Visible = false;
            label5.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label19.Visible = false;
            label18.Visible = false;
            label17.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;

            ahiz.Visible = false;
            r1.Visible = false;
            r2.Visible = false;
            r3.Visible = false;
            r4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            _acisalhiz.Visible = false;
            x1.Visible = false;
            x2.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            textBox11.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;

            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            x1.Visible = true;
            x2.Visible = true;
            _acisalhiz.Visible = true;
            button3.Visible = true;

        }

        private void iskoçBoyunduruğuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            pictureBox1.Image = Image.FromFile(@"C:\Users\karta\OneDrive\Masaüstü\odev7\ib.jpg");
            textBox5.Visible = false;
            label1.Visible = false;
            label8.Visible = false;
            label7.Visible = false;
            label6.Visible = false;
            label5.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label19.Visible = false;
            label18.Visible = false;
            label17.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;

            ahiz.Visible = false;
            r1.Visible = false;
            r2.Visible = false;
            r3.Visible = false;
            r4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            _acisalhiz.Visible = false;
            x1.Visible = false;
            x2.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            textBox11.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;

            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            button2.Visible = true;

        }

        private void sürgüKızakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            pictureBox1.Image = Image.FromFile(@"C:\Users\karta\OneDrive\Masaüstü\odev7\surgukizak.jpg");

            textBox5.Visible = false;
            label1.Visible = false;
            label8.Visible = false;
            label7.Visible = false;
            label6.Visible = false;
            label5.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label19.Visible = false;
            label18.Visible = false;
            label17.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;

            ahiz.Visible = false;
            r1.Visible = false;
            r2.Visible = false;
            r3.Visible = false;
            r4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            _acisalhiz.Visible = false;
            x1.Visible = false;
            x2.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            textBox11.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;

            label17.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            textBox9.Visible = true;
            textBox10.Visible = true;
            textBox11.Visible = true;
            button5.Visible = true;


        }

        ArrayList ___Dizitet2 = new ArrayList();
        ArrayList ___Dizisaniye = new ArrayList();
        private void button2_Click(object sender, EventArgs e)
        {

           




            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();


            double ahizis = double.Parse(textBox8.Text);
            double tet2 = 56.19;
            double f = 0;
            double ris = double.Parse(textBox5.Text);
            double beta = double.Parse(textBox6.Text);
            double eis = double.Parse(textBox7.Text);
            double teta21 = tet2;
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();


            int l = 0;

            while (l<360)
            {
                tet2 = tet2 * (Math.PI / 180);
                beta = beta * (Math.PI / 180);
                //***********************S3 S4 KONUM********************************
                double s3 = (ris * Math.Sin(tet2) - eis) / Math.Sin(beta);
                double s4 =(ris * Math.Sin(beta-tet2)+eis*Math.Cos(beta))/Math.Sin(beta);

                //***********************S3 S4 HIZ***********************************

                double z1s3 = ris * Math.Cos(tet2);
                double z2s3 = Math.Sin(beta);
                double z1s4 = -ris * Math.Cos(beta - tet2);
                double z2s4 = Math.Sin(beta);

                double guss3 = z1s3 / z2s3;
                double guss4 = z1s4 / z2s4;

                double s3dot = guss3 * ahizis;
                double s4dot = guss4 * ahizis;


                //***********************S3 S4 İVME****************************************

                double z1s3us = -ris * Math.Sin(tet2);
                double z2s3us = 0;
                double z1s4us = -ris * Math.Sin(beta - tet2);
                double z2s4us = 0;

                double gususs3 = (z1s3us * z2s3 - z1s3 * z2s3us) / (z2s3 * z2s3);
                double gususs4 = (z1s4us * z2s4 - z1s4 * z2s4us) / (z2s4 * z2s4);

                double s3ddot = gususs3 * ahizis * ahizis;
                double s4ddot = gususs4 * ahizis * ahizis;

                tet2 = tet2 * 180 / Math.PI;
                if (tet2 > 360)
                {
                    tet2 = tet2 % 360;
                }


                f = tet2 - teta21;
                double _ahizderece = ahizis * 180 / Math.PI;
                double _saniye = f / ahizderece;

                ___Dizitet2.Add(tet2);
                Dizihizs3.Add(s3dot);
                Dizihizs4.Add(s4dot);
                Diziivmes3.Add(s3ddot);
                Diziivmes4.Add(s4ddot);
                ___Dizisaniye.Add(saniye);

                listBox1.Items.Add("Hizs3" + "" + "=" + Dizihizs3[0]);
                listBox2.Items.Add("Hizs4:" + "" + "=" + Dizihizs4[0]);
                listBox3.Items.Add("İvmes3:" + "" + "=" + Diziivmes3[0]);
                listBox4.Items.Add("İvmes4:" + "" + "=" + Diziivmes4[0]);
                listBox5.Items.Add("Saniye:" + "" + ___Dizisaniye[0]);
                l++;
                tet2++;


            }



        }

        
        
        
        double gusustet3, gusustet4;



        ArrayList Dizihiztet3 = new ArrayList();
        ArrayList Dizihiztet4 = new ArrayList();
        ArrayList Diziivmetet3 = new ArrayList();
        ArrayList Diziivmetet4 = new ArrayList();
        ArrayList Dizitet2 = new ArrayList();
        ArrayList Dizisaniye = new ArrayList();
        private void button1_Click_1(object sender, EventArgs e)
        {
            
            



            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();

            r11 = double.Parse(r1.Text);
            r22 = double.Parse(r2.Text);
            r33 = double.Parse(r3.Text);
            r44 = double.Parse(r4.Text);
            tet2 = 56.19; /*double.Parse(teta2.Text);*/
            //tet3 = double.Parse(teta3.Text);
            //tet4 = double.Parse(teta4.Text);
            ahizz = double.Parse(ahiz.Text);
            teta21 = tet2;
            
            
            ////if(tet4<90)
            ////{
            //    r11 = r22 * Math.Cos(tet2 * Math.PI / 180) + r33 * Math.Cos(tet3 * Math.PI / 180) - r44 * Math.Cos(tet4 * Math.PI / 180); 
            ////}
            ////else
            ////{
            ////    r11 = r22 * Math.Cos(tet2 * Math.PI / 180) + r33 * Math.Cos(tet3 * Math.PI / 180) + r44 * Math.Cos(tet4 * Math.PI / 180); 
            ////}


            int i = 0;
            while (i < 360)
            {
                //*************************KONUM TETA 3 ve TETA 4  **********************
                tet2 = tet2 * (Math.PI / 180);
                double a = Math.Sin(tet2);
                double b = Math.Cos(tet2) - (r11 / r22);
                double c = ((r11 * r11 + r22 * r22 + r33 * r33 - r44 * r44) / (2 * r22 * r33)) - ((r11 / r33) * Math.Cos(tet2));
                double d = (r11 / r44) * Math.Cos(tet2) - (r11 * r11 + r22 * r22 - r33 * r33 + r44 * r44) / (2 * r22 * r44);

                tet3 = 2 * Math.Atan((a - Math.Sqrt(a * a + b * b - c * c)) / (b - c));
                tet4 = 2 * Math.Atan((a - Math.Sqrt(a * a + b * b - d * d)) / (b - d));

                //**************************HIZ TETA 3 VE TETA 4    **********************

                z1t3 = Math.Sin(tet2 - tet3) - (r11 / r33) * Math.Sin(tet2);
                z2t3 = Math.Sin(tet2 - tet3) + (r11 / r22) * Math.Sin(tet3);
                z1t4 = Math.Sin(tet2 - tet4) + (r11 / r44) * Math.Sin(tet2);
                z2t4 = Math.Sin(tet2 - tet4) + (r11 / r22) * Math.Sin(tet4);
                gustet3 = z1t3 / z2t3;
                gustet4 = z1t4 / z2t4;

                hiztet3 = gustet3 * ahizz;
                hiztet4 = gustet4 * ahizz;

                //************************* İVME TETA 3 VE TETA 4   *******************

                z1t3us = Math.Cos(tet2 - tet3) * (1 - gustet3) - (r11 / r33) * Math.Cos(tet2);
                z2t3us = Math.Cos(tet2 - tet3) * (1 - gustet3) + (r11 / r22) * gustet3 * Math.Cos(tet3);
                z1t4us = Math.Cos(tet2 - tet4) * (1 - gustet4) + (r11 / r44) * Math.Cos(tet2);
                z2t4us = Math.Cos(tet2 - tet4) * (1 - gustet4) + (r11 / r22) * gustet4 * Math.Cos(tet4);
                gusustet3 = (z1t3us * z2t3 - z1t3 * z2t3us) / (z2t3 * z2t3);
                gusustet4 = (z1t4us * z2t4 - z1t4 * z2t4us) / (z2t4 * z2t4);

                ivmetet3 = gusustet3 * ahizz * ahizz;
                ivmetet4 = gusustet4 * ahizz * ahizz;


                tet2 = tet2 * 180 / Math.PI;
                if (tet2 > 360)
                {
                    tet2 = tet2 % 360;
                }
                

                f = tet2 - teta21;
                ahizderece = ahizz * 180 / Math.PI;
                saniye = f / ahizderece;

                Dizitet2.Add(tet2);
                Dizihiztet3.Add(hiztet3);
                Dizihiztet4.Add(hiztet4);
                Diziivmetet3.Add(ivmetet3);
                Diziivmetet4.Add(ivmetet4);
                Dizisaniye.Add(saniye);

                listBox1.Items.Add("Hizteta3" + "" + "=" +Dizihiztet3[i]);
                listBox2.Items.Add("Hizteta4:" + "" +  "=" + Dizihiztet4[i]);
                listBox3.Items.Add("İvmeteta3:" + "" +  "=" + Diziivmetet3[i]);
                listBox4.Items.Add("İvmeteta4:" + "" +  "=" + Diziivmetet4[i]);
                listBox5.Items.Add("Saniye:" + "" + Dizisaniye[i]);
                i++;
                tet2++;





 
            }
            
            



            //cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            //{
            //    Title = "Saniye",
            //    Labels = new[] { "0", "3,14", "6,18" }
            //});

            //cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            //{
            //    Title = "Rad/Sn",
            //    Labels = new[] { "-0,6", "0", "0,4" }
            //});
            //cartesianChart1.LegendLocation = LiveCharts.LegendLocation.Right;


        }
        double s = 0;
        double _r1, _r2, _ahiz;


        ArrayList Dizihizs = new ArrayList();
        ArrayList Dizihiztet = new ArrayList();
        ArrayList Diziivmes = new ArrayList();
        ArrayList Diziivmetet = new ArrayList();
        ArrayList Dizitet = new ArrayList();
        ArrayList _Dizisaniye = new ArrayList();


        private void button3_Click(object sender, EventArgs e)
        {

           



            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();



            double fi = 56.19;
            double fi1 = 56.19;
            _r1 = double.Parse(x1.Text);
            _r2 = double.Parse(x2.Text);
            _ahiz = double.Parse(_acisalhiz.Text);
            double tet = 0;
            double z1s, z2s, z1t, z2t;
            double sgus, tgus, hizs, hizt;
            double z1sus, z2sus, z1tus, z2tus;
            double gsusus, gtusus, sivme, tetivme;
            double ff;
            double _ahizderece, _saniye;

            int j = 0;
            while (j < 360)
            {
                //**************************KONUM*********************************//

                fi = fi * Math.PI / 180;
                s = Math.Sqrt(_r1 * _r1 + _r2 * _r2 - 2 * _r1 * _r2 * Math.Cos(fi));

                tet = Math.Atan((_r2 * Math.Sin(fi)) / (_r2 * Math.Cos(fi) - _r1));


                //****************************HIZ******************************//

                z1s = _r1 * _r2 * Math.Sin(fi);
                z2s = s;
                sgus = z1s / z2s;
                
                hizs = sgus * _ahiz;

                z1t = ((_r2 * _r2 - _r1 * _r2 * Math.Cos(fi)) * (Math.Cos(tet) * Math.Cos(tet)));
                z2t = (_r2 * Math.Cos(fi) - _r1) * (_r2 * Math.Cos(fi) - _r1);
                tgus = z1t / z2t;

                hizt = tgus * _ahiz;

                //***************************İVME*****************************//
                z1sus = _r1 * _r2 * Math.Cos(fi);
                z2sus = sgus;
                gsusus = (z1sus * z2s - z1s * z2sus) / (z2s * z2s);

                sivme = gsusus * _ahiz * _ahiz;

                z1tus = _r1 * _r2 * Math.Sin(fi) * Math.Cos(tet) * Math.Cos(tet) - 2 * tgus * (_r2 * _r2 - _r1 * _r2 * Math.Cos(fi) * Math.Sin(tet) * Math.Cos(tet));
                z2tus = 2 * _r2 * (_r1 - _r2 * Math.Cos(fi)) * Math.Sin(fi);
                gtusus = (z1tus * z2t - z1t * z2tus) / (z2t * z2t);

                tetivme = gtusus * _ahiz * _ahiz;

                fi = fi * 180 / Math.PI;
                if(fi >360)
                fi = fi % 360;
                ff = fi - fi1;
                _ahizderece = _ahiz * 180 / Math.PI;
                _saniye = ff / _ahizderece;

                Dizihizs.Add(hizs);
                Dizihiztet.Add(hizt);
                Diziivmes.Add(sivme);
                Diziivmetet.Add(tetivme);
                Diziivmes.Add(sivme);
                _Dizisaniye.Add(_saniye);




                listBox1.Items.Add("S Hız" + "" + "=" + Dizihizs[j]);
                listBox2.Items.Add("TetaHiz:" + "" + "=" + Dizihiztet[j]);
                listBox3.Items.Add("S İvme:" + "" + "=" + Diziivmes[j]);
                listBox4.Items.Add("Teta İvme:" + "" + "=" + Diziivmetet[j]);
                listBox5.Items.Add("Saniye:" + "" + _Dizisaniye[j]);
                j++;
                fi++;

            }







        }




    }
}
