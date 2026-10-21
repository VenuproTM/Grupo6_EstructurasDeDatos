using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComercialAndina.ComercialAndina.Models;

namespace ComercialAndina.ComercialAndina.Estructuras
{
    public sealed class ColaSolicitudes
    {
        private Queue<Solicitud> elementos = new Queue<Solicitud>();

        public int Cantidad => elementos.Count;

        public void Encolar(Solicitud solicitud)
        {
            elementos.Enqueue(solicitud);
        }

        public Solicitud AtenderSiguiente()
        {
            if (elementos.Count == 0)
            {
                return null;
            }

            return elementos.Dequeue();
        }

        public List<Solicitud> ObtenerPendientes()
        {
            return elementos.ToList();
        }
    }
}
