namespace ChallengeApp.Tests
{
    public class SupervisiorTests
    {
        [Test]
        public void WhenAddGradeProcessesStringWithinRange_ShouldAssignCorrectValue()
        {
            // arrange
            var supervisior = new Supervisior();

            supervisior.AddGrade("6");
            supervisior.AddGrade("5");
            supervisior.AddGrade("4");
            supervisior.AddGrade("3");
            supervisior.AddGrade("2");
            supervisior.AddGrade("1");

            // act
            var result = supervisior.Result;

            // assert
            Assert.AreEqual(300, result);
        }

        [Test]
        public void WhenAddGradeProcessesStringWithModificator_ShouldAssignCorrectValue()
        {
            // arrange
            var supervisior = new Supervisior();

            supervisior.AddGrade("-6");
            supervisior.AddGrade("6+");
            supervisior.AddGrade("6-");
            supervisior.AddGrade("1+");
            supervisior.AddGrade("-1");


            // act
            var result = supervisior.Result;

            // assert
            Assert.AreEqual(295, result);
        }

        [Test]
        public void WhenAddGradeProcessesStringOutsideRange_ShouldThrowException()
        {
            // arrange
            var supervisior = new Supervisior();

            var exception = Assert.Throws<Exception>(() =>
            {
                supervisior.AddGrade("-7");
            });

            // assert
            StringAssert.Contains("Grade value should be between 1-6 and only + and - modificators are allowed!", exception.Message.ToString());
        }
    }
}
