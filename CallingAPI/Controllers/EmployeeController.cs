using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net;
using System.Net.Http.Headers;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
    [Route("api/Employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        [HttpGet]
        [Route("~/api/Employees")]
        public IActionResult GetEmployees()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7089/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage responseMsg = client.GetAsync("api/Employees").Result;
                if (responseMsg.IsSuccessStatusCode)
                {
                    return Ok(responseMsg.Content.ReadAsStringAsync().Result);
                }
                else
                {

                    return BadRequest("some thing went wrong, please check request uri");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally { }
        }

        [HttpGet]
        [Route("~/api/Employees/{id}")]
        public IActionResult GetEmployee(long id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7089/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMsg = client.GetAsync("api/Employees/" + id).Result;
                if (responseMsg.IsSuccessStatusCode)
                {
                    return Ok(responseMsg.Content.ReadAsStringAsync().Result);
                }
                else
                {

                    return BadRequest("some thing went wrong, please check request uri");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally { }
        }

        [HttpDelete]
        [Route("~/api/Employees/{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7089/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMsg = client.DeleteAsync("api/Employees/" + id).Result;
                if (responseMsg.IsSuccessStatusCode)
                {
                    return Ok(HttpStatusCode.NoContent);
                }
                else
                {

                    return BadRequest("some thing went wrong, please check request uri");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally { }
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7089/api/Employees");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMsg = client.PostAsJsonAsync<Employee>("Employees", employee).Result;
                if (responseMsg.IsSuccessStatusCode)
                {
                    return Ok(HttpStatusCode.Created);
                }
                else
                {
                    return BadRequest("some thing went wrong, please check request uri");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally { }
        }

        [HttpPut]
        public IActionResult UpdateEmployee(long id, Employee employee)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7089/api/Employees");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMsg = client.PutAsJsonAsync<Employee>("Employees/" + id, employee).Result;
                if (responseMsg.IsSuccessStatusCode)
                {
                    return Ok(HttpStatusCode.Accepted);
                }
                else
                {
                    return BadRequest("some thing went wrong, please check request uri");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally { }
        }

    }
}
