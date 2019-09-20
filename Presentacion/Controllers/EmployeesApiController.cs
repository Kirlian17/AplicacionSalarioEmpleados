using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using SalarioEmpleados.Model;
using SalarioEmpleados.Busines;

namespace Presentacion.Controllers
{
    public class EmployeesApiController : ApiController
    {
        // GET: api/EmployeesApi
        [HttpGet]
        public IEnumerable<Employees> Get()
        {


            EmployeesRules employeesRules = new EmployeesRules();
            List<Employees> employeesList = employeesRules.GetEmployees();

                return employeesList;
        }

        // GET: api/EmployeesApi/5
        [HttpGet]
        public List<Employees> Get(int id)
        {
            EmployeesRules employeesRules = new EmployeesRules();
            List<Employees> employeesList = employeesRules.GetEmployees();
            List<Employees> result = new List<Employees>();
            
            Employees employed = employeesList.FirstOrDefault(x => x.id == id);
            result.Add(employed);

            return result;
        }  
    }
}
