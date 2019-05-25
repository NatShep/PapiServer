using Microsoft.Azure.CognitiveServices.Vision.Face.Models;

namespace PapiServiсe.Models
{
    public class FaceDto
    {
        public FaceRectangle Rectangle { get; set; }
        public double ? Smile { get; set; }
        public Gender ? Gender { get; set; }
        public double ? Age { get; set; }
    }
}