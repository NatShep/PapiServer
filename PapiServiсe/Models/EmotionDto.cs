using Newtonsoft.Json;

namespace PapiServiсe.Models
{
    public class EmotionDto
    {
        /// <summary>Initializes a new instance of the Emotion class.</summary>
        public EmotionDto()
        {
        }

        /// <summary>Initializes a new instance of the Emotion class.</summary>
        public EmotionDto(
            double anger = 0.0,
            double contempt = 0.0,
            double disgust = 0.0,
            double fear = 0.0,
            double happiness = 0.0,
            double neutral = 0.0,
            double sadness = 0.0,
            double surprise = 0.0)
        {
            this.Anger = anger;
            this.Contempt = contempt;
            this.Disgust = disgust;
            this.Fear = fear;
            this.Happiness = happiness;
            this.Neutral = neutral;
            this.Sadness = sadness;
            this.Surprise = surprise;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "anger")]
        public double Anger { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "contempt")]
        public double Contempt { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "disgust")]
        public double Disgust { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "fear")]
        public double Fear { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "happiness")]
        public double Happiness { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "neutral")]
        public double Neutral { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "sadness")]
        public double Sadness { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "surprise")]
        public double Surprise { get; set; }
    }
}