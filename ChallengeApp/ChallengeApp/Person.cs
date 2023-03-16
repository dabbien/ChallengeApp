namespace ChallengeApp
{
    public abstract class Person
    {
        public Person(string name)
            : this(name, "Not Stated", "Not Stated")
        {
        }

        public Person(string name, string surname)
            : this(name, surname, "Not Stated")
        {
        }

        public Person(string name, string surname, string sex)
        {
            this.Name = name;
            this.Surname = surname;
            this.Sex = sex;
        }

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Sex { get; private set; }
    }
}
