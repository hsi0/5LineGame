using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;

namespace joclinii5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        const int nmax = 18;
        int Jucator = 0;
        int[,] tab = new int[nmax + 1, nmax + 1];
        Graphics g;
        [DllImport("kernel32.dll")]
        public static extern bool Beep(int freq, int duration);

        private System.Media.SoundPlayer mediaSoundPlayer = new System.Media.SoundPlayer();
        public void PlaySound(string path)
        {
            

           // aPath = Application.StartupPath + "\\wav\\" + wavName.Trim();
           if (File.Exists(path))
            {
                mediaSoundPlayer.SoundLocation = path;
                mediaSoundPlayer.Play();
            }
            else
                throw new Exception("Invalid sound file!");
        }

     /*   public void StopSound()
        {
            try
            {
                mediaSoundPlayer.Stop();
            }
            catch { }

        }*/
        private void initab()
        {
            int i, j;
            for (i = 1; i <= nmax; i++)
                for (j = 1; j <= nmax; j++)
                    tab[i, j] = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Beep(100, 300))
            {

            }
       
        
            initab();
            Desenare();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (Beep(100, 300))
            {

            }
            g.Clear(Color.Black);
            label1.Visible = true;
         
        
           


        }
      

        

        private void button3_Click(object sender, EventArgs e)
        {
            if (Beep(100, 300))
            {

            }
            Application.Exit();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            PlaySound("Z:\\musicc.wav");
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetBounds(0, 0, Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            panel1.SetBounds(160, 0, this.Width - 160, this.Height - 5);
            g = panel1.CreateGraphics();
       
        }
        private void Desenare()
        {
            g.Clear(Color.Black);
            Pen p = new Pen(Color.Black, 3);
            int i;
            string[] s1 = new string[] { "", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R" };
            string[] s2 = new string[] { "", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };
            Rectangle r = new Rectangle(158, 5, Width - 5, Height - 5);
            SolidBrush b = new SolidBrush(Color.Black);
            g.FillRectangle(b, r);
            label1.Visible = false;
        
          

            for (i = 25; i <= 691; i += 37)
            {
                p = new Pen(Color.White, 3);
                g.DrawLine(p, new Point(i, 17), new Point(i, Height - 10));


            }
            for (i = 42; i <= 900; i += 37)
            {
                p = new Pen(Color.White, 1);
                g.DrawLine(p, new Point(5, i), new Point(700, i));
            }
            Font f = new Font("Arial", 12, FontStyle.Bold);
            for (i = 1; i <= 18; i++)
            {
                g.DrawString(s1[i], f, Brushes.White, 1 + i * 37, 10);
                Thread.Sleep(50);
            }
            for (i = 1; i <= 18; i++)
            {
                g.DrawString(s2[i], f, Brushes.White, 1, 5 + 37 * i);
                Thread.Sleep(50);
            }

            Jucator = 1;
        }
        private void jucator()
        {
            Jucator = 1;
        }
        private void jucator2()
        {
            Jucator = 2;
        }
        private int linie51()
        {
            int i, j, k, c;
            for (i = 1; i <= nmax; i++)
                for (j = 1; j <= nmax; j++)
                    if (tab[i, j] == 1)
                    {
                        c = 1;
                        if (j + 4 <= nmax)
                            for (k = 1; k <= 4; k++)
                                if (tab[i, j + k] == 1)
                                    c++;
                        if (c == 5)
                            return 1;
                        c = 1;
                        if (i + 4 <= nmax)
                            for (k = 1; k <= 4; k++)
                                if (tab[i + k, j] == 1)
                                    c++;
                        if (c == 5)
                            return 1;
                        c = 1;
                        if (i + 4 <= nmax && j + 4 <= nmax)
                            for (k = 1; k <= 4; k++)
                                if (tab[i + k, j + k] == 1)
                                    c++;
                        if (c == 5)
                            return 1;
                        c = 1;
                        if (j - 5 >= 1 && i + 4 <= nmax)
                            for (k = 1; k <= 4; k++)
                                if (tab[i + k, j - k] == 1)
                                    c++;
                        if (c == 5)
                            return 1;
                    }
            return 0;
        }

        private int linie52()
        {
            int i, j, k, c;
            for (i = 1; i <= nmax; i++)
                for (j = 1; j <= nmax; j++)
                    if (tab[i, j] == 2)
                    {
                        c = 1;
                        if (j + 4 <= nmax)
                            for (k = 1; k <= 4; k++)
                                if (tab[i, j + k] == 2)
                                    c++;
                        if (c == 5)
                            return 1;
                        c = 1;
                        if (i + 4 <= nmax)
                            for (k = 1; k <= 4; k++)
                                if (tab[i + k, j] == 2)
                                    c++;
                        if (c == 5)
                            return 1;
                        c = 1;
                        if (i + 4 <= nmax && j + 4 <= nmax)
                            for (k = 1; k <= 4; k++)
                                if (tab[i + k, j + k] == 2)
                                    c++;
                        if (c == 5)
                            return 1;
                        c = 1;
                        if (j - 5 >= 1 && i + 4 <= nmax)
                            for (k = 1; k <= 4; k++)
                                if (tab[i + k, j - k] == 2)
                                    c++;
                        if (c == 5)
                            return 1;
                    }
            return 0;
        }


        private void joc()
        {
            int ok = 0;

            if (Jucator == 1)
            {
                if (linie51() == 1)
                    ok = 1;
            }
            else
                if (Jucator == 2)
                    if (linie52() == 1)
                        ok = 1;
            if (ok == 1)
            {
                if (Beep(700, 1000))
                {

                }
                MessageBox.Show("Jucatorul " + Jucator + " a castigat!");
                initab();
                Desenare();
            }
            else
            {
                if (Jucator == 1)
                {
                    jucator2();
                    if (Beep(50, 300))
                    {

                    }
                }
                else
                    if (Jucator == 2)
                    {
                        jucator();
                        if (Beep(50, 300))
                        {

                        }
                    }
            }

        }
      

        private void panel1_MouseClick_1(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            int i = (int)((float)(x - 25) / 37 + 1);
            int j = (int)((float)(y - 42) / 37 + 1);

            if (Jucator == 1)
            {
                tab[i, j] = 1;
                SolidBrush b = new SolidBrush(Color.Blue);
                g.FillEllipse(b, i * 37 - 4, j * 37 + 13, 25, 25);
            }
            else
                if (Jucator == 2)
                {
                    tab[i, j] = 2;
                    SolidBrush b = new SolidBrush(Color.Aquamarine);
                    g.FillEllipse(b, i * 37 - 4, j * 37 + 13, 25, 25);
                }
            joc();
            
        }

       

      
    }
}
