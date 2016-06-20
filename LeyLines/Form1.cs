using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LeyLines
{
    public partial class Form1 : Form
    {
        Point[] pts;
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int l = 0;
            if (pts != null)
            {
                //for (int i = 0; i < pts.Length-1; i++)
                //{
                //    for (int j = i + 1; j < pts.Length; j++)
                //    {
                //        e.Graphics.DrawLine(Pens.HotPink, pts[i], pts[j]);
                //    }
                //}
                foreach (Point pt in pts)
                {
                    e.Graphics.DrawEllipse(Pens.Blue, pt.X - 3, pt.Y - 3, 5, 5);
                }
                for (int i0 = 0; i0 < pts.Length - 2; i0++)
                {
                    for (int i1 = i0 + 1; i1 < pts.Length - 1; i1++)
                    {
                        for (int i2 = i1 + 1; i2 < pts.Length - 2; i2++)
                        {
                            if ((pts[i1].Y - pts[i0].Y) * (pts[i2].X - pts[i1].X) ==
                                (pts[i2].Y - pts[i1].Y) * (pts[i1].X - pts[i0].X))
                            {
                               //e.Graphics.DrawLine(new Pen(Color.FromArgb(l*1228 | 0x7f000000), 3), pts[i0], pts[i1]);
                               e.Graphics.DrawLine(new Pen(Color.Pink, 3), pts[i0], pts[i1]);
                               e.Graphics.DrawLine(Pens.Green, pts[i1], pts[i2]);
                               l++;
                            }
                        }
                    }
                }
                textBox2.Text = l.ToString();
            }
        }

        private void btGo_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int n = rnd.Next(10) + 200;
            textBox1.Text = n.ToString();
            pts = new Point[n];
            for (int i = 0; i < n; i++)
            {
                pts[i] = new Point(rnd.Next(panel1.Width), rnd.Next(panel1.Height));
            }
            Refresh();
        }
    }
}
