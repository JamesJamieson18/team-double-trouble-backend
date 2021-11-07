namespace team_double_trouble_backend.Models
{
    public class AuthenticateResponse //The AuthenticateResponse model defines the data returned by the Authenticate method
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string JwtToken { get; set; }
    }
}