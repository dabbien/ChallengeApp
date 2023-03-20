namespace ChallengeApp
{
    public class EmployeeInFile : EmployeeBase
    {
        private const string gradesFileName = "grades.txt";

        public override event GradeAddedDelegate GradeAdded;

        public EmployeeInFile(string name, string surname)
            : base(name, surname)
        {
        }

        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                this.SaveGradeToFile(grade, gradesFileName);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Grade value should be between 0 and 100");
            }
        }

        public override void AddGrade(string grade)
        {
            if (float.TryParse(grade, out float result))
            {
                this.AddGrade(result);
            }
            else
            {
                grade = grade.ToUpper();

                switch (grade)
                {
                    case "A":
                        this.SaveGradeToFile(100, gradesFileName);
                        break;
                    case "B":
                        this.SaveGradeToFile(80, gradesFileName);
                        break;
                    case "C":
                        this.SaveGradeToFile(60, gradesFileName);
                        break;
                    case "D":
                        this.SaveGradeToFile(40, gradesFileName);
                        break;
                    case "E":
                        this.SaveGradeToFile(20, gradesFileName);
                        break;
                    default:
                        throw new Exception("Invalid score value, only A-E and numerical values allowed.");
                }
            }
        }

        public override void AddGrade(char grade)
        {
            string result = Convert.ToString(grade);
            this.AddGrade(result);
        }

        public override void AddGrade(int grade)
        {
            float result = Convert.ToSingle(grade);
            this.AddGrade(result);
        }

        public override void AddGrade(double grade)
        {
            float result = Convert.ToSingle(grade);
            this.AddGrade(result);
        }

        public override void AddGrade(long grade)
        {
            float result = Convert.ToSingle(grade);
            this.AddGrade(result);
        }
        public override float Result
        {
            get
            {
                return GetGradesListFromFile(gradesFileName).Sum();
            }
        }

        private void SaveGradeToFile(float data, string fileName)
        {
            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine(data);
            }
        }

        private List<float> GetGradesListFromFile(string fileName)
        {
            List<float> tempGradesList = new List<float>();

            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        if (float.TryParse(line, out float result))
                        {
                            tempGradesList.Add(result);
                        }
                        else
                        {
                            throw new Exception($"Invalid grade value read from file: {fileName}");
                        }

                        line = reader.ReadLine();
                    }
                }
            }
            return tempGradesList;
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            var gradesSnapshot = this.GetGradesListFromFile(gradesFileName);

            if (gradesSnapshot.Count == 0)
            {
                statistics.Average = 0;
                statistics.Max = 0;
                statistics.Min = 0;
            }
            else
            {
                statistics.Average = 0;
                statistics.Max = float.MinValue;
                statistics.Min = float.MaxValue;

                foreach (var grade in gradesSnapshot)
                {
                    statistics.Max = Math.Max(statistics.Max, grade);
                    statistics.Min = Math.Min(statistics.Min, grade);
                    statistics.Average += grade;
                }

                statistics.Average /= gradesSnapshot.Count;
            }

            switch (statistics.Average)
            {
                case var average when average >= 80:
                    statistics.AverageLetter = 'A';
                    break;
                case var average when average >= 60:
                    statistics.AverageLetter = 'B';
                    break;
                case var average when average >= 40:
                    statistics.AverageLetter = 'C';
                    break;
                case var average when average >= 20:
                    statistics.AverageLetter = 'D';
                    break;
                default:
                    statistics.AverageLetter = 'E';
                    break;
            }

            return statistics;
        }
    }
}
