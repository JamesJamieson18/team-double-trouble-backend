using System.ComponentModel.DataAnnotations; //.NET Data Annotations are used to automatically handle model validation, the [Required] attribute sets both the username and password as required fields so if either are missing a validation error message is returned from the api.

namespace team_double_trouble_backend.Models
{
    public class AuthenticateRequest //The AuthenticateRequest model defines the parameters for incoming POST requests to the /users/authenticate route
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}