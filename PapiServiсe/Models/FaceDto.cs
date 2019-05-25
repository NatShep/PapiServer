using Microsoft.Azure.CognitiveServices.Vision.Face.Models;

namespace PapiServiсe.Models
{
    public class FaceDto
    {
        public ResultEmotion EmotionType { get; set; }
        public string EmotionName { get; set; }

        public double EmotionLevel { get; set; }
        public FaceRectangle Rectangle { get; set; }
        public double ? Smile { get; set; }
        public Gender ? Gender { get; set; }
        public double ? Age { get; set; }
    }
}