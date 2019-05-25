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
            var answer = new DetectedFace[0];
            return Task.FromResult<IList<DetectedFace>>(answer);
        }
    }
}