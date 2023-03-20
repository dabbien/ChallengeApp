using System.Text.RegularExpressions;

namespace ChallengeApp
{
    public class Supervisior : EmployeeBase
    {
        private List<float> grades = new List<float>();
        public override event GradeAddedDelegate GradeAdded;

        public Supervisior(string name, string surname)
            : base(name, surname)
        {
        }

        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                this.grades.Add(grade);
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
            if (float.TryParse(grade, out float result) && result > 6)
            {
                this.AddGrade(result);
            }
            else
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

                    switch (trimmedGrade)
                    {
                        case "6" when modificator < 0:
                            this.AddGrade(95);
                            break;
                        case "6":
                            this.AddGrade(100);
                            break;
                        case "5":
                            this.AddGrade(80 + modificator);
                            break;
                        case "4":
                            this.AddGrade(60 + modificator);
                            break;
                        case "3":
                            this.AddGrade(40 + modificator);
                            break;
                        case "2":
                            this.AddGrade(20 + modificator);
                            break;
                        case "1" when modificator > 0:
                            this.AddGrade(5);
                            break;
                        case "1":
                            this.AddGrade(0);
                            break;
                    }
                }
                else
                {
                    throw new Exception("Grade value should be between 1-6 and only + and - modificators are allowed!");
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
            this.AddGrade((float)grade);
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

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            foreach (var grade in grades)
            {
                statistics.AddGrade(grade);
            }
            return statistics;
        }
    }
}