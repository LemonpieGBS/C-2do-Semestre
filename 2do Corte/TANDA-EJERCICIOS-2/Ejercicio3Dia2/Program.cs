namespace Ejercicio3Dia2;

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
    public static List<Tuple<string, string>> CrearDiccionario()
    {
        const int MaximoEntradas = 5;
        List<Tuple<string, string>> diccionario = new() { };

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

            diccionario.Add(new Tuple<string, string>(palabraIngles, palabraEspañol));
        }

        return diccionario;
    }

    public static void Traducir(List<Tuple<string,string>> diccionario)
    {
        Console.WriteLine("+: Escriba la palabra (español o ingles) a traducir:");
        string palabraATraducir = Console.ReadLine() ?? "";

        foreach(Tuple<string,string> traduccion in diccionario) {
            if (traduccion.Item1 == palabraATraducir) {
                Console.WriteLine($"!: La traducción de {palabraATraducir} (ingles) es {traduccion.Item2} (español)");
                return;
            } else if(traduccion.Item2 == palabraATraducir) {
                Console.WriteLine($"!: La traducción de {palabraATraducir} (español) es {traduccion.Item1} (ingles)");
                return;
            }
        }
        
        Console.WriteLine($"!: No existe una traducción para {palabraATraducir}");
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

        List<Tuple<string,string>> diccionario = new() { };

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
                case 2: Traducir(diccionario); Console.WriteLine(); break;
                case 3:
                    {
                        int i = 0;
                        foreach(Tuple<string,string> traduccion in diccionario)
                        {
                            i++;
                            Console.WriteLine(
                                $""""
                                --- ENTRADA #{i} ---

                                  > Palabra en Ingles: {traduccion.Item1}
                                  > Palabra en Español: {traduccion.Item2}

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
