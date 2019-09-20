using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalarioEmpleados.Busines;

namespace Test
{
    [TestClass]
    public class FactoryTest
    {

        [TestMethod]
        public void ContratoNoEncontrado()
        {
            string contractType = "HourlyEmployee";
            double hourlySalary = 20000;
            double monthlySalary = 60000;

            FactorySalary factorySalary = new FactorySalary();
            var result = factorySalary.GetInstance(contractType, hourlySalary, monthlySalary);

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void ContratoEncontrado()
        {  
            string contractType = "HourlySalaryEmployee";
            double hourlySalary = 20000;
            double monthlySalary = 60000;
            HourlyContract prueba = new HourlyContract(hourlySalary);

            FactorySalary factorySalary = new FactorySalary();
            var result = factorySalary.GetInstance(contractType, hourlySalary, monthlySalary);

            Assert.AreEqual(prueba.GetType(), result.GetType());
        }
    }
}
