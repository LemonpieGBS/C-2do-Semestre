namespace Ejercicio3Formativo;

class Program
{
    public class Estudiante {

        // Declara una lista vacía de doubles
        public List<double> Notas = new(){};
        public string Nombre;

        // Constructor vacío
        public Estudiante(string nombre) {
            this.Nombre = nombre;
        }

        // Constructor por si un estudiante ya tiene notas existentes
        public Estudiante(string nombre, List<double> NotasExistentes) {
            this.Nombre = nombre;
            this.Notas = NotasExistentes;
        }
    }

    // Función para agregar estudiante
    public static void AgregarEstudiante(List<Estudiante> listaEstudiantes, Estudiante estudiante) {
        listaEstudiantes.Add(estudiante);
    }

    // Función para calcular promedio
    public static double CalcularPromedio(Estudiante estudiante) {
        double promedio = 0;
        foreach(double Nota in estudiante.Notas) {
            promedio += Nota;
        }
        promedio /= estudiante.Notas.Count;
        return promedio;
    }

    // Función para determinar el mejor y el peor estudiante
    public static void MejorPeorEstudiante(List<Estudiante> listaEstudiantes) {

        if(listaEstudiantes.Count == 0) {
            Console.WriteLine("==== NO HAY ESTUDIANTES PARA ANALIZAR ====");
            return;
        }

        Estudiante? mejorEstudiante = null, peorEstudiante = null;

        foreach (Estudiante estudiante in listaEstudiantes) {
            // Si estos campos son nulos, asignarlo al estudiante actual
            mejorEstudiante ??= estudiante;
            peorEstudiante ??= estudiante;

            // Si el promedio del estudiante actual es mayor al del mejor estudiante, se asigna
            if(CalcularPromedio(estudiante) > CalcularPromedio(mejorEstudiante)) mejorEstudiante = estudiante;

            // Si el promedio del estudiante actual es menor al del peor estudiante, se asigna
            if(CalcularPromedio(estudiante) < CalcularPromedio(peorEstudiante)) peorEstudiante = estudiante;
            
        }

        Console.WriteLine(
            $""""
            ESTUDIANTE CON EL MEJOR PROMEDIO:
            - Nombre: {(mejorEstudiante is not null ? mejorEstudiante.Nombre : "")}
            - Promedio: {(mejorEstudiante is not null ? CalcularPromedio(mejorEstudiante) : 0) : 0.00}

            ESTUDIANTE CON EL PEOR PROMEDIO:
            - Nombre: {(peorEstudiante is not null ? peorEstudiante.Nombre : "")}
            - Promedio: {(peorEstudiante is not null ? CalcularPromedio(peorEstudiante) : 0) : 0.00}
            """"
        );

    }

    static void Main(string[] args)
    {
        /*
        Desarrolla un programa que gestione las calificaciones de un 
        grupo de estudiantes. El programa debe: 
        ✓ Permitir ingresar las calificaciones de varios 
        estudiantes. 
        ✓ Calcular el promedio de calificaciones de cada 
        estudiante. 
        ✓ Determinar el estudiante con el promedio más alto y el 
        más bajo. 

        Requisitos: 

        ✓ Implementar 
        la función agregar_estudiante 
        (estudiantes, nombre, calificaciones) para agregar 
        estudiantes y sus calificaciones (una lista de notas). 
        ✓ Implementar la función calcular_promedio 
        (calificaciones) para calcular el promedio de un 
        estudiante. 
        ✓ Implementar 
        la función determinar_mejor_peor_estudiante (estudiantes) que 
        devuelva los nombres del estudiante con el promedio 
        más alto y el promedio más bajo. 
        */

        List<Estudiante> listaEstudiante = new(){};
        Console.WriteLine(
""""          
   _____      _      ___   ___  _ 
  / ____|    | |    / _ \ / _ \| |
 | (___   ___| |__ | | | | | | | |
  \___ \ / __| '_ \| | | | | | | |
  ____) | (__| | | | |_| | |_| | |
 |_____/ \___|_| |_|\___/ \___/|_|
""""
        );

        double 

        Console.WriteLine();
    }
}