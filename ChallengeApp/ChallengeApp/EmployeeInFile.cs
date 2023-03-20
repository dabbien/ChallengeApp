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
                        this.AddGrade(100);
                        break;
                    case "B":
                        this.AddGrade(80);
                        break;
                    case "C":
                        this.AddGrade(60);
                        break;
                    case "D":
                        this.AddGrade(40);
                        break;
                    case "E":
                        this.AddGrade(20);
                        break;
                    case "F":
                        this.AddGrade(0);
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

        private void SaveGradeToFile(float data, string fileName)
        {
            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine(data);
            }
        }

        private List<float> GetGradesListFromFile(string fileName)
        {
            var tempGradesList = new List<float>();

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
            foreach (var grade in GetGradesListFromFile(gradesFileName))
            {
                statistics.AddGrade(grade);
            }
            return statistics;
        }
    }
}