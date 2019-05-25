using System;
using System.Collections.Generic;
using System.IO;
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
        public CompileResponseDto Post(IFormFile jpgRequest)
        { 
            var stream = jpgRequest.OpenReadStream();
            var name = jpgRequest.FileName;

            var client = new FakeCognitiveApiClient();
            var task = client.GetFaceListAsync(null);
            task.Wait();
            var cognitiveAnswer = task.Result;
            FaceDto output = cognitiveAnswer
                .Select(o => new FaceDto
                {
                    Rectangle = new FaceRectangle
                    {
                        Top = o.FaceRectangle.Top, Height = o.FaceRectangle.Top, Left = o.FaceRectangle.Left,
                        Width = o.FaceRectangle.Width
                    },
                    Age = o.FaceAttributes.Age,
                    Gender = o.FaceAttributes.Gender,
                    Smile = o.FaceAttributes.Smile
                }).FirstOrDefault();



            // var cognitiveAnswer = task.Result.FirstOrDefault();
            if (cognitiveAnswer == null)
            {
                return null;
            }

            var face = new FaceDto { };
            return new CompileResponseDto {Faces = outputs};


            //var response = HttpContext.Response.Headers;
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