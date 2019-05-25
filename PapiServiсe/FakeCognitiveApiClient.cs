using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using PapiService.CognitiveClient;

namespace PapiServiсe
{
    public class FakeCognitiveApiClient: ICognitiveApiClient
    {
        public Task<IList<DetectedFace>> GetFaceListAsync(Stream stream)
        {
            var answer = new[]
            {
                new DetectedFace
                {
                     FaceRectangle = new FaceRectangle(42,43,44,45),
                     FaceAttributes =  new FaceAttributes
                     {
                         Age =  50,
                         Gender = Gender.Female,
                         Smile = 0.55
                     }
                }
            };
                
            return Task.FromResult<IList<DetectedFace>>(answer);
        }
    }
}