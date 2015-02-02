using Aptitud.SwetuggMob.Web.Services;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class FetchTweetsTests
    {
        [Test]
        public void FetchTweetsTest()
        {
            var finder = new TweetFinder();
            var tweets = finder.GetTweetsForHashTag("#Swetugg");
            Assert.That(tweets, Is.Not.Null);
            Assert.That(tweets, Is.Not.Empty);
        }
    }
}
