using SalarioEmpleados.Busines.Interfaz;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalarioEmpleados.Busines
{
    public class FactorySalary
    {
        public ICalculateSalary GetInstance(string contractTypeName, double hourlySalary, double monthSalary)
        {

            switch (contractTypeName)
            {
                case "HourlySalaryEmployee":
                    return new HourlyContract(hourlySalary);
                    break;

                case "MonthlySalaryEmployee":
                    return new MonthlyContract(monthSalary);
                    break;
            }

            return null;
        }
    }
}
