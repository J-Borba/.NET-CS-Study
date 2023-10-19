namespace Program2.Entities.Order
{
    class OrderItem
    {
        public int Quantity { get; private set; }
        public double Price { get; private set; }
        public Product Product { get; private set; }

        public OrderItem(int quantity, Product product)
        {
            Quantity = quantity;
            Price = product.Price;
            Product = product;
        }

        public double SubTotal()
        {
            return Price * Quantity;
        }
    }
}
