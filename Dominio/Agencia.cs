using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Agencia
    {
        #region Atributos
        private List<Excursion> excursiones = new List<Excursion>();
        private List<Destino> destinos = new List<Destino>();
        private List<CompaniaAerea> companiasAereas = new List<CompaniaAerea>();
        private static decimal dolar = 42;
        #endregion
        #region Propiedades
        public List<Destino> Destino
        {
            get { return destinos; }
        }
        public List<CompaniaAerea> CompaniasAereas
        {
            get { return companiasAereas; }
        }
        public static decimal Dolar
        {
            get { return dolar; }
        }
        #endregion
        #region Precargas
        public Agencia()
        {
            PrecargaCompaniaAerea();
            PrecargasDestinos();
            PrecargarExcursiones();
        }
        private void PrecargaCompaniaAerea()
        {
            AltaCompaniaAerea("Alemania", 1);
            AltaCompaniaAerea("Argentina", 2);
            AltaCompaniaAerea("EE.UU", 3);
            AltaCompaniaAerea("Brasil", 4);
            AltaCompaniaAerea("Brasil", 4);
        }
        private void PrecargasDestinos()
        {
            // Destinos internacionales
            
            AgregarDestinos("Barcelona", "España", 150, 5);
            AgregarDestinos("Madrid", "España", 150, 5);
            AgregarDestinos("Granada", "España", 150, 5);
            AgregarDestinos("Mallorca", "España", 150, 5);
            AgregarDestinos("Paris", "Francia", 150, 5);
            AgregarDestinos("Lyon", "Francia", 150, 5);
            AgregarDestinos("Roma", "Italia", 150, 5);
            AgregarDestinos("Atenas", "Grecia", 150, 5);
            AgregarDestinos("Venecia", "Italia", 150, 5);
            
            // Destinos Nacionales
            AgregarDestinos("Montevideo", "Uruguay", 150, 5);
            AgregarDestinos("Montevideo", "Uruguay", 150, 5);// prueba de destino ya agregado
            AgregarDestinos("Salto", "Uruguay", 150, 5);
            AgregarDestinos("Paysandu", "Uruguay", 150, 5);
            AgregarDestinos("Artigas", "Uruguay", 150, 5);
            AgregarDestinos("San José", "Uruguay", 150, 5);
            AgregarDestinos("Maldonado", "Uruguay", 150, 5);
            AgregarDestinos("Rivera", "Uruguay", 150, 5);
            AgregarDestinos("Rocha", "Uruguay", 150, 5);
            AgregarDestinos("Fray Bentos", "Uruguay", 150, 5);
            
        }
        // Precarga excursiones
        private void PrecargarExcursiones()
        {
            DateTime fecha;

            fecha = new DateTime(2020, 08, 10);

            AltaExcursionNacional("Cabo Polonio", fecha, 5, 45, 1300, true, DevolverDestino("Montevideo", "Uruguay", "Montevideo", "Uruguay"));

            AltaExcursionNacional("Cabo Polonio", fecha, 5, 45, 1000, true, DevolverDestino("Montevideo", "Uruguay", "Montevideo", "Uruguay")); // No debe aparecer en los listados. Misma Ciudad-Pais en los dos destinos
            /*
            fecha = new DateTime(2020, 01, 10);
            AltaExcursionNacional("Portezuelo", fecha, 5, 45, 1000, true, DevolverDestino("Salto", "Uruguay", "Artigas", "Uruguay"));


            fecha = new DateTime(2020, 01, 10);
            AltaExcursionNacional("Portezuelo", fecha, 5, 45, 1700, true, DevolverDestino("Salto", "Uruguay", "Artigas", "Uruguay"));

            fecha = new DateTime(2020, 02, 10);
            AltaExcursionNacional("Atlantida", fecha, 5, 45, 2000, true, DevolverDestino("Rivera", "Uruguay", "Maldonado", "Uruguay"));

            fecha = new DateTime(2020, 03, 10);
            AltaExcursionNacional("Cerro chato", fecha, 5, 45, 1500, true, DevolverDestino("Rocha", "Uruguay", "Fray Bentos", "Uruguay"));

            //Excursiones internacionales

            fecha = new DateTime(2020, 02, 01);
            AltaExcursionesInternacionales("OctoberFest", fecha, 4, 25, 1800, 4, DevolverDestino("Barcelona", "España", "Madrid", "España"));

            fecha = new DateTime(2020, 01, 01);
            AltaExcursionesInternacionales("San Fermin", fecha, 4, 15, 1500, 4, DevolverDestino("Granada", "España", "Mallorca", "España"));// No debe aparecer porq Cerro Chato tiene el mismo código

            fecha = new DateTime(2020, 04, 01);
            AltaExcursionesInternacionales("Madrid", fecha, 4, 25, 1900, 4, DevolverDestino("Paris", "Francia", "Lyon", "Francia"));

            fecha = new DateTime(2020, 08, 01);
            AltaExcursionesInternacionales("Todo Italia", fecha, 4, 25, 1580, 4, DevolverDestino("Roma", "Italia", "Venecia", "Italia"));

            fecha = new DateTime(2020, 08, 01);
            AltaExcursionesInternacionales("Todo Italia", fecha, 4, 25, 1580, 4, DevolverDestino("Roma", "Italia", "Venecia", "Italia"));
            */
        }
        #endregion
        #region Métodos de Alta
        // Alta compania aerea
        private bool AltaCompaniaAerea(string pais, int idCompania)
        {
            bool exito = false, existe = BuscarCompania(idCompania);
            if (!existe)
            {
                CompaniaAerea unCompaniaAerea = new CompaniaAerea(pais);
                companiasAereas.Add(unCompaniaAerea);
                exito = true;
            }
            return exito;
        }
        public bool PrecargarDestinosAExcursiones(List<Destino> aux, Excursion excursion)
        {
            bool exito = false;

            return exito;
        }
        //Alta de excursiones nacionales
        public bool AltaExcursionNacional(string descripcion, DateTime fecha, int diasTraslados, int stockLugares, int idExcursion, bool esInteres, List<Destino> destinos)
        {
            bool exito = false, existe = BuscarExcursion(idExcursion);
            if (!existe)
            {
                Nacional unNacional = new Nacional(descripcion, fecha, diasTraslados, stockLugares, esInteres, destinos);
                excursiones.Add(unNacional);
                exito = true;
            }
            return exito;
        }
        // Alta de excursiones internacionales
        public bool AltaExcursionesInternacionales(string descripcion, DateTime fecha, int diasTraslados, int stockLugares, int idExcursion, int idCompania, List<Destino> destinos)
        {
            bool exito = false, existe = BuscarExcursion(idExcursion);
            int contador = 0;
            if (!existe)
            {
                foreach (Destino unDestino in destinos)
                {
                    if (NoNacional(unDestino.Pais))
                    {
                        contador++;
                    }
                }
                CompaniaAerea unCompania = ObtenerCompania(idCompania);
                if (unCompania != null && destinos != null && contador == 2)
                {
                    Internacional unInter = new Internacional(descripcion, fecha, diasTraslados, stockLugares, unCompania, destinos);
                    excursiones.Add(unInter);
                    exito = true;
                }
            }
            return exito;
        }
        public bool NoNacional(string pais)
        {

            return pais != "Uruguay";
        }
        //Ultimo Método actualizado de Agregar Destino
        public bool AgregarDestinos(string ciudad, string pais, decimal costo, decimal cantidadDias)
        {
            bool exito = false;
            if (BuscarDestino(ciudad) == null)
            {
                Destino unDestino = new Destino(ciudad, pais, costo, cantidadDias);
                if (unDestino.ValidarDestino(ciudad, pais, costo, cantidadDias))
                {
                    unDestino.CostoEstadia = (unDestino.Costo * unDestino.CantidadDias);
                    destinos.Add(unDestino);
                    exito = true;
                }
            }
            else
            {
                Console.WriteLine("Destino ya existe");
            }
            return exito;
        }
        

        #endregion
        #region Métodos de busqueda

        //Buscar compania a partir del id
        private bool BuscarCompania(int idCompania)
        {
            bool encontre = false;
            int i = 0;
            while (!encontre && i < companiasAereas.Count)
            {
                if (companiasAereas[i].Id == idCompania)
                {
                    encontre = true;
                }
                i++;
            }
            return encontre;
        }
        // Buscar excursión existente
        public bool BuscarExcursion(int id)
        {
            bool encontre = false;
            int i = 0;
            while (!encontre && i < excursiones.Count)
            {
                if (excursiones[i].Id == id)
                {
                    encontre = true;
                }
                i++;
            }
            return encontre;
        }    
        // Obtener compania a partir del id
        private CompaniaAerea ObtenerCompania(int idCompania)
        {
            bool encontre = false;
            int i = 0;
            CompaniaAerea unCompania = null;
            while (!encontre && i < companiasAereas.Count)
            {
                if (companiasAereas[i].Id == idCompania)
                {
                    //encontre = true;
                    unCompania = companiasAereas[i];
                }
                i++;
            }
            return unCompania;
        }
        //Buscar destino
        public Destino BuscarDestino(string ciudad, string pais, decimal costo, decimal cantidadDias, List<Destino> auxDestino)
        {
            int i = 0;
            Destino destino = null;
            while (destino == null && i < auxDestino.Count)
            {
                if (auxDestino[i].Ciudad == ciudad)
                {
                    destino = destinos[i];
                }
                i++;
            }
            return destino;
        }
        public Destino BuscarDestino(string ciudad)
        {
            int i = 0;
            Destino destino = null;
            while (destino == null && i < destinos.Count)
            {
                if (destinos[i].Ciudad == ciudad)
                {
                    destino = destinos[i];
                }
                i++;
            }
            return destino;
        }
        #endregion
        #region Listas
        public List<Excursion> Excursiones()
        {
            List<Excursion> asist = new List<Excursion>();
            foreach (Excursion unaExcursion in excursiones)
            {
                if (unaExcursion.Destinos != null) // Para lista solo las excursiones que tengan Destinos && que tengan dos destinos (&& ControlDosDestinos(unaExcursion.Destinos))
                {
                    asist.Add(unaExcursion);
                }
            }
            return asist;
        }
        public List<Destino> Destinos()
        {
            List<Destino> asist = new List<Destino>();
            foreach (Destino unDestino in destinos)
            {
                asist.Add(unDestino);
            }
            return asist;
        }
        // Genero la lista de destinos para ser asignadas a las excursiones
        public List<Destino> DevolverDestino(string ciudad, string pais, string ciudad2, string pais2)
        {
            List<Destino> aux = new List<Destino>();
            foreach (Destino unDestino in destinos)
            {
                if (unDestino.Ciudad == ciudad && unDestino.Pais == pais || unDestino.Ciudad == ciudad2 && unDestino.Pais == pais2 || ciudad != ciudad2 && pais != pais2)
                {
                    aux.Add(unDestino);
                }
            }
            // Dejo en null la lista si los destinos ya estan asignados en alguna otra excursion.
            // ControlDosDetinos verifica que sean 2 destinos, en el caso que sean más de dos deja en null la lista
            if (ControlDestinosEnExcursiones(aux) && !ControlDosDestinos(aux))
            {
                aux = null;
            }
            return aux;
        }
        // Obtengo la lista de destinos que se van asignar a las excursiones y controlo que no existan en alguna otra excursion.
        public bool ControlDestinosEnExcursiones(List<Destino> aux)
        {
            bool bandera = false;
            List<Excursion> auxEx = new List<Excursion>();
            foreach (Excursion unaExcursion in excursiones)
            {
                if (unaExcursion.Destinos == aux)
                {
                    bandera = true;
                }
            }
            return bandera;
        }

        //Obtengo la lista de excursiones en un rango de fechas
        public List<Excursion> ListarExcursionesEnFecha(DateTime desde, DateTime hasta, string pais, string ciudad)
        {
            List<Excursion> asist = new List<Excursion>();
            int id = 0;
            if (desde < hasta)
            {
                foreach (Excursion unaExcursion in excursiones)
                {
                    if (unaExcursion.Fecha >= desde && unaExcursion.Fecha <= hasta)
                    {
                        if (unaExcursion.ExisteDestino(ciudad, pais))
                        {
                            id = unaExcursion.Id;
                            asist.Add(unaExcursion);
                        }
                        
                    }
                }
            }
            return asist;
        }
        #endregion
        #region Método Cotizacion
        //Mostrar Cotización
        public decimal MostrarDolar()
        {
            return dolar;
        }
        //Modificar Cotización
        public bool ModificarDolar(decimal numero)
        {
            bool valido = false;
            if (numero > 0)
            {
                dolar = numero;
                valido = true;
            }
            return valido;
        }
        #endregion




        #region Otros Métodos
        private static bool ControlDosDestinos(List<Destino> aux)
        {
            bool bandera = false;
            int contador = 0;
            foreach (Destino unDestino in aux)
            {
                contador++;
            }
            if (contador == 2)
            {
                bandera = true;
            }
            return bandera;
        } 
        #endregion

    }
}

