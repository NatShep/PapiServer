using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;

namespace PapiService.CognitiveClient
{
    public class CognitiveApiClient : ICognitiveApiClient
    {
        private IFaceClient _faceClient;

        public static CognitiveApiClient CreateDefault()
        {
            var url = "https://westcentralus.api.cognitive.microsoft.com"; ///face/v1.0/";
            var key1 = "829cf5ddf69e4eba9070c631c92c79e5";
            var key2 = "dc4c94ea9c654568b22ae4b4c1f8ae15";
            return new CognitiveApiClient(key2, url);
        }
        
        
        public CognitiveApiClient(string key, string endpoint)
        {
            _faceClient = new FaceClient(
                new ApiKeyServiceClientCredentials(key));
            _faceClient.Endpoint = endpoint;
            
        }

        /// <summary>
        /// Returns all faces detected in an image stream
        /// </summary>
        /// <param name="stream">An image</param>
        /// <returns>A list of detected faces or an empty list</returns>
        public async Task<IList<DetectedFace>> GetFaceListAsync(Stream stream)
        {
            try
            {
                return await _faceClient.Face.DetectWithStreamAsync(
                    stream, true, false,
                    new[]
                        { 
                            FaceAttributeType.Age, 
                            FaceAttributeType.Gender, 
                            FaceAttributeType.Smile ,
                        });
            }
            catch (APIErrorException e)
            {
                Console.WriteLine("GetFaceListAsync: " + e.Message);
            }
            return Array.Empty<DetectedFace>();
        }
    }
}