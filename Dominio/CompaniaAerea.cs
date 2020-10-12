using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CompaniaAerea
    {
        // Atributos
        private int id = 0;
        private static int ultId = 0;
        private string pais = "";

        //Property
        public string Pais
        {
            get { return pais; }
        }
        public int Id
        {
            get { return id; }
        }

        //Constructor
        public CompaniaAerea(string pais)
        {
            this.id = ++ultId;
            this.pais = pais;
        }
        public override string ToString()
        {
            string respuesta = "";
            respuesta += pais + "\n";
            return respuesta;
        }
    }
}
