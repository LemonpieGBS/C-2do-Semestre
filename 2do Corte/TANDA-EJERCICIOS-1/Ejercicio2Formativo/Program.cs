namespace Ejercicio2Formativo;

class Input
{
    public static int obtenerEntero()
    {
        int returner;
        while(!int.TryParse(Console.ReadLine(), out returner))
        {
            Console.WriteLine("El input no se pudo convertir a entero! Por favor intentar de nuevo");
        }
        return returner;
    }

    public static double obtenerDecimal()
    {
        double returner;
        while (!double.TryParse(Console.ReadLine(), out returner))
        {
            Console.WriteLine("El input no se pudo convertir a decimal! Por favor intentar de nuevo");
        }
        return returner;
    }
}

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
                Console.WriteLine($"Cantidad editada de {inventario[i].Cantidad} a {cantidad}");
                // Los structs son raros porque las cosas las pasan por valor y no por referencia
                // Con una clase solo tendria que hacer inventario[i].Cantidad = cantidad pero o bueno
                inventario[i] = new Producto(inventario[i].Nombre, inventario[i].Precio, cantidad);
                return true;
            }
        }

        Console.WriteLine($"#ERROR: No se encontró el producto con nombre: {nombre} !");
        return false;
    }

    public static double CalcularValorTotal(ref List<Producto> inventario)
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

        List<Producto> Productos = new List<Producto>();
        Console.WriteLine(
            """"
            $$$$$$$$\                                   $$\           $$\            $$$$$$\  
            $$  _____|                                  \__|          \__|          $$  __$$\ 
            $$ |      $$\  $$$$$$\   $$$$$$\   $$$$$$$\ $$\  $$$$$$$\ $$\  $$$$$$\  \__/  $$ |
            $$$$$\    \__|$$  __$$\ $$  __$$\ $$  _____|$$ |$$  _____|$$ |$$  __$$\  $$$$$$  |
            $$  __|   $$\ $$$$$$$$ |$$ |  \__|$$ /      $$ |$$ /      $$ |$$ /  $$ |$$  ____/ 
            $$ |      $$ |$$   ____|$$ |      $$ |      $$ |$$ |      $$ |$$ |  $$ |$$ |      
            $$$$$$$$\ $$ |\$$$$$$$\ $$ |      \$$$$$$$\ $$ |\$$$$$$$\ $$ |\$$$$$$  |$$$$$$$$\ 
            \________|$$ | \_______|\__|       \_______|\__| \_______|\__| \______/ \________|
                $$\   $$ |                                                                    
                \$$$$$$  |                                                                    
                 \______/                                                                     
            """");

        while (true)
        {
            bool exit = false;
            Console.Write(
                $""""

                     === Menu Principal ===
                     - 1: Agregar Producto al Inventario ({Productos.Count})
                     - 2: Actualizar Stock de un Producto
                     - 3: Calcular valor total del Inventario
                     - 4: Ver inventario completo
                     - 5: <- Salir

                     > 
                """");

            int opcion = Input.obtenerEntero();

            switch(opcion)
            {
                case 1:
                    {
                        Console.WriteLine("+: Ingrese el nombre del producto:");
                        string nombreProducto = Console.ReadLine() ?? "";

                        Console.WriteLine("+: Ingrese el precio del producto:");
                        double precioProducto = Input.obtenerDecimal();

                        Console.WriteLine("+: Ingrese la cantidad en stock:");
                        int cantidadProducto = Input.obtenerEntero();

                        bool operacion = AgregarProducto(ref Productos,
                            nombreProducto, precioProducto, cantidadProducto);

                        Console.WriteLine(
                            (operacion) ?
                            "La operación se realizó con exito" :
                            "Hubo un error al realizar la operación"
                            );
                    }
                    break;

                case 2:
                    {
                        Console.WriteLine("+: Ingrese el nombre del producto a editar:");
                        string nombreProducto = Console.ReadLine() ?? "";

                        Console.WriteLine("+: Ingrese la nueva cantidad en stock:");
                        int cantidadProducto = Input.obtenerEntero();

                        bool operacion = ActualizarStock(ref Productos, nombreProducto, cantidadProducto);

                        Console.WriteLine(
                            (operacion) ?
                            "La operación se realizó con exito" :
                            "Hubo un error al realizar la operación"
                            );
                    }
                    break;

                case 3:
                    {
                        double valor = CalcularValorTotal(ref Productos);
                        Console.WriteLine(
                            $""""
                            -----------------------------------------------
                            VALOR TOTAL DEL INVENTARIO: {valor}$
                            -----------------------------------------------
                            """");
                    }
                    break;

                case 4:
                    {
                        int i = 0;
                        foreach (Producto producto in Productos)
                        {
                            i++;
                            Console.WriteLine(
                                $""""
                                ================================
                                = PRODUCTO #{i} =
                                - Nombre: {producto.Nombre}
                                - Precio: {producto.Precio}
                                - Cantidad: {producto.Cantidad}
                                """");
                        }
                    }
                    break;

                case 5:
                    {
                        exit = true;
                    }
                    break;
            }

            if (exit) break;
        }

    }
}
