using System;
using System.Collections.Generic;

namespace PruebaEjemplo_Caja
{
    class Program
    {
        static void Main(string[] args)
        {
            string rutaArchivo = @"E:\Visual Studio\Semana 5\Dia 3\bd.txt";
            string dni;
            string cuenta;
            double monto;
            char moneda;

            ControllerCuenta controller = new ControllerCuenta(rutaArchivo);
            List<UsuarioCuenta> usuarios; //= new List<UsuarioCuenta>();

            Console.WriteLine("Hello World!");
            /*
            Console.WriteLine("Ingrese el DNI: ");
            dni = Console.ReadLine();

            

            usuarios = controller.buscarXDni(dni);
            foreach (var item in usuarios)
            {
                Console.WriteLine(item);
            }

            controller.listarTodos();
            */
            //Console.WriteLine("Ingrese el monto a retirar: ");
            //monto = double.Parse (Console.ReadLine());
            //Console.WriteLine("Ingrese la cuenta: ");
            //cuenta = Console.ReadLine();

            //Console.WriteLine(controller.buscarXCuenta(cuenta));
            //controller.retirarDinero(monto, cuenta);
            //Console.WriteLine(controller.buscarXCuenta(cuenta));
            bool resp = controller.transferenciaDinero("275-8143201", "379-2398783", 1000);
            controller.listarTodos();
            Console.WriteLine(resp);
            Console.ReadKey();
        }
    }
}
