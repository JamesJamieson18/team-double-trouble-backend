using System.ComponentModel.DataAnnotations;

namespace team_double_trouble_backend.Models
{
    public class RegisterRequest //The register request model defines the parameters for incoming POST requests to the /users/register route
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}