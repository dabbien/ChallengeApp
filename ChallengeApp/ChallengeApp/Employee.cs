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
            this.grades.Add(grade);
        }

        public void AddPenalty(float penalty)
        {
            if (penalty > 0)
            {
                this.grades.Add(-penalty);
            }
            else
            {
                this.grades.Add(penalty);
            }
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
