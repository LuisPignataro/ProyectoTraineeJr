using System;

namespace WSVenta
{
    public class WeatherForecast
    {
        public int Id { get; set; } // es importante poner get y set. Para que el sistema serialice los objetos
        public string Nombre { get; set; }
    }
}
