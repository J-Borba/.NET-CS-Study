using System.Text;

namespace Program1.Entities
{
    class Post
    {
        public DateTime Moment { get; private set; }
        public string? Title { get; private set; }
        public string? Content { get; private set; }
        public int Likes { get; private set; }
        public List<Comment> Comments { get; private set; } = new List<Comment>();

        public Post(string title, string content, int likes)
        {
            Moment = DateTime.Now;
            Title = title;
            Content = content;
            Likes = likes;
        }
        public void AddComment(string commentContent)
        {
            Comments.Add(new Comment(commentContent));
        }
        public void RemoveComment(Comment comment)
        {
            Comments.Remove(comment);
        }
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine(Title);
            sb.AppendLine($"{Likes} Likes - {Moment.ToString("dd/MM/yyyy HH:mm:ss")}");
            sb.AppendLine(Content);
            sb.AppendLine("Comments:");
            foreach (Comment comment in Comments)
            {
                sb.AppendLine(comment.Text);
            }
            return sb.ToString();
        }
    }
}
