namespace SalarioEmpleados.Busines
{
    using Salario.DataAccess;
    using SalarioEmpleados.Busines.Interfaz;
    using SalarioEmpleados.Model;
    using System.Collections.Generic;
    public class EmployeesRules
    {
        public List<Employees> GetEmployees()
        {
            Adapter adapter = new Adapter();
            FactorySalary factorySalary = new FactorySalary();
            List<Employees> employees = adapter.EmployeesList();

            foreach(var employed in employees)
            {   
                ICalculateSalary interfaz = factorySalary.GetInstance(employed.contractTypeName, employed.hourlySalary, employed.monthlySalary);
                employed.annualSalary = interfaz.CalculateSalary();
            }
            return employees;
        }

    }
}
