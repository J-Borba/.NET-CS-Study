using Program1.Entities;

namespace Program1
{
    class Program
    {
        public static void Main(string[] args)
        {
            string title = "Traveling to New Zealand";
            string content = "I'm going to visit this wonderful country";
            int likes = 12;

            Post post1 = new Post(title, content, likes);
            post1.AddComment("Have a nice trip");
            post1.AddComment("Wow that's awesome");

            Console.WriteLine(post1);
        }
    }
}