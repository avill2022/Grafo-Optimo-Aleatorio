using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GrafoOptimoAleatorio
{
    class CArista
    {
        private int peso;
        public int Peso { get { return this.peso; } }
        private Point puntoMedio;
        public Point _puntoMedio { get { return puntoMedio; } set { puntoMedio = value; } }
        private CNodo NodoOrigen;
        public CNodo NODO_ORIGEN { get { return this.NodoOrigen; } set { value = this.NodoOrigen; } }
        private CNodo NodoDestino;
        public CNodo NODO_DESTINO { get { return this.NodoDestino; } set { value = this.NodoDestino; } }



        public CArista(CNodo NOrigen, CNodo NDestino)
        {
            NodoDestino = NDestino;
            NodoOrigen = NOrigen;
            calculaPeso();
            calculaPuntoMedio();
        }
        public void calculaPuntoMedio()
        {
            puntoMedio = new Point((NodoOrigen.PosNodo.X + NodoDestino.PosNodo.X)/2,(NodoOrigen.PosNodo.Y + NodoDestino.PosNodo.Y)/2);
        }
        public void calculaPeso()
        {
            if (NodoOrigen == NodoDestino)
            {
                peso = 0;
            }
            else
            {
                peso = (int)Math.Sqrt(Math.Pow(NodoDestino.PosNodo.X - NodoOrigen.PosNodo.X, 2) + Math.Pow(NodoDestino.PosNodo.Y - NodoOrigen.PosNodo.Y, 2));
            }
        }

     
        
    }
}
