using System;
public class Post
{
    //DateTime UTCDate = DateTime.UtcNow;
    public int PostId { get; set; }
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; }
}