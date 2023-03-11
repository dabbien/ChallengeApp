namespace ChallengeApp.Tests
{
    public class EmployeeTests
    {
        [Test]
        public void GetEmployeeReturnsDifferentReferencesForNewObjects()
        {
            // arrange
            var employee1 = GetEmployee("John", "Smith");
            var employee2 = GetEmployee("John", "Smith");

            // assert
            Assert.AreNotEqual(employee1, employee2);
        }

        [Test]
        public void EmployeeResult_ShouldReturnGradesSum()
        {
            // arrange
            var employee = GetEmployee("John", "Smith");
            employee.AddGrade(5.3f);
            employee.AddGrade(6.2f);

            // act
            var result = employee.Result;

            // assert
            Assert.AreEqual(11.5, result);
        }

        [Test]
        public void EmployeeResultWithoutGrades_ShouldReturn0()
        {
            // arrange
            var employee = GetEmployee("John", "Smith");

            // act
            var result = employee.Result;

            // assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void WhenEmployeeReceivesPenalty_ShouldStoreItAsNegativeNumber()
        {
            // arrange
            var employee = GetEmployee("John", "Smith");
            employee.AddPenalty(5);
            employee.AddPenalty(-6);

            // act
            var result = employee.Result;

            // assert
            Assert.AreEqual(-11, result);
        }

        [Test]
        public void StatisticsForEmployeeWithoutGrades_ShouldReturn0()
        {
            // arrange
            var employee = GetEmployee("John", "Smith");

            // act
            var max = employee.GetStatistics().Max;
            var min = employee.GetStatistics().Min;
            var average = employee.GetStatistics().Average;

            // assert
            Assert.AreEqual(0, max);
            Assert.AreEqual(0, min);
            Assert.AreEqual(0, average);
        }

        [Test]
        public void GetStatisticsMin_ShouldReturnMinGrade()
        {
            // arrange
            var employee = GetEmployee("John", "Smith");
            employee.AddPenalty(6);
            employee.AddGrade(5);

            // act
            var result = employee.GetStatistics().Min;

            // assert
            Assert.AreEqual(-6, result);
        }

        [Test]
        public void GetStatisticsMax_ShouldReturnMaxGrade()
        {
            // arrange
            var employee = GetEmployee("John", "Smith");
            employee.AddPenalty(5);
            employee.AddGrade(6);

            // act
            var result = employee.GetStatistics().Max;

            // assert
            Assert.AreEqual(6, result);
        }

        [Test]
        public void GetStatisticsAverage_ShouldReturnAverageGrade()
        {
            // arrange
            var employee = GetEmployee("John", "Smith");
            employee.AddPenalty(5);
            employee.AddPenalty(-5);
            employee.AddGrade(2);
            employee.AddGrade(6);

            // act
            var result = employee.GetStatistics().Average;

            // assert
            Assert.AreEqual(-0.5, result);
        }

        private Employee GetEmployee(string name, string surname)
        {
            return new Employee(name, surname);
        }
    }
}
