using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Yeni_klasör__2_.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet("{birinci}/{ikinci}")]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync(string birinci, string ikinci)
        {
            string type = birinci;
            string id = ikinci;

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Get, $"https://swapi.co/api/{type}/{id}"))
            {
                var response = await client.SendAsync(request);
                var asString = await response.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<ahmet>(asString);
                return Ok(jsonData);
            }
        }
    }
    public class ahmet
    {
        public string name { get; set; }
        public string rotation_period { get; set; }
        public string height { get; set; }
    }
}

