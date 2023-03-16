using System.Text.RegularExpressions;

namespace ChallengeApp
{
    public class Supervisior : IEmployee
    {
        private List<float> grades = new List<float>();

        public Supervisior()
            : this("Not Stated", "Not Stated")
        {
        }

        public Supervisior(string name, string surname)
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
                throw new Exception("Grade value should be between 0 and 100");
            }

        }

        public void AddGrade(string grade)
        {
            string pattern1 = @"^[1-6][\+-]$";
            string pattern2 = @"^[\+-][1-6]$";
            string pattern3 = @"^[1-6]$";
            if (Regex.IsMatch(grade, pattern1) || Regex.IsMatch(grade, pattern2) || Regex.IsMatch(grade, pattern3))
            {
                float modificator = 0;
                if (grade.StartsWith("-") || grade.EndsWith("-"))
                {
                    modificator = -5;
                }
                else if (grade.StartsWith("+") || grade.EndsWith("+"))
                {
                    modificator = 5;
                }

                char[] charsToTrim = { '-', '+' };
                string trimmedGrade = grade.Trim(charsToTrim);

                if (trimmedGrade == "6" && modificator < 0)
                {
                    this.grades.Add(95);
                }
                else if (trimmedGrade == "1" && modificator > 0)
                {
                    this.grades.Add(5);
                }
                else
                {
                    switch (trimmedGrade)
                    {
                        case "6":
                            this.grades.Add(100);
                            break;
                        case "5":
                            this.grades.Add(80 + modificator);
                            break;
                        case "4":
                            this.grades.Add(60 + modificator);
                            break;
                        case "3":
                            this.grades.Add(40 + modificator);
                            break;
                        case "2":
                            this.grades.Add(20 + modificator);
                            break;
                        case "1":
                            this.grades.Add(0);
                            break;
                    }
                }
            }
            else
            {
                throw new Exception("Grade value should be between 1-6 and only + and - modificators are allowed!");
            }
        }

        public void AddGrade(char grade)
        {
            string result = Convert.ToString(grade);
            this.AddGrade(result);
        }

        public void AddGrade(int grade)
        {
            this.AddGrade((float)grade);
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
}
