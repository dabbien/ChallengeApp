using System.Reflection.Metadata;

namespace ChallengeApp.Tests
{
    public class UserTests
    {
        [Test]
        public void WhenUserCollectTwoScores_ShouldReturnResult()
        {
            // arrange
            var user = new User("makak", "1234");
            user.AddScore(5);
            user.AddScore(6);

            // act
            var result = user.Result;

            // assert
            Assert.AreEqual(11, result);
        }
    }
}