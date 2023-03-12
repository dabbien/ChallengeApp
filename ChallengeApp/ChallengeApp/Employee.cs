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

        public string Name { get; private set; }
        public string Surname { get; private set; }
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
                Console.WriteLine("Grade value should be between 0 and 100");
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
                Console.WriteLine("Given string is not a float");
            }
        }

        public void AddGrade(char grade)
        {
            if (char.IsDigit(grade))
            {
                float result = Convert.ToSingle(grade);
                this.AddGrade(result);
            }
            else
            {
                Console.WriteLine($"Character {grade} is not a digit");
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

                statistics.Average = statistics.Average / this.grades.Count;
            }

            return statistics;
        }
    }
}
