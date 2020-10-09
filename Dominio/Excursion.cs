using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Excursion
    {
        //Atributos
        private int id = 0;
        private static int ultid = 1000;
        private string descripcion = "";
        private DateTime fecha;
        private int diasTraslados = 0;
        private int stockLugares = 0;
        private List<Destino> destinos = new List<Destino>();

        // Constructor
        public Excursion(string descripcion, DateTime fecha, int diasTraslados, int stockLugares, List<Destino> destinos)
        {
            this.id = GenerarId(id);
            this.descripcion = descripcion;
            this.fecha = fecha;
            this.diasTraslados = diasTraslados;
            this.stockLugares = stockLugares;
            this.destinos = destinos;
        }
        public List<Destino> Destinos
        {
            get { return destinos; }
        }
        public int Id
        {
            get { return id; }
        }
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
            respuesta += "Id: " + id + "\n";
            respuesta += "Descripcion: " + descripcion + "\n";
            respuesta += "Fecha: " + fecha + "\n";
            respuesta += "Días traslados: " + diasTraslados + "\n";
            respuesta += "Stock: " + stockLugares + "\n";
            respuesta += "DESTINOS " + "\n";
            if (destinos != null)
            {
                for (int i = 0; i < destinos.Count; i++)
                {
                    respuesta += destinos[i] + "\n";
                }
            }
            respuesta += "-----------------------------------" + "\n";
            return respuesta;
        }
        private bool ExisteDestino(string ciudad, string pais)
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
    }

}
