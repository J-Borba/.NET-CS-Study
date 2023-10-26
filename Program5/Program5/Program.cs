namespace Program5
{
    class Program
    {
        public static void Main(string[] args)
        {
            int nA = 0;
            int nB = 0;
            int nC = 0;
            HashSet<int> studentsA = new HashSet<int>();
            HashSet<int> studentsB = new HashSet<int>();
            HashSet<int> studentsC = new HashSet<int>();

            Console.Write("How many students for course A? ");
            nA = int.Parse(Console.ReadLine());
            for (int i = 0; i < nA; i++)
            {
                int _sA = int.Parse(Console.ReadLine());
                studentsA.Add(_sA);
            }

            Console.Write("How many students for course B? ");
            nB = int.Parse(Console.ReadLine());
            for (int i = 0; i < nB; i++)
            {
                int _sB = int.Parse(Console.ReadLine());
                studentsB.Add(_sB);
            }

            Console.Write("How many students for course C? ");
            nC = int.Parse(Console.ReadLine());
            for (int i = 0; i < nC; i++)
            {
                int _sC = int.Parse(Console.ReadLine());
                studentsC.Add(_sC);
            }

            HashSet<int> students = new HashSet<int>();
            students.UnionWith(studentsA);
            students.UnionWith(studentsB);
            students.UnionWith(studentsC);
            Console.WriteLine($"Total students: {students.Count}");
        }
    }
}