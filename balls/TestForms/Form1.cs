using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestForms
{
    public partial class Form1 : Form
    {
        Graphics gr;
        Random rnd;
        struct Colors
        {
            public int r;
            public int g;
            public int b;
        };
        Colors[,] colors;
        public Form1()
        {
            rnd = new Random();
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            int width = 50;
            textBox1.Visible = false;
            textBox2.Visible = false;
            btnDraw.Visible = false;
            gr = Graphics.FromHwnd(Handle);
            int x = 1, y = 1;
            colors = new Colors[Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)]; 
            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {
                for (int j = 0; j < Convert.ToInt32(textBox2.Text); j++)
                {
                    colors[i, j].r = rnd.Next(0, 255);
                    colors[i, j].g = rnd.Next(0, 255);
                    colors[i, j].b = rnd.Next(0, 255);
                    gr.DrawEllipse(new Pen(Color.FromArgb(colors[i, j].r, colors[i, j].g, colors[i, j].b)), x, y, this.ClientSize.Width / Convert.ToInt32(textBox2.Text) - 3, this.ClientSize.Height / Convert.ToInt32(textBox1.Text) - 2);
                    x += this.ClientSize.Width / Convert.ToInt32(textBox2.Text);
                }
                x = 1;
                y += this.ClientSize.Height / Convert.ToInt32(textBox1.Text);
            }
        }

        private void Paint1(int n, int m)
        {
            gr = Graphics.FromHwnd(Handle);
            int x = 1, y = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    gr.DrawEllipse(new Pen(Color.FromArgb(colors[i, j].r, colors[i, j].g, colors[i, j].b)), x, y, this.ClientSize.Width / m - 3, this.ClientSize.Height / n - 2);
                    x += this.ClientSize.Width / m;
                }
                x = 1;
                y += this.ClientSize.Height / n;
            }
        }

        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
            Paint1(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
            textBox1.Visible = true;
            textBox1.Text = "";
            textBox2.Visible = true;
            textBox2.Text = "";
            btnDraw.Visible = true;
        }
    }
}
