namespace team_double_trouble_backend.Models
{
    public class UpdateRequest //The update request model defines the parameters for incoming PUT requests to the /users/{id} route.
    {
        public string Username { get; set; } //Unlike RegRequest this model does not have required fields so the user can update both or only one field.
        public string Password { get; set; }
    }
}