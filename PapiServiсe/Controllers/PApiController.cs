using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PapiServiсe.Models;

namespace PapiServiсe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PApiController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"value1", "value2"};
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

       
        [HttpPost]
        public Face Post(IFormFile jpgRequest)
        {
            
            var stream = jpgRequest.OpenReadStream();
            var name = jpgRequest.FileName;
            
            
            
            var face = new Face();
            return face;
         
            
            var response = HttpContext.Response.Headers;
        //    return StatusCode(200);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PApiRequestDto papirequest)
        {
           
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}