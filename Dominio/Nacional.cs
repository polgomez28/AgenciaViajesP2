using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Nacional : Excursion
    {
        #region Atributos
        private bool esInteres = false;
        #endregion
        #region Constructor
        //Constructor
        public Nacional(string descipcion, DateTime fecha, int diasTraslados, int stockLugares, bool esInteres, List<Destino> destinos) : base(descipcion, fecha, diasTraslados, stockLugares, destinos)
        {
            this.esInteres = esInteres;
        }
        #endregion
        #region Métodos
        public override string ToString()
        {
            string respuesta = "";
            respuesta = "Excursión Nacional" + "\n";
            if (esInteres)
            {
                respuesta = "Es de interes por el Ministerio de Turismo" + "\n";
            }
            else
            {
                respuesta = "No es de interes por el Ministerio de Turismo" + "\n";
            }
            return base.ToString() + respuesta;
        }
        #endregion
    }
}
