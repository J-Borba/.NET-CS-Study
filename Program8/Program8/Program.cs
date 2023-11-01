using Program8.Entities;
using System.Globalization;

namespace Program8
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\jvfbo\\Github\\.NET-CS-Study\\Program8\\Program8\\FileFolder\\in.txt";
            double salary;

            Console.Write("Enter Salary:");
            salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            List<Employee> list = new List<Employee>();

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');

                        string _name = line[0];
                        string _email = line[1];
                        double _salary = double.Parse(line[2], CultureInfo.InvariantCulture);

                        list.Add(new Employee(_name, _email, _salary));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var query1 = list.Where(e => e.Salary > salary).OrderBy(e => e.Name).Select(e => e.Email);
            Console.WriteLine($"Email of people whose salary is more than {salary:F2}:");
            foreach (string email in query1)
            {
                Console.WriteLine(email);
            }

            var query2 = list.Where(e => e.Name.ToUpper()[0] == 'A').Select(e => e.Salary).DefaultIfEmpty(0.0).Aggregate((x, y) => x + y);
            Console.Write($"Sum of salary of people whose name starts with 'A': {query2}");
        }
    }
}