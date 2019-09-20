using Newtonsoft.Json;
using SalarioEmpleados.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentacion.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                List<Employees> employeesList = GetEmployeesLocalApi();
                return View(employeesList);
            }

            else
            {
                List<Employees> employeesList = new List<Employees>();
                Employees employed = GetEmployedLocalApi(id);
                employeesList.Add(employed);
                return View(employeesList);
            }
        }

        // GET: Employees/Details/5
        public ActionResult Employees(int id)
        {
            Employees employed = GetEmployedLocalApi(id);
            return View(employed);
        }

        public List<Employees> GetEmployeesLocalApi()
        {
            List<Employees> employeesinformation = new List<Employees>();
            string baseUrl;

                baseUrl = "https://localhost:44300/api/employeesapi";
            
            System.Net.Http.HttpResponseMessage response = null;

            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                response = client.GetAsync(baseUrl).Result;
            }

            if (response.IsSuccessStatusCode)
            {
                var employedResponse = response.Content.ReadAsStringAsync().Result;
                employeesinformation = JsonConvert.DeserializeObject<List<Employees>>(employedResponse);
            }

            return employeesinformation;
        }

        public Employees GetEmployedLocalApi(int? id)
        {
            Employees employeesinformation = new Employees();
            string baseUrl;

                baseUrl = $"https://localhost:44300/api/employeesapi/{id}";

            System.Net.Http.HttpResponseMessage response = null;

            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                response = client.GetAsync(baseUrl).Result;
            }

            if (response.IsSuccessStatusCode)
            {
                var employedResponse = response.Content.ReadAsStringAsync().Result;
                employeesinformation = JsonConvert.DeserializeObject<Employees>(employedResponse);
            }

            return employeesinformation;
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Details()
        {
            return View();
        }
    }
}
