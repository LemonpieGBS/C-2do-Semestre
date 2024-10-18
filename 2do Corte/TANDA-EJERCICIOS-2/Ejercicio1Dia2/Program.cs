namespace Ejercicio1Dia2;

/*
Crear un programa que simule la gestión de un inventario en una tienda. Utilizar un menú para
agregar, eliminar, modificar y consultar productos en el inventario. Cada producto tendrá un
código, nombre, cantidad y precio.

Menú de opciones:

1. Agregar producto
2. Eliminar producto
3. Modificar producto
4. Consultar producto
5. Mostrar todos los productos
6. Salir
*/

class Program
{
    public class Producto
    {
        public int Id;
        public string Nombre;
        public int Cantidad;
        public double Precio;

        public Producto(int id, string nombre, int cantidad, double precio)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Cantidad = cantidad;
            this.Precio = precio;
        }

        public override string ToString()
        {
            return $""""
                  #: {Id}
                  Nombre: {Nombre}
                  Cantidad: {Cantidad}
                  Precio: {Precio}
                --------------
                """";
        }
    }

    public static int? IDExistente(List<Producto> inventario, int ID)
    {
        int i = 0;
        foreach(Producto producto in inventario)
        {
            if (producto.Id == ID) return i;
            i++;
        }
        return null;
    }

    public static void AgregarProducto(List<Producto> inventario)
    {
        int nuevoID;
        do
        {
            Console.WriteLine("+: Ingrese el ID (#) del producto");
            nuevoID = int.Parse(Console.ReadLine() ?? "");

            if (IDExistente(inventario, nuevoID) is not null) Console.WriteLine("!: EL ID YA EXISTE, DEBE SER ÚNICO!");
        } while (IDExistente(inventario, nuevoID) is not null);

        Console.WriteLine("+: Ingrese el nombre del producto");
        string nuevoNombre = Console.ReadLine() ?? "";

        Console.WriteLine("+: Ingrese la cantidad disponible del producto");
        int nuevaCantidad = int.Parse(Console.ReadLine() ?? "");

        Console.WriteLine("+: Ingrese el precio del producto");
        double nuevoPrecio = double.Parse(Console.ReadLine() ?? "");

        inventario.Add(new Producto(nuevoID, nuevoNombre, nuevaCantidad, nuevoPrecio));
    }

    public static void EliminarProducto(List<Producto> inventario)
    {
        Console.WriteLine("+: Ingrese el ID del producto a eliminar:");
        int idBuscado = int.Parse(Console.ReadLine() ?? "");

        int? indiceEncontrado = IDExistente(inventario, idBuscado);
        
        if (indiceEncontrado is null)
        {
            Console.WriteLine("El producto no se encontró!");
        } else
        {
            Console.WriteLine(
                $""""
                PRODUCTO ENCONTRADO!

                {inventario[indiceEncontrado ?? 0].ToString}

                +: Está seguro de eliminarlo? (true/false)
                """");

            if(bool.Parse(Console.ReadLine() ?? ""))
            {
                inventario.RemoveAt(indiceEncontrado ?? 0);
            }
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
