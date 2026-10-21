using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComercialAndina.ComercialAndina.Models;

namespace ComercialAndina.ComercialAndina.Estructuras
{
    public sealed class PilaReversas
    {
        private Stack<Reversa> elementos = new Stack<Reversa>();

        public int Cantidad => elementos.Count;

        public void Apilar(Reversa reversa)
        {
            elementos.Push(reversa);
        }

        public Reversa VerUltima()
        {
            if (elementos.Count == 0)
            {
                return null;
            }

            return elementos.Peek();
        }

        public List<Reversa> ObtenerHistorial()
        {
            return elementos.ToList();
        }
    }
}
