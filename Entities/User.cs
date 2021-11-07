using System.Text.Json.Serialization;

namespace team_double_trouble_backend.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        [JsonIgnore] //prevents properties from being serialized and returned in api responses.
        public string PasswordHash { get; set; }
    }
}