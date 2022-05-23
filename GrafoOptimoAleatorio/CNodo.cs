using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GrafoOptimoAleatorio
{
    class CNodo
    {
        private string nombre;
        public string Nombre { get { return this.nombre; } }
        private List<CArista> listaAristas;
        public List<CArista> ListaAristas { get { return this.listaAristas; } }
        public Point PosNodo;

        public CNodo(string UnNombre,int x,int y)
        {
            nombre = UnNombre;
            PosNodo = new Point(x+20,y+30);
            listaAristas = new List<CArista>();
        }
    }
}
