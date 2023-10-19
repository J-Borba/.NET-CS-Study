using Program2.Entities;
using Program2.Entities.Order;
using Program2.Entities.Order.Enums;

namespace Program2
{
    class Program
    {
        public static void Main(string[] args)
        {
            string clientName;
            string clientEmail;
            DateTime clientBirthDate;
            Client client;
            OrderStatus status;
            int itemsQuantity;
            List<OrderItem> items;
            Order order;

            Console.WriteLine("Enter client data: ");

            Console.Write("Name: ");
            clientName = Console.ReadLine();

            Console.Write("Email: ");
            clientEmail = Console.ReadLine();

            Console.Write("Birth Date (DD/MM/YYYY): ");
            clientBirthDate = DateTime.Parse(Console.ReadLine());

            client = new Client(clientName, clientEmail, clientBirthDate);

            Console.WriteLine("Enter order data:");

            Console.Write("Status: ");
            status = Enum.Parse<OrderStatus>(Console.ReadLine());

            order = new Order(client, status);

            Console.Write("How many items to this order? ");
            itemsQuantity = int.Parse(Console.ReadLine());

            for (int i = 0; i < itemsQuantity; i++)
            {
                string productName;
                double productPrice;
                Product product;
                int productQuantity;
                OrderItem orderItem;

                Console.WriteLine($"Enter #{i + 1} item data:");

                Console.Write("Product name: ");
                productName = Console.ReadLine();

                Console.Write("Product price: ");
                productPrice = double.Parse(Console.ReadLine());

                product = new Product(productName, productPrice);

                Console.Write("Quantity: ");
                productQuantity = int.Parse(Console.ReadLine());

                orderItem = new OrderItem(productQuantity, product);

                order.AddItem(orderItem);
            }
            Console.WriteLine();
            Console.WriteLine(order);
        }
    }
}