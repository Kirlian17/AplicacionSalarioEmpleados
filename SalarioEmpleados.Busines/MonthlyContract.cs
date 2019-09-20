namespace SalarioEmpleados.Busines
{
    using SalarioEmpleados.Busines.Interfaz;

    public class MonthlyContract : ICalculateSalary
    {
        private double Salary;
        public MonthlyContract(double salary)
        {
            Salary = salary;
        }
        public double CalculateSalary()
        {
            double annualSalaryMonthly = Salary * 12;
            return annualSalaryMonthly;
        }
    }
}
