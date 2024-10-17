namespace KIDS_SEE_GHOSTS
{
    public class Program
    {
        // Por valor
        public static double CalcularAreaTriangulo(double baseTriangulo, double alturaTriangulo)
        {
            return (baseTriangulo * alturaTriangulo) / 2;
        }

        // Por referencia
        public static void CalcularAreaTriangulo(ref double baseTriangulo, ref double alturaTriangulo, ref double resultado)
        {
            resultado = (baseTriangulo * alturaTriangulo) / 2;
        }

        public static void Main()
        {
            /*
            Crea un programa que administre un inventario de productos.
            Cada producto tiene un nombre, un precio y una cantidad en
            stock. El programa debe permitir:
            ✓ Añadir nuevos productos al inventario.
            ✓ Actualizar la cantidad en stock de un producto
            existente.
            ✓ Calcular el valor total del inventario (sumando el valor
            de cada producto: precio × cantidad en stock).
            Requisitos:
            ✓ Implementar la función agregar_producto (inventario,
            nombre, precio, cantidad) para añadir productos.
            ✓ Implementar la función actualizar_stock (inventario,
            nombre, nueva_cantidad) para modificar la cantidad de
            un producto.
            ✓ Implementar la función calcular_valor_total (inventario)
            que devuelva el valor total del inventario.
            */

            Console.WriteLine("=== Calculadora de Área de Triangulos ===");

            Console.WriteLine("+: Ingrese la base del tríangulo: ");
            double baseObtenida = double.Parse(Console.ReadLine() ?? "");

            Console.WriteLine("+: Ingrese la altura del tríangulo: ");
            double alturaObtenida = double.Parse(Console.ReadLine() ?? "");

            double resultado = 0;

            CalcularAreaTriangulo(ref baseObtenida, ref alturaObtenida, ref resultado);
            Console.WriteLine($"El área del triangulo es: {resultado}");
        }
    }
}