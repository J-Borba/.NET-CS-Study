using Program6.Entities;
using System.Collections;
using System.Linq;

namespace Program6
{
    class Program
    {

        static void Print<T>(string text, IEnumerable<T> col)
        {
            Console.WriteLine(text);

            foreach (T obj in col)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Electronics", Tier = 1 };

            List<Product> products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Computer", Price = 1100.0, Category = c2 },
                new Product() { Id = 2, Name = "Hammer", Price = 90.0, Category = c1 },
                new Product() { Id = 3, Name = "TV", Price = 1700.0, Category = c3 },
                new Product() { Id = 4, Name = "Notebook", Price = 1300.0, Category = c2 },
                new Product() { Id = 5, Name = "Saw", Price = 80.0, Category = c1 },
                new Product() { Id = 6, Name = "Tablet", Price = 700.0, Category = c2 },
                new Product() { Id = 7, Name = "Camera", Price = 700.0, Category = c3 },
                new Product() { Id = 8, Name = "Printer", Price = 350.0, Category = c3 },
                new Product() { Id = 9, Name = "MacBook", Price = 1800.0, Category = c2 },
                new Product() { Id = 10, Name = "Sound Bar", Price = 700.0, Category = c3 },
                new Product() { Id = 11, Name = "Level", Price = 70.0, Category = c1 }
            };

            var query1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900);
            Print("TIER 1 AND PRICE < 900:", query1);

            var query2 = products.Where(p => p.Category.Name.ToUpper() == "TOOLS").Select(p => p.Name);
            Print("NAMES OF PRODUCTS FROM TOOLS:", query2);

            var query3 = products.Where(p => p.Name[0] == 'C').Select(p => new
            {
                p.Name,
                p.Price,
                CategoryName = p.Category.Name
            });
            Print("PRODUCTS STARTING WITH C:", query3);

            var query4 = products.Where(p => p.Category.Tier == 1).OrderByDescending(p => p.Price).ThenBy(p => p.Name);
            Print("PRODUCTS TIER 1 - ORDER BY PRICE THEN NAME:", query4);

            var query5 = query4.Skip(2).Take(4);
            Print("PRODUCTS TIER 1 - ORDER BY PRICE THEN NAME SKIP 2 TAKE 4:", query5);

            var query6 = products.FirstOrDefault();
            Console.WriteLine($"FIRST TEST 1:\n{query6}");

            var query7 = products.Where(p => p.Price > 3000).FirstOrDefault();
            Console.WriteLine($"FIRST OR DEFAULT TEST 1:\n{query7}");

            var query8 = products.Where(p => p.Category.Id == 1).Select(p => p.Price).Aggregate(0.0, (x, y) => x + y);
            Console.WriteLine("Aggregate sum Price: " + query8 + "\n");

            var query9 = products.GroupBy(p => p.Category);
            Console.WriteLine("Group By:");
            foreach (var group in query9)
            {
                Console.WriteLine($"Category: {group.Key.Name}:");
                foreach (var p in group)
                {
                    Console.WriteLine(p);
                }
            }
        }
    }
}  