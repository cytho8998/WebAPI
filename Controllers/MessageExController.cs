using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageExController : ControllerBase
    {
        // GET: api/<MessageExController>
        [HttpGet]
        public string Get()
        {
            //return new string[] { "value1", "value2" };
            return "WebAPI Container OK";
        }

  

        // POST api/<MessageExController>
        [HttpPost]
        public void Post([FromBody] MessageExClass MessageDetails)
        {
            
            var headers = Request.Headers;
            var autho = "";
            if (headers.Authorization != string.IsNullOrEmpty)
            {
                autho = headers.Authorization.ToString();
                
            }
  
            if (autho.ToLower().StartsWith("bearer"))
            {
                autho = autho.Substring(7);
            }
        }

     
    }
}
