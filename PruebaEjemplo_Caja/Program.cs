using System;
using System.Collections.Generic;
using System.IO;

namespace PruebaEjemplo_Caja
{
    class Program
    {
    	
    	public static void save(ControllerCuenta controller){
    		controller.EscribirLista();
    	}
    	
    	public static void menuOption4(ControllerCuenta controller, UsuarioCuenta user){
    		
    		double monto = 0;
    		string number="";
    		string number00="";
    		string message="";
    		Console.Clear();
    		Console.WriteLine("-------------------------------");
			Console.WriteLine("|    Deposito entre cuentas   |");
			Console.WriteLine("-------------------------------");
			Console.Write("Ingrese el numero de cuenta de origen: ");
			number = Console.ReadLine();
			
			user = controller.buscarXCuenta(number);
			
			if(user!=null){
			
			Console.Write("Ingrese el numero de cuenta de destino: ");
			number00 = Console.ReadLine();
			
			user = controller.buscarXCuenta(number00);
			
			if(user!=null){
			
			if(number.Equals(number00)==false){
				
				
				
			try{
			Console.Write("Ingrese el monto: ");
			monto = double.Parse(Console.ReadLine());
			
			message = controller.transferenciaDinero(number,number00,monto);
			
			if(message.Equals("La transacción se realizo con éxito")==true){
				Console.WriteLine(message);
				save(controller);
			}else{
				Console.WriteLine(message);
			}
			}catch(Exception ex){
				Console.WriteLine("Valor invalido");
			}
			}else{
					Console.WriteLine("La cuenta de destino no puede ser igual a la de origen");
			}
				
			}else{
				Console.WriteLine("Cuenta no encontrada");
			}
			
			}else{
				Console.WriteLine("Cuenta no encontrada");
			}
//			Console.WriteLine();
//			Console.WriteLine("El saldo de la cuenta es: "+user.monto);
			Console.ReadKey(true);
			Console.Clear();
    	}
    	
    	public static void menuOption3(ControllerCuenta controller, UsuarioCuenta user){
    		bool temp=false;
    		double monto = 0;
    		string number="";
    		Console.Clear();
    		Console.WriteLine("-------------------------------");
			Console.WriteLine("|       Retiro de dinero      |");
			Console.WriteLine("-------------------------------");
			Console.Write("Ingrese el numero de cuenta: ");
			number = Console.ReadLine();
			
			user = controller.buscarXCuenta(number);
			
			if(user!=null){
			
			try{
			Console.Write("Ingrese el monto: ");
			monto = double.Parse(Console.ReadLine());
			
			if(monto>=0){
			
			temp = controller.retirarDinero(monto, number);
			if(temp==true){
				Console.WriteLine("Usted retiro " + monto + "");
				save(controller);
			}else{
				Console.WriteLine("No se pudo realizar el retiro");
			}
			}else{
				Console.WriteLine("Monto invalido");
			}
			}catch(Exception ex){
				Console.WriteLine("Monto invalido");
			}
			}else{
				Console.WriteLine("Cuenta no encontrada");
			}
			
//			Console.WriteLine("El saldo de la cuenta es: "+user.monto);
			Console.ReadKey(true);
			Console.Clear();
    	}
    	
    	public static void menuOption2(ControllerCuenta controller, UsuarioCuenta user){
    		bool temp=false;
    		double monto = 0;
    		string number="";
    		Console.Clear();
    		Console.WriteLine("-------------------------------");
			Console.WriteLine("|      Deposito de saldo      |");
			Console.WriteLine("-------------------------------");
			Console.Write("Ingrese el numero de cuenta: ");
			number = Console.ReadLine();
			
			user = controller.buscarXCuenta(number);
			if(user!=null){
			
			Console.Write("Ingrese el monto: ");
			try{
			monto = double.Parse(Console.ReadLine());
			temp = controller.depositarDinero(monto, number);
			if(temp==true){
				Console.WriteLine("Deposito exitoso");
				save(controller);
			}else{
				Console.WriteLine("No se pudo realizar el deposito");
			}
			}catch(Exception ex){
				Console.WriteLine("Valor no valido");
			}
			
			}else{
				Console.WriteLine("Cuenta no encontrada");
			}
//			Console.WriteLine("El saldo de la cuenta es: "+user.monto);
			Console.ReadKey(true);
			Console.Clear();
    	}
    	
    	public static void menuOption1(ControllerCuenta controller, UsuarioCuenta user){
    		Console.Clear();
    		Console.WriteLine("-------------------------------");
			Console.WriteLine("|      Consulta de saldo      |");
			Console.WriteLine("-------------------------------");
			Console.Write("Ingrese su numero de cuenta: ");
			user = controller.buscarXCuenta(Console.ReadLine());
			try{
			Console.WriteLine("El saldo de la cuenta es: "+user.monto);
			}catch(Exception ex){
				Console.WriteLine("No se encontro la cuenta");
			}
			Console.ReadKey(true);
			Console.Clear();
    	}
    	
    	public static void menu(){
		
    		string option="";
    		UsuarioCuenta user=new UsuarioCuenta();
    		
    		//string rutaArchivo = (Directory.GetCurrentDirectory() + @"\db\bd.txt").ToString();
    		string rutaArchivo = ("//172.23.11.136/pruebas/bdcajero.txt").ToString();
            ControllerCuenta controller = new ControllerCuenta(rutaArchivo);
           
    		
    		
    		while(option!="0"){
            	Console.Clear();
    		Console.WriteLine("-------------------------------");
			Console.WriteLine("| Cajero automatico - Grupo 3 |");
			Console.WriteLine("-------------------------------");
			Console.WriteLine("1               Consultar saldo");
			Console.WriteLine("2                     Depositar");
			Console.WriteLine("3                       Retirar");
			Console.WriteLine("4        Deposito entre cuentas");
			Console.WriteLine("0                      Terminar");
			Console.WriteLine("-------------------------------");
			
			Console.Write("Teclea la operacion: ");
			option = Console.ReadLine();
			
			switch(option){
				case "1":
					menuOption1(controller, user);
				break;
					case "2":
					menuOption2(controller,user);
					break;
					case "3":
					menuOption3(controller,user);
					break;
					case "4":
					menuOption4(controller,user);
					break;
			}
			
    		}
			
		}
    	
        static void Main(string[] args)
        {
            string rutaArchivo = (Directory.GetCurrentDirectory() + @"\db\bd.txt").ToString();
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
//            Console.WriteLine("Ingrese el monto a retirar: ");
//            monto = double.Parse (Console.ReadLine());
//            Console.WriteLine("Ingrese la cuenta: ");
//            cuenta = Console.ReadLine();

//            Console.WriteLine(controller.buscarXCuenta(cuenta));
//            controller.retirarDinero(monto, cuenta);
//            Console.WriteLine(controller.buscarXCuenta(cuenta));

			menu();
			  Console.ReadKey(true);
        }
    }
}
