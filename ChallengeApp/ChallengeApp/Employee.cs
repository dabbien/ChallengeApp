namespace ChallengeApp
{
    public class Employee
    {
        private List<float> grades = new List<float>();
        public Employee(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public Employee()
        {
            this.Name = null;
            this.Surname = null;
        }

        public string? Name { get; private set; }
        public string? Surname { get; private set; }
        public float Result
        {
            get
            {
                return this.grades.Sum();
            }
        }

        public void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                this.grades.Add(grade);
            }
            else
            {
                throw new Exception("Grade value should be between 0 and 100");
            }
        }

        public void AddGrade(string grade)
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
                        this.grades.Add(100);
                        break;
                    case "B":
                        this.grades.Add(80);
                        break;
                    case "C":
                        this.grades.Add(60);
                        break;
                    case "D":
                        this.grades.Add(40);
                        break;
                    case "E":
                        this.grades.Add(20);
                        break;
                    default:
                        throw new Exception("Invalid score value, only A-E and numerical values allowed.");
                }
            }
        }

        public void AddGrade(char grade)
        {
            grade = char.ToUpper(grade);

            switch (grade)
            {
                case 'A':
                    this.grades.Add(100);
                    break;
                case 'B':
                    this.grades.Add(80);
                    break;
                case 'C':
                    this.grades.Add(60);
                    break;
                case 'D':
                    this.grades.Add(40);
                    break;
                case 'E':
                    this.grades.Add(20);
                    break;
                default:
                    throw new Exception("Invalid score value, only A-E and numerical values allowed.");
            }
        }

        public void AddGrade(int grade)
        {
            float result = Convert.ToSingle(grade);
            this.AddGrade(result);
        }

        public void AddGrade(double grade)
        {
            float result = Convert.ToSingle(grade);
            this.AddGrade(result);
        }

        public void AddGrade(long grade)
        {
            float result = Convert.ToSingle(grade);
            this.AddGrade(result);
        }

        public Statistics GetStatistics()
        {
            var statistics = new Statistics();

            if (this.grades.Count == 0)
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

                foreach (var grade in this.grades)
                {
                    statistics.Max = Math.Max(statistics.Max, grade);
                    statistics.Min = Math.Min(statistics.Min, grade);
                    statistics.Average += grade;
                }

                statistics.Average /= this.grades.Count;
            }

            switch(statistics.Average)
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
