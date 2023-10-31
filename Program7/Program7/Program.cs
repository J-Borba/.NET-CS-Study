using Program7.Entities;
using System.Globalization;
using System.Linq;

namespace Program7
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "c:/Users/jborba/source/repos/.NET-CS-Study/Program7/Program7/FileFolder/data.txt";

            List<Product> list = new List<Product>();

            using(StreamReader sr = File.OpenText(filePath))
            {
                while(!sr.EndOfStream)
                {
                    string[] dataVet = sr.ReadLine().Split(',');

                    string name = dataVet[0];
                    double price = double.Parse(dataVet[1], CultureInfo.InvariantCulture);

                    list.Add(new Product(name, price));
                }
            }

            var averagePrice = list.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            var productsUnderAverage = list.Where(p => p.Price < averagePrice).OrderByDescending(p => p.Name).Select(p => p.Name);

            Console.WriteLine($"Average Price: {averagePrice:F2}\n");
            foreach (var obj in productsUnderAverage)
            {
                Console.WriteLine(obj);
            }
        }
    }
}