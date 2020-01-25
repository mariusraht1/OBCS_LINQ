namespace OrderManagement.Models
{
    class Order
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double TotalValue => Quantity * Product.Price;
        public double TotalWeight => Quantity * Product.Weight;

        public Order(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
