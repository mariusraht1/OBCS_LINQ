using System.Collections.Generic;

namespace OrderManagement.Models
{
    class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public List<Order> OrderList { get; set; } = new List<Order> { };

        public Customer(string firstName, string lastName, string city, string street, string houseNumber, string postalCode)
        {
            FirstName = firstName;
            LastName = lastName;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            PostalCode = postalCode;
        }

        public void AddOrder(Order order)
        {
            OrderList.Add(order);
        }
    }
}
