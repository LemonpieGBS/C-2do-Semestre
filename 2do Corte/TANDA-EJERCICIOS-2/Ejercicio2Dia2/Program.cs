namespace Ejercicio2Dia2;

/*
Desarrollar un programa que permita al usuario gestionar una cuenta bancaria. El programa
deberá utilizar un menú que permita realizar diferentes operaciones sobre el saldo de la cuenta.

Menú de opciones:
1. Consultar saldo
2. Depositar dinero
3. Retirar dinero
4. Salir

El programa debe permitir al usuario ingresar la cantidad para depositar o retirar, actualizar el
saldo y mostrar los resultados. Si se elige la opción de retiro, debe verificar que el saldo sea
suficiente.
*/

class Program
{
    public class Usuario
    {
        public string Nombre;
        public double Saldo = 0;

        public Usuario(string nombre) { this.Nombre = nombre; }
        public Usuario(string nombre, double saldo) {
            this.Nombre = nombre;
            this.Saldo = saldo;
        }
    }

    public static void ConsultarSaldo(Usuario usuario)
    {
        Console.WriteLine(
            $""""
            ===============================
            USUARIO {usuario.Nombre}
            SU SALDO ES DE: {usuario.Saldo:0.00}
            ===============================
            """");
    }

    public static void DepositarSaldo(Usuario usuario)
    {
        Console.WriteLine("===============================");
        Console.WriteLine("+: Ingrese el saldo a depositar:");

        double SaldoAFavor = double.Parse(Console.ReadLine() ?? "");
        usuario.Saldo += SaldoAFavor;

        Console.WriteLine($"Se han ingresado {SaldoAFavor:0.00} al usuario {usuario.Nombre}");
        Console.WriteLine("===============================");
    }

    public static void RetirarSaldo(Usuario usuario)
    {
        Console.WriteLine("===============================");
        Console.WriteLine("+: Ingrese el saldo a retirar:");

        double SaldoARetirar = double.Parse(Console.ReadLine() ?? "");
        if(SaldoARetirar > usuario.Saldo)
        {
            Console.WriteLine("NO HAY SUFICIENTE SALDO PARA RETIRAR LA CANTIDAD PEDIDA!");
        } else
        {
            usuario.Saldo -= SaldoARetirar;
            Console.WriteLine($"Se han retirado {SaldoARetirar:0.00} del usuario {usuario.Nombre}");
        }
        Console.WriteLine("===============================");
    }

    static void Main(string[] args)
    {
        Console.WriteLine("+: Ingrese su nombre: ");
        Usuario usuarioPrincipal = new(Console.ReadLine() ?? "");

        Console.WriteLine(
                """"
                                
                ██████╗  █████╗ ███╗   ██╗ ██████╗ █████╗ ██╗   ██╗ █████╗ ███╗   ███╗
                ██╔══██╗██╔══██╗████╗  ██║██╔════╝██╔══██╗██║   ██║██╔══██╗████╗ ████║
                ██████╔╝███████║██╔██╗ ██║██║     ███████║██║   ██║███████║██╔████╔██║
                ██╔══██╗██╔══██║██║╚██╗██║██║     ██╔══██║██║   ██║██╔══██║██║╚██╔╝██║
                ██████╔╝██║  ██║██║ ╚████║╚██████╗██║  ██║╚██████╔╝██║  ██║██║ ╚═╝ ██║
                ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝

                """");

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine(
                $""""
                === Hola, {usuarioPrincipal.Nombre} ===

                    Elije una opción
                    #1. Consultar Saldo
                    #2. Depositar Dinero
                    #3. Retirar Dinero
                    #4. <- Salir

                """");
            Console.Write("> ");

            int Opcion = int.Parse(Console.ReadLine() ?? "");
            switch(Opcion)
            {
                case 1: ConsultarSaldo(usuarioPrincipal); break;
                case 2: DepositarSaldo(usuarioPrincipal); break;
                case 3: RetirarSaldo(usuarioPrincipal); break;
                case 4: exit = true; break;
                default: break;
            }
        }
    }
}
