﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Destino
    {
        // Atributos
        private string ciudad = "";
        private string pais = "";
        private decimal costo = 0;
        private decimal cantidadDias = 0;
        // Constructor
        public Destino(string ciudad, string pais, decimal costo, decimal cantidadDias)
        {
            this.ciudad = ciudad;
            this.pais = pais;
            this.costo = costo;
            this.cantidadDias = cantidadDias;
        }

        public string Ciudad
        {
            get { return ciudad; }
        }

        public string Pais
        {
            get { return pais; }
        }

        // Método ToString
        public override string ToString()
        {
            string respuesta = "";
            respuesta += "País: " + pais + "\n";
            respuesta += "Ciudad: " + ciudad + "\n";
            respuesta += "Costo diario: " + costo + "\n";
            respuesta += "Cantidad de días: " + cantidadDias + "\n";
            return respuesta;
        }
        //Validar string mayores a 3 caracteres
        public static bool ValidarString2(string nombre)
        {
            return nombre.Length >= 3;
        }
        //Validar enteros positivos.
        public static bool ValidarEnteros(decimal valor)
        {
            return valor >= 0;
        }
        // Validar Ciudad
        public bool ValidarCiudad(string ciudad)
        {
            string nombre = "";
            return nombre.Length >= 2;
        }
        // Validar Pais
        public bool ValidarPais(string pais)
        {
            string nombre = "";
            return nombre.Length >= 2;
        }


    }

}
