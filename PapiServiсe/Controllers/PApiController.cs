using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PapiService.CognitiveClient;
using PapiServiсe.Models;

namespace PapiServiсe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PApiController : ControllerBase
    {
        ICognitiveApiClient _client = CognitiveApiClient.CreateDefault();
        
        [HttpGet("/api/health")]
        public string Health() => "Ok";

        [HttpPost]
        public CompileResponseDto Post(IFormFile jpgRequest)
        { 
            var stream = jpgRequest.OpenReadStream();
            
            var task = _client.GetFaceListAsync(stream);
            task.Wait();
            var cognitiveAnswer = task.Result;
            
            var face = cognitiveAnswer?
                .Select(o => new FaceDto
                {
                    Rectangle = new FaceRectangle
                    {
                        Top    = o.FaceRectangle.Top, 
                        Height = o.FaceRectangle.Height, 
                        Left   = o.FaceRectangle.Left,
                        Width  = o.FaceRectangle.Width
                    },
                    Age    = o.FaceAttributes.Age,
                    Gender = o.FaceAttributes.Gender,
                    Smile  = o.FaceAttributes.Smile
                }).FirstOrDefault();

            return new CompileResponseDto {Face = face};
        }
    }
}