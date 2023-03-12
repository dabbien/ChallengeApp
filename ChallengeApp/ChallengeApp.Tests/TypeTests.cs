/*
namespace ChallengeApp.Tests
{

    public class TypeTests
    {
        [Test]
        public void UserLoginValueTypeIsString()
        {
            // arrange
            var user = GetUser("Bartek", "qwerty");

            // assert
            Assert.IsTrue(user.Login is string);
        }

        [Test]
        public void UserAgeValueTypeIsInt()
        {
            // arrange
            var user = GetUser("Bartek", "qwerty", 1);

            // assert
            Assert.IsTrue(user.Age is int);
        }

        [Test]
        public void UserFloValueTypeIsFloat()
        {
            // arrange
            var user = GetUser("Bartek", "qwerty", null, 0.1f);

            // assert
            Assert.IsTrue(user.Flo is float);
        }

        [Test]
        public void GetUserReturnsDifferentReferencesForNewObjects()
        {
            // arrange
            var user1 = GetUser("Bartek", "qwerty");
            var user2 = GetUser("Bartek", "qwerty");

            // assert
            Assert.AreNotEqual(user1, user2);
        }

        [Test]
        public void UsersAssignedWithinSameObjectRef_ShareReferedPropsAndVals()
        {
            // arrange
            var user1 = GetUser("Bartek", "qwerty");
            var user2 = user1;

            // act
            user1.Editable = "would it work?";
            user2.Editable = "yay, it works!";
            var result = user1.Editable;

            // assert
            Assert.AreEqual(result, "yay, it works!");
        }

        private User GetUser(string login, string password, int? intValue = null, float? floatValue = null, string? editable = null)
        {
            return new User(login, password, intValue, floatValue, editable);
        }
    }
}
*/
