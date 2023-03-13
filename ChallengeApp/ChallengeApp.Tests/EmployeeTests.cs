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
        public void AddGradeAcceptsFloatValuesFrom_0To100()
        {
            // arrange
            var employee = GetEmployee("John", "Smith");
            try
            {
                employee.AddGrade(100);
                employee.AddGrade(10);
                employee.AddGrade(150);
                employee.AddGrade(-20);
            }
            catch (Exception)
            {

            }

            // act
            var result = employee.Result;

            // asserrt
            Assert.AreEqual(110, result);
        }

        [Test]
        public void AddGradePassedNumbersInStrings_ShouldProperlyParse()
        {
            // arrange
            var employee = GetEmployee("John", "Smith");
            employee.AddGrade("1");
            employee.AddGrade("1,4");

            // act
            var result = employee.Result;

            // asserrt
            Assert.AreEqual(2.40, Math.Round(result,2));
        }

        [Test]
        public void AddGradePassedStringsAndChars_ShouldBeCaseInsensitive()
        {
            // arrange
            var employee = GetEmployee("John", "Smith");
            employee.AddGrade("A");
            employee.AddGrade("a");
            employee.AddGrade('A');
            employee.AddGrade('a');

            // act
            var result = employee.Result;

            // asserrt
            Assert.AreEqual(400, result);
        }

        [Test]
        public void AddGradePassedStringsOrChars_A_to_E_ShouldAssignNumericalValue()
        {
            // arrange
            var employee = GetEmployee("John", "Smith");
            try
            {
                employee.AddGrade("A");
                employee.AddGrade("B");
                employee.AddGrade("C");
                employee.AddGrade("D");
                employee.AddGrade("E");
                employee.AddGrade('a');
                employee.AddGrade('b');
                employee.AddGrade('c');
                employee.AddGrade('d');
                employee.AddGrade('e');
                employee.AddGrade('f');
            }
            catch (Exception)
            {

            }

            // act
            var result = employee.Result;

            // asserrt
            Assert.AreEqual(600, result);
        }

        [Test]
        public void Result_ShouldReturnGradesSum()
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
        public void ResultWithoutGrades_ShouldReturn0()
        {
            // arrange
            var employee = GetEmployee("John", "Smith");

            // act
            var result = employee.Result;

            // assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void GetStatisticsWithoutGrades_ShouldReturn0()
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
            employee.AddGrade(6);
            employee.AddGrade(5);

            // act
            var result = employee.GetStatistics().Min;

            // assert
            Assert.AreEqual(5, result);
        }

        [Test]
        public void GetStatisticsMax_ShouldReturnMaxGrade()
        {
            // arrange
            var employee = GetEmployee("John", "Smith");
            employee.AddGrade(5);
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
            employee.AddGrade(5);
            employee.AddGrade(5);
            employee.AddGrade(4);
            employee.AddGrade(6);

            // act
            var result = employee.GetStatistics().Average;

            // assert
            Assert.AreEqual(5, result);
        }
        [Test]
        public void GetStatisticsAverageLetter_ShouldReturnProperLetterForGivenResult()
        {
            // arrange
            var employee1 = GetEmployee("John", "Smith");
            var employee2 = GetEmployee("John", "Smith");
            var employee3 = GetEmployee("John", "Smith");
            var employee4 = GetEmployee("John", "Smith");
            var employee5 = GetEmployee("John", "Smith");
            employee1.AddGrade(100);
            employee2.AddGrade(79);
            employee3.AddGrade(59);
            employee4.AddGrade(39);
            employee5.AddGrade(19);

            //act
            var result1 = employee1.GetStatistics().AverageLetter;
            var result2 = employee2.GetStatistics().AverageLetter;
            var result3 = employee3.GetStatistics().AverageLetter;
            var result4 = employee4.GetStatistics().AverageLetter;
            var result5 = employee5.GetStatistics().AverageLetter;

            // assert
            Assert.AreEqual('A', result1);
            Assert.AreEqual('B', result2);
            Assert.AreEqual('C', result3);
            Assert.AreEqual('D', result4);
            Assert.AreEqual('E', result5);

        }

        private Employee GetEmployee(string name, string surname)
        {
            return new Employee(name, surname);
        }
    }
}
