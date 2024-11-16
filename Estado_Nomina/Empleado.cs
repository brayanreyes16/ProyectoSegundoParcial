using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estado_Nomina
{
    public class Empleado
    {
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public int HorasOrdinarias { get; set; }
        public int HorasExtra { get; set; }
        public double Tarifa { get; set; }

        public Empleado(string nombre, string cargo, int horasOrdinarias, int horasExtra, double tarifa) 
        {
            Nombre = nombre;
            Cargo = cargo;
            HorasOrdinarias = horasOrdinarias;
            HorasExtra = horasExtra;
            Tarifa = tarifa;
        }
        public string MostrarInformacionEmpleado()
        {
            return($"Nombre: {Nombre}, Cargo: {Cargo}, Horas Ordinarias: {HorasOrdinarias}, Horas Extra {HorasExtra}, Tarifa: {Tarifa}\n");
        }

    }

   
}
