using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrafoOptimoAleatorio
{
    public partial class Form1 : Form
    {
        bool band;
        Graphics gr;
        CGrafo g;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            band = false;
            gr = CreateGraphics();
            g = new CGrafo();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            g.CreaGrafo(4);
            band = true;
            Invalidate();


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (band)
            {
                g.imprimeGrafo(gr);
            }
        }
    }
}
