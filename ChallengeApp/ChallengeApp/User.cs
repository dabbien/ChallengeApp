namespace ChallengeApp
{
    public class User
    {
        private List<int> points = new List<int>();
        public User(string login, string password, int? age, float? floatValue, string? editable)
        {
            this.Login = login;
            this.Password = password;
            this.Age = age;
            this.Flo = floatValue;
            this.Editable = editable;

        }
        public User(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }
        public int? Age { get; private set; }
        public float? Flo { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string? Editable { get; set; }

        public int Result
        {
            get
            {
                return this.points.Sum();
            }
        }
        public void AddScore(int score)
        {
            this.points.Add(score);
        }
    }
}