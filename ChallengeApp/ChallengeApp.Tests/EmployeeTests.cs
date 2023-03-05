namespace ChallengeApp.Tests
{
    public class EmployeeTests
    {
        [Test]
        public void WhenNonTypicalOrNoGenderSet_ShouldNotReturnTitle()
        {
            // arrange
            var rysiek1 = new Employee("Ryszard", "Emplojewski", 22, "ROBOCOP");
            var rysiek2 = new Employee("Ryszard", "Emplojewski", 22);

            // act
            var result1 = rysiek1.Title;
            var result2 = rysiek2.Title;

            // assert
            Assert.AreEqual(null, result1);
            Assert.AreEqual(null, result2);
        }

        [Test]
        public void WhenTypicalGenderSet_ShouldReturnAproporiateTitle()
        {
            // arrange
            var rysiek1 = new Employee("Ryszarda", "Emplojewska", 22, "F");
            var rysiek2 = new Employee("Ryszarda", "Emplojewska", 22, "f");
            var rysiek3 = new Employee("Ryszarda", "Emplojewska", 22, "Female");
            var rysiek4 = new Employee("Ryszarda", "Emplojewska", 22, "female");
            var rysiek5 = new Employee("Ryszard", "Emplojewski", 22, "M");
            var rysiek6 = new Employee("Ryszard", "Emplojewski", 22, "m");
            var rysiek7 = new Employee("Ryszard", "Emplojewski", 22, "Male");
            var rysiek8 = new Employee("Ryszard", "Emplojewski", 22, "male");

            // act
            var result1 = rysiek1.Title;
            var result2 = rysiek2.Title;
            var result3 = rysiek3.Title;
            var result4 = rysiek4.Title;
            var result5 = rysiek5.Title;
            var result6 = rysiek6.Title;
            var result7 = rysiek7.Title;
            var result8 = rysiek8.Title;

            // assert
            Assert.AreEqual("Mrs. ", result1);
            Assert.AreEqual("Mrs. ", result2);
            Assert.AreEqual("Mrs. ", result3);
            Assert.AreEqual("Mrs. ", result4);
            Assert.AreEqual("Mr. ", result5);
            Assert.AreEqual("Mr. ", result6);
            Assert.AreEqual("Mr. ", result7);
            Assert.AreEqual("Mr. ", result8);
        }

        [Test]
        public void WhenEmployeeCollectsReward_ShouldReturnTotalScore()
        {
            // arrange
            var rysiek = new Employee("Ryszard", "Emplojewski", 22, "M");
            rysiek.Reward(5);
            rysiek.Reward(6);
            rysiek.Reward(-7);

            // act
            var result = rysiek.TotalScore;

            // assert
            Assert.AreEqual(4, result);
        }

        [Test]
        public void WhenEmployeeCollectsPenalty_ShouldSubtractItFromTotalScore()
        {
            // arrange
            var rysiek = new Employee("Ryszard", "Emplojewski", 22, "M");
            rysiek.Reward(5);
            rysiek.Penalize(6);
            rysiek.Penalize(-6);

            // act
            var result = rysiek.TotalScore;

            // assert
            Assert.AreEqual(-7, result);
        }
    }
}
