using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Excursion
    {
        #region Atributos
        private int id = 0;
        private static int ultid = 1000;
        private string descripcion = "";
        private DateTime fecha;
        private decimal totalUsd = 0;
        private decimal totalPeso = 0;
        private int diasTraslados = 0;
        private int stockLugares = 0;
        private List<Destino> destinos = new List<Destino>();
        #endregion
        #region Constructor
        public Excursion(string descripcion, DateTime fecha, int diasTraslados, int stockLugares, List<Destino> destinos)
        {
            this.id = GenerarId(id);
            this.descripcion = descripcion;
            this.fecha = fecha;
            this.diasTraslados = diasTraslados;
            this.stockLugares = stockLugares;
            this.destinos = destinos;
        }
        #endregion
        #region Propiedades
        public List<Destino> Destinos
        {
            get { return destinos; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public int Id
        {
            get { return id; }
        }
        #endregion
        #region Métodos
        // Método que genera id sumando de a 100.
        public int GenerarId(int id)
        {
            id = ultid;
            ultid += 100;
            return id;
        }
        // Método ToString
        public override string ToString()
        {
            string respuesta = "";
            respuesta += "------EXCURSIONES------ " + "\n" + "\n";
            respuesta += "Id: " + id + "\n";
            respuesta += "Descripcion: " + descripcion + "\n";
            respuesta += "Fecha: " + fecha.ToShortDateString() + "\n";
            respuesta += "Días traslados: " + diasTraslados + "\n";
            respuesta += "Stock: " + stockLugares + "\n" + "\n";
            respuesta += "-------DESTINOS-------- " + "\n" + "\n";
            if (destinos != null)
            {
                for (int i = 0; i < destinos.Count; i++)
                {
                    respuesta += destinos[i] + "\n";
                    totalUsd += destinos[i].CostoEstadia;
                    totalPeso += destinos[i].CostoEstadiaPesos;
                }
                respuesta += ("El Costo total de la excursion en Dolares es de: U$S " + totalUsd + "\n");
                respuesta += ("El Costo total de la excursion en Pesos es de: $ " + totalPeso + "\n");
            }
            return respuesta;
        }
            // Buscar destino, teniendo ciudad-pais.
            public bool ExisteDestino(string ciudad, string pais)
        {
            int i = 0;
            bool encontre = false;
            while (!encontre && i < destinos.Count)
            {
                if (destinos[i].Ciudad == ciudad && destinos[i].Pais == pais)
                {
                    encontre = true;
                }
                i++;
            }
            return encontre;
        }
        #endregion
    }
}
