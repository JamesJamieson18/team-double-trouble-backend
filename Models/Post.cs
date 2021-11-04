public class Post
{
    public long PostId { get; set; }
    public string Username { get; set; }
    public string Text { get; set; }
    public string Date { get; set; }

    //Foreign key connection to User
    public long UserId { get; set; }
    public User User { get; set; }
}