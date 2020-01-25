namespace OrderManagement.Models
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }

        public Product(string name, double price, double weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Preis: {Price}, Gewicht: {Weight}";
        }
    }
}
