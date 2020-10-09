using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Nacional : Excursion
    {
        // Atributos
        private bool esInteres = false;

        public Nacional(string descipcion, DateTime fecha, int diasTraslados, int stockLugares, bool esInteres, List<Destino> destinos) : base(descipcion, fecha, diasTraslados, stockLugares, destinos)
        {
            this.esInteres = esInteres;
        }
    }
}
