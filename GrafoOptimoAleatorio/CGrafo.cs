using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GrafoOptimoAleatorio
{
    class CGrafo : List<CNodo>
    {
        Random rdn;
        Pen pluma;
         

        public CGrafo()
        {
            rdn = new Random();
            pluma = new Pen(Color.Red);
            AdjustableArrowCap acc = new AdjustableArrowCap(5, 5, true);
            pluma.CustomEndCap = acc;
        }
        public void CreaGrafo(int numVer)
        {
            int existe;
            char cad = 'A';
            CNodo _CNodo;
            CArista _CArista;
      

            if (this.Count != 0)
            {
                this.Clear();
            }
            while (numVer-- > 0)
            {
                _CNodo = new CNodo(cad.ToString(),rdn.Next(450),rdn.Next(400));
                this.Add(_CNodo);
                cad++;
            }
            foreach (CNodo p1 in this)
            {
                foreach (CNodo p2 in this)
                {
                    existe = rdn.Next(2);
                    if (existe == 0)
                    {
                        _CArista = new CArista(p1,p2);
                        p2.ListaAristas.Add(_CArista);

                    }
                }
            }
            //Ordea con delegados
            /*foreach (CNodo p3 in this)
            {
                p3.ListaAristas.Sort(delegate(CArista x, CArista y)
                {
                    return x.Peso.CompareTo(y.Peso);
                });
            }*/
        }
        public void imprimeGrafo(Graphics g)
        {
            //Imprime todas las aristas 
            foreach (CNodo np in this)
            {
                foreach (CArista nr in np.ListaAristas)
                {
                    if (nr.NODO_DESTINO != null)
                    {
                        if (nr.NODO_DESTINO == np)
                        { 
                            //g.DrawString(nr.Peso.ToString(), font, brush, np.PosNodo.X-10, np.PosNodo.Y -40);
                            DrawCurvePoint(g, np.PosNodo.X, np.PosNodo.Y);
                        }
                        imprimeArista(g, nr.NODO_ORIGEN.PosNodo, nr.NODO_DESTINO.PosNodo);
                        g.DrawString(nr.Peso.ToString(), new Font("Arial", 10), new SolidBrush(Color.Red), nr._puntoMedio);
                    }
                }                
            }
            //Imprime los Nodos
            foreach (CNodo np in this)
            {
                g.FillEllipse(Brushes.Yellow, np.PosNodo.X - 15, np.PosNodo.Y - 15, 30, 30);
                g.DrawEllipse(Pens.Red, np.PosNodo.X - 15, np.PosNodo.Y - 15, 30, 30);
                g.DrawString(np.Nombre, new Font("Arial", 10), new SolidBrush(Color.Red), np.PosNodo.X - 5, np.PosNodo.Y - 5);
            }



        }
        private void imprimeArista(Graphics g, Point p1, Point p2)
        {
            float CatOx1, CatAy1;
            float CatOx2, CatAy2;

            if (p1.X > p2.X){CatOx1 = p1.X - 10;}
            else{CatOx1 = p1.X + 10;}
            if (p1.Y > p2.Y){CatAy1 = p1.Y - 10;}
            else{CatAy1 = p1.Y + 10;}
            /////////////
            if (p1.X > p2.X){ CatOx2 = p2.X + 10;}
            else{CatOx2 = p2.X - 10;}
            if (p1.Y > p2.Y){CatAy2 = p2.Y + 10;}
            else{ CatAy2 = p2.Y - 10;}
            g.DrawLine(pluma, CatOx1, CatAy1, CatOx2, CatAy2);
        }
        private void DrawCurvePoint(Graphics g,int x,int y)
        {
            // Create points that define curve.
            Point point1 = new Point(x-10, y-10);
            Point point2 = new Point(x-15, y-23);
            Point point3 = new Point(x,y-40);
            Point point4 = new Point(x+15, y-23);
            Point point5 = new Point(x + 10, y - 10);
          
           
            Point[] curvePoints = { point1,  point2,point3,point4 ,point5};

            // Draw lines between original points to screen.
            //g.DrawLines(redPen, curvePoints);

            // Draw curve to screen.
            g.DrawCurve(pluma, curvePoints);
        }
    }
}
