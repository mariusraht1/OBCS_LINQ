using OrderManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            //Beispieldaten erzeugen
            List<Product> products = new List<Product>
            {
                new Product("Milch",0.79,1),
                new Product("Müsli",2.99,0.5),
                new Product("Pizza",1.99,0.8),
                new Product("Wein",4.99,1.2),
                new Product("Schokolade",1.19,0.1),
                new Product("Wasserkiste",3.99,10)
            };

            List<Customer> customers = new List<Customer>
            {
                new Customer("Max","Mustermann","Essen","Essener Str.","12","45127"),
                new Customer("John","Doe","Berlin","Berliner Str.","23","0115"),
                new Customer("Marita","Müller","Essen","Essener Str.","12","45127"),
                new Customer("Jane","Schuster","Hambug","Hamburger Str.","99","12345")
            };

            List<Order> orders = new List<Order>
            {
                new Order(products[0],1),
                new Order(products[0],2),
                new Order(products[1],1),
                new Order(products[2],4),
                new Order(products[2],1),
                new Order(products[3],3),
                new Order(products[4],1),
                new Order(products[5],2),
                new Order(products[5],4),
                new Order(products[5],1),
                new Order(products[5],20)
            };

            customers[0].AddOrder(orders[0]);
            customers[1].AddOrder(orders[1]);
            customers[0].AddOrder(orders[2]);
            customers[2].AddOrder(orders[3]);
            customers[0].AddOrder(orders[4]);
            customers[2].AddOrder(orders[5]);
            customers[1].AddOrder(orders[6]);
            customers[0].AddOrder(orders[7]);
            customers[1].AddOrder(orders[8]);
            customers[2].AddOrder(orders[9]);
            customers[0].AddOrder(orders[10]);

            //LINQ Queries

            //Im Rahmen der Erstellung der LINQ to Entities Queries kann auf die 
            //drei Datenquellen "products", "customers" und "orders" zugegriffen werden,
            //die mit Beispieldaten gefüllt sind

            #region Query 1
            //Query1 liefert alle Produktnamen in der Datenbank in aufsteigender Reihenfolge
            //Als Beispiel bereits implementiert
            var result1 = products.OrderBy(p => p.Name).Select(p => p.Name).ToList();

            Console.WriteLine("###### Query 1 ######");
            result1.ForEach(p => Console.Write(p.ToString() + " "));
            Console.WriteLine("\n\n");
            #endregion Query 1

            #region Query 2
            //Query2 liefert alle Nachnamen der Kunden, die eine Bestellung getätigt haben
            //TODO
            var result2 = customers.Where(x => x.OrderList.Count > 0).ToList();

            Console.WriteLine("###### Query 2 ######");
            result2.ForEach(x => Console.Write(x.LastName + " "));
            Console.WriteLine("\n\n");
            #endregion Query 2

            #region Query 3
            //Query3 liefert alle bestellten Produkten und die jeweilige Anzahl
            //TODO
            var result3 = orders.GroupBy(x => x.Product).Select(x => new Order(x.First().Product, x.Sum(y => y.Quantity))).ToList();

            Console.WriteLine("###### Query 3 ######");
            result3.ForEach(x => Console.WriteLine($"{x.Quantity} {x.Product.ToString()} "));
            Console.WriteLine("\n\n");
            #endregion Query 3

            #region Query 4
            //Query4 liefert alle Nachnamen der Kunden mit der jeweiligen Gesamtsumme der getätigten Bestellungen
            //TODO
            var result4 = customers.Select(x => $"{x.LastName}, { x.OrderList.Sum(y => y.TotalValue)}").ToList();

            Console.WriteLine("###### Query 4 ######");
            result4.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("\n\n");
            #endregion Query 4

            #region Query 5
            //Query5 liefert den Nachnamen des Kunden mit dem höchsten Gesamtgewicht aller Bestellungen
            //TODO
            //var result5 = customers.Where(x => 
            //    x.OrderList.Where(y => y.Equals(
            //        x.OrderList.OrderByDescending(y => y.TotalWeight).FirstOrDefault()
            //    ));

            var result5 = customers.Where(c => c.OrderList.Contains(orders.OrderByDescending(x => x.TotalWeight).FirstOrDefault())).Single();

            Console.WriteLine("###### Query 5 ######");
            Console.Write(result5.LastName);
            Console.WriteLine("\n\n");
            #endregion Query 5

            #region Query 6
            //Query6 liefert den Namen und das Gewicht des teuersten Produkts in der Datenbank
            //TODO
            var result6 = products.OrderByDescending(p => p.Price).FirstOrDefault();

            Console.WriteLine("###### Query 6 ######");
            Console.Write($"{result6.Name}, {result6.Weight}");
            Console.WriteLine("\n\n");
            #endregion Query 6

            #region Query N
            //QueryN Eigene Queries
            //TODO
            var resultN = Enumerable.Empty<Object>();

            Console.WriteLine("###### Query N ######");
            Console.Write(resultN);
            Console.WriteLine("\n\n");
            #endregion Query N

            Console.ReadKey();
        }
    }
}
