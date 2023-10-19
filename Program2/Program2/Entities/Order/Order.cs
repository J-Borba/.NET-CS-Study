using Program2.Entities.Order.Enums;
using System.Text;

namespace Program2.Entities.Order
{
    class Order
    {
        public Client Client { get; private set; }
        public DateTime Moment { get; private set; }
        public OrderStatus Status { get; private set; }
        public List<OrderItem> OrderItems { get; private set; } = new();

        public Order(Client client, OrderStatus status)
        {
            Client = client;
            Moment = DateTime.Now;
            Status = status;
        }

        public void AddItem(OrderItem item)
        {
            OrderItems.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            OrderItems.Remove(item);
        }
        public double Total()
        {
            double total = 0;
            foreach (OrderItem item in OrderItems)
            {
                total += item.SubTotal();
            }
            return total;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order Summary:");
            sb.AppendLine($"Order moment: {Moment.ToString("dd/MM/yyyy HH:mm:ss")}");
            sb.AppendLine($"Order status: {Status}");
            sb.AppendLine($"Client: {Client}");
            sb.AppendLine("Order items:");
            foreach (OrderItem item in OrderItems)
            {
                sb.AppendLine($"{item.Product.Name}, R${item.Price}, Quantity: {item.Quantity}, Subtotal: R${item.SubTotal()}");
            }
            sb.AppendLine($"Total price: R${Total()}");
            return sb.ToString();
        }
    }
}
