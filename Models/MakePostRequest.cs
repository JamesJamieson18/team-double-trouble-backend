using System.ComponentModel.DataAnnotations;

namespace team_double_trouble_backend.Models
{
    public class MakePostRequest //The register request model defines the parameters for incoming POST requests to the /users/register route
    {
    [Required]
    public long UserId { get; set; }
    public string Username { get; set; }
    [Required]
    public string Text { get; set; }
    public string Date { get; set; }
    }
}