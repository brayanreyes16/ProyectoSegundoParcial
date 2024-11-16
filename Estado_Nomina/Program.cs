using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estado_Nomina
{
    class Program
    {
        public static void Main(string[] args)
        {
            //crear la lista de empleados de tipo datos
            Datos empleados = new Datos();
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Bienvenido al Sistema de Estado de Nomina");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Ingrese el Nombre de la Empresa: ");
            string empresa = Console.ReadLine();
            Console.WriteLine("\nIngrese el mes en el que se genera el estado de nomina (Al mes de) : ");
            string periodo = Console.ReadLine();
            Console.WriteLine("\nIngrese el numero de empleados para ingresar en el estado de nomina: ");
            
            int numoroempleados = int.Parse(Console.ReadLine());

            //ciclo para agregar los empleados
            for (int i = 0; i < numoroempleados; i++)
            {
                Console.WriteLine($"\nIngrese la informacion del empleado numero: { i +1}");
                Console.WriteLine($"Ingrese el Nombre de Empleado: ");
                string nombre = Console.ReadLine();
                Console.WriteLine($"\nIngrese el Cargo del Empleado: ");
                string cargo = Console.ReadLine();
                Console.WriteLine($"\nIngrese la Horas Ordinarias del empleado: ");
                int horaOrdinarias = int.Parse(Console.ReadLine());
                Console.WriteLine($"\nIngrese las Horas Extras del Empleado: ");
                int horasExtras = int.Parse(Console.ReadLine());
                Console.WriteLine($"\nIngrese la tarifa por hora del pago al empleado: ");
                double tarifa = double.Parse(Console.ReadLine());

                //agrego al empleado
                Empleado empleado = new Empleado(nombre,  cargo, horaOrdinarias, horasExtras, tarifa);
                empleados.AgregarEmpleado(empleado);
            }

            //Mostramos La Tabla de todos los empleados
            Console.WriteLine("Empleados ingresados\n");
            empleados.MostrarEmpleados();

            Console.WriteLine("Preciones Cualquier tecla para Generar el Estado de Nomina");
            string continuar = Console.ReadLine();
            //Ciclo for para crear el estado de nomina
            Console.WriteLine($"\n  {empresa}");
            Console.WriteLine($"  {periodo}");
            Console.WriteLine($" Estado de Nomina: \n");

            for(int i = 0; i < numoroempleados; i++)
            {
                //Obtenemos la informacion del empleado i con el metodo GetEmpleado
                Empleado empleadoI = empleados.GetEmpleado(i);
                string salariOrdinario = empleados.CarcularSalarioOrdinario(empleadoI.Tarifa, empleadoI.HorasOrdinarias, empleadoI.Nombre);
                string horasExtras = empleados.CarcularHorasExtra(empleadoI.Tarifa, empleadoI.HorasExtra, empleadoI.Nombre);

                //calculamos otra vez el salario ordinario y el salario de horas extra para usar el metodo de salario devengado
                double salarioOrdinarioValor = empleadoI.HorasOrdinarias * empleadoI.Tarifa;
                double salarioHorasExtravalor = (empleadoI.Tarifa *2) * empleadoI.HorasExtra;

                string SalarioDevengado = empleados.SalarioDevengado(salarioHorasExtravalor, salarioOrdinarioValor);

                //calcamos el salario devengado otra vez para el inss
                double salariodevengadoValor = salarioOrdinarioValor + salarioHorasExtravalor;
                string Inss = empleados.CalcularInss(salariodevengadoValor);

                //Calcular IR
                double inssValor = salariodevengadoValor * 0.07;
                double ir = empleados.CalcularIR(salariodevengadoValor, inssValor);
                
                //Calcular Neto a Recibir
                string NetoARecibir = empleados.NetoaRecibir(empleadoI.Nombre, salariodevengadoValor, inssValor, ir);

                 Console.WriteLine($"\nInformacion del empleado {i + 1}: ");
                
                
                Console.WriteLine(salariOrdinario);
                Console.WriteLine(horasExtras);
                Console.WriteLine(SalarioDevengado);
                Console.WriteLine(Inss);
                Console.WriteLine($"El impuesto de IR es de: {ir} C$");
                Console.WriteLine(NetoARecibir);
            }
        }
    }
}
