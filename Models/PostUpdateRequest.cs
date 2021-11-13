namespace team_double_trouble_backend.Models
{
    public class PostUpdateRequest //The update request model defines the parameters for incoming PUT requests to the /users/{id} route.
    {
        public string Text { get; set; }
    }
}