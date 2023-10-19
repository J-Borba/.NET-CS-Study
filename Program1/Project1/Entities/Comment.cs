namespace Program1.Entities
{
    class Comment
    {
        public string Text { get; private set; }

        public Comment() { }

        public Comment(string text)
        {
            Text = text;
        }
    }
}
