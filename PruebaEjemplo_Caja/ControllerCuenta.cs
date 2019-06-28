using System;
using System.Collections.Generic;
using System.IO;

namespace PruebaEjemplo_Caja
{
    public class ControllerCuenta
    {
        List<UsuarioCuenta> usuarioCuentas;
        string archivo;

        public ControllerCuenta(string archivo)
        {
            usuarioCuentas = new List<UsuarioCuenta>();
            this.archivo = archivo;

            CargarLista();
        }

      

        public void listarTodos()
        {
            Console.WriteLine("Mostrando lista");
            foreach (var item in usuarioCuentas)
            {
                Console.WriteLine(item);
            }
        }

        public string transferenciaDinero(string ctaOrigen, string ctaDestino, double monto)
        {
            UsuarioCuenta usuario = new UsuarioCuenta();
            bool bandera = false;
            char monedacta1, monedacta2;

            usuario = buscarXCuenta(ctaOrigen);
            if (monto > usuario.monto)
            {
                return "Saldo insuficiente en cuenta origen saldo actual: " + usuario.monto;
            }
            else
            {
                if (usuario != null)
                {
                    monedacta1 = usuario.moneda;
                    usuario = buscarXCuenta(ctaDestino);
                    if (usuario != null)
                    {
                        monedacta2 = usuario.moneda;
                        bandera = true;
                    }
                    else
                    {
                        return "Cuenta destino inexistente.";
                    }
                }
                else
                {
                    return "Cuenta origen inexistente";
                }
                if (bandera == true)
                {
                    if (monedacta1 == monedacta2)
                    {
                        foreach (var item in usuarioCuentas)
                        {
                            if (item.cuenta.Equals(ctaOrigen.Trim()))
                            {
                                item.monto = item.monto - monto;
                            }
                        }
                        foreach (var item in usuarioCuentas)
                        {
                            if (item.cuenta.Equals(ctaDestino.Trim()))
                            {
                                item.monto = item.monto + monto;
                            }
                        }
                        return "La transacción se realizo con éxito";
                    }
                    else
                    {
                        return "La moneda de las cuentas no coinciden";
                    }

                }
            }
            return "No se realizo la transacción";
        }
        public bool retirarDinero(double monto, string cuenta)
        {
            //UsuarioCuenta uCuenta = buscarXCuenta(cuenta);

            foreach (var item in usuarioCuentas)
            {
                if (item.cuenta.Equals(cuenta.Trim()))
                {
                    item.monto = item.monto - monto;
                    return true;
                }
            }
            return false;
        }
        public bool depositarDinero(double monto, string cuenta)
        {
            foreach (var item in usuarioCuentas)
            {
                if (item.cuenta.Equals(cuenta.Trim()))
                {
                    item.monto = item.monto + monto;
                    return true;
                }
            }
            return false;
        }

        public UsuarioCuenta buscarXCuenta(string cuenta)
        {
            foreach (var item in usuarioCuentas)
            {
                if (item.cuenta.Equals(cuenta.Trim()))
                {
                    return item;
                    
                }
            }
            return null;
        }

        public List<UsuarioCuenta> buscarXDni(string dni)
        {
            List<UsuarioCuenta> lista = new List<UsuarioCuenta>();
            UsuarioCuenta obj;

            foreach (var item in usuarioCuentas)
            {
                if (item.dni == dni.Trim())
                {
                    Console.WriteLine(item);
                    obj = new UsuarioCuenta();
                    obj = item;
                    lista.Add(obj);
                }
            }
            return lista;
        }

        public void EscribirLista()
        {
            StreamWriter sw;
            string linea = "";
        }
        private void CargarLista()
        {
            StreamReader sr;
            string linea = "";
            string[] arrayLinea;

            UsuarioCuenta obj;

            try
            {
                sr = new StreamReader(archivo);
                sr.ReadLine();
                while ((linea = sr.ReadLine()) != null)
                {
                    arrayLinea = linea.Split(',');

                    obj = new UsuarioCuenta
                    {
                        dni = arrayLinea[0],
                        nombres = arrayLinea[1],
                        apellidos = arrayLinea[2],
                        cuenta = arrayLinea[3],
                        monto = double.Parse(arrayLinea[4]),
                        moneda = char.Parse(arrayLinea[5])
                    };

                    usuarioCuentas.Add(obj);

                }

                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer archivo BD. {0}" + ex);
            }
        }
    }
}
