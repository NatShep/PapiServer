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
        public async Task<IList<DetectedFace>> GetFaceListAsync(FileStream stream)
        {
            try
            {
                return await _faceClient.Face.DetectWithStreamAsync(
                    stream, 
                    true, 
                    false,
                    new FaceAttributeType[]
                        { FaceAttributeType.Age, 
                            FaceAttributeType.Gender, 
                            FaceAttributeType.Smile ,
                            FaceAttributeType.HeadPose
                            
                        });
            }
            catch (APIErrorException e)
            {
                Debug.WriteLine("GetFaceListAsync: " + e.Message);
            }
            return Array.Empty<DetectedFace>();
        }
    }
}