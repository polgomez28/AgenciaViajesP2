﻿using System;
using Dominio;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgenciaDeViajes
{
    public class Program
    {
        #region Creación de la empresa
        static Agencia unaAgencia = new Agencia();
        #endregion
        static void Main(string[] args)
        {
            int opcion;
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------------------------------------------------" + "\n");
                Console.WriteLine("                      AGENCIA DE VIAJES                                         " + "\n");
                Console.WriteLine("                           MENU                                                 " + "\n");
                Console.WriteLine("--------------------------------------------------------------------------------" + "\n");
                Console.WriteLine("          1- Ingresar un destino                                                " + "\n");
                Console.WriteLine("          2- Visualizar todos los destinos disponibles                          " + "\n");
                Console.WriteLine("          3- Cotización del dolar                                               " + "\n");
                Console.WriteLine("          4- Registrar excursiones (Precargas)                                  " + "\n");
                Console.WriteLine("          5- Listar todas las excursiones                                       " + "\n");
                Console.WriteLine("          6- Listar excursiones que vayan a un destino dado entre dos fechas.   " + "\n");
                Console.WriteLine("          7- Salir                                                              " + "\n");
                Console.WriteLine("--------------------------------------------------------------------------------" + "\n");
                int.TryParse(Console.ReadLine(), out opcion);
                switch (opcion)
                {
                    case 1:
                        IngresaDestino();
                        Console.ReadKey();
                        break;
                    case 2:
                        ListarDestinos();
                        Console.ReadKey();
                        break;
                    case 3:
                        MostrarCotizacion();
                        break;
                    case 4:
                        Console.WriteLine("Ya se encuentran registradas (Precargas)");
                        break;
                    case 5:
                        ListarExcursiones();
                        Console.ReadKey();
                        break;
                    case 6:
                        //ListarExcursionesEnFecha();
                        break;
                    case 7:
                        return;
                    default:
                        break;
                }
            }
        }
        #region Case1
        private static void IngresaDestino()
        {
            string ciudad, pais;
            decimal costo;
            decimal cantidadDias;
            bool bandera = false;
            ciudad = PedirTexto("Ingrese la ciudad");
            pais = PedirTexto("Ingrese el pais");
            costo = PedirNumero("Ingrese el costo");
            cantidadDias = PedirNumero("Ingrese los días");
            if (Destino.ValidarString2(ciudad) && Destino.ValidarString2(pais) && Destino.ValidarEnteros(costo) && Destino.ValidarEnteros(cantidadDias))
            {
                bandera = unaAgencia.AgregarDestinos(ciudad, pais, costo, cantidadDias);
                if (bandera)
                {
                    Console.WriteLine("Alta destino OK");
                }
                else
                {
                    Console.WriteLine("Error, algo salió mal. Verifique que lo ingresado este correcto.");
                }
            }
        }
        #endregion
        #region Case2
        private static void ListarDestinos()
        {
            List<Destino> asist = unaAgencia.Destinos();
            MostrarListaDestinos(asist, "No hay destinos.");
        }
        // Muestra en pantalla la lista de destinos si los hubiera
        private static void MostrarListaDestinos(List<Destino> asist, string msgError)
        {
            if (asist.Count > 0)
            {
                foreach (Destino unDestino in asist)
                {
                    Console.WriteLine(unDestino);
                }
            }
            else
            {
                Console.WriteLine(msgError);
            }
        }
        #endregion
        #region Case3
        private static void MostrarCotizacion()
        {
            int opcion;
            bool salir = false;
            decimal cotiz = unaAgencia.MostrarDolar();
            Console.WriteLine("\nLa cotización actual del dólar es: $ " + cotiz);
            do
            {
                opcion = PedirNumero("\nDesea modificar la cotización?\n1 - Si\n2 - No");
                if (opcion == 1)
                {
                    ModificarCotizacion();
                    salir = true;
                }
                else if (opcion == 2)
                {
                    salir = true;
                }
                else
                {
                    Console.WriteLine("\nDebe ingresar una opción valida");
                }

            } while (!salir);

        }
        // Se modifica la cotización
        private static void ModificarCotizacion()
        {
            decimal cotizacion;
            string mensajeOk = "\nLa cotización actualizada es: $ ";
            string mensajeSalir = "Presione cualquier tecla para volver al menú";
            cotizacion = PedirDecimal("Ingrese la nueva cotización: ");
            bool valido = unaAgencia.ModificarDolar(cotizacion);
            if (!valido)
            {
                do
                {
                    decimal num = PedirDecimal();
                    valido = unaAgencia.ModificarDolar(num);
                    if (valido)
                    {
                        Console.WriteLine(mensajeOk + num);
                        Console.WriteLine(mensajeSalir);
                        Console.ReadKey();
                    }
                } while (!valido);
            }
            else
            {
                Console.WriteLine(mensajeOk + cotizacion);
                Console.WriteLine(mensajeSalir);
                Console.ReadKey();
            }
        }
        #endregion
        #region Case5
        // Creo una lista auxiliar de excursiones, la cargo con la lista de excursiones (agencia) y la mando al método MostrarLista
        private static void ListarExcursiones()
        {
            List<Excursion> asist = unaAgencia.Excursiones(); // obtiene una lista de excursiones generada desde el método en Agencia
            MostrarListaExcursiones(asist, "No hay excursiones.");
        }
        //Muestro la lista excursiones
        private static void MostrarListaExcursiones(List<Excursion> asist, string msgError)
        {
            if (asist.Count > 0)
            {
                foreach (Excursion unExcursion in asist)
                {
                    Console.WriteLine(unExcursion);
                }
            }
            else
            {
                Console.WriteLine(msgError);
            }
        }
        #endregion
        #region Otros Métodos
        private static string PedirTexto(string mensaje)
        {
            Console.WriteLine(mensaje);
            string texto = Console.ReadLine();
            return texto;
        }
        private static int PedirNumero(string mensaje = "Ingrese el numero")
        {
            int num;
            bool valido = false;
            do
            {
                Console.WriteLine(mensaje);
                valido = int.TryParse(Console.ReadLine(), out num);
                if (!valido)
                {
                    Console.WriteLine("\nSolo se admiten numeros\n");
                }

            } while (!valido);

            return num;
        }
        private static decimal PedirDecimal(string mensaje = "El valor debe ser positivo, ingrese nuevamente la cotizacion: ")
        {
            decimal num;
            bool valido = false;
            do
            {
                Console.WriteLine(mensaje);
                valido = decimal.TryParse(Console.ReadLine(), out num);
                if (!valido)
                {
                    Console.WriteLine("\nSolo se admiten numeros\n");
                }

            } while (!valido);

            return num;
        }
        #endregion
    }
}
