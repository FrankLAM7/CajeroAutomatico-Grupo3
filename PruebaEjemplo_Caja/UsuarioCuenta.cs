using System;
namespace PruebaEjemplo_Caja
{
    public class UsuarioCuenta
    {
        public string dni { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string cuenta { get; set; }
        public double monto { get; set; }
        public char moneda { get; set; }

        public override string ToString()
        {
            return $"UsuarioCuenta: {dni} - {nombres} - {apellidos} - {cuenta} - {monto} - {moneda}";
        }

        public UsuarioCuenta()
        {
            
        }
    }
}
