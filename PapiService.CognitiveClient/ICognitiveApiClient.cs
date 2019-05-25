using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;

namespace PapiService.CognitiveClient
{
    public interface ICognitiveApiClient
    {
        /// <summary>
        /// Returns all faces detected in an image stream
        /// </summary>
        /// <param name="stream">An image</param>
        /// <returns>A list of detected faces or an empty list</returns>
        Task<IList<DetectedFace>> GetFaceListAsync(Stream stream);
    }
}