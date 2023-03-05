namespace ChallengeApp
{
    public class Employee
    {
        List<int> points = new List<int>();

        public Employee(string name, string surname, int age, string sex)
        {
            this.Name = name;
            this.Surname = surname;
            this.Sex = sex;
            this.Age = age;

            if (this.Sex == "F" || this.Sex == "f" || this.Sex == "female" || this.Sex == "Female")
            {
                this.Title = "Mrs.";
            }
            else
            {
                this.Title = "Mr.";
            }
        }

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public int Age { get; private set; }
        public string Sex { get; private set; }
        public string Title { get; private set; }

        public int TotalScore
        {
            get
            {
                return this.points.Sum();
            }
        }

        public void Reward(int number)
        {
            this.points.Add(number);
        }
    }
}
