using System.IO;
using System.Linq;
using NUnit.Framework;
using PapiService.CognitiveClient;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /*
        [Test]
        public void CognitiveApiTest()
        {
            CognitiveApiClient c = CognitiveApiClient.CreateDefault();
            Assert.IsTrue(File.Exists("/Users/TT/Documents/Hacka/loom2.jpg"));
            var bytes = File.ReadAllBytes("/Users/TT/Documents/Hacka/loom2.jpg");
            var memostream = new MemoryStream(bytes);
            memostream.Position = 0;
                var res = c.GetFaceListAsync(memostream);
                res.Wait();
                var face = res.Result.FirstOrDefault();
                Assert.IsTrue( res.IsCompleted);

            Assert.Pass();
        }*/
    }
}