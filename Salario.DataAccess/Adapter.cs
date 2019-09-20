namespace Salario.DataAccess
{
    using Newtonsoft.Json;
    using SalarioEmpleados.Model;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    public class Adapter
    {
        public List<Employees> EmployeesList()
        {
            List<Employees> employeesinformation = new List<Employees>();
            string baseUrl = "http://masglobaltestapi.azurewebsites.net/api/Employees";
            HttpResponseMessage response = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = client.GetAsync(baseUrl).Result;
            }

            if (response.IsSuccessStatusCode)
            {
                var employedResponse = response.Content.ReadAsStringAsync().Result;
                employeesinformation = JsonConvert.DeserializeObject<List<Employees>>(employedResponse);
            }

            return employeesinformation;

        }
    }
}
