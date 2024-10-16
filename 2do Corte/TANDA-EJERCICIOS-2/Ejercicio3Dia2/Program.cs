﻿namespace Ejercicio3Dia2;

/*
Desarrollar un programa que se comporte como un diccionario Inglés-Español; esto es, solicitará
una palabra en inglés y escribirá la correspondiente palabra en español. Para hacer más sencillo
el ejercicio, el número de parejas de palabras estará limitado a 5. Por ejemplo, suponer que
introducimos las siguientes parejas de palabras:

book libro
green verde
mouse ratón

Una vez finalizada la introducción de las listas de palabras, pasamos al modo traducción, de
forma que si introducimos green, la respuesta ha de ser verde. Si la palabra no se encuentra, se
emitirá un mensaje que lo indique.

El programa constará de dos métodos, aparte de Main():
1. crearDiccionario(). Este método creará el diccionario.
2. traducir(). Este método realizará la labor de traducción.
*/

class Program
{
    public static Dictionary<string, string> CrearDiccionario()
    {
        const int MaximoEntradas = 5;
        Dictionary<string, string> diccionario = new() { };

        Console.WriteLine($"+: Cuantas entradas desea agregar? (El máximo es 5)");
        int Entradas = Math.Min(int.Parse(Console.ReadLine() ?? ""), MaximoEntradas);

        for (int i = 0; i < Entradas; i++)
        {
            Console.WriteLine($"--- ENTRADA #{i + 1} ---");

            Console.Write("\nPalabra en Ingles: ");
            string palabraIngles = Console.ReadLine() ?? "";

            Console.Write("\nPalabra en Español: ");
            string palabraEspañol = Console.ReadLine() ?? "";

            Console.WriteLine();

            diccionario.Add(palabraIngles, palabraEspañol);
        }

        return diccionario;
    }

    public static void Traducir(Dictionary<string, string> diccionario)
    {
        Console.WriteLine("+: Escriba la palabra (en ingles) a traducir:");
        string palabraATraducir = Console.ReadLine() ?? "";

        if (diccionario.TryGetValue(palabraATraducir, out string? palabraEspañol))
        {
            Console.WriteLine($"!: La traducción de {palabraATraducir} es {palabraEspañol}");
        } else
        {
            Console.WriteLine($"!: No existe una traducción para {palabraATraducir}");
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        Console.WriteLine(
            """"
                        
            ██████╗ ██╗ ██████╗ ██████╗██╗ ██████╗ ███╗   ██╗ █████╗ ██████╗ ██╗ ██████╗ 
            ██╔══██╗██║██╔════╝██╔════╝██║██╔═══██╗████╗  ██║██╔══██╗██╔══██╗██║██╔═══██╗
            ██║  ██║██║██║     ██║     ██║██║   ██║██╔██╗ ██║███████║██████╔╝██║██║   ██║
            ██║  ██║██║██║     ██║     ██║██║   ██║██║╚██╗██║██╔══██║██╔══██╗██║██║   ██║
            ██████╔╝██║╚██████╗╚██████╗██║╚██████╔╝██║ ╚████║██║  ██║██║  ██║██║╚██████╔╝
            ╚═════╝ ╚═╝ ╚═════╝ ╚═════╝╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝ ╚═════╝ 
            """");

        Dictionary<string, string> diccionario = new() { };

        bool exit = false;
        do
        {

            Console.WriteLine(
                $""""
            -- MENU PRINCIPAL --
               
               Elija una opción
               #1. Crear Diccionario
               #2. Traducir
               #3. Leer Diccionario [{diccionario.Count} palabra(s)]
               #4. <- Salir

            --------------------

            """");

            Console.Write("> ");
            int Opcion = int.Parse(Console.ReadLine() ?? "");

            switch(Opcion)
            {
                case 1: diccionario = CrearDiccionario(); break;
                case 2: Traducir(diccionario);  break;
                case 3:
                    {
                        int i = 0;
                        foreach(KeyValuePair<string,string> traduccion in diccionario)
                        {
                            i++;
                            Console.WriteLine(
                                $""""
                                --- ENTRADA #{i} ---

                                  > Palabra en Ingles: {traduccion.Key}
                                  > Palabra en Español: {traduccion.Value}

                                """");
                        }
                        Console.WriteLine();
                    }
                    break;
                case 4: exit = true; break;
                default: break;
            }

        } while (!exit);
    }
}
