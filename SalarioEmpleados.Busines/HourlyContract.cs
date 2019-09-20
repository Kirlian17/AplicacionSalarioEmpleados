using SalarioEmpleados.Busines.Interfaz;

namespace SalarioEmpleados.Busines
{
    public class HourlyContract : ICalculateSalary
    {
        private double Salary;
        public HourlyContract(double salary)
        {
            Salary = salary;
        }
        public double CalculateSalary()
        {
            double annualHourlySalary = 120 * Salary * 12;
            return annualHourlySalary;
        }
    }
}
