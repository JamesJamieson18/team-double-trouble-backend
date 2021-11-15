using System.ComponentModel.DataAnnotations;
using System;

namespace team_double_trouble_backend.Models
{
    public class MakePostRequest //Defines the parameters for incoming POST requests to the /api/Post route
    {
    [Required]
    public long UserId { get; set; }
    public string Username { get; set; }
    [Required]
    public string Text { get; set; }
    }
}