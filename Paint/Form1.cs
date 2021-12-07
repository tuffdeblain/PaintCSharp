using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Paint
{
    public partial class Form1 : Form
    {
        Bitmap bm;
        Graphics g;
        bool paint = false;
        Point px, py;
        Pen p = new Pen(Color.Black, 5);
        Pen erase = new Pen(Color.White, 5);
        int x, y, Sx, Sy, cX, cY;

        ColorDialog cd = new ColorDialog();
        Color newColor;
        SolidBrush Sb = new SolidBrush(Color.White);

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                newColor = cd.Color;
                button4.BackColor = cd.Color;
                p.Color = cd.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                newColor = cd.Color;
                button5.BackColor = cd.Color;
                g.Clear(cd.Color);
                pictureBox1.Refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                newColor = cd.Color;
                Sb.Color = newColor;
                button6.BackColor = cd.Color;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Refresh();
            button5.BackColor = Color.White;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            paint = false;

            Sx = x - cX;
            Sy = y - cY;

            if (radioButton2.Checked == true)
            {

                g.DrawEllipse(p, cX, cY, Sx, Sy);
                g.FillEllipse(Sb, cX, cY, Sx, Sy);


            }

            if (radioButton3.Checked == true)
            {

                g.DrawRectangle(p, cX, cY, Sx, Sy);
                g.FillRectangle(Sb, cX, cY, Sx, Sy);

            }

            if (radioButton1.Checked == true)
            {
                g.DrawLine(p, cX, cY, x, y);
            }

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            py = e.Location;

            cX = e.X;
            cY = e.Y;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (paint)
            {
                if (radioButton2.Checked == true)
                {

                    g.DrawEllipse(p, cX, cY, Sx, Sy);
                    g.FillEllipse(Sb, cX, cY, Sx, Sy);

                }

                if (radioButton3.Checked == true)
                {
                    g.DrawRectangle(p, cX, cY, Sx, Sy);
                    g.FillRectangle(Sb, cX, cY, Sx, Sy);
                }

                if (radioButton1.Checked == true)
                {
                    g.DrawLine(p, cX, cY, x, y);
                }
            }
        }



        public Form1()
        {
            InitializeComponent();

            bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bm);

            pictureBox1.Image = bm;
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            erase.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            erase.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            pictureBox1.Refresh();
            x = e.X;
            y = e.Y;
            Sx = e.X - cX;
            Sy = e.Y - cY;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
