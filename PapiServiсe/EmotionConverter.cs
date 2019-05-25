using Microsoft.Azure.CognitiveServices.Vision.Face.Models;

namespace PapiServiсe
{
    public enum ResultEmotion
    {
        Neutral = 0,
        Anger = 1,
        Contempt = 2,
        Disgust = 3,
        Fear= 4,
        Happiness = 5,
        Sadness = 6,
        Surprise = 7,   
    }
    public static class EmotionConverter
    {
        public static (ResultEmotion, double) GetResultEmotion(Emotion emotion)
        {
            var bestEmotion = ResultEmotion.Anger;
            var maxLevel = emotion.Anger;
            
            if (emotion.Contempt > maxLevel)
            {
                bestEmotion = ResultEmotion.Contempt;
                maxLevel = emotion.Contempt;
            }
            
            if (emotion.Disgust > maxLevel)
            {
                bestEmotion = ResultEmotion.Disgust;
                maxLevel = emotion.Disgust;
            }
            if (emotion.Fear > maxLevel)
            {
                bestEmotion = ResultEmotion.Fear;
                maxLevel = emotion.Fear;
            }
            if (emotion.Neutral > maxLevel)
            {
                bestEmotion = ResultEmotion.Neutral;
                maxLevel = emotion.Neutral;
            }
            if (emotion.Sadness > maxLevel)
            {
                bestEmotion = ResultEmotion.Sadness;
                maxLevel = emotion.Sadness;
            }
            if (emotion.Surprise > maxLevel)
            {
                bestEmotion = ResultEmotion.Surprise;
                maxLevel = emotion.Surprise;
            }
            if (emotion.Happiness > maxLevel)
            {
                bestEmotion = ResultEmotion.Happiness;
                maxLevel = emotion.Happiness;
            }
            return (bestEmotion, maxLevel);
        }   
    }
}