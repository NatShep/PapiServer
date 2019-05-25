using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using PapiService.CognitiveClient;
using PapiServiсe.Models;
using FaceRectangle = PapiServiсe.Models.FaceRectangle;

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
                .Select(ConvertToResponseDto).FirstOrDefault();

            return new CompileResponseDto {Face = face};
        }

        private FaceDto ConvertToResponseDto(DetectedFace o)
        {
            var (emotion, emoLevel) 
                = EmotionConverter.GetResultEmotion(o.FaceAttributes.Emotion);

            return new FaceDto
            {
                EmotionLevel = emoLevel,
                EmotionType = emotion,
                EmotionName = emotion.ToString(),
                Age = o.FaceAttributes.Age,
                Gender = o.FaceAttributes.Gender,
                Smile = o.FaceAttributes.Smile,
                Rectangle = new FaceRectangle
                {
                    Top = o.FaceRectangle.Top,
                    Height = o.FaceRectangle.Height,
                    Left = o.FaceRectangle.Left,
                    Width = o.FaceRectangle.Width
                }
            };
        }
    }
}