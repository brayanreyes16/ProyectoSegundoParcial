using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estado_Nomina
{
    public class Datos
    {
        private List<Empleado> empleados;

        public Datos()
        {
            empleados = new List<Empleado>();
        }
        public void AgregarEmpleado(Empleado empleado)
        {
            empleados.Add(empleado);
        }
        public void MostrarEmpleados()
        {
            foreach (var empleadoss in empleados)
            {
                Console.WriteLine(empleadoss.MostrarInformacionEmpleado());
            }
        }

        public Empleado GetEmpleado(int i)
        {
            return empleados[i];
        }

        //Calculo de Datos para Nomina

        public string CarcularSalarioOrdinario(double tarifa, int horasOrdinarias, string nombre)
        {
            double salarioOrdinario = horasOrdinarias * tarifa;

            return $"El Salario Ordinario de {nombre} es: {salarioOrdinario} C$";
        }

        public string CarcularHorasExtra(double tarifa, int horasExtra, string nombre)
        {
            double SalarioHorasExtra = (tarifa * 2) * horasExtra;
            return $"EL Salario de Horas Extra de {nombre} es de {SalarioHorasExtra} C$";
        }
        public string SalarioDevengado(double SalarioHorasExtra, double salarioOrdinario)
        {
            double salarioDevengado = SalarioHorasExtra + salarioOrdinario;
            return $"El Salario Devengado es de: {salarioDevengado} C$";
        }

        public string CalcularInss(double salarioDevengado)
        {
            double inss = salarioDevengado * 0.07;
            return $"EL impuesto de inss es de: {inss} C$";
        }
        public double CalcularIR(double salarioDevengado, double inss)
        {
            //calculo de ir primer paso ( restar el inss al salario devendago y multiplicarlo por 12)
            double salariodevenMenosInss = (salarioDevengado - inss) * 12;
            //verificar la tabla de rango salarial anual

            double ir = 0.0;
            if (salariodevenMenosInss < 100000)
            {
                ir = (salariodevenMenosInss - 0) * 0;
            }
            else if (salariodevenMenosInss > 100000 & salariodevenMenosInss <= 200000)
            {
                ir = ((((salariodevenMenosInss - 100000) * 0.15) + 0) / 12);
            }
            else if (salariodevenMenosInss > 200000 & salariodevenMenosInss <= 350000)
            {
                ir = ((((salariodevenMenosInss - 200000) * 0.20) + 15000) / 12);
            }
            else if (salariodevenMenosInss > 350000 & salariodevenMenosInss <= 500000)
            {
                ir = ((((salariodevenMenosInss - 350000) * 0.25) + 45000) / 12);
            }
            else if (salariodevenMenosInss > 500000)
            {
                ir = ((((salariodevenMenosInss - 500000) * 0.30) + 82500) / 12);
            }

            return ir;
        }

        public string NetoaRecibir(string nombre, double salarioDevengado, double inss, double ir)
        {
            double salario_a_recibir = salarioDevengado - inss - ir;

            return $"El Salario Neto a Recibir del empleado {nombre} es de: {salario_a_recibir} C$";
        }
    }
}
