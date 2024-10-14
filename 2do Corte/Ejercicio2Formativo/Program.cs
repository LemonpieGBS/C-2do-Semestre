namespace Ejercicio2Formativo;

class Program
{
    public struct Producto
    {
        public string Nombre;
        public double Precio;
        public int Cantidad;

        public Producto(string nombre, double precio, int cantidad)
        {
            this.Nombre = nombre;
            this.Precio = precio;
            this.Cantidad = cantidad;
        }
    }

    static List<Producto> Productos = new List<Producto>();

    public static bool AgregarProducto(ref List<Producto> inventario,
        string nombre, double precio, int cantidad)
    {

        foreach(Producto producto in inventario)
        {
            if(producto.Nombre == nombre)
            {
                Console.WriteLine("#ERROR: El nombre del producto ya está en uso!");
                return false;
            }
        }

        inventario.Add(new Producto(nombre, precio, cantidad));
        return true;
    }

    public static bool ActualizarStock(ref List<Producto> inventario, string nombre, int cantidad)
    {
        // No se puede editar un indice en foreach, toca usar for
        for(int i = 0; i < inventario.Count; i++)
        {
            if (inventario[i].Nombre == nombre)
            {
                // Los structs son raros porque las cosas las pasan por valor y no por referencia
                // Con una clase solo tendria que hacer inventario[i].Cantidad = cantidad pero o bueno
                inventario[i] = new Producto(inventario[i].Nombre, inventario[i].Precio, cantidad);
                return true;
            }
        }

        Console.WriteLine($"#ERROR: No se encontró el producto con nombre: {nombre} !");
        return false;
    }

    public static double CalcularValorTotal(List<Producto> inventario)
    {
        double totalInventario = 0;
        foreach(Producto producto in inventario)
        {
            totalInventario += producto.Cantidad * producto.Precio;
        }

        return totalInventario;
    }

    static void Main(string[] args)
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
        Console.WriteLine("Hello, World!");
    }
}
