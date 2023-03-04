namespace ChallengeApp
{
    public class User
    {
        private List<int> points = new List<int>();
        public User(string login, string password)
        {
            this.Login = login;
            this.Password = password;
            this.points.Add(0);
        }

        public string Login { get; private set; }
        public string Password { get; private set; }
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