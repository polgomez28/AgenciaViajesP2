using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Internacional : Excursion
    {

        // Atributos 
        private CompaniaAerea compania;
        // Constructor
        public Internacional(string descipcion, DateTime fecha, int diasTraslados, int stockLugares, CompaniaAerea compania, List<Destino> destinos) : base(descipcion, fecha, diasTraslados, stockLugares, destinos)
        {
            this.compania = compania;
        }
        // Método ToString
        public override string ToString()
        {
            string respuesta = "";
            respuesta = "Excursión internacional" + "\n";
            respuesta = "Compañia Aerea: " + compania + "\n";
            return base.ToString() + respuesta;
        }
    }
}
