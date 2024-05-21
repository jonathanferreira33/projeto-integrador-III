namespace Auth.Security
{
    public class TokenConfig
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
        public int Minutes { get; set; }
        public int Hours { get; set; }

        public TokenConfig(int minutes, int seconds, int hours)
        {
            this.Minutes = minutes;
            this.Seconds = seconds;
            this.Hours = hours;
        }
    }
}
