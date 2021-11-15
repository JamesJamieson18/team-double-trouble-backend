namespace team_double_trouble_backend.Models
{
    public class PostUpdateRequest //model defines the parameters for incoming PUT requests to the /api/Post/{id} route.
    {
        public string Text { get; set; }
    }
}